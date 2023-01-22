using System.Security.Authentication;
using RestaurantAccounting.Core.DbContexts;
using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.UnitTests.Helpers;
using RestaurantAccounting.Core.Utils;
using SemanticComparison.Fluent;

namespace RestaurantAccounting.Core.UnitTests.AuthService;

public partial class AuthServiceTests
{
    private EmployeeContext _context;

    private Employee _employee = new Employee()
    {
        FirstName = "Test",
        LastName = "Test",
        Login = "Test",
        Password = PasswordEncryptor.EncryptPassword("password"),
        ShiftStatus = "Close"
    };
    
    [SetUp]
    public void BeforeEachTest()
    {
        _context = new DbContextHelper().Context;
        _context.Employees.Add(_employee);
        _context.SaveChanges();
    }
    
    [Test]
    public void Authenticate_LoginAndPasswordCorrect_ReturnsEmployee()
    {
        // arrange
        var sut = new Services.Auth.AuthService(_context);

        // act
        var result = sut.Authenticate("Test", "password");

        // assert
        _employee.AsSource().OfLikeness<Employee>().Without(x => x.Id).Without(x => x.ShiftStatus)
            .ShouldEqual(result);
        
        _context.Dispose();
    }

    [TearDown]
    public void AfterEachTest()
    {
        _context.Dispose();
    }

    [Test]
    public void Authenticate_LoginIncorrect_ThrowsAuthenticationException()
    {
        // arrange
        var sut = new Services.Auth.AuthService(_context);
        
        // act and assert
        Assert.Throws<AuthenticationException>(() => sut.Authenticate("Incorrect", "password"));
    }

    [Test]
    public void Authenticate_PasswordIncorrect_ThrowsAuthenticationException()
    {
        // arrange
        var sut = new Services.Auth.AuthService(_context);
        
        // act and assert
        Assert.Throws<AuthenticationException>(() => sut.Authenticate("Test", "incorrect"));
    }
}