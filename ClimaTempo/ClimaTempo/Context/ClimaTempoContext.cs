using ClimaTempo.Models;
using ClimaTempo.Models.Maps;
using System.Data.Entity;

namespace ClimaTempo.Context
{
    public class ClimaTempoContext : DbContext
    {
        public ClimaTempoContext() : base("ClimaTempoSimples")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EstadoMap());
            modelBuilder.Configurations.Add(new CidadeMap());
            modelBuilder.Configurations.Add(new PrevisaoClimaMap());
        }

        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<PrevisaoClima> PrevisaoClima { get; set; }
    }
}