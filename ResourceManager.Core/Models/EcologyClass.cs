namespace ResourceManager.Core.Models
{
    public class EcologyClass : IEntity<int>
    {
        public int Id { get; set; }

        public string CodeName { get; set; }
    }
}
