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

        // 1. Tela inicial que lista os Cupcakes disponíveis para venda
        public async Task<IActionResult> Index()
        {
            var cupcakes = await _context.Cupcakes.ToListAsync();
            return View(cupcakes);
        }

        // 2. Ação de registrar a venda e dar baixa automática no estoque (Regra de Negócio)
        [HttpPost]
        public async Task<IActionResult> Comprar(long idCupcake)
        {
            // Busca o cupcake escolhido
            var cupcake = await _context.Cupcakes.FindAsync(idCupcake);
            if (cupcake == null) return NotFound();

            // Busca a receita (quais ingredientes esse cupcake gasta)
            var receita = await _context.ReceitasInsumos
                                        .Include(r => r.Insumo)
                                        .Where(r => r.CupcakeId == idCupcake)
                                        .ToListAsync();

            // PASSO A: Verifica se tem estoque suficiente ANTES de vender
            foreach (var item in receita)
            {
                if (item.Insumo != null && item.Insumo.QtdStock < item.QtdUtilizada)
                {
                    TempData["Erro"] = $"Estoque insuficiente de {item.Insumo.Nome}! Venda cancelada.";
                    return RedirectToAction("Index");
                }
            }

            // PASSO B: Se tem estoque, desconta a quantidade usada de cada ingrediente
            foreach (var item in receita)
            {
                if (item.Insumo != null)
                {
                    item.Insumo.QtdStock -= item.QtdUtilizada;
                    _context.Update(item.Insumo);
                }
            }

            // PASSO C: Registra o pedido de venda no financeiro
            var novoPedido = new Pedido
            {
                ValorTotal = cupcake.PrecoVenda,
                StatusPedido = "Concluído",
                DataPedido = DateTime.Now
            };
            _context.Pedidos.Add(novoPedido);

            // PASSO D: Salva todas as alterações no banco de dados de uma só vez
            await _context.SaveChangesAsync();

            TempData["Sucesso"] = $"Venda do {cupcake.Nome} registrada! O estoque foi atualizado automaticamente.";
            return RedirectToAction("Index");
        }
    }
}
