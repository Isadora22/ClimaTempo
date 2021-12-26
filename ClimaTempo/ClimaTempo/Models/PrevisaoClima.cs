using System;

namespace ClimaTempo.Models
{
    public class PrevisaoClima
    {
        public int Id { get; set; }
        public int CidadeId { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string Clima { get; set; }
        public decimal TemperaturaMinima { get; set; }
        public decimal TemperaturaMaxima { get; set; }

        public virtual Cidade Cidade { get; set; }

        internal object ToList()
        {
            throw new NotImplementedException();
        }
    }
}