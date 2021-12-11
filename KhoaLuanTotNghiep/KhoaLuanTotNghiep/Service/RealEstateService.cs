using AutoMapper;
using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.Enum;
using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Service
{
    public class RealEstateService : IRealEstate
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public RealEstateService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ICollection<RealEstateModel>> GetAllAsync()
        {
            var queryable = _dbContext.realEstates.Include(p => p.category).Include(p => p.user).AsQueryable();
            var product = await queryable.Select(p => new RealEstateModel
            {
                RealEstateID = p.RealEstateID,
                CategoryID = p.category.CategoryID,
                UserID = p.user.Id,
                CategoryName = p.category.CategoryName,
                ReportID = p.ReportID,
                Title = p.Title,
                Price = p.Price,
                Image = p.Image,
                Description = p.Description,
                Acgreage = p.Acgreage,
                Approve = p.Approve,
                Status = p.Status,
                PhoneNumber = Int32.Parse(p.user.PhoneNumber),
                CreateTime = p.CreateTime,
                UpdateTime = p.UpdateTime,
                Location = p.Location,
            }).ToListAsync();
            return product;
        }

        //  public async Task<ActionResult<PageResponse<RealEstateModel>>> Getproduct(
        //[FromQuery] RealEstateCriteria productCriteriaDto,
        //CancellationToken cancellationToken)
        //  {
        //      var productQuery = _dbContext
        //                              .realEstates
        //                              .Include(p => p.category)
        //                              .Include(p => p.user)
        //                              .AsQueryable();

        //      productQuery = ProductFilter(productQuery, productCriteriaDto);

        //      var pageProducts = await productQuery
        //                                  .AsNoTracking()
        //                                  .PaginateAsync(productCriteriaDto, cancellationToken);

        //      var productDto = _mapper.Map<IEnumerable<RealEstateModel>>(pageProducts.Items);
        //      return new PageResponse<RealEstateModel>
        //      {
        //          TotalPages = pageProducts.TotalPages,
        //          TotalItems = pageProducts.TotalItems,
        //          Search = productCriteriaDto.Search,
        //          Items = productDto
        //      };
        //  }

        //  #region Private Method
        //  private IQueryable<RealEstate> ProductFilter(
        //      IQueryable<RealEstate> productQuery,
        //      RealEstateCriteria productCriteriaDto)
        //  {
        //      if (!String.IsNullOrEmpty(productCriteriaDto.Search))
        //      {
        //          productQuery = productQuery.Where(b =>
        //              b.Title.Contains(productCriteriaDto.Search));
        //      }

        //      //if (productCriteriaDto.Types != null)
        //      //{
        //      //    for (int i = 0; i < productCriteriaDto.Types.Length; i++)
        //      //    {
        //      //        if (productCriteriaDto.Types[i] != "0")
        //      //        {
        //      //            productQuery = productQuery.Where(x =>
        //      //            productCriteriaDto.Types.Any(t => t == x.CategoryId));
        //      //        }
        //      //    }
        //      //}

        //      return productQuery;
        //  }
        //  #endregion

        public async Task<RealEstateCreateRequest> CreateRealEstatesAsync(RealEstateCreateRequest realEstateModel)
        {
            //var realEstate = await _dbContext.categories.FirstOrDefaultAsync(p => p.CategoryID == realEstateModel.CategoryID);
            //if (realEstate == null)
            //{
            //    throw new Exception("Have not Category");
            //}

            var Model = new RealEstate
            {
                RealEstateID = Guid.NewGuid().ToString(),
                CategoryID = realEstateModel.CategoryID,
                UserID = realEstateModel.UserID,
                Title = realEstateModel.Title,
                Price = realEstateModel.Price,
                Image = realEstateModel.Image,
                Description = realEstateModel.Description,
                Acgreage = realEstateModel.Acgreage,
                Approve = realEstateModel.Approve,
                Status = realEstateModel.Status,
                CreateTime = realEstateModel.CreateTime,
                UpdateTime = realEstateModel.UpdateTime,
                Location = realEstateModel.Location,
            };
            var create = _dbContext.Add(Model);
            var result = _dbContext.SaveChanges();
            if (result > 0)
            {
                return realEstateModel;
            }
            throw new Exception("Create News Fail");
        }

        public async Task<RealEstateModel> GetByIdAsync(string id)
        {
            var queryable = _dbContext.realEstates.Include(p => p.category).Include(p => p.user).AsQueryable();
            queryable = queryable.Where(p => p.RealEstateID == id);
            var real = await queryable.Select(p => new RealEstateModel
            {
                RealEstateID = p.RealEstateID,
                CategoryID = p.category.CategoryID,
                UserID = p.user.Id,
                CategoryName = p.category.CategoryName,
                ReportID = p.ReportID,
                Title = p.Title,
                Price = p.Price,
                Image = p.Image,
                Description = p.Description,
                Acgreage = p.Acgreage,
                Approve = p.Approve,
                Status = p.Status,
                PhoneNumber = Int32.Parse(p.user.PhoneNumber),
                CreateTime = p.CreateTime,
                UpdateTime = p.UpdateTime,
                Location = p.Location,
            }).FirstOrDefaultAsync();
            return real;
        }

        public async Task<IEnumerable<RealEstatefromCategory>> GetByCategoryAsync(string categoryname)
        {
            var products = await _dbContext.realEstates.Include(p => p.category)
                .Where(p => p.category.CategoryName == categoryname)
                .Select(p =>

                new RealEstatefromCategory
                {
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    Image = p.Image,
                    CategoryName = p.category.CategoryName
                }).ToListAsync();

            return products;
        }

        public async Task<RealEstate> DeleteAsync(string id)
        {
            var product = await _dbContext.realEstates.FindAsync(id);
            if (product == null)
                return null;
            _dbContext.realEstates.Remove(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<ListApprove> UpdateRealEstateAsync(string id, ListApprove realEstateModel)
        {
            var realEstate = await _dbContext.realEstates.FirstOrDefaultAsync(x => x.RealEstateID == id);
            if (realEstate == null)
            {
                throw new Exception("Have not NewsID");
            }
            //realEstateModel.RealEstateID = Guid.NewGuid().ToString();
            realEstate.Approve = realEstateModel.Approve;
            //realEstate.PhoneNumber = realEstateModel.PhoneNumber;
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return realEstateModel;
            }
            throw new Exception("Update  fail");
        }

        public async Task<bool> DeleteRealEstateModelAsync(string id)
        {
            var realEstate = await _dbContext.realEstates.FirstOrDefaultAsync(x => x.RealEstateID == id);
            if (realEstate == null)
            {
                throw new Exception("Have not RealEstate");
            }
            var delete = _dbContext.Remove(realEstate);
            var result = _dbContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            throw new Exception("Delete fail");
        }
    }
}
