using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccesLayer.Repositories;
using BuisnesLogicLayer.Services;
using BuisnesLogicLayer.Interfaces;
using DataAccesLayer.Interfaces;
using DataAccesLayer;
using DataAccesLayer.EF;
using BuisnesLogicLayer.DTO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DataAccesLayer.Enteties;

namespace HauseAPI
{
    public class Startup
    {
        //private IServiceCollection _services;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            #region Repositories
            services.AddTransient<IAdRepository, AdRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFavoriteRepository, FavoriteRepository>();
            services.AddTransient<IForCompareRepository, ForCompareRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #region Services
            services.AddTransient<IAdServices, AdServices>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<ICommentServices, CommentServices>();
            services.AddTransient<IFavoritesServices, FavoritesServices>();
            services.AddTransient<IForCompareServices, ForcompareServices>();
            services.AddTransient<IImageServices, ImageServices>();
            #endregion

            services.AddDbContext<AppDBContext>();

            services.AddControllers();

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDBContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HauseAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IUserServices userServices)
        {

            if (env.IsDevelopment())
            {
                // �� ������� ���������� �� ������, ��� ������� ������
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HauseAPI v1"));
            }

            app.UseHttpsRedirection();
            //// ��������� ����������� �������������
            app.UseRouting();

            app.UseAuthentication();    // ����������� ��������������
            app.UseAuthorization();

            // ������������� ������, ������� ����� ��������������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
