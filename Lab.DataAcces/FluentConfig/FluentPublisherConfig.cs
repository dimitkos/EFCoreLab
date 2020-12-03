using Lab.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.DataAccess.FluentConfig
{
    public class FluentPublisherConfig : IEntityTypeConfiguration<Fluent_Publisher>
    {
        public void Configure(EntityTypeBuilder<Fluent_Publisher> modelBuilder)
        {
            //Publisher
            modelBuilder.HasKey(x => x.Publisher_Id);
            modelBuilder.Property(x => x.Name).IsRequired();
            modelBuilder.Property(x => x.Location).IsRequired();
        }
    }
}
