namespace stock_api.Models.Dto
{
    public class SaleItemDto
    {
        public int? SaleId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
