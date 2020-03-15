using Microsoft.EntityFrameworkCore;
using System;
using apicore.Domain.Models;
namespace apicore.Domain.Contexts
{
    public class AppDbContext : DbContext
    {
         public DbSet<Test> Tests { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        
            builder.Entity<Test>().ToTable("Tests");
            builder.Entity<Test>().HasKey(p => p.Id);
            builder.Entity<Test>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Test>().Property(p => p.Name).IsRequired().HasMaxLength(512);


            builder.Entity<Test>().HasData(
                new Test(){Id=1,Name= "Test1"},
                new Test(){Id=2,Name= "Test2"},
                new Test(){Id=3,Name= "Test3"}
            ); 
           
            }
    }
}