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

                try
                {
                    // Check if the database exists before applying migrations
      
                    {
                        // Apply migrations if the database is not reachable
                        await context.Database.MigrateAsync();
                        await StoreDbContextSeed.SeedingData(context, loggerFactory);
                    }

                    
                  
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<StoreDBContext>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }
    }
}
