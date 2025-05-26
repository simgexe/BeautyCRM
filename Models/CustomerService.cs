using System;
using System.Collections.Generic;

namespace BeautyCRM.Models;

public partial class CustomerService
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ServiceId { get; set; }

    public DateTime? StartDate { get; set; }

    public decimal? TotalPaid { get; set; }

    public string? PaymentType { get; set; }

    public decimal? RemainingAmount { get; set; }

    public int? RemainingSessionCount { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
