using AutoMapper;
using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.Enum;
using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;

        public RealEstateService(ApplicationDbContext dbContext, IMapper mapper, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ICollection<RealEstateModel>> GetAllAsync()
        {
            var queryable = _dbContext.realEstates.Include(p => p.category).Include(p => p.user).AsQueryable();
            var product = await queryable.Select(p => new RealEstateModel
            {
                RealEstateID = p.RealEstateID,
                // CategoryID = p.category.CategoryID,
                UserName = p.user.FullName,
                CategoryName = p.category.CategoryName,
                ReportID = p.ReportID,
                Title = p.Title,
                Price = p.Price,
                Image = p.Image,
                Description = p.Description,
                Acgreage = p.Acgreage,
                Approve = p.Approve.ToString(),
                Status = p.Status,
                PhoneNumber = Int32.Parse(p.user.PhoneNumber),
                CreateTime = p.CreateTime,
                UpdateTime = p.UpdateTime,
                Location = p.Location,
            }).ToListAsync();
            return product;
        }

        public async Task<ICollection<RealEstateModel>> GetByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var userRoles = await _userManager.GetRolesAsync(user);
            var productStaff = new List<RealEstateModel>();
            var productAdmin = new List<RealEstateModel>();
            if (userRoles.Contains(Roles.Staff))
            {
                var queryable = _dbContext.realEstates.Include(p => p.category).Include(p => p.user).AsQueryable();
                queryable = queryable.Where(p => p.AdminID == user.Id && p.Approve == true);
                productStaff = await queryable.Select(p => new RealEstateModel
                {
                    RealEstateID = p.RealEstateID,
                    // CategoryID = p.category.CategoryID,
                    UserName = p.user.FullName,
                    CategoryName = p.category.CategoryName,
                    ReportID = p.ReportID,
                    Title = p.Title,
                    Price = p.Price,
                    Image = p.Image,
                    Description = p.Description,
                    Acgreage = p.Acgreage,
                    Approve = p.Approve.ToString(),
                    Status = p.Status,
                    PhoneNumber = Int32.Parse(p.user.PhoneNumber),
                    CreateTime = p.CreateTime,
                    UpdateTime = p.UpdateTime,
                    Location = p.Location,
                }).ToListAsync();
                return productStaff;
            }

            if (userRoles.Contains(Roles.Admin))
            {
                var queryable = _dbContext.realEstates.Include(p => p.category).Include(p => p.user).AsQueryable();
                productAdmin = await queryable.Select(p => new RealEstateModel
                {
                    RealEstateID = p.RealEstateID,
                    // CategoryID = p.category.CategoryID,
                    UserName = p.user.FullName,
                    CategoryName = p.category.CategoryName,
                    ReportID = p.ReportID,
                    Title = p.Title,
                    Price = p.Price,
                    Image = p.Image,
                    Description = p.Description,
                    Acgreage = p.Acgreage,
                    Approve = p.Approve.ToString(),
                    Status = p.Status,
                    PhoneNumber = Int32.Parse(p.user.PhoneNumber),
                    CreateTime = p.CreateTime,
                    UpdateTime = p.UpdateTime,
                    Location = p.Location,
                }).ToListAsync();
            }
            return productAdmin;
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
                //CategoryID = p.category.CategoryID,
                UserName = p.user.FullName,
                CategoryName = p.category.CategoryName,
                ReportID = p.ReportID,
                Title = p.Title,
                Price = p.Price,
                Image = p.Image,
                Description = p.Description,
                Acgreage = p.Acgreage,
                Approve = p.Approve.ToString(),
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

        public async Task<ListApprove> UpdateRealEstateAsync(string id, ListApprove realEstateModel)
        {
            var realEstate = await _dbContext.realEstates.FirstOrDefaultAsync(x => x.RealEstateID == id);
            if (realEstate == null)
            {
                throw new Exception("Have not RealEstateID");
            }
            //realEstateModel.RealEstateID = Guid.NewGuid().ToString();
            realEstate.Approve = bool.Parse(realEstateModel.Approve);
            realEstate.AdminID = realEstateModel.AssignTo;
            await _dbContext.SaveChangesAsync();
            return realEstateModel;
        }

        public async Task<OrderModel> OrderAsync(string id)
        {
            var realEstate = await _dbContext.realEstates.FirstOrDefaultAsync(x => x.RealEstateID == id);
            if (realEstate == null)
            {
                throw new Exception("Have not RealEstateID");
            }
            var orderCreate = new Order
            {
                OrderId = Guid.NewGuid().ToString(),
                OrderDate = DateTime.Now,
                RealestateId = id,
                UserId = realEstate.UserID,
                AdminId = realEstate.AdminID
            };
            var create = _dbContext.Add(orderCreate);

            realEstate.Status = true;

            User staff = await _userManager.FindByIdAsync(realEstate.AdminID);
            User user = await _userManager.FindByIdAsync(realEstate.UserID);
            if (staff.Salary == 0)
            {
                staff.Salary = staff.SalaryBasic + ((staff.SalaryBasic) / 10);
            }
            else
            {
                staff.Salary = staff.Salary + ((staff.SalaryBasic) / 10);
            }
            var result = _dbContext.SaveChanges();

            var userIdList = (await _userManager.GetUsersInRoleAsync(Roles.User)).Select(u => u.Id);
            var staffIdList = (await _userManager.GetUsersInRoleAsync(Roles.Staff)).Select(u => u.Id);

            //User category = await _dbContext.realEstates.Where(c => c.Name == createAssetDto.Category).SingleOrDefaultAsync();
            //Rea state = await _dbContext.realEstates.Where(s => s.Name == createAssetDto.State).SingleOrDefaultAsync();
            OrderModel orderDto = new OrderModel();
            orderDto.OrderId = orderCreate.OrderId;
            orderDto.OrderDate = orderCreate.OrderDate;
            orderDto.Title = orderCreate.RealestateId;
            orderDto.UserName = (userIdList.Contains(user.Id)) ? user.FullName : null;
            orderDto.AdminName = (staffIdList.Contains(staff.Id)) ? staff.UserName : null;
            return orderDto;
        }
    }
}
