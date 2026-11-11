using System.ComponentModel.DataAnnotations;

namespace CupcakeErp.Web.Models
{
    public class Cupcake
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal PrecoVenda { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
