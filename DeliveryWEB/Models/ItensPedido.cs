namespace DeliveryWEB.Models
{
    public class ItensPedido
    {
        public string Produto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Total => Quantidade * ValorUnitario;
    }
}
