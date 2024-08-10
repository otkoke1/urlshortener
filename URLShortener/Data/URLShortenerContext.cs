using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using URLShortener.Models;
using URLShortener.Services;

namespace URLShortener.Data
{
    public class URLShortenerContext : DbContext
    {
        public URLShortenerContext (DbContextOptions<URLShortenerContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<URLShorter>(builder =>
            {
                builder
                .Property(urlShortener => urlShortener.URLName)
                .HasMaxLength(2000);

                builder
                .Property(URLShortener => URLShortener.URLShorterName)
                .HasMaxLength(20);

                builder
                .Property(u => u.ShortCode).HasMaxLength(URLShortenerService.URLLength);
                builder
                .HasIndex(u => u.ShortCode).IsUnique();
            });
        }

        public DbSet<URLShorter> URLShorter { get; set; }
    }
}
