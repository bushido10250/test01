using System;
using System.Collections.Generic;

namespace stock_api.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? StockQuantity { get; set; }
}
