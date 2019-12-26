using System.ComponentModel.DataAnnotations.Schema;
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

        private void ConfigureProperties()
        {
            ToTable("Color");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
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
                .IsRequired();
        }

        private void ConfigureRelations()
        {

        }
    }
}