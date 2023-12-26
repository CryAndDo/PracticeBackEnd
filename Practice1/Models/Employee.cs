using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Practice1.Models;

public partial class Employee
{
    public int IdEmpleyee { get; set; }

    public string? Username { get; set; }
    [JsonIgnore]
    public virtual ICollection<PricesAndAccommodationsEmployee> PricesAndAccommodationsEmployees { get; set; } = new List<PricesAndAccommodationsEmployee>();
}
