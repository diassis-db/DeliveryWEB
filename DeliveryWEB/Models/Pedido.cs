namespace DeliveryWEB.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; } = "";

        public List<ItensPedido> Itens { get; set; } = new List<ItensPedido>();

        public decimal ValorTotal => Itens.Sum(i => i.Total);

        public bool Entregue { get; set; } = false;
    }
}
