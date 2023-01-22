using System.Security.Authentication;
using RestaurantAccounting.Core.DbContexts;
using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.UnitTests.Helpers;
using RestaurantAccounting.Core.Utils;
using SemanticComparison.Fluent;

namespace RestaurantAccounting.Core.UnitTests.AuthService;

public partial class AuthServiceTests : TestBase
{

    [Test]
    public void Authenticate_LoginAndPasswordCorrect_ReturnsEmployee()
    {
        // arrange
        var sut = new Services.Auth.AuthService(Context);

        // act
        var result = sut.Authenticate("Test", "password");

        // assert
        Employee.AsSource().OfLikeness<Employee>().Without(x => x.Id).Without(x => x.ShiftStatus)
            .ShouldEqual(result);
        
        Context.Dispose();
    }

    [Test]
    public void Authenticate_LoginIncorrect_ThrowsAuthenticationException()
    {
        // arrange
        var sut = new Services.Auth.AuthService(Context);
        
        // act and assert
        Assert.Throws<AuthenticationException>(() => sut.Authenticate("Incorrect", "password"));
    }

    [Test]
    public void Authenticate_PasswordIncorrect_ThrowsAuthenticationException()
    {
        // arrange
        var sut = new Services.Auth.AuthService(Context);
        
        // act and assert
        Assert.Throws<AuthenticationException>(() => sut.Authenticate("Test", "incorrect"));
    }
}