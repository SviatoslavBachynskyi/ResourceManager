using System.Collections.Generic;

namespace ResourceManager.Core.Models
{
    public class ResourceCategory : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ResourceSubCategory> ResourceSubCategories { get; set; }
    }
}
