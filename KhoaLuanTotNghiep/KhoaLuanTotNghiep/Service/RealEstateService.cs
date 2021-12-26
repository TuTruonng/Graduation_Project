using AutoMapper;
using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.Enum;
using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.AspNetCore.Http;
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
            queryable = queryable.Where(p => p.Approve == true && p.Status == Convert.ToInt32(StateApprove.Available));
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
            //var userCreate = new User
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    UserName = realEstateModel.Username,
            //    FullName = realEstateModel.Fullname,
            //    PhoneNumber = realEstateModel.PhoneNumber,
            //    Email = realEstateModel.Email,
            //    CreateDate = realEstateModel.CreateDate,
            //};

            //var result1 = await _userManager.CreateAsync(userCreate);
            //if (result1.Succeeded)
            //{
            //    userCreate = await _userManager.FindByNameAsync(userCreate.UserName);
            //    var result2 = await _userManager.AddToRoleAsync(userCreate,
            //       Roles.User);
            //}

            var user = await _userManager.FindByNameAsync(realEstateModel.Username);
            var Model = new RealEstate
            {
                RealEstateID = Guid.NewGuid().ToString(),
                CategoryID = realEstateModel.CategoryID,
                UserID = user.Id,
                Title = realEstateModel.Title,
                Price = realEstateModel.Price,
                Image = realEstateModel.Image,
                Description = realEstateModel.Description,
                Acgreage = realEstateModel.Acgreage,
                Approve = realEstateModel.Approve,
                Status = Convert.ToInt32(realEstateModel.Status),
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

        public async Task<RealEstateDetail> GetByIdAsync(string id)
        {
            var queryable = _dbContext.realEstates.Include(p => p.category).Include(p => p.user).Include(p => p.admin).AsQueryable();
            queryable = queryable.Where(p => p.RealEstateID == id);
            var real = await queryable.Select(p => new RealEstateDetail
            {
                RealEstateID = p.RealEstateID,
                CategoryID = p.category.CategoryID,
                UserID = p.user.Id,
                AdminName = p.admin.FullName,
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
            queryable = queryable.Where(p => p.Approve == true && p.Status == Convert.ToInt32(StateApprove.Available) && p.category.CategoryName == categoryname);
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

        public async Task<OrderModel> OrderAsync(OrderModel order)
        {
            var userCreate = await _userManager.FindByNameAsync(order.UserName);
            var realEstate = await _dbContext.realEstates.FirstOrDefaultAsync(x => x.RealEstateID == order.RealEstateID);
            if (realEstate == null)
            {
                throw new Exception("Have not RealEstateID");
            }
            var orderCreate = new Order
            {
                OrderId = Guid.NewGuid().ToString(),
                OrderDate = DateTime.Now,
                RealestateId = order.RealEstateID,
                CustomerId = userCreate.Id,
                UserId = realEstate.UserID,
                AdminId = realEstate.AdminID
            };
            var create = _dbContext.Add(orderCreate);

            realEstate.Status = Convert.ToInt32(StateApprove.WaitingAcceptance);
            var result = await _dbContext.SaveChangesAsync();
            User staff = await _userManager.FindByIdAsync(realEstate.AdminID);
            User user = await _userManager.FindByIdAsync(realEstate.UserID);

            var userIdList = (await _userManager.GetUsersInRoleAsync(Roles.User)).Select(u => u.Id);
            var staffIdList = (await _userManager.GetUsersInRoleAsync(Roles.Staff)).Select(u => u.Id);

            //User category = await _dbContext.realEstates.Where(c => c.Name == createAssetDto.Category).SingleOrDefaultAsync();
            //Rea state = await _dbContext.realEstates.Where(s => s.Name == createAssetDto.State).SingleOrDefaultAsync();
            OrderModel orderDto = new OrderModel();
            orderDto.OrderID = orderCreate.OrderId;
            orderDto.OrderDate = orderCreate.OrderDate;
            orderDto.Title = orderCreate.RealestateId;
            orderDto.UserName = (userIdList.Contains(user.Id)) ? user.FullName : null;
            orderDto.AdminName = (staffIdList.Contains(staff.Id)) ? staff.UserName : null;

            return orderDto;
        }

        public async Task<IEnumerable<OrderModel>> GetOrderAsync()
        {
            var queryable = _dbContext.orders.Include(p => p.realEstate).Include(p => p.user).Include(p => p.admin).AsQueryable();
            var order = await queryable.Select(p => new OrderModel
            {
                OrderID = p.OrderId,
                UserName = p.user.UserName,
                AdminName = p.admin.UserName,
                RealEstateID = p.realEstate.RealEstateID,
                OrderDate = p.OrderDate,
                Title = p.realEstate.Title,
                Status = (p.Status == true) ? "Order Accepted" : "Have Not Accepted",
            }).ToListAsync();
            return order;
        }

        public async Task<IEnumerable<OrderModel>> GetOrderWaitingAcceptAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var queryable = _dbContext.orders.Include(p => p.realEstate).Include(p => p.user).Include(p => p.admin).AsQueryable();
            queryable = queryable.Where(p => p.CustomerId == user.Id);
            var order = await queryable.Select(p => new OrderModel
            {
                OrderID = p.OrderId,
                UserName = p.user.UserName,
                AdminName = p.admin.UserName,
                RealEstateID = p.realEstate.RealEstateID,
                OrderDate = p.OrderDate,
                Title = p.realEstate.Title,
                Status = (p.Status == true) ? "Order Accepted" : "Have Not Accepted",
            }).ToListAsync();
            return order;
        }
        public async Task<ICollection<OrderExcel>> ExportOrderAcceptedAsync()
        {
            var queryable = _dbContext.orders.Include(p => p.realEstate).Include(p => p.user).Include(p => p.admin).AsQueryable();
            queryable = queryable.Where(p => p.Status == true);
            var orderModel = await queryable.Select(p => new OrderExcel
            {
                OrderID = p.OrderId,
                UserName = p.user.UserName,
                AdminName = p.admin.UserName,
                RealEstateID = p.realEstate.RealEstateID,
                OrderDate = p.OrderDate,
                Title = p.realEstate.Title,
                Status = "Accepted",

            }).ToListAsync();
            return orderModel;
        }
        public async Task<ICollection<OrderExcel>> ExportOrderNotAcceptedAsync()
        {
            var queryable = _dbContext.orders.Include(p => p.realEstate).Include(p => p.user).Include(p => p.admin).AsQueryable();
            queryable = queryable.Where(p => p.Status == false);
            var orderModel = await queryable.Select(p => new OrderExcel
            {
                OrderID = p.OrderId,
                UserName = p.user.UserName,
                AdminName = p.admin.UserName,
                RealEstateID = p.realEstate.RealEstateID,
                OrderDate = p.OrderDate,
                Title = p.realEstate.Title,
                Status = "Have Not Accepted",

            }).ToListAsync();
            return orderModel;
        }
        public async Task<AcceptOrder> UpdateOrderAsync(string id, AcceptOrder orderModel)
        {
            var order = await _dbContext.orders.FirstOrDefaultAsync(x => x.OrderId == id);
            if (order == null)
            {
                throw new Exception("Have not Order");
            }
            var realEstate = await _dbContext.realEstates.FirstOrDefaultAsync(x => x.RealEstateID == orderModel.RealEstateID);
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
            realEstate.Status = Convert.ToInt32(StateApprove.Ordered);
            //realEstateModel.RealEstateID = Guid.NewGuid().ToString();
            order.Status = bool.Parse(orderModel.Status);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return orderModel;
            }
            throw new Exception("Update  fail");
        }
    }
}
