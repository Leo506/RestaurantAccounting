using Microsoft.Extensions.Logging;

namespace RestaurantAccounting.Core.Extensions;

public static class LoggerExtensions
{
    public static IDisposable? BeginScopeWithCorrelationId(this ILogger logger)
    {
        return logger.BeginScope(new Dictionary<string, Guid>()
        {
            ["CorrelationId"] = Guid.NewGuid()
        });
    }
}