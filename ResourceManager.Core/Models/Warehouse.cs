namespace ResourceManager.Core.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        
        public int WarehouseNumber { get; set; }
        
        public decimal? Volume { get; set; }
        
        public int CityId { get; set; }
        
        public string Address { get; set; }
        
        public City City { get; set; }
    }
}
