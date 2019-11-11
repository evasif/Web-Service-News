using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using template.Models.DetailDto;
using template.Models.Dto;
using template.Models.Entities;
using template.Models.InputModels;

namespace template
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<NewsItemDto, NewsItem>();
                cfg.CreateMap<NewsItem, NewsItemDto>();
                cfg.CreateMap<NewsItemInputModel, NewsItem>();
                cfg.CreateMap<NewsItem, NewsItemInputModel>();
                cfg.CreateMap<CategoryInputModel, Category>();
                cfg.CreateMap<Category, CategoryInputModel>();
                cfg.CreateMap<NewsItemDetailDto, NewsItem>();
                cfg.CreateMap<NewsItem, NewsItemDetailDto>();
                cfg.CreateMap<CategoryDetailDto, Category>();
                cfg.CreateMap<Category, CategoryDetailDto>();
                cfg.CreateMap<CategoryDto, Category>();
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<AuthorDetailDto, Author>();
                cfg.CreateMap<Author, AuthorDetailDto>();
                cfg.CreateMap<AuthorDto, Author>();
                cfg.CreateMap<Author, AuthorDto>();
                cfg.CreateMap<AuthorInputModel, Author>();
                cfg.CreateMap<Author, AuthorInputModel>();

            });
        }
    }
}
