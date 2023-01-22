using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Wpf.Core;
using RestaurantAccounting.Core.Interactions;
using Serilog;
using Serilog.Extensions.Logging;
using AlertInteraction = RestaurantAccounting.WPF.Interactions.AlertInteraction;

namespace RestaurantAccounting.WPF;

public class Setup : MvxWpfSetup<Core.App>
{
    protected override ILoggerProvider CreateLogProvider()
    {
        return new SerilogLoggerProvider();
    }

    protected override ILoggerFactory CreateLogFactory()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("Logs\\AppLog.log",
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
            .Enrich.FromLogContext()
            .CreateLogger();

        return new SerilogLoggerFactory();
    }

    protected override void InitializeFirstChance(IMvxIoCProvider iocProvider)
    {
        Mvx.IoCProvider.RegisterType<IAlertInteraction, AlertInteraction>();
        base.InitializeFirstChance(iocProvider);
    }
}