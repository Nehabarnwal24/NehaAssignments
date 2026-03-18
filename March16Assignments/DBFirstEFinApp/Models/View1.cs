using System;
using System.Collections.Generic;

namespace DBFirstEFinApp.Models;

public partial class View1
{
    public string CompanyName { get; set; } = null!;

    public string? City { get; set; }

    public string? ContactName { get; set; }

    public DateTime? OrderDate { get; set; }

    public string CustomerId { get; set; } = null!;

    public string? Expr1 { get; set; }

    public int OrderId { get; set; }

    public decimal? Freight { get; set; }
}
