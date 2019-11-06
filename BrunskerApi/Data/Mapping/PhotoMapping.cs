using BrunskerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrunskerApi.Data.Mapping
{
    public class PhotoMapping : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Url).IsRequired().HasColumnType("varchar(120)").HasMaxLength(120);            
        }
    }
}