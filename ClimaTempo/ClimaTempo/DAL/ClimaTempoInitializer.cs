using ClimaTempo.Context;
using ClimaTempo.Models;
using System.Collections.Generic;

namespace ClimaTempo.DAL
{
    public class ClimaTempoInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ClimaTempoContext>
    {
        protected override void Seed(ClimaTempoContext context)
        {
            var estados = new List<Estado>
            {
                new Estado { Id = 1, Nome = "Acre", UF = "AC"},
                new Estado { Id = 2, Nome = "Alagoas", UF = "AL"},
                new Estado { Id = 3, Nome = "Amapá", UF = "AP"},
                new Estado { Id = 4, Nome = "Amazonas", UF = "AM"},
                new Estado { Id = 5, Nome = "Bahia", UF = "BA"},
                new Estado { Id = 6, Nome = "Ceará", UF = "CE"},
                new Estado { Id = 7, Nome = "Espírito Santo", UF = "ES"},
                new Estado { Id = 8, Nome = "Goiás", UF = "GO"},
                new Estado { Id = 9, Nome = "Maranhão", UF = "MA"},
                new Estado { Id = 10, Nome = "Mato Grosso", UF = "MT"},
                new Estado { Id = 11, Nome = "Mato Grosso do Sul", UF = "MS"},
                new Estado { Id = 12, Nome = "Minas Gerais", UF = "MG"},
                new Estado { Id = 13, Nome = "Pará", UF = "PA"},
                new Estado { Id = 14, Nome = "Paraíba", UF = "PB"},
                new Estado { Id = 15, Nome = "Paraná", UF = "PR"},
                new Estado { Id = 16, Nome = "Pernambuco", UF = "PE"},
                new Estado { Id = 17, Nome = "Piauí", UF = "PI"},
                new Estado { Id = 18, Nome = "Rio de Janeiro", UF = "RJ"},
                new Estado { Id = 19, Nome = "Rio Grande do Norte", UF = "RN"},
                new Estado { Id = 20, Nome = "Rio Grande do Sul", UF = "RS"},
                new Estado { Id = 21, Nome = "Rondônia", UF = "RO"},
                new Estado { Id = 22, Nome = "Roraima", UF = "RR"},
                new Estado { Id = 23, Nome = "Santa Catarina", UF = "SC"},
                new Estado { Id = 24, Nome = "São Paulo", UF = "SP"},
                new Estado { Id = 25, Nome = "Sergipe", UF = "SE"},
                new Estado { Id = 26, Nome = "Tocantins", UF = "TO"},
                new Estado { Id = 27, Nome = "Distrito Federal", UF = "DF"},
            };

            estados.ForEach(s => context.Estado.Add(s));
            context.SaveChanges();

            var cidades = new List<Cidade>
            {
                new Cidade { Id = 1, Nome = ""},
            };

            base.Seed(context);
        }
    }
}