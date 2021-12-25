using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClimaTempo.Models.Maps
{
    public class PrevisaoClimaMap : EntityTypeConfiguration<PrevisaoClima>
    {
        public PrevisaoClimaMap()
        {
            ToTable("PrevisaoClima");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CidadeId).HasColumnName("CidadeId").IsRequired();
            Property(x => x.DataPrevisao).HasColumnName("DataPrevisao").IsRequired();
            Property(x => x.Clima).HasColumnName("Clima").HasMaxLength(15).IsRequired();
            Property(x => x.TemperaturaMinima).HasColumnName("TemperaturaMinima").IsOptional();
            Property(x => x.TemperaturaMaxima).HasColumnName("TemperaturaMaxima").IsOptional();

            HasRequired(x => x.Cidade).WithMany().HasForeignKey(x => x.CidadeId).WillCascadeOnDelete(false);
        }
    }
}