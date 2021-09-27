using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookartAPI.Errors;
using BookartAPI.Extensions;
using BookartAPI.Helpers;
using BookartAPI.Middleware;
using Core.Entities.Identities;
using Core.Interface;
using Infrastructure.Data;
using Infrastructure.Identity;
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
using StackExchange.Redis;
using BookartAPI.Extensions;

namespace BookartAPI
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public IConfiguration _Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(x => x.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infrastructure")));

            services.AddDbContext<AppIdentityDbContext>(
                x =>
                {
                    x.UseSqlServer(_Configuration.GetConnectionString("IdentityConnection"));
                }
                );
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookartAPI", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            
            services.AddSingleton<IConnectionMultiplexer>(
                c =>
                {
                    var con = ConfigurationOptions.Parse(_Configuration.GetConnectionString("Redis"), true);
                    return ConnectionMultiplexer.Connect(con);
                }
                );
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
            //services.IdentityServiceExtensions.AddIdentityServices();

            services.AddIdentityServices();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddCors(opt=>
                {
                    opt.AddPolicy("corspolicy", policy => {
                        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                    });
                }
            );
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
            app.UseCors("corspolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
