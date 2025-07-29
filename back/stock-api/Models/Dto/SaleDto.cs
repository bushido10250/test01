namespace stock_api.Models.Dto
{
    public class SaleDto
    {
        public int? ProductId { get; set; }
        public decimal? TotalAmount { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
