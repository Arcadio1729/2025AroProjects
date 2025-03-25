using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aroshopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace aroshopapi.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<User>? Users{get;set;}
        public DbSet<Role>? Roles { get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasIndex(u => u.Name)
                .IsUnique();  
        }
    }
}