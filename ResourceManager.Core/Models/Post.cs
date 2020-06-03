namespace ResourceManager.Core.Models
{
    public class Post : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
