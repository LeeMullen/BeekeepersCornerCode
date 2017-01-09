using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeekeepersCorner.Models;
using Microsoft.EntityFrameworkCore;

namespace BeekeepersCorner.Data
{
    public class BeekeepersDBContext : DbContext
    {

        public BeekeepersDBContext(DbContextOptions<BeekeepersDBContext> options) : base(options)
        {
            
        }

        public DbSet<Beekeeper> Beekeepers { get; set; }
        public DbSet<Beehive> Beehives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beekeeper>().ToTable("Beekeepers");
            modelBuilder.Entity<Beehive>().ToTable("Beehives");

            
        }

    }

    
}
