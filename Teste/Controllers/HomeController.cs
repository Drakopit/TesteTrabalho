using System.Collections.Generic;
using System.Web.Mvc;
using Teste.Models;
using Teste.Utils;

namespace Teste.Controllers
{
    public class HomeController : Controller
    {
        private List<Cliente> _clientes = new List<Cliente>();
        private readonly string filePath = "D:\\Lista_De_Clientes.json";

        public ActionResult Index()
        {
            _clientes = JsonBD<Cliente>.ObterArquivo(filePath);
            return View(_clientes);
        }

        [HttpGet]
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Cliente cliente)
        {

            JsonBD<Cliente>.Inserir(filePath, cliente);
            return View(cliente);
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            return View(JsonBD<Cliente>.Obter(filePath, id));
        }

        [HttpPost]
        public ActionResult Alterar(int id, Cliente cliente)
        {
            JsonBD<Cliente>.Alterar(filePath, id, cliente);
            return View(cliente);
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            return View(JsonBD<Cliente>.Obter(filePath, id));
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            JsonBD<Cliente>.ExcluirPorId(filePath, id);
            return RedirectToAction("Index");
        }
    }
}