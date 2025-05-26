using System;
using System.Collections.Generic;

namespace BeautyCRM.Models;

public partial class Service
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? TotalSessionCount { get; set; }

    public decimal? FixedPrice { get; set; }

    public bool? IsPerSessionPricing { get; set; }

    public virtual ServiceCategory Category { get; set; } = null!;

    public virtual ICollection<CustomerService> CustomerServices { get; set; } = new List<CustomerService>();
}
