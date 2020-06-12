using System;

namespace ResourceManager.Core.Models
{
    [Flags]
    public enum Role
    {
        Admin,
        Manager,
        InventoryManager,
        Worker
    }
}
