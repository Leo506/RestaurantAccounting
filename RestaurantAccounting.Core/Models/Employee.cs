using System;
using System.Collections.Generic;

namespace RestaurantAccounting.Core.Models;

public enum ShiftStatus
{
    Close,
    Open
}

public partial class Employee
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public ShiftStatus ShiftStatus { get; set; }
}
