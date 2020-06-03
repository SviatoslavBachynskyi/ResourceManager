using Microsoft.Extensions.DependencyInjection;
using ResourceManager.Core;
using ResourceManager.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace ResourceManager.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICityRepository _cityRepository;

        private ICountryRepository _countryRepository;

        private IDistrictRepository _districtRepository;

        private IEcologyClassRepository _ecologyClassRepository;

        private IInventoryGivingRepository _inventoryGivingRepository;

        private IInventoryRepository _inventoryRepository;

        private IMeasuringUnitRepository _measuringUnitRepository;

        private IOrderItemRepository _orderItemRepository;

        private IOrderRepository _orderRepository;

        private IOrderStatusRepository _orderStatusRepository;

        private IPostRepository _postRepository;

        private IResourceCategoryRepository _resourceCategoryRepository;

        private IResourceRepository _resourceRepository;

        private IResourceSubCategoryRepository _resourceSubCategoryRepository;

        private ISafetyClassRepository _safetyClassRepository;

        private ISupplierRepository _supplierRepository;

        private ISupplyRepository _supplyRepository;

        private IWarehouseRepository _warehouseRepository;

        private IWorkerRepository _workerRepository;

        private readonly ResourceManagerContext _dbContext;

        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(ResourceManagerContext dbContext, IServiceProvider serviceProvider)
        {
            this._dbContext = dbContext;
            this._serviceProvider = serviceProvider;
        }

        public ICityRepository CityRepository =>
            this._cityRepository ??= this._serviceProvider.GetService<ICityRepository>();

        public ICountryRepository CountryRepository =>
            this._countryRepository ??= this._serviceProvider.GetService<ICountryRepository>();

        public IDistrictRepository DistrictRepository =>
            this._districtRepository ??= this._serviceProvider.GetService<IDistrictRepository>();

        public IEcologyClassRepository EcologyClassRepository =>
            this._ecologyClassRepository ??= this._serviceProvider.GetService<IEcologyClassRepository>();

        public IInventoryGivingRepository InventoryGivingRepository =>
            this._inventoryGivingRepository ??= this._serviceProvider.GetService<IInventoryGivingRepository>();

        public IInventoryRepository InventoryRepository =>
            this._inventoryRepository ??= this._serviceProvider.GetService<IInventoryRepository>();

        public IMeasuringUnitRepository MeasuringUnitRepository =>
            this._measuringUnitRepository ??= this._serviceProvider.GetService<IMeasuringUnitRepository>();

        public IOrderItemRepository OrderItemRepository =>
            this._orderItemRepository ??= this._serviceProvider.GetService<IOrderItemRepository>();

        public IOrderRepository OrderRepository =>
            this._orderRepository ??= this._serviceProvider.GetService<IOrderRepository>();

        public IOrderStatusRepository OrderStatusRepository =>
            this._orderStatusRepository ??= this._serviceProvider.GetService<IOrderStatusRepository>();

        public IPostRepository PostRepository =>
            this._postRepository ??= this._serviceProvider.GetService<IPostRepository>();

        public IResourceCategoryRepository ResourceCategoryRepository =>
            this._resourceCategoryRepository ??= this._serviceProvider.GetService<IResourceCategoryRepository>();

        public IResourceRepository ResourceRepository =>
            this._resourceRepository ??= this._serviceProvider.GetService<IResourceRepository>();

        public IResourceSubCategoryRepository ResourceSubCategoryRepository =>
            this._resourceSubCategoryRepository ??= this._serviceProvider.GetService<IResourceSubCategoryRepository>();

        public ISafetyClassRepository SafetyClassRepository =>
            this._safetyClassRepository ??= this._serviceProvider.GetService<ISafetyClassRepository>();

        public ISupplierRepository SupplierRepository =>
            this._supplierRepository ??= this._serviceProvider.GetService<ISupplierRepository>();

        public ISupplyRepository SupplyRepository =>
            this._supplyRepository ??= this._serviceProvider.GetService<ISupplyRepository>();

        public IWarehouseRepository WarehouseRepository =>
            this._warehouseRepository ??= this._serviceProvider.GetService<IWarehouseRepository>();

        public IWorkerRepository WorkerRepository =>
            this._workerRepository ??= this._serviceProvider.GetService<IWorkerRepository>();

        public void SaveChanges()
        {
            this._dbContext.SaveChanges();
        }
        
        public async Task SaveChangesAsync()
        {
            await this._dbContext.SaveChangesAsync();
        }
    }
}
