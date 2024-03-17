﻿namespace Taxmo.Infrastructure.Persistence.Context;

public partial class Carrent
{
    public int RentId { get; set; }

    public int? DailyPrice { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? CarId { get; set; }

    public int? DriverId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Driver? Driver { get; set; }
}
