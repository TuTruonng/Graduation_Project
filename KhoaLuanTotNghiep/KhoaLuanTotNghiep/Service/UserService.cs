using KhoaLuanTotNghiep.Data;
using KhoaLuanTotNghiep_BackEnd.Interface;
using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShareModel;
using ShareModel.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Service
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public UserService(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            var user = await _dbContext.Users.ToListAsync();
            return user;
        }

        public async Task<UserModel> CreateAsync(CreateClientModel createUser)
        {
            var userCreate = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = createUser.Username,
                PhoneNumber = createUser.PhoneNumber,
                Email = createUser.Email,
                CreateDate = createUser.CreateDate,
            };

            var result1 = await _userManager.CreateAsync(userCreate);
            if (result1.Succeeded)
            {
                userCreate = await _userManager.FindByNameAsync(userCreate.UserName);
                var result2 = await _userManager.AddToRoleAsync(userCreate,
                   Roles.User);

                UserModel userDto = new UserModel();
                if (result2.Succeeded)
                {
                    userDto.UserId = userCreate.Id;
                    userDto.Username = userCreate.UserName;
                    userDto.PhoneNumber = userCreate.PhoneNumber;
                    userDto.Email = userCreate.Email;
                    userDto.CreateDate = userCreate.CreateDate;
                    userDto.Type = Roles.User;
                    return userDto; ;
                }
            }
            return null;
        }

        public async Task<IEnumerable<UserModel>> GetAdminAsync()
        {
            var adminIdList = (await _userManager.GetUsersInRoleAsync(Roles.Admin)).Select(u => u.Id);
            var staffIdList = (await _userManager.GetUsersInRoleAsync(Roles.Staff)).Select(u => u.Id);

            var queryable = _dbContext.Users.AsQueryable();
            queryable = queryable.Where(u => (adminIdList.Contains(u.Id) || staffIdList.Contains(u.Id)) && u.Status == true);
            //List<RealEstate> querySelled = new List<RealEstate>();
            //List<RealEstate> query = new List<RealEstate>();
            //foreach (var q in queryable.SelectMany().)
            //{
            //    querySelled = await _dbContext.realEstates
            //        .Include(p => p.category)
            //        .Include(p => p.user)
            //        .Where(p => p.AdminID == q.Id && p.Status == true).ToListAsync();
            //    query = await _dbContext.realEstates
            //        .Include(p => p.category)
            //        .Include(p => p.user)
            //        .Where(p => p.AdminID == q.Id).ToListAsync();
            //}

            var users = await queryable.Select(u => new UserModel
            {
                UserId = u.Id,
                FullName = u.FullName,
                Username = u.UserName,
                PhoneNumber = u.PhoneNumber,
                JoinedDate = u.JoinedDate,
                Email = u.Email,
                SalaryBasic = u.SalaryBasic.ToString(),
                Salary = u.Salary.ToString(),
                DateOfBirth = u.DateOfBirth,
                //quantityRealEstate = query.Count(),
                //quantityRealEstateSelled = querySelled.Count(),
                Status = u.Status.ToString(),
                Type = (adminIdList.Contains(u.Id) && staffIdList.Contains(u.Id))
                    ? string.Join(",", new string[] { Roles.Admin, Roles.Staff }) // Have both 'Admin' and 'Staff' roles
                    : (adminIdList.Contains(u.Id))
                        ? Roles.Admin // Have only 'Admin' role
                        : (staffIdList.Contains(u.Id))
                            ? Roles.Staff // Have only 'Staff' role
                            : string.Empty, // Have neither 'Admin' nor 'Staff' role
                CreateDate = u.CreateDate,
            }).ToListAsync();
            return users;
        }

        public async Task<IEnumerable<UserModel>> GetUserAsync()
        {
            var userIdList = (await _userManager.GetUsersInRoleAsync(Roles.User)).Select(u => u.Id);

            var queryable = _dbContext.Users.AsQueryable();
            queryable = queryable.Where(u => (userIdList.Contains(u.Id)) && u.Status == true);
            var users = await queryable.Select(u => new UserModel
            {
                UserId = u.Id,
                FullName = u.FullName,
                Username = u.UserName,
                PhoneNumber = u.PhoneNumber,
                //JoinedDate = u.JoinedDate,
                Email = u.Email,
                Type = Roles.User,
                CreateDate = u.CreateDate,
            }).ToListAsync();
            return users;
        }

        public async Task<UserModel> AddAsync(CreateUserModel createUser)
        {
            var userCreate = new User
            {
                Id = Guid.NewGuid().ToString(),
                FullName = createUser.FullName,
                UserName = createUser.Username,
                PhoneNumber = createUser.PhoneNumber,
                Email = createUser.Email,
                DateOfBirth = createUser.DateOfBirth,
                JoinedDate = createUser.JoinedDate,
                CreateDate = DateTime.Now,
                SalaryBasic = SalaryConstant.SALARY_BASIC,
                ChangePassword = false,
                Status = true,
            };
            string password = "123456";

            var result1 = await _userManager.CreateAsync(userCreate, password);
            if (result1.Succeeded)
            {
                userCreate = await _userManager.FindByNameAsync(userCreate.UserName);
                var result2 = await _userManager.AddToRoleAsync(userCreate,
                    (createUser.Type == Roles.Admin)
                    ? Roles.Admin
                    : (createUser.Type == Roles.Staff)
                    ? Roles.Staff
                    : Roles.User);

                UserModel userDto = new UserModel();
                if (result2.Succeeded)
                {
                    userDto.UserId = userCreate.Id;
                    userDto.FullName = userCreate.FullName;
                    userDto.Username = userCreate.UserName;
                    userDto.PhoneNumber = userCreate.PhoneNumber;
                    userDto.Email = userCreate.Email;
                    userDto.DateOfBirth = userCreate.DateOfBirth;
                    userDto.JoinedDate = userCreate.JoinedDate;
                    userDto.CreateDate = userCreate.CreateDate;
                    userDto.SalaryBasic = userCreate.SalaryBasic.ToString();
                    userDto.Type = (createUser.Type == Roles.Admin)
                        ? Roles.Admin
                        : (createUser.Type == Roles.Staff)
                        ? Roles.Staff
                        : Roles.User;
                    return userDto;
                }
            }
            return null;
        }

        public async Task<UserModel> UpdateAsync(string id, EditUserModel editUserDto)
        {
            User user = await _userManager.FindByIdAsync(id);
            {
                user.FullName = editUserDto.FullName; ;
                user.Email = editUserDto.Email;
                user.PhoneNumber = editUserDto.PhoneNumber;
                user.JoinedDate = editUserDto.JoinedDate;
                user.UserName = editUserDto.UserName;
                user.DateOfBirth = editUserDto.DateOfBirth;
                user.SalaryBasic = decimal.Parse(editUserDto.SalaryBasic);
            };

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                var roles = new string[] { Roles.Admin, Roles.Staff, Roles.User };
                if (roles.Contains(editUserDto.Type))
                {
                    IList<string> userRoles = await _userManager.GetRolesAsync(user);

                    // Remove from current role(s) if have more than 1 role or in different role
                    // User can only have 1 role (either 'Admin' or 'Staff')
                    if (userRoles.Count > 1 || !userRoles.Contains(editUserDto.Type))
                    {
                        await _userManager.RemoveFromRolesAsync(user, userRoles);
                        await _userManager.AddToRoleAsync(user, editUserDto.Type);
                    }
                }
                UserModel userDto = new UserModel();
                userDto.UserId = user.Id;
                userDto.FullName = user.FullName;
                userDto.Username = user.UserName;
                userDto.PhoneNumber = user.PhoneNumber;
                userDto.Email = user.Email;
                userDto.JoinedDate = user.JoinedDate;
                userDto.DateOfBirth = user.DateOfBirth;
                userDto.SalaryBasic = user.SalaryBasic.ToString();
                userDto.Type = (editUserDto.Type == Roles.Admin)
                    ? Roles.Admin
                    : (editUserDto.Type == Roles.Staff)
                    ? Roles.Staff
                    : Roles.User;
                return userDto;
            }
            return null;
        }

        public async Task<bool> DisableAsync(string id)
        {
            //User user = await _userManager.FindByIdAsync(id);
            User user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null /*|| user.Status == false*/)
            {
                throw new Exception("Error");
            }
            user.Status = false;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeUserPasswordAsync(ChangeUserPasswordDto changeUserPasswordDto)
        {
            User user = await _userManager.FindByNameAsync(changeUserPasswordDto.Username);

            var result = await _userManager.ChangePasswordAsync(user, changeUserPasswordDto.CurrentPassword, changeUserPasswordDto.NewPassword);
            return result.Succeeded;
        }
    }
}
