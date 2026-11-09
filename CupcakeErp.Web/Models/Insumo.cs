namespace CupcakeErp.Web.Models
{
    public class Insumo
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public double QtdStock { get; set; }
        public double QtdMinima { get; set; }
        public string UnidadeMedida { get; set; } = string.Empty;
    }
}