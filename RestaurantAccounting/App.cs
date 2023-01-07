using MvvmCross;
using MvvmCross.ViewModels;
using RestaurantAccounting.Services.Auth;
using RestaurantAccounting.ViewModels;

namespace RestaurantAccounting
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