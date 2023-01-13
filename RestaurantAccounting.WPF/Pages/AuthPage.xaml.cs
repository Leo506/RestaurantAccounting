using System.Windows;
using System.Windows.Controls;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Interactions;
using RestaurantAccounting.Core.ViewModels;

namespace RestaurantAccounting.WPF.Pages;

[MvxContentPresentation]
[MvxViewFor(typeof(AuthViewModel))]
public partial class AuthPage : MvxWpfView
{
    private IMvxInteraction<AlertInteraction> _alertInteraction;
    public IMvxInteraction<AlertInteraction> AlertInteraction
    {
        get => _alertInteraction;
        set
        {
            if (_alertInteraction != null)
                _alertInteraction.Requested -= OnAlertInteractionRequested;

            _alertInteraction = value;
            _alertInteraction.Requested += OnAlertInteractionRequested;
        }
    }


    public AuthPage()
    {
        InitializeComponent();

        var set = this.CreateBindingSet<AuthPage, AuthViewModel>();
        set.Bind(this).For(view => view.AlertInteraction).To(viewModel => viewModel.AuthFailedInteraction).OneWay();
        set.Apply();
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        var actualPassword = (sender as PasswordBox)?.Password;
        if (ViewModel is AuthViewModel authViewModel) authViewModel.Password = actualPassword ?? "";
    }
    
    
    private void OnAlertInteractionRequested(object sender, MvxValueEventArgs<AlertInteraction> e)
    {
        MessageBox.Show(e.Value.Message);
    }
}