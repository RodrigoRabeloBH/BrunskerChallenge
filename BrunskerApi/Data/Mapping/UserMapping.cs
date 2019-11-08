using BrunskerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrunskerApi.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FullName).IsRequired().HasColumnType("varchar(120)").HasMaxLength(120);
            builder.Property(u => u.Nickname).IsRequired().HasColumnType("varchar(60)").HasMaxLength(60);
            builder.Property(u => u.Document).IsRequired().HasColumnType("varchar(11)").HasMaxLength(11);            
            builder.Property(u => u.Gender).IsRequired().HasColumnType("varchar(9)").HasMaxLength(9);            
            builder.Property(u => u.Email).IsRequired().HasColumnType("varchar(120)").HasMaxLength(120);
            builder.Property(u => u.Phone).IsRequired().HasColumnType("varchar(10)").HasMaxLength(10);
            builder.Property(u => u.CellPhone).IsRequired().HasColumnType("varchar(11)").HasMaxLength(11);
            builder.Property(u => u.State).IsRequired().HasColumnType("varchar(30)").HasMaxLength(30);
            builder.Property(u => u.City).IsRequired().HasColumnType("varchar(30)").HasMaxLength(30);
            builder.Property(u => u.Zipcode).IsRequired().HasColumnType("varchar(9)").HasMaxLength(9);
            builder.Property(u => u.DateOfBirth).IsRequired().HasColumnType("date");   
         }
    }
}