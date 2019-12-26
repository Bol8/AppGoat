using System.Data.Entity.ModelConfiguration;
using AppGoat.Domain.Entities;

namespace AppGoat.Repository.Mappers
{
    internal class ColorPromoMapper : EntityTypeConfiguration<ColorPromo>
    {

        internal ColorPromoMapper()
        {
            ConfigureProperties();
            ConfigureRelations();
        }

        private void ConfigureRelations()
        {
            ToTable("Color");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            Property(x => x.Code)
                .HasColumnName("Code")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
        }

        private void ConfigureProperties()
        {

        }
    }
}