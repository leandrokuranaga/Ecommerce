namespace Ecommerce.Application.Commands.Product
{
    public class AddProductCommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int SellerId { get; set; }
    }
}
