using System.Data.Entity.ModelConfiguration;
using AppGoat.Domain.Entities;

namespace AppGoat.Repository.Mappers
{
    internal class OfferMapper : EntityTypeConfiguration<Offer>
    {

        public OfferMapper()
        {
            ConfigureProperties();
            ConfigureRelations();
        }

        private void ConfigureProperties()
        {
            ToTable("Offer");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(550)
                .IsUnicode(false)
                .IsOptional();

            Property(x => x.ColorCode)
                .HasColumnName("ColorCode")
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .IsRequired();

        }

        private void ConfigureRelations()
        {

        }
    }
}