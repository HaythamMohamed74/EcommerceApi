using Ecommerce.Data.Data.contexts;
using Ecommerce.Repository;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Helper
{
    public class SeedingData
    {
       public static async Task SeedData(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                var context = serviceProvider.GetRequiredService<StoreDBContext>();
                await context.Database.MigrateAsync();
                await StoreDbContextSeed.SeedingData(context, loggerFactory);

            }
        }
    }
}
