using System.Collections.Generic;

namespace ClimaTempo.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }
    }
}