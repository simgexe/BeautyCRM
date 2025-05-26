using System;
using System.Collections.Generic;

namespace BeautyCRM.Models;

public partial class Session
{
    public int Id { get; set; }

    public int CustomerServiceId { get; set; }

    public DateTime SessionDate { get; set; }

    public bool? IsAttended { get; set; }

    public int SessionNumber { get; set; }

    public string? Note { get; set; }

    public virtual CustomerService CustomerService { get; set; } = null!;
}
