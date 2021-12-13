using KhoaLuanTotNghiep_BackEnd.Data.SeedData;
using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await IdentityDataInitializer.SeedUsersAsync(userManager);
                await IdentityDataInitializer.SeedAsync(userManager);
                await IdentityDataInitializer.SeedRoleAsync(roleManager);
            }
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
