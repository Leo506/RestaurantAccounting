namespace RestaurantAccounting.Core.Interactions;

public enum AlertType
{
    None,
    Error,
    Warning
}

public interface IAlertInteraction
{
    public void Alert(string message, string title = "", AlertType alertType = AlertType.None);
}