using Ecommerce.Data.Data.contexts;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Ecommerce.Repository
{
    public class StoreDbContextSeed
    {
        public static async Task SeedingData(StoreDBContext storeDBContext,ILoggerFactory loggerFactory)
        {

            try
            {

                if (storeDBContext.ProductBrands is not null && !storeDBContext.ProductBrands.Any())
                {
                    var json = File.ReadAllText("../Ecommerce.Repository/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(json);
                    if (brands is not null)
                    {
                        await storeDBContext.AddRangeAsync(brands);
                    }
                    
                }   if (storeDBContext.ProductTypes is not null && !storeDBContext.ProductTypes.Any())
                {
                    var json = File.ReadAllText("../Ecommerce.Repository/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(json);
                    if (types is not null)
                    {
                        await storeDBContext.AddRangeAsync(types);
                    }
                    
                }if (storeDBContext.Products is not null && !storeDBContext.Products.Any())
                {
                    var json = File.ReadAllText("../Ecommerce.Repository/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(json);
                    if (products is not null)
                    {
                        await storeDBContext.AddRangeAsync(products);
                    }
                    
                }
                await storeDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
              var log=  loggerFactory.CreateLogger<StoreDbContextSeed>();
                log.LogError(ex.Message);
              
                
            }

           

        }
    }
}
