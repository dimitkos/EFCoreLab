using Lab.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.DataAccess.FluentConfig
{
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            //Author
            modelBuilder.HasKey(x => x.Author_Id);
            modelBuilder.Property(x => x.FirstName).IsRequired();
            modelBuilder.Property(x => x.LastName).IsRequired();
            modelBuilder.Ignore(x => x.FullName);
        }
    }
}
