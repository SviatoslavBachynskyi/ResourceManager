using System;

namespace ResourceManager.Core.Models
{
    [Flags]
    public enum Role
    {
        Admin = 1,
        Manager = 2,
        InventoryManager = 4,
        Worker = 8
    }
}
