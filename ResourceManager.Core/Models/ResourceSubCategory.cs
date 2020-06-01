namespace ResourceManager.Core.Models
{
    public class ResourceSubCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ResourceCategoryId { get; set; }

        public ResourceCategory ResourceCategory { get; set; }
    }
}
