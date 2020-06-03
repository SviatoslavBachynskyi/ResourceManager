using ResourceManager.Core.Repositories;
using System.Threading.Tasks;

namespace ResourceManager.Core
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }

        ICountryRepository CountryRepository { get; }

        IDistrictRepository DistrictRepository { get; }

        IEcologyClassRepository EcologyClassRepository { get; }

        IInventoryGivingRepository InventoryGivingRepository { get; }

        IInventoryRepository InventoryRepository { get; }

        IMeasuringUnitRepository MeasuringUnitRepository { get; }

        IOrderItemRepository OrderItemRepository { get; }

        IOrderRepository OrderRepository { get; }

        IOrderStatusRepository OrderStatusRepository { get; }

        IPostRepository PostRepository { get; }

        IResourceCategoryRepository ResourceCategoryRepository { get; }

        IResourceRepository ResourceRepository { get; }

        IResourceSubCategoryRepository ResourceSubCategoryRepository { get; }

        ISafetyClassRepository SafetyClassRepository { get; }

        ISupplierRepository SupplierRepository { get; }

        ISupplyRepository SupplyRepository { get; }

        IWarehouseRepository WarehouseRepository { get; }

        IWorkerRepository WorkerRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
