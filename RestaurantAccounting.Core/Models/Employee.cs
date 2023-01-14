using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

    public string ShiftStatus { get; set; } = null!;

    [NotMapped]
    public ShiftStatus PersonalShiftStatus
    {
        get => ShiftStatus == "Open" ? Models. ShiftStatus. Open : Models. ShiftStatus. Close;
        set => ShiftStatus = value == Models.ShiftStatus.Open ? "Open" : "Close";
    }
}
