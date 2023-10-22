using BAU_Project_RentACarPortal.App.DataAccess.Contexts;
using BAU_Project_RentACarPortal.App.DataAccess.Identity.Model;
using BAU_Project_RentACarPortal.App.DataAccess.UnitOfWorks;
using BAU_Project_RentACarPortal.App.Entity.Interfaces;
using BAU_Project_RentACarPortal.App.Entity.IUnitOfWorks;
using BAU_Project_RentACarPortal.App.Entity.Services;
using BAU_Project_RentACarPortal.App.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAU_Project_RentACarPortal.App.Service.Mapping;
using BAU_Project_RentACarPortal.App.Service.Services;
using Microsoft.AspNetCore.Identity;

namespace BAU_Project_RentACarPortal.App.Service.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddExtensions(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(
                 opt =>
                 {
                     opt.Password.RequireNonAlphanumeric = false;
                     opt.Password.RequiredLength = 3;
                     opt.Password.RequireUppercase = false;
                     opt.Password.RequireLowercase = false;
                     opt.Password.RequireDigit = false;

                     //opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789";

                     opt.User.RequireUniqueEmail = true;

                     opt.Lockout.MaxFailedAccessAttempts = 3;    //default : 5
                     opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default 5 dk
                 }
                     ).AddEntityFrameworkStores<RentalDbContext>()
                     .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Account/Login");
                opt.LogoutPath = new PathString("/Account/Logout");
                //opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                opt.SlidingExpiration = true; //10 dk dolmadan kullanıcı login olursa süre baştan başlar.
                opt.Cookie = new CookieBuilder()
                {
                    Name = "Identity.App.Cookie",
                    HttpOnly = true
                };
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWorks, UnitOfWork>();
            services.AddScoped(typeof(IAccountService), typeof(AccountService));
            services.AddScoped<IArabaService, ArabaService>();
            services.AddScoped<IArabaDetayService, ArabaDetayService>();
            services.AddScoped<IKategoriService, KategoriService>();
            services.AddScoped<IFirmaService, FirmaService>();
            services.AddScoped<ISigortaService, SigortaService>();
            services.AddScoped<IKiralamaService, KiralamaService>();
            services.AddScoped<IKiralamaDetayService, KiralamaDetayService>();
            services.AddScoped<ITeslimService, TeslimService>();
            services.AddScoped<IDegerlendirmeService, DegerlendirmeService>();
            services.AddScoped<IDevirService, DevirService>();

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
