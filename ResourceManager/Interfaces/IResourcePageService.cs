using ResourceManager.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceManager.PageServices
{
    public interface IResourcePageService
    {
        Task<IEnumerable<ResourceViewModel>> GetAllAsync();
    }
}
