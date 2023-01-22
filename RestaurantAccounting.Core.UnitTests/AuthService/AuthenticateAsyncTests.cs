using System.Security.Authentication;
using RestaurantAccounting.Core.Models;
using SemanticComparison.Fluent;

namespace RestaurantAccounting.Core.UnitTests.AuthService;

public partial class AuthServiceTests
{
    [Test]
    public async Task AuthenticateAsync_LoginAndPasswordCorrect_ReturnsEmployee()
    {
        // arrange
        var sut = new Services.Auth.AuthService(_context);
        
        // act
        var result = await sut.AuthenticateAsync("Test", "password");
        
        // assert
        result.AsSource().OfLikeness<Employee>().Without(x => x.Id).Without(x => x.ShiftStatus).ShouldEqual(result);
    }

    [Test]
    public void AuthenticateAsync_LoginIncorrect_ThrowsAuthenticationException()
    {
        // arrange
        var sut = new Services.Auth.AuthService(_context);
        
        // act and assert
        async Task AuthAction() => await sut.AuthenticateAsync("Incorrect", "password");
        Assert.That((AsyncTestDelegate)AuthAction, Throws.TypeOf<AuthenticationException>());
    }

    [Test]
    public void AuthenticateAsync_PasswordIncorrect_ThrowsAuthenticationException()
    {
        // arrange
        var sut = new Services.Auth.AuthService(_context);
        
        // act and assert
        async Task AuthAction() => await sut.AuthenticateAsync("Test", "Incorrect");
        Assert.That((AsyncTestDelegate)AuthAction, Throws.TypeOf<AuthenticationException>());
    }
}