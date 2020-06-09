using Microsoft.AspNetCore.Identity;

namespace ResourceManager.Core.Models
{
    public class Worker : IdentityUser, IEntity<string>
    {
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
