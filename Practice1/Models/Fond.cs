using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Practice1.Models;

public partial class Fond
{
    public int TableId { get; set; }

    public int? TotalNumberOfGuestRooms { get; set; }

    public bool? Status { get; set; }

    public decimal? Price { get; set; }
    [JsonIgnore]
    public virtual ICollection<PricesAndAccommodationsEmployee> PricesAndAccommodationsEmployees { get; set; } = new List<PricesAndAccommodationsEmployee>();
}
