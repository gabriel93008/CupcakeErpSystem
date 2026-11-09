using CupcakeErp.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CupcakeErp.Web.Controllers
{
    public class InsumoController : Controller
    {
        private readonly AppDbContext _context;

        public InsumoController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var listaDeInsumos = await _context.Insumos.ToListAsync();
            return View(listaDeInsumos);
        }
    }
}
