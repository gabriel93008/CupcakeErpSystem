namespace CupcakeErp.Web.Models
{
    public class ReceitaInsumo
    {
        public long Id { get; set; }
        public long CupcakeId { get; set; }
        public long InsumoId { get; set; }
        public double QtdUtilizada { get; set; }

        // Relacionamentos para o C# reconhecer de onde vêm os IDs
        public Cupcake? Cupcake { get; set; }
        public Insumo? Insumo { get; set; }
    }
}
