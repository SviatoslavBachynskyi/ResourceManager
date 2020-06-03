namespace ResourceManager.Core.Models
{
    public class OrderItem : IEntity<int>
    {
        public int Id { get; set; }

        public int ResourceId { get; set; } 

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public Resource Resource { get; set; }
    }
}
