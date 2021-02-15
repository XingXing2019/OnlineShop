using System.Collections.Generic;

namespace Shop.Domain.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public IEnumerable<StockViewModel> Stocks { get; set; }
    }
}