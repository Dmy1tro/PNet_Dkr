using System;
using Microsoft.EntityFrameworkCore;
using PNet_Project.Models.Entities;

namespace PNet_Project.Context
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<BookGenre> BookGenres { get; set; }

        public DbSet<Author> Authors { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public event Action Notify;

        public override int SaveChanges()
        {
            var affectedRows = base.SaveChanges();

            Notify?.Invoke();

            return affectedRows;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(x => x.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
