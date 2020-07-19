using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PurchaseC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using PurchaseC.Models;

namespace PurchaseC
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
            services.AddRazorPages();

            services.AddDbContext<PurchaseCContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PurchaseCContext")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddDefaultUI()
                    .AddEntityFrameworkStores<PurchaseCContext>()
                    .AddDefaultTokenProviders();

            services.AddMvc()
            .AddRazorPagesOptions(options =>
            {
                // options.Conventions.AllowAnonymousToFolder("/Computers");
                // options.Conventions.AuthorizePage("/Computers/Create");
                //  options.Conventions.AuthorizeAreaPage("Identity", "/Manage/Accounts");
                //options.Conventions.AuthorizeFolder("/Computers");
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages("text/html", "<h1 style='font-size: 120px;font-family: Tahoma;color: #ff0033'> Error in accessing page!</h1> <h2 style='font-size: 60px;font-family: Tahoma'>Status Code: {0}</h2>");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePages("text/html", "<h1 style='font-size: 120px;font-family: Tahoma;color: #ff0033'> Error in accessing page!</h1> <h2 style='font-size: 60px;font-family: Tahoma'>Status Code: {0}</h2>");
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
