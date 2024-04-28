using System;
using System.Collections.Generic;

namespace GeneralAppCore.EF.Entities;

public partial class StudentPrice
{
    public int StudentPriceId { get; set; }

    public int StudentId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public virtual Student Student { get; set; } = null!;
}
