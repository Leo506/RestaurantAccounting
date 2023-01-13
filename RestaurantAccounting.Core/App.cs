using MvvmCross;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Services.Auth;
using RestaurantAccounting.Core.ViewModels;

namespace RestaurantAccounting.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<IAuthService, AuthService>();
            
            RegisterAppStart<AuthViewModel>();
        }
    }
}