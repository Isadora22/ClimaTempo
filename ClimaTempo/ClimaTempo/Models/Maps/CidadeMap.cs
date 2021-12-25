using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ClimaTempo.Models.Maps
{
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            ToTable("Cidade");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasColumnName("Nome").HasMaxLength(200).IsRequired();
            Property(x => x.EstadoId).HasColumnName("EstadoId").IsRequired();

            HasRequired(x => x.Estado).WithMany().HasForeignKey(x => x.EstadoId).WillCascadeOnDelete(false);
        }
    }
}