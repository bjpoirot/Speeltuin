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
        public ShipwharfDbContext(DbContextOptions<ShipwharfDbContext> options) : base(options)
        {
            
        }

        public DbSet<Ship> Ships { get; set; }

        public DbSet<ShipType> ShipTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
