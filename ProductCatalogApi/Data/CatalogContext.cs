using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalogApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogApi.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {
        }

        //Handler method OnModelCreating
        //Override object use ModeBuilder as parameter
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CatalogBrand>(ConfigureCatalogBrand);
            builder.Entity<CatalogType>(ConfigureCatalogType);
            builder.Entity<CatalogItem>(ConfigureCatalogItem);
        }

        private void ConfigureCatalogItem(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog");
            builder.Property(c => c.Id)
                .ForSqlServerUseSequenceHiLo("catalog_hilo")
                .IsRequired(true);
            builder.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.Property(c => c.Price)
                .IsRequired(true);
            builder.Property(c => c.PictureUrl)
                .IsRequired(false);
            builder.HasOne(c => c.CatalogBrand)
                .WithMany()
                .HasForeignKey(c => c.CatalogBrandId);
            builder.HasOne(c => c.CatalogType)
               .WithMany()
               .HasForeignKey(c => c.CatalogTypeId);


        }

        private void ConfigureCatalogType(EntityTypeBuilder<CatalogType> obj)
        {
            throw new NotImplementedException();
        }

        private void ConfigureCatalogBrand(EntityTypeBuilder<CatalogBrand> obj)
        {
            throw new NotImplementedException();
        }
    }
}
