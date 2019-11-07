using BrunskerApi.Data.Mapping;
using BrunskerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BrunskerApi.Data
{
    public class BrunskerContext:DbContext
    {
        public DbSet<User> Users { get; set; }   

        public BrunskerContext(DbContextOptions options):base(options){}

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());         
        }
    }
}