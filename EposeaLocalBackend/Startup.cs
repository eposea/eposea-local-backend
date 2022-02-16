using Autofac;
using EposeaLocalBackend.API.Extensions;
using EposeaLocalBackend.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
namespace EposeaLocalBackend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddGrpc();
            services.AddGrpcReflection();
            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("BloggingDatabase")));
            services.AddAutoMapper(typeof(Startup));

        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAllServices();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseGrpcWeb();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<CourseService>()
                         .EnableGrpcWeb(); ;
                endpoints.MapGrpcService<ItemService>()
                         .EnableGrpcWeb();

                if (env.IsDevelopment())
                {
                    endpoints.MapGrpcReflectionService();
                }   
            });
        }
    }
}
