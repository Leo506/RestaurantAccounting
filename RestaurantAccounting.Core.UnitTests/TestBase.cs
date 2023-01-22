using RestaurantAccounting.Core.DbContexts;
using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.UnitTests.Helpers;
using RestaurantAccounting.Core.Utils;

namespace RestaurantAccounting.Core.UnitTests;

public class TestBase
{
    protected EmployeeContext Context;
    
    protected Employee Employee = new Employee()
    {
        FirstName = "Test",
        LastName = "Test",
        Login = "Test",
        Password = PasswordEncryptor.EncryptPassword("password"),
        ShiftStatus = "Close"
    };

    [SetUp]
    public virtual void BeforeEachTest()
    {
        Context = new DbContextHelper().Context;
        Context.Employees.Add(Employee);
        Context.SaveChanges();
    }
    
    [TearDown]
    public virtual void AfterEachTest()
    {
        Context.Dispose();
    }
}