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

        static  IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
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
    }
}
