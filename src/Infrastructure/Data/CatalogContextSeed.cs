using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext context, ILogger logger, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (context.Database.IsSqlServer())
                {
                    context.Database.Migrate();
                }
                if (!await context.CatalogBrands.AnyAsync())
                {
                    await context.CatalogBrands.AddRangeAsync(GetPreconfiguredCatalogBrands());
                    await context.SaveChangesAsync();
                }
                if (!await context.CatalogTypes.AnyAsync())
                {
                    await context.CatalogTypes.AddRangeAsync(GetPreconfiguredCatalogTypes());
                    await context.SaveChangesAsync();
                }
                if (!await context.CatalogItems.AnyAsync())
                {
                    await context.CatalogItems.AddRangeAsync(GetPerconfiguredCatalogItems());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;
                retryForAvailability++;
                logger.LogError(ex.Message);
                await SeedAsync(context, logger, retryForAvailability);
                throw;
            }
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new ("T-Shirt"),
                new("Sheet")
            };
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new ("Azure"),
                new(".NET")
            };
        }

        static IEnumerable<CatalogItem> GetPerconfiguredCatalogItems()
        {
            return new List<CatalogItem>() { new(1, 1, "体恤1", "描述", 20.5M, "http://catalogbaseurltobereplaced/images/products/1.png"),
            new(1, 1, "体恤2", "描述", 20.5M, "http://catalogbaseurltobereplaced/images/products/1.png") ,
            new(1, 1, "体恤3", "描述", 20.5M, "http://catalogbaseurltobereplaced/images/products/1.png") ,
            new(1, 1, "体恤4", "描述", 20.5M, "http://catalogbaseurltobereplaced/images/products/1.png") ,
            new(1, 1, "体恤5", "描述", 20.5M, "http://catalogbaseurltobereplaced/images/products/1.png") ,
            new(1, 2, "sheet1", "描述", 8, "http://catalogbaseurltobereplaced/images/products/2.png") ,
            new(1, 2, "sheet2", "描述", 8, "http://catalogbaseurltobereplaced/images/products/2.png") ,
            new(1, 2, "sheet3", "描述", 8, "http://catalogbaseurltobereplaced/images/products/2.png") ,
            new(1, 2, "sheet4", "描述", 8, "http://catalogbaseurltobereplaced/images/products/2.png") ,
            new(1, 2, "sheet5", "描述", 8, "http://catalogbaseurltobereplaced/images/products/2.png") ,

            };
        }
    }
}
