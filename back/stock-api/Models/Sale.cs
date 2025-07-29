using System;
using System.Collections.Generic;

namespace stock_api.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public DateTime? SaleDate { get; set; }

    public decimal? TotalAmount { get; set; }
}
