using CloudinaryDotNet;
using KhoaLuanTotNghiep_CustomerSite.Datas;
using KhoaLuanTotNghiep_CustomerSite.Extensions.ServiceCollection;
using KhoaLuanTotNghiep_CustomerSite.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ShareModel.Constant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using AspNet.Security.OpenIdConnect.Primitives;

namespace KhoaLuanTotNghiep_CustomerSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = AuhthorityConstants.AUTHORITY;
                    options.RequireHttpsMetadata = false;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.SaveTokens = true;

                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("KhoaLuan.api");

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Authen/Login";
                options.LogoutPath = $"/Authen/Logout";
                options.AccessDeniedPath = $"/Account/AccessDenied";
            });

            var cloudName = Configuration.GetValue<string>("AccountSettings:CloudName");
            var apiKey = Configuration.GetValue<string>("AccountSettings:ApiKey");
            var apiSecret = Configuration.GetValue<string>("AccountSettings:ApiSecret");

            if (new[] { cloudName, apiKey, apiSecret }.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("Please specify Cloudinary account details!");
            }

            services.AddSingleton(new Cloudinary(new Account(cloudName, apiKey, apiSecret)));


            var dbFolder = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Cloudinary\\samples";
            System.IO.Directory.CreateDirectory(dbFolder);
            services.AddDbContext<PhotosDbContext>(options => options.UseSqlite($"Data Source ={dbFolder}\\PhotosCoreDb.sqlite"));

            services.AddHttpContextAccessor();
            services.AddCustomHttpClient(Configuration);
            services.AddRazorPages();
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);
            services.AddHttpClient();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllersWithViews();
            services.AddTransient<IRealEstateApiClient, RealEstateApiClient>();
            services.AddTransient<ICategoryApiClient, CategoryApiClient>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<INewsApiClient, NewsApiCLient>();
            services.AddTransient<IReportApiClient, ReportApiClient>();
            services.AddTransient<IOrderApiClient, OrderApiClient>();
            services.AddTransient<ISearchApiClient, SearchApiClient>();
            services.AddTransient<IAuthenApiClient, AuthenApiClient>();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();


            app.UseAuthorization();

            app.UseSession();
            app.Use(async (context, next) =>
            {
                var JWToken = context.Session.GetString("JWToken");
                if (!string.IsNullOrEmpty(JWToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
                }
                await next();
            });

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
