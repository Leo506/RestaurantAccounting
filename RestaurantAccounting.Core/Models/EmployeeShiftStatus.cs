using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAccounting.Core.Models;

public partial class Employee
{
    [NotMapped]
    public ShiftStatus PersonalShiftStatus
    {
        get => ShiftStatus == "Open" ? Models. ShiftStatus. Open : Models. ShiftStatus. Close;
        set => ShiftStatus = value == Models.ShiftStatus.Open ? "Open" : "Close";
    }
}

public enum ShiftStatus
{
    Close,
    Open
}
