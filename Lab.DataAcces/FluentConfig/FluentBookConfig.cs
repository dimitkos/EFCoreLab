using Lab.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            //Book
            modelBuilder.HasKey(x => x.Book_Id);
            modelBuilder.Property(x => x.ISBN).IsRequired().HasMaxLength(15);
            modelBuilder.Property(x => x.Title).IsRequired();
            modelBuilder.Property(x => x.Price).IsRequired();
            //one to one relationship between book and book detail
            modelBuilder
                .HasOne(x => x.Fluent_BookDetail)
                .WithOne(x => x.Fluent_Book)
                .HasForeignKey<Fluent_Book>("BookDetail_Id");
            //one to many relationship between book and publishers
            modelBuilder
                .HasOne(x => x.Fluent_Publisher)
                .WithMany(x => x.Fluent_Books)
                .HasForeignKey(x => x.Publisher_Id);
            //many to many relationship between book and author
            modelBuilder
                .HasMany(x => x.Fluent_Authors)
                .WithMany(x => x.Fluent_Books);
        }
    }
}
