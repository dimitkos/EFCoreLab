using Lab.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Category
            modelBuilder.Entity<Category>().ToTable("tbl_category");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("CategoryName");

            //BookDetails
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(x => x.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(x => x.NumberOfChapters).IsRequired();          

            //Book
            modelBuilder.Entity<Fluent_Book>().HasKey(x => x.Book_Id);
            modelBuilder.Entity<Fluent_Book>().Property(x => x.ISBN).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Fluent_Book>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(x => x.Price).IsRequired();
            //one to one relationship between book and book detail
            modelBuilder.Entity<Fluent_Book>()
                .HasOne(x => x.Fluent_BookDetail)
                .WithOne(x => x.Fluent_Book)
                .HasForeignKey<Fluent_Book>("BookDetail_Id");
            //one to many relationship between book and publishers
            modelBuilder.Entity<Fluent_Book>()
                .HasOne(x => x.Fluent_Publisher)
                .WithMany(x => x.Fluent_Books)
                .HasForeignKey(x=> x.Publisher_Id);
            //many to many relationship between book and author
            modelBuilder.Entity<Fluent_Book>()
                .HasMany(x => x.Fluent_Authors)
                .WithMany(x => x.Fluent_Books);

            //Author
            modelBuilder.Entity<Fluent_Author>().HasKey(x => x.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(x => x.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(x => x.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(x => x.FullName);

            //Publisher
            modelBuilder.Entity<Fluent_Publisher>().HasKey(x => x.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Fluent_Publisher>().Property(x => x.Location).IsRequired();
        }
    }
}
