using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;

namespace ResourceManager.Dal.Repositories
{
    public class OrderStatusRepository : BaseRepository<OrderStatus, int>, IOrderStatusRepository
    {
        public OrderStatusRepository(ResourceManagerContext context) : base(context)
        {
        }
    }
}
