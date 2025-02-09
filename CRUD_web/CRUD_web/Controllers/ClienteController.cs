using Microsoft.AspNetCore.Mvc;
using CRUD_web.Data;
using CRUD_web.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AppDBcontext _appDbcontext;
        public ClienteController(AppDBcontext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Cliente> lista = await _appDbcontext.CLIENTES.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public  IActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Cliente cliente)
        {
            await _appDbcontext.CLIENTES.AddAsync(cliente);
            await _appDbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Cliente cliente = await _appDbcontext.CLIENTES.FirstAsync(c => c.Idcliente == id);
            return View(cliente);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Cliente cliente)
        {
            _appDbcontext.CLIENTES.Update(cliente);
            await _appDbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Cliente cliente = await _appDbcontext.CLIENTES.FirstAsync(c => c.Idcliente == id);

            _appDbcontext.CLIENTES.Remove(cliente); 
            await _appDbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));

          
        }

    }
}
