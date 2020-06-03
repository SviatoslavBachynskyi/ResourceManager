using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem, int>, IOrderItemRepository
    {
        public OrderItemRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
