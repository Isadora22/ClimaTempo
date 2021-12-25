namespace ClimaTempo.Migrations
{
    using ClimaTempo.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClimaTempo.Context.ClimaTempoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClimaTempo.Context.ClimaTempoContext context)
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
                new Cidade { Id = 1, Nome = "Catalão", EstadoId = 8},
                new Cidade { Id = 2, Nome = "Formosa", EstadoId = 8},
                new Cidade { Id = 3, Nome = "Goianésia", EstadoId = 8},
                new Cidade { Id = 4, Nome = "Goiânia", EstadoId = 8},
            };
            cidades.ForEach(s => context.Cidade.Add(s));
            context.SaveChanges();

            var previsaoClima = new List<PrevisaoClima>
            {
                new PrevisaoClima { Id = 1, CidadeId = 3, DataPrevisao = DateTime.Today, Clima = "Quente", TemperaturaMaxima = 32, TemperaturaMinima = 28 },
                new PrevisaoClima { Id = 2, CidadeId = 4, DataPrevisao = DateTime.Today, Clima = "Quente", TemperaturaMaxima = 31, TemperaturaMinima = 27 },
                new PrevisaoClima { Id = 3, CidadeId = 1, DataPrevisao = DateTime.Today, Clima = "Quente", TemperaturaMaxima = 30, TemperaturaMinima = 26 },
            };
            previsaoClima.ForEach(s => context.PrevisaoClima.Add(s));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
