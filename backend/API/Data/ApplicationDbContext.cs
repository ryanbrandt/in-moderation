using System;
using Microsoft.EntityFrameworkCore;

using InModeration.Backend.API.Models;


namespace InModeration.Backend.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        private const string DEFAULT_DATETIME_SQL = "DATE()";

        public DbSet<User> Users { get; set; }

        public DbSet<Site> Sites { get; set; }

        public DbSet<SiteRule> SiteRules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=app.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .Property(u => u.Created)
                .HasDefaultValueSql(DEFAULT_DATETIME_SQL);
            modelBuilder.Entity<User>()
                .Property(u => u.Modified)
                .HasDefaultValueSql(DEFAULT_DATETIME_SQL);

            modelBuilder.Entity<Site>()
                .HasIndex(s => s.Domain)
                .IsUnique();
            modelBuilder.Entity<Site>()
                .Property(s => s.Created).HasDefaultValueSql(DEFAULT_DATETIME_SQL);

            modelBuilder.Entity<SiteRule>()
                .HasKey(sr => new { sr.UserId, sr.SiteId });
            modelBuilder.Entity<SiteRule>()
                .Property(sr => sr.Created).HasDefaultValueSql(DEFAULT_DATETIME_SQL);
            modelBuilder.Entity<SiteRule>()
                .Property(sr => sr.Modified).HasDefaultValueSql(DEFAULT_DATETIME_SQL);
        }
    }
}
