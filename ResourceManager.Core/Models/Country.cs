using System.Collections.Generic;

namespace ResourceManager.Core.Models
{
    public class Country : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<District> Districts { get; set; }
    }
}
