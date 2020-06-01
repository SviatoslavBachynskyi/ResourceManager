using System.Collections.Generic;

namespace ResourceManager.Core.Models
{
    public class District
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public List<City> Cities { get; set; }
    }
}
