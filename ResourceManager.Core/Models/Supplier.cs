namespace ResourceManager.Core.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}
