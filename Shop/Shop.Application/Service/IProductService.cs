using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Domain.ViewModel;

namespace Shop.Application.Service
{
    public interface IProductService
    {
        Task<ProductViewModel> Get(int id);
        Task<ProductViewModel> Get(string productName);
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> Post(ProductViewModel vm);
        Task<ProductViewModel> Put(ProductViewModel vm);
        Task<bool> Delete(int id);
    }
}