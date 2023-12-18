using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class CatalogBrandConfiguration : IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.HasKey(cb => cb.Id);
            builder.Property(cb => cb.Id).UseHiLo("catalog_brand_hilo").IsRequired();
            builder.Property(cb => cb.Brand).IsRequired().HasMaxLength(100);
        }
    }
}
