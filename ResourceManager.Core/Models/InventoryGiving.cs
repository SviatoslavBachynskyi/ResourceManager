using System;

namespace ResourceManager.Core.Models
{
    public class InventoryGiving : IEntity<int>
    {
        public int Id { get; set; }

        public DateTime RequestDate { get; set; }

        public string TakenById { get; set; }

        public int? InventoryGivingStatusId { get; set; }

        public string ApprovedById { get; set; }

        public int InventoryId { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public InventoryGivingStatus InventoryGivingStatus { get; set; }

        public Worker ApprovedBy { get; set; }

        public Inventory Inventory { get; set; }

        public Worker TakenBy { get; set; }
    }
}
