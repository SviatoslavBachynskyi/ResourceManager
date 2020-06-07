using System;
using System.Collections.Generic;

namespace ResourceManager.Core.Models
{
    public class Supply : IEntity<int>
    {
        public int Id { get; set; }

        public string WayBillNumber { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int AcceptedById { get; set; }

        public Worker AcceptedBy { get; set; }

        public List<Order> Orders { get; set; }
    }
}
