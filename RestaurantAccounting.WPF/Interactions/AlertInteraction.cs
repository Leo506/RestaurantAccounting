using System.Threading.Tasks;
using System.Windows;
using RestaurantAccounting.Core.Interactions;

namespace RestaurantAccounting.WPF.Interactions;

public class AlertInteraction : IAlertInteraction
{
    public void Alert(string message, string title = "", AlertType alertType = AlertType.None)
    {
        var icon = alertType switch
        {
            AlertType.Error => MessageBoxImage.Error,
            AlertType.Warning => MessageBoxImage.Warning,
            _ => MessageBoxImage.None
        };
        
        MessageBox.Show(message, title, MessageBoxButton.OK, icon);
    }
}