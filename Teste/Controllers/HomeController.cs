using SmartIT.Employee.MockDB;
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

        [HttpGet]
        public ActionResult Index()
        {
            _clientes = JsonBD.ObterArquivo<Cliente>(filePath);
            return View(_clientes);
        }

        public ActionResult Inserir(Cliente cliente)
        {
            if (cliente != null)
            {
                JsonBD.Inserir<Cliente>(filePath, cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Alterar(int id, Cliente cliente)
        {
            if (cliente != null)
            {
                JsonBD.Alterar<Cliente>(filePath, id, cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Excluir(int id)
        {
            if (id != null)
            {
                JsonBD.Excluir<Cliente>(filePath, id);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}