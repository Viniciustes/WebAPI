using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var clientes = new ClienteViewModel().ListarTodos();

            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel cliente)
        {
            new ClienteViewModel().Cadastrar();
            return View();
        }

        public IActionResult Edit(int id)
        {
            var cliente = new ClienteViewModel().BuscarPorId(id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClienteViewModel cliente)
        {
            new ClienteViewModel().Editar(id);
            return View();
        }

        public IActionResult Delete(int id)
        {
            var cliente = new ClienteViewModel().BuscarPorId(id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            new ClienteViewModel().Apagar((int)id);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
