using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookartAPI.Errors;
using BookartAPI.Helpers;
using BookartAPI.Middleware;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BookartAPI
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
            services.AddDbContext<BookStoreContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infrastructure")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookartAPI", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            services.AddAutoMapper(typeof(MappingHelper));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.Configure<ApiBehaviorOptions>(options => {
                options.InvalidModelStateResponseFactory = actionsContext =>
                 {
                     var errors = actionsContext.ModelState.Where(e => e.Value.Errors.Count > 0)
                     .SelectMany(x => x.Value.Errors)
                     .Select(x => x.ErrorMessage).ToArray();

                     var errorResponse = new ApiValidationError
                     {
                         Errors = errors
                     };

                     return new BadRequestObjectResult(errorResponse);

                 };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           app.UseMiddleware<ExceptionMiddleware>();
            if (env.IsDevelopment())
            {
              // app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookartAPI v1"));
            }
            app.UseStatusCodePagesWithReExecute("/errors/{500}");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
