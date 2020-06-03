namespace ResourceManager.Core.Models
{
    public class MeasuringUnit : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
