using Lab.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.DataAccess.FluentConfig
{
    public class FluentBookDetailsConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            //BookDetails
            modelBuilder.HasKey(x => x.BookDetail_Id);
            modelBuilder.Property(x => x.NumberOfChapters).IsRequired();
        }
    }
}
