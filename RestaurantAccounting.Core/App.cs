using Microsoft.Extensions.Configuration;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.DbContexts;
using RestaurantAccounting.Core.Services.Auth;
using RestaurantAccounting.Core.Services.ProductService;
using RestaurantAccounting.Core.Services.Register;
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
            
#if INMEMORY
            Mvx.IoCProvider.RegisterType<IAuthService, InMemoryAuthService>();
            Mvx.IoCProvider.RegisterType<IRegistrationService, InMemoryAuthService>();

#else
            Mvx.IoCProvider.RegisterType<IAuthService, AuthService>();
            Mvx.IoCProvider.RegisterType<IRegistrationService, RegistrationService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<EmployeeContext>(() =>
                new EmployeeContext(configuration.GetConnectionString("postgres")!));
            Mvx.IoCProvider.RegisterType<IProductService, ProductService>();
#endif
            
            RegisterAppStart<AuthViewModel>();
        }
    }
}