using System;
using System.Collections.Generic;

namespace Practice1.Models;

public partial class PricesAndAccommodationsEmployee
{
    public int IdPriceAccomodations { get; set; }

    public decimal? Stoimos { get; set; }

    public DateOnly? Start { get; set; }

    public DateOnly? Finish { get; set; }

    public int? IdFond { get; set; }

    public int? IdEmpleyee { get; set; }

    public bool? StatusAccommodation { get; set; }
    
    public virtual Employee? IdEmpleyeeNavigation { get; set; }

    public virtual Fond? IdFondNavigation { get; set; }
}
