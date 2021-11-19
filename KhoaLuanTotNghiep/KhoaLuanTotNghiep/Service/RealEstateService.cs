using AutoMapper;
using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.Enum;
using KhoaLuanTotNghiep_BackEnd.Extension;
using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using KhoaLuanTotNghiep_BackEnd.Models;
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
            var queryable = _dbContext.realEstates.Include(x => x.category).Include(x => x.user).AsQueryable();
            queryable = queryable.Where(x => x.Approve == 1);
            var list = await queryable.Select(p => new RealEstateModel
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
                acreage = p.Acgreage,
                Slug = p.Slug,
                Approve = p.Approve,
                Status = p.Status,
                PhoneNumber = Int32.Parse(p.user.PhoneNumber),
                CreateTime = p.CreateTime,
                UpdateTime = p.UpdateTime,
                Location = p.Location,
            }).ToListAsync();
            return list;

        }

        //public async Task<PagedResponseDto<RealEstateModel>> GetAllAsync(
        //    RealEstateCriteriaDto realEstateCriteriaDto,
        //    CancellationToken cancellationToken)
        //{
        //    var queryable = _dbContext
        //                        .realEstates
        //                        .Include(x => x.category)
        //                        .Where(x => x.Approve == 1)
        //                        .AsQueryable();

        //    queryable = RealEstateFilter(queryable, realEstateCriteriaDto);

        //    var pagedBrands = await queryable
        //                      .AsNoTracking()
        //                      .PaginateAsync(realEstateCriteriaDto, cancellationToken);

        //    var realEstateDto = _mapper.Map<IEnumerable<RealEstateModel>>(pagedBrands.Items);
        //    return new PagedResponseDto<RealEstateModel>
        //    {
        //        CurrentPage = pagedBrands.CurrentPage,
        //        TotalPages = pagedBrands.TotalPages,
        //        TotalItems = pagedBrands.TotalItems,
        //        Search = realEstateCriteriaDto.Search,
        //        SortColumn = realEstateCriteriaDto.SortColumn,
        //        SortOrder = realEstateCriteriaDto.SortOrder,
        //        Limit = realEstateCriteriaDto.Limit,
        //        Items = realEstateDto
        //    };
        //    //var list = await queryable.Select(p => new RealEstateModel
        //    //{
        //    //    RealEstateID = p.RealEstateID,
        //    //    CategoryID = p.category.CategoryID,
        //    //    UserID = p.user.Id,
        //    //    CategoryName = p.category.CategoryName,
        //    //    ReportID = p.ReportID,
        //    //    Title = p.Title,
        //    //    Price = p.Price,
        //    //    Image = p.Image,
        //    //    Description = p.Description,
        //    //    acreage = p.Acgreage,
        //    //    Slug = p.Slug,
        //    //    Approve = p.Approve,
        //    //    Status = p.Status,
        //    //    PhoneNumber = Int32.Parse(p.user.PhoneNumber),
        //    //    CreateTime = p.CreateTime,
        //    //    UpdateTime = p.UpdateTime,
        //    //    Location = p.Location,
        //    //}).ToListAsync();
        //    //return list;
        //}

        public async Task<RealEstateCreateRequest> CreateRealEstatesAsync(RealEstateCreateRequest realEstateModel)
        {
            var realEstate = await _dbContext.categories.FirstOrDefaultAsync(p => p.CategoryID == realEstateModel.CategoryID);
            if (realEstate == null)
            {
                throw new Exception("Have not Category");
            }
            realEstateModel.RealEstateID = Guid.NewGuid().ToString();
            var Model = new RealEstate
            {
                RealEstateID = realEstateModel.RealEstateID,
                CategoryID = realEstateModel.CategoryID,
                UserID = realEstateModel.UserID,
                ReportID = realEstateModel.ReportID,
                Title = realEstateModel.Title,
                Price = realEstateModel.Price,
                Image = realEstateModel.Image,
                Description = realEstateModel.Description,
                Acgreage = realEstateModel.acreage,
                Slug = realEstateModel.Slug,
                Approve = (int)StateApprove.FALSE,
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
                acreage = p.Acgreage,
                Slug = p.Slug,
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

        #region Private Method
        private IQueryable<RealEstate> RealEstateFilter(
            IQueryable<RealEstate> realEstateQuery,
            RealEstateCriteriaDto realEstateCriteriaDto)
        {
            if (!String.IsNullOrEmpty(realEstateCriteriaDto.Search))
            {
                realEstateQuery = realEstateQuery.Where(b =>
                    b.Title.Contains(realEstateCriteriaDto.Search));
            }

            if (realEstateCriteriaDto.Types != null &&
                realEstateCriteriaDto.Types.Count() > 0 &&
               !realEstateCriteriaDto.Types.Any(x => x == 0))
            {
                realEstateQuery = realEstateQuery.Where(x =>
                    realEstateCriteriaDto.Types.Any(t => t == Int32.Parse(x.CategoryID)));
            }

            return realEstateQuery;
        }
        #endregion
    }
}
