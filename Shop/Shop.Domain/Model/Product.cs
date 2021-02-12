using System.Collections;
using System.Collections.Generic;

namespace Shop.Domain.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}