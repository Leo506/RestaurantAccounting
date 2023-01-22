using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RestaurantAccounting.Core.DbContexts;
using RestaurantAccounting.Core.Services;

namespace RestaurantAccounting.Core.UnitTests.Helpers;

public class DbContextHelper
{
    public EmployeeContext Context { get; set; }

    public DbContextHelper()
    {
        var builder = new DbContextOptionsBuilder<EmployeeContext>();
        builder.UseInMemoryDatabase(Guid.NewGuid().ToString())
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

        var options = builder.Options;
        Context = new EmployeeContext(options);
        
        DbFiller.FillDb(Context);
    }
}