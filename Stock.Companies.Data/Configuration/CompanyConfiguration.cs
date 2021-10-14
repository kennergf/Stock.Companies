using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stock.Companies.Domain.Entities;

namespace Stock.Companies.Data.Configuration
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        /// <summary>
        /// Configure the entity to be transformed in SQL instructions without DataAnnotation
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.HasIndex(x => x.Id)
                .HasDatabaseName("IdIndex")
                .IsUnique();
            
            builder.Property(x => x.Name)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();
            
            builder.Property(x => x.Exchange)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();
            
            builder.Property(x => x.Ticker)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();
            
            builder.Property(x => x.ISIN)
                .HasColumnType("varchar(12)")
                .HasMaxLength(12)
                .IsRequired();
            
            builder.HasIndex(x => x.ISIN)
                .HasDatabaseName("ISINIndex")
                .IsUnique();
            
            builder.Property(x => x.WebSite)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256);
        }
    }
}