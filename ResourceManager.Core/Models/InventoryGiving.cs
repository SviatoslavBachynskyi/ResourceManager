using System;

namespace ResourceManager.Core.Models
{
    public class InventoryGiving
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int TakenById { get; set; }

        public int ApprovedById { get; set; }

        public int InventoryId { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public Worker ApprovedBy { get; set; }

        public Inventory Inventory { get; set; }

        public Worker TakenBy { get; set; }
    }
}
