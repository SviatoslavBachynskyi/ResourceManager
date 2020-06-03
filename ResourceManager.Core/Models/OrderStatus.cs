namespace ResourceManager.Core.Models
{
    public class OrderStatus : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
