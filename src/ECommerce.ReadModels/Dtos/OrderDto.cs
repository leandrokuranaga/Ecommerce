namespace Ecommerce.ReadModels.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
        public List<OrderItemDto> Items { get; set; } = [];
    }
}