using Microsoft.EntityFrameworkCore;
using Shipwharf.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipwharf.Infrastructure
{
    public class ShipwharfDbContext : DbContext
    {


        public ShipwharfDbContext(DbContextOptions<ShipwharfDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ship> Ships { get; set; }
        public DbSet<ShipType> ShipTypes { get; set; }

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
