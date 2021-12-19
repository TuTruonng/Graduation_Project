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
            queryable = queryable.Where(p => p.Approve == true && p.Status == false);
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
                Approve = p.Approve.ToString(),
                Status = p.Status.ToString(),
                PhoneNumber = Int32.Parse(p.user.PhoneNumber),
                CreateTime = p.CreateTime,
                UpdateTime = p.UpdateTime,
                Location = p.Location,
            }).ToListAsync();
            return product;
        }

        public async Task<ICollection<RealEstateModel>> Search(string query)
        {
            var queryable = _dbContext.realEstates.Include(p => p.category).Include(p => p.user).AsQueryable();
            if (!string.IsNullOrEmpty(query))
                queryable = queryable.Where(x => x.Title.Contains(query) || x.Price.Contains(query) || x.Acgreage.Contains(query));
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
                Approve = p.Approve.ToString(),
                Status = p.Status.ToString(),
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
                    Status = p.Status.ToString(),
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
                    Status = p.Status.ToString(),
                    PhoneNumber = Int32.Parse(p.user.PhoneNumber),
                    CreateTime = p.CreateTime,
                    UpdateTime = p.UpdateTime,
                    Location = p.Location,
                }).ToListAsync();
            }
            return productAdmin;
        }

        public async Task<RealEstateCreateRequest> CreateRealEstatesAsync(RealEstateCreateRequest realEstateModel)
        {
            //var realEstate = await _dbContext.categories.FirstOrDefaultAsync(p => p.CategoryID == realEstateModel.CategoryID);
            //if (realEstate == null)
            //{
            //    throw new Exception("Have not Category");
            //}
            var userCreate = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = realEstateModel.Username,
                FullName = realEstateModel.Fullname,
                PhoneNumber = realEstateModel.PhoneNumber,
                Email = realEstateModel.Email,
                CreateDate = realEstateModel.CreateDate,
            };

            var result1 = await _userManager.CreateAsync(userCreate);
            if (result1.Succeeded)
            {
                userCreate = await _userManager.FindByNameAsync(userCreate.UserName);
                var result2 = await _userManager.AddToRoleAsync(userCreate,
                   Roles.User);

                //UserModel userDto = new UserModel();
                //if (result2.Succeeded)
                //{
                //    userDto.UserId = userCreate.Id;
                //    userDto.Username = userCreate.UserName;
                //    userDto.PhoneNumber = userCreate.PhoneNumber;
                //    userDto.Email = userCreate.Email;
                //    userDto.CreateDate = userCreate.CreateDate;
                //    userDto.Type = Roles.User;
                //    return userDto; 
                //}
            }

            var Model = new RealEstate
            {
                RealEstateID = Guid.NewGuid().ToString(),
                CategoryID = realEstateModel.CategoryID,
                UserID = userCreate.Id,
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
                UserName = p.user.FullName,
                CategoryName = p.category.CategoryName,
                ReportID = p.ReportID,
                Title = p.Title,
                Price = p.Price,
                Image = p.Image,
                Description = p.Description,
                Acgreage = p.Acgreage,
                Approve = p.Approve.ToString(),
                Status = p.Status.ToString(),
                PhoneNumber = Int32.Parse(p.user.PhoneNumber),
                CreateTime = p.CreateTime,
                UpdateTime = p.UpdateTime,
                Location = p.Location,
            }).FirstOrDefaultAsync();
            return real;
        }

        public async Task<IEnumerable<RealEstatefromCategory>> GetByCategoryAsync(string categoryname)
        {
            var queryable = _dbContext.realEstates.Include(p => p.category).Include(p => p.user).AsQueryable();
            queryable = queryable.Where(p => p.Approve == true && p.Status == false && p.category.CategoryName == categoryname);
            var product = await queryable.Select(p => new RealEstatefromCategory
            {
                RealEstateID = p.RealEstateID,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                Image = p.Image,
                CategoryName = p.category.CategoryName,
                Location = p.Location,
                UserID = p.user.Id,
                UserName = p.user.FullName,
                CreateTime = p.CreateTime,
            }).ToListAsync();

            return product;
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
            var user = await _userManager.FindByNameAsync(realEstateModel.AssignTo);
            var realEstate = await _dbContext.realEstates.FirstOrDefaultAsync(x => x.RealEstateID == id);
            if (realEstate == null)
            {
                throw new Exception("Have not NewsID");
            }
            //realEstateModel.RealEstateID = Guid.NewGuid().ToString();
            realEstate.Approve = bool.Parse(realEstateModel.Approve);
            realEstate.AdminID = user.Id;
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
            //var create = _dbContext.Add(model);


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
            var result = await _dbContext.SaveChangesAsync();
            return orderDto;
        }
    }
}
