using ClimaTempo.Models.ViewModel;
using System.Collections.Generic;

namespace ClimaTempo.Models
{
    public class ClimaViewModel
    {
        public CidadeViewModel CidadeVM { get; set; }
        public PrevisaoClimaViewModel PrevisaoVM { get; set;}
        public EstadoViewModel EstadoVM { get; set; }
    }
}