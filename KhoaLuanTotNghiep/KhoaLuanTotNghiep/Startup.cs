
using KhoaLuanTotNghiep_BackEnd.Interface;
using KhoaLuanTotNghiep_BackEnd.InterfaceService;
using KhoaLuanTotNghiep_BackEnd.Service;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using FluentValidation.AspNetCore;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using KhoaLuanTotNghiep_BackEnd.Extensions.ServiceCollection;
using FluentValidation;
using KhoaLuanTotNghiep_BackEnd.Request;
using KhoaLuanTotNghiep_BackEnd.Validators;

namespace KhoaLuanTotNghiep_BackEnd
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
            services.AddSwagger();
            services.AddDataAccessorLayer(Configuration);
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            //services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);

            //services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllers()
               .AddFluentValidation(fv =>
               {
                   fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                   fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
               })
               .AddJsonOptions(ops =>
               {
                   ops.JsonSerializerOptions.IgnoreNullValues = true;
                   ops.JsonSerializerOptions.WriteIndented = true;
                   ops.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                   ops.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                   ops.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
               });

            services.AddControllers().AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           );


            //services.ConfigureApplicationCookie(config =>
            //{
            //    config.LoginPath = "/CustomAuthentication/Login";
            //});
            services.AddTransient<INews, NewsService>();
            services.AddTransient<IUser, UserService>();
            services.AddTransient<Icategory, CategoryService>();
            services.AddTransient<IRate, RateService>();
            services.AddTransient<IRealEstate, RealEstateService>();
            services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();

            //services.AddSingleton<IAuthorizationHandler, AdminRoleHandler>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddHttpContextAccessor();

            //services.AddIdentityServer(options =>
            //{
            //    options.Events.RaiseErrorEvents = true;
            //    options.Events.RaiseInformationEvents = true;
            //    options.Events.RaiseFailureEvents = true;
            //    options.Events.RaiseSuccessEvents = true;
            //    options.EmitStaticAudienceClaim = true;
            //})
            //   // this adds the operational data from DB (codes, tokens, consents)

            //   .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
            //   .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
            //   .AddInMemoryClients(IdentityServerConfig.Clients)
            //   .AddAspNetIdentity<User>()
            //   .AddProfileService<CustomProfileService>()
            //   .AddDeveloperSigningCredential(); // not recommended for production - you need to store your key material somewhere secure

            //services.AddAuthentication()
            //    .AddLocalApi("Bearer", option =>
            //    {
            //        option.ExpectedScope = "KhoaLuan.api";
            //    });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy(SecurityConstants.BEARER_POLICY, policy =>
            //    {
            //        policy.AddAuthenticationSchemes("Bearer");
            //        policy.RequireAuthenticatedUser();
            //    });

            //    options.AddPolicy(SecurityConstants.ADMIN_ROLE_POLICY, policy =>
            //        policy.Requirements.Add(new AdminRoleRequirement()));
            //});

            services.AddAuthenticationRegister();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("Policy", builder => builder
            //        .WithOrigins("http://localhost:3000")
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials()
            //    );
            //});

            //services.AddRazorPages();

            //services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "admin/build";
            });


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Khoa Luan API", Version = "v1" });
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Type = SecuritySchemeType.OAuth2,
            //        Flows = new OpenApiOAuthFlows
            //        {
            //            AuthorizationCode = new OpenApiOAuthFlow
            //            {
            //                TokenUrl = new Uri("/connect/token", UriKind.Relative),
            //                AuthorizationUrl = new Uri("/connect/authorize", UriKind.Relative),
            //                Scopes = new Dictionary<string, string> { { "KhoaLuan.api", "Khoa Luan API" } }
            //            },
            //        },
            //    });
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            //            },
            //            new List<string>{ "KhoaLuan.api" }
            //        }
            //    });
            //});
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KhoaLuanTotNghiep_BackEnd v1"));
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                //app.UseMiddleware<ErrorHandler>();
            }

            app.UseHttpsRedirection();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "admin";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
