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

        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<PrevisaoClima> PrevisaoClima { get; set; }
    }
}