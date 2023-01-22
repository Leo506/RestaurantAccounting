using FluentAssertions;
using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.Services.Register;

namespace RestaurantAccounting.Core.UnitTests.Register;

public class RegistrationServiceTests : TestBase
{
    [Test]
    public void Register_LoginNotUnique_ThrowInvalidDataException()
    {
        // arrange
        var sut = new RegistrationService(Context);
        var employeeToRegister = new Employee()
        {
            Login = Employee.Login
        };
        
        // act and assert
        Assert.Throws<InvalidDataException>(() => sut.Register(employeeToRegister));
    }

    [Test]
    public void RegisterAsync_LoginNotUnique_ThrowInvalidDataException()
    {
        // arrange
        var sut = new RegistrationService(Context);
        var employeeToAdd = new Employee()
        {
            Login = Employee.Login
        };
        
        // act and assert
        async Task RegisterAction() => await sut.RegisterAsync(employeeToAdd);
        Assert.That((AsyncTestDelegate)RegisterAction, Throws.TypeOf<InvalidDataException>());
    }

    [Test]
    public void Register_AllGood_EmployeeCountIncrease()
    {
        // arrange
        var sut = new RegistrationService(Context);
        var employeeToAdd = new Employee()
        {
            FirstName = "Test2",
            LastName = "Test2",
            Login = "Test2",
            Password = "password",
            ShiftStatus = "Close"
        };

        // act
        sut.Register(employeeToAdd);
        
        // assert
        Context.Employees.Count().Should().Be(2);
    }

    [Test]
    public async Task RegisterAsync_AllGood_EmployeeCountIncrease()
    {
        // arrange
        var sut = new RegistrationService(Context);
        var employeeToAdd = new Employee()
        {
            FirstName = "Test2",
            LastName = "Test2",
            Login = "Test2",
            Password = "password",
            ShiftStatus = "Close"
        };
        
        // act
        await sut.RegisterAsync(employeeToAdd);
        
        // assert
        Context.Employees.Count().Should().Be(2);
    }
}