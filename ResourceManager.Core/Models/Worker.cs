namespace ResourceManager.Core.Models
{
    public class Worker : IEntity<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string FatherName { get; set; }

        public string LastName { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public int PostId { get; set; }

        public City City { get; set; }

        public Post Post { get; set; }
    }
}
