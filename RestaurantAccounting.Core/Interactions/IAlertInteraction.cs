namespace RestaurantAccounting.Core.Interactions;

public enum AlertType
{
    None,
    Error,
    Warning
}

public interface IAlertInteraction
{
    public void AlertAsync(string message, string title = "", AlertType alertType = AlertType.None);
}