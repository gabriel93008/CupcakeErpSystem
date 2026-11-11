using System;

namespace CupcakeErp.Web.Models
{
    public class Pedido
    {
        public long Id { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public string StatusPedido { get; set; } = "Concluído";
        public decimal ValorTotal { get; set; }
    }
}