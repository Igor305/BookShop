using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataAccessLayer.AppContext;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Repositories.EFRepositories;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Services;
using AutoMapper;
using BusinessLogicLayer.AutoMapper;
using Microsoft.OpenApi.Models;

namespace PresentationLayer
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration["ConnectionStrings:BookShopDB"];
            services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(connectionString));
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddControllers();
            MapperConfiguration mapperconfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            IMapper mapper = mapperconfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
