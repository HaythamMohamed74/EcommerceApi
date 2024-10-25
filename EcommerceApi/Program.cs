
using Ecommerce.Data.Data.contexts;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Repository.Repositories;
using Ecommerce.Service.Services.ProductService;
using Ecommerce.Service.Services.ProductService.Dtos;
using EcommerceApi.Helper;
using EcommerceApi.Middlewars;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductService, ProductServices>();
            builder.Services.AddAutoMapper(typeof(ProductProfile));

            builder.Services.AddDbContext<StoreDBContext>
                (optionsAction :(op)=>op.
                UseSqlServer(builder.Configuration.
                GetConnectionString("DefaultConnection"),
                                   op =>
                                   {
                                       op.CommandTimeout(3600);
                                       //sqlServerOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(60), null);
                                   }
                   ));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        
            
            var app = builder.Build();
            await SeedingData.SeedData(app);
           

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStatusCodePagesWithReExecute("/error/{0}");  //not found endpoint
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
    
}
