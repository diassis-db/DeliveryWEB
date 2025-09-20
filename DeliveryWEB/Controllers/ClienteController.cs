using DeliveryWEB.Data;
using DeliveryWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryWEB.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            ViewData["BodyPictures"] = "cliente-bp";
            return View(BancoDB.Clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["BodyPictures"] = "cliente-bp";
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            cliente.Id = BancoDB.Clientes.Count + 1;
            BancoDB.Clientes.Add(cliente);
            return RedirectToAction("Index");
        }
    }
}
