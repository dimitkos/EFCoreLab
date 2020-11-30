using Lab.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //BookDetails
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(x => x.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(x => x.NumberOfChapters).IsRequired();
        }
    }
}
