using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ShipwharfMVCSolution.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Ship> Ships { get; set; }
        public DbSet<ShipType> ShipTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ship>()
                .Property(b => b.Id)
                .IsRequired();
            modelBuilder.Entity<Ship>()
                .Property(b => b.Name)
                .HasMaxLength(255);
            modelBuilder.Entity<Ship>()
                .HasIndex(s => s.Name);
            modelBuilder.Entity<Ship>()
                .Property(b => b.EuNumber)
                .HasMaxLength(50);
            modelBuilder.Entity<Ship>()
                .HasIndex(s => s.EuNumber);


            modelBuilder.Entity<ShipType>()
                .Property(b => b.Id)
                .IsRequired();
        }
    }
}
