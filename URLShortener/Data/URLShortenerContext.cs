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
        // Constructor to initialize the DbContext
        public URLShortenerContext (DbContextOptions<URLShortenerContext> options)
            : base(options)
        {
        }
        // Configures the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<URLShorter>(builder =>
            {
                // Sets a maximum length for the URLName column.
                builder
                .Property(urlShortener => urlShortener.URLName)
                .HasMaxLength(2000);
                // Sets the maximum length of the ShortCode column
                builder
                .Property(URLShortener => URLShortener.URLShorterName)
                .HasMaxLength(20);
                // Ensures that the ShortCode column is unique
                builder
                .Property(u => u.ShortCode).HasMaxLength(URLShortenerService.URLLength);
                builder
                .HasIndex(u => u.ShortCode).IsUnique();
            });
        }
        // Represents the URLShorter in the database.
        public DbSet<URLShorter> URLShorter { get; set; }
    }
}
