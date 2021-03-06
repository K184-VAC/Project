using TPS.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPS.Data
{
    public class TPSDataContext : DbContext
    {
        public TPSDataContext() : base() { }
        public TPSDataContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember>()
                .HasKey(tm => new { tm.UserId, tm.TeamId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;User=tps;Password=;Database=tps_dev", new MariaDbServerVersion(new Version(10, 6, 3)));
            }
        }

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Team> Teams => Set<Team>(); 
        public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
        public DbSet<User> Users => Set<User>();
    }
}