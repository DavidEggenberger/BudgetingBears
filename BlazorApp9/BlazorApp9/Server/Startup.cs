using BlazorApp9.Server.Data;
using BlazorApp9.Server.Models;
using Data;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorApp9.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            if (Env.IsDevelopment())
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["ConnectionST"]));
                services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    Configuration["ConnectionST"]));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
                services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            }

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<ApplicationUser>(options => 
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789, -._@+/ ";
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
                .AddProfileService<ProfileService>();

            services.AddAuthentication()
                .AddLinkedIn(op => 
                {
                    op.Scope.Clear();
                    op.Scope.Add("r_liteprofile");
                    op.Scope.Add("r_emailaddress");
                    op.ClientId = "7774seconxg2r2";
                    op.ClientSecret = Configuration["LinkedInSecret"];
                })
                .AddGitHub(op =>
                {
                    op.Scope.Add("email");
                    op.ClientId = "4aaea7373a832a79b9bb";
                    op.ClientSecret = Configuration["GitHubSecret"];
                })
                .AddMicrosoftAccount(op =>
                {
                    op.ClientId = "82aadf42-dfc1-4247-887c-e2ef17c6dd34";
                    op.ClientSecret = Configuration["MicrosoftSecret"];
                })
                .AddGoogle(op => 
                {
                    op.ClientId = "977151835804-48vji105vrn2j5qm9uvpqqb2jdve48ca.apps.googleusercontent.com";
                    op.ClientSecret = Configuration["GoogleSecret"];
                })
                .AddIdentityServerJwt();

            services.ConfigureApplicationCookie(op =>
            {
                op.LogoutPath = "/Logout";
                op.LoginPath = "/Login";
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddHttpClient<SGClient>(op =>
            {
                op.BaseAddress = new Uri("https://daten.stadt.sg.ch/api/datasets/1.0/search/?q=");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseCors(op => op.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
    public class ProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;
        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);

            var claims = new List<Claim>
            {
                new Claim("FullName", user.UserName),
            };
            context.IssuedClaims.AddRange(claims);
        }
        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);

            context.IsActive = (user != null) && true;
        }
    }
}
