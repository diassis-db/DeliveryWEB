using DeliveryWEB.Models;

namespace DeliveryWEB.Data
{
    public static class BancoDB
    {
        public static List<Cliente> Clientes { get; set; } = new();
        public static List<Pedido> Pedidos { get; set; } = new();
    }
}
