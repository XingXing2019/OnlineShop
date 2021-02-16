namespace Shop.Domain.ViewModel
{
    public class StockViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Qty { get; set; }
    }
}