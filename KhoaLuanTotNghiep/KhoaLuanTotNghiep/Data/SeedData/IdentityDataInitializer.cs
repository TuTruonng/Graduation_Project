using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.AspNetCore.Identity;
using ShareModel.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Data.SeedData
{
    public static class IdentityDataInitializer
    {
        public static async Task SeedAsync(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var adminHCM = new User
                {
                    UserName = "adminhcm",
                    Status = true
                };

                await userManager.CreateAsync(adminHCM, "123456");
            }

            if (!userManager.Users.Any())
            {
                var admin1 = new User
                {
                    UserName = "admin1",
                    Email = "admin1@gmail.com",
                    FullName = "Admin 1",
                    Status = true,
                    ChangePassword = false
                };
                await userManager.CreateAsync(admin1, "123456");
            }
            if (!userManager.Users.Any())
            {
                var admin2 = new User
                {
                    UserName = "admin2",
                    Email = "admin1@gmail.com",
                    FullName = "Admin 2",
                    Status = true,
                    ChangePassword = false
                };
                await userManager.CreateAsync(admin2, "123456");
            }

        }

        public static async Task SeedUsersAsync(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("staff").Result == null)
            {
                User user = new User();
                user.UserName = "staff";
                user.Email = "user@gmail.com";
                user.Status = false;

                await userManager.CreateAsync(user, "123456");
            }


            if (userManager.FindByNameAsync("adminhn").Result == null)
            {
                User user = new User();
                user.UserName = "adminhn";
                user.Email = "adminhn@gmail.com";
                user.Status = true;

                await userManager.CreateAsync(user, "123456");
            }


            if (userManager.FindByNameAsync("user").Result == null)
            {
                User user = new User();
                user.UserName = "user";
                user.Email = "user@gmail.com";
                user.Status = true;

                await userManager.CreateAsync(user, "123456");
            }
        }

        public static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Staff.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
        }
    }
}
