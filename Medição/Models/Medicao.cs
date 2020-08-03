namespace SistemaMedicao.Models
{
    public class Medicao
    {
        public int Id { get; set; }
        public Pessoa Pessoa { get; set; }
        public float Temperatura { get; set; }
    }
}