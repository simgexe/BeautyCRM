using System;
using System.Collections.Generic;

namespace BeautyCRM.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<CustomerService> CustomerServices { get; set; } = new List<CustomerService>();
}
