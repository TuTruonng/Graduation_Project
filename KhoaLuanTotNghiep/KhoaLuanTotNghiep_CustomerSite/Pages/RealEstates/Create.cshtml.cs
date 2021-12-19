using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using KhoaLuanTotNghiep_CustomerSite.Datas;
using KhoaLuanTotNghiep_CustomerSite.Service;
using KhoaLuanTotNghiep_CustomerSite.ViewModel.RealEstate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.FlashMessages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShareModel;
using UploadResult = KhoaLuanTotNghiep_CustomerSite.Datas.UploadResult;

namespace KhoaLuanTotNghiep_CustomerSite.Pages.RealEstates
{
    public class CreateModel : PageModel
    {
        private readonly IRealEstateApiClient _realestateApiClient;
        private readonly IMapper _mapper;
        private const string Tags = "backend_PhotoAlbum";
        private readonly Cloudinary _cloudinary;
        private readonly PhotosDbContext _context;

        public CreateModel(IRealEstateApiClient productApiClient, IMapper mapper, Cloudinary cloudinary,
            PhotosDbContext context)
        {
            _realestateApiClient = productApiClient;
            _mapper = mapper;
            _cloudinary = cloudinary;
            _context = context;
        }

        [BindProperty]
        public RealEstateViewModel realEstate { get; set; }

        [BindProperty]
        public CreateClientModel user { get; set; }

        public IActionResult OnGetAsync()
        {
            return Page();
        }

        //public void OnGet()
        //{
        //}

        public async Task<IActionResult> OnPostAsync(IFormFile[] images, string cate)
        {
            var results = new List<Dictionary<string, string>>();

            if (images == null || images.Length == 0)
            {
                throw new Exception();
            }

            IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
            foreach (var image in images)
            {
                //if (image.Length == 0) return RedirectToPage("Create");

                var result = await _cloudinary.UploadAsync(new ImageUploadParams
                {
                    File = new FileDescription(image.FileName,
                        image.OpenReadStream()),
                    Tags = Tags
                }).ConfigureAwait(false);

                var imageProperties = new Dictionary<string, string>();
                foreach (var token in result.JsonObj.Children())
                {
                    if (token is JProperty prop)
                    {
                        imageProperties.Add(prop.Name, prop.Value.ToString());
                    }
                }

                results.Add(imageProperties);

                await _context.Photos.AddAsync(new Photo
                {
                    Bytes = (int)result.Bytes,
                    CreatedAt = DateTime.Now,
                    Format = result.Format,
                    Height = result.Height,
                    Path = result.Url.AbsolutePath,
                    PublicId = result.PublicId,
                    ResourceType = result.ResourceType,
                    SecureUrl = result.SecureUrl.AbsoluteUri,
                    Signature = result.Signature,
                    Type = result.JsonObj["type"]?.ToString(),
                    Url = result.Url.AbsoluteUri,
                    Version = int.Parse(result.Version, provider),
                    Width = result.Width
                }).ConfigureAwait(false);
                realEstate.Image = result.SecureUrl.AbsoluteUri;
            }

            await _context.UploadResults.AddAsync(new UploadResult
            {
                UploadResultAsJson = JsonConvert.SerializeObject(results)
            }).ConfigureAwait(false);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            realEstate.CategoryID = cate;
            realEstate.Location = realEstate.Location + "," + " " + realEstate.District + "," + " " + realEstate.Province;
            var real = _mapper.Map<RealEstateCreateRequest>(realEstate);

            var client = new RealEstateCreateRequest();
            client.ID = Guid.NewGuid().ToString();
            client.Username = user.Username;
            client.Fullname = user.FullName;
            client.PhoneNumber = user.PhoneNumber;
            client.Email = user.Email;
            client.CreateDate = DateTime.Now;

            await _realestateApiClient.CreateRealEstates(real);


            TempData["SuccessMessage"] = "Đăng tin thành công";
            return RedirectToAction("Index", "Home");
            //return RedirectToPage("./Index");

        }
    }
}
