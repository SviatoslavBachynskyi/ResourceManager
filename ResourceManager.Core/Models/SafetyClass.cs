namespace ResourceManager.Core.Models
{
    public class SafetyClass : IEntity<int>
    {
        public int Id { get; set; }

        public string CodeName { get; set; }
    }
}
