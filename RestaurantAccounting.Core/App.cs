using Microsoft.Extensions.Configuration;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.DbContexts;
using RestaurantAccounting.Core.Services.Auth;
using RestaurantAccounting.Core.ViewModels;

namespace RestaurantAccounting.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            
            Mvx.IoCProvider.RegisterSingleton<IConfiguration>(configuration);
            Mvx.IoCProvider.RegisterType<IAuthService, AuthService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<EmployeeContext>(() =>
                new EmployeeContext(configuration.GetConnectionString("postgres")!));
            
            RegisterAppStart<AuthViewModel>();
        }
    }
}