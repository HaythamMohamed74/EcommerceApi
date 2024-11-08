using Ecommerce.Data.Data.contexts;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Repository.Repositories;
using Ecommerce.Service.Services.BasketService;
using Ecommerce.Service.Services.ProductService;
using Ecommerce.Service.Services.ProductService.Dtos;
using EcommerceApi.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EcommerceApi.Extentions
{
    public static class AppServices
    {
        public static IServiceCollection ConfigurationService(this IServiceCollection Services)
        {
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IBasketRepository, BasketRepository>();  // BasketRepo Injection 
            Services.AddScoped<IBasketService, BasketService>();  // BasketService Injection 
            Services.AddScoped<IProductService, ProductServices>();
            Services.AddAutoMapper(typeof(ProductProfile));

            Services.Configure<ApiBehaviorOptions>
               (op => op.InvalidModelStateResponseFactory = context =>
               {
                   var errors =
                   context.ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage);
                   var response = new ApiValidationError(errors);
                   return new BadRequestObjectResult(response);

               }
           );
            return Services;

        }
    }
}
