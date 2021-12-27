namespace ClimaTempo.Models.ViewModel
{
    public class CidadeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
    }
}