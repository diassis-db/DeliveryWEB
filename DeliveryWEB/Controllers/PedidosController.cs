using DeliveryWEB.Data;
using DeliveryWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DeliveryWEB.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            ViewData["BodyPictures"] = "pedidos-bp";
            return View(BancoDB.Pedidos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["BodyPictures"] = "pedidos-bp";          
            ViewBag.Clientes = BancoDB.Clientes;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pedido pedido)
        {
            foreach (var item in pedido.Itens)
            {
                // Converte vírgula para ponto se necessário
                item.ValorUnitario = decimal.Parse(item.ValorUnitario.ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            }
            pedido.Id = BancoDB.Pedidos.Count + 1;
            var cliente = BancoDB.Clientes.FirstOrDefault(c => c.Id == pedido.ClienteId);
            if (cliente != null)
            {
                pedido.ClienteNome = cliente.Nome;
            }
            pedido.Entregue = false; 
            BancoDB.Pedidos.Add(pedido);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarcarEntregue(int id)
        {
            var pedido = BancoDB.Pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido != null)
            {
                pedido.Entregue = true;
            }

            return RedirectToAction("Index");
        }
    }
}
