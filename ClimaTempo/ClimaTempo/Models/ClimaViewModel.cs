using ClimaTempo.Models.ViewModel;

namespace ClimaTempo.Models
{
    public class ClimaViewModel
    {
        public CidadeViewModel CidadeVM { get; set; }
        public PrevisaoClimaViewModel PrevisaoVM { get; set;}
        public EstadoViewModel EstadoVM { get; set; }
    }
}