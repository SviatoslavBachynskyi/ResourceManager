namespace ResourceManager.Core.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public string InventoryNum { get; set; }

        public int WareHouseId { get; set; }

        public int ResourceId { get; set; }

        public int OrderItemId { get; set; }

        public int Quantity { get; set; }

        public OrderItem OrderItem { get; set; }

        public Resource Resource { get; set; }

        public Warehouse WareHouse { get; set; }
    }
}
