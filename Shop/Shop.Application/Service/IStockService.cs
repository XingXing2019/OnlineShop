using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Domain.ViewModel;

namespace Shop.Application.Service
{
    public interface IStockService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<StockViewModel> Post(StockViewModel vm);
        Task<StockListViewModel> Put(StockListViewModel vm);
        Task<bool> Delete(int id);
    }
}