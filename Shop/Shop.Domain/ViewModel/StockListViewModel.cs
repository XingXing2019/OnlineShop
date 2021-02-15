using System.Collections.Generic;

namespace Shop.Domain.ViewModel
{
    public class StockListViewModel
    {
        public IEnumerable<StockViewModel> Stocks { get; set; }
    }
}