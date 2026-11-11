using CupcakeErp.Web.Data;
using CupcakeErp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CupcakeErp.Web.Controllers
{
    public class PedidoController : Controller
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var cupcakes = await _context.Cupcakes.ToListAsync();
            return View(cupcakes);
        }

        
        [HttpPost]
        public async Task<IActionResult> Comprar(long idCupcake)
        {
            
            var cupcake = await _context.Cupcakes.FindAsync(idCupcake);
            if (cupcake == null) return NotFound();

            
            var receita = await _context.ReceitasInsumos
                                        .Include(r => r.Insumo)
                                        .Where(r => r.CupcakeId == idCupcake)
                                        .ToListAsync();

            
            foreach (var item in receita)
            {
                if (item.Insumo != null && item.Insumo.QtdStock < item.QtdUtilizada)
                {
                    TempData["Erro"] = $"Estoque insuficiente de {item.Insumo.Nome}! Venda cancelada.";
                    return RedirectToAction("Index");
                }
            }

            
            foreach (var item in receita)
            {
                if (item.Insumo != null)
                {
                    item.Insumo.QtdStock -= item.QtdUtilizada;
                    _context.Update(item.Insumo);
                }
            }

            
            var novoPedido = new Pedido
            {
                ValorTotal = cupcake.PrecoVenda,
                StatusPedido = "Concluído",
                DataPedido = DateTime.Now
            };
            _context.Pedidos.Add(novoPedido);

            
            await _context.SaveChangesAsync();

            TempData["Sucesso"] = $"Venda do {cupcake.Nome} registrada! O estoque foi atualizado automaticamente.";
            return RedirectToAction("Index");
        }
    }
}
