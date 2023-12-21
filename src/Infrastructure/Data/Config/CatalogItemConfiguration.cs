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
    public class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog");
            builder.Property(ci => ci.Id).UseHiLo("catalog_hilo").IsRequired();
            builder.Property(ci => ci.Name).HasMaxLength(50).IsRequired();
            builder.Property(ci => ci.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(ci => ci.PictureUrl).IsRequired(false);

            builder.HasOne(ci => ci.CatalogBrand).WithMany().HasForeignKey(ci => ci.CatalogBrandId);
            builder.HasOne(ci => ci.CatalogType).WithMany().HasForeignKey(ci => ci.CatalogTypeId);
        }
    }
}
