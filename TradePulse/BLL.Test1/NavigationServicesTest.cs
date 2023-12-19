using System;
using Moq;
using Presentation.Core;
using Presentation.Services;
using Xunit;

public class NavigationServicesTests
{
    [Fact]
    public void NavigateTo_ShouldSetCurrentView()
    {
        // Arrange
        var viewModelFactoryMock = new Mock<Func<Type, ViewModel>>();
        var navigationService = new NavigationServices(viewModelFactoryMock.Object);

        // Act
        navigationService.NavigateTo<SomeViewModel>();

        // Assert
        Assert.NotNull(navigationService.CurrentView);
        Assert.IsType<SomeViewModel>(navigationService.CurrentView);
    }

    [Fact]
    public void InitParam_ShouldInvokeInitFunc()
    {
        // Arrange
        var viewModelFactoryMock = new Mock<Func<Type, ViewModel>>();
        var navigationService = new NavigationServices(viewModelFactoryMock.Object);
        navigationService.NavigateTo<SomeViewModel>();

        var initFuncMock = new Mock<Action<SomeViewModel>>();

        // Act
        navigationService.InitParam(initFuncMock.Object);

        // Assert
        initFuncMock.Verify(initFunc => initFunc(It.IsAny<SomeViewModel>()), Times.Once);
    }

    // Add more tests as needed
}

public class SomeViewModel : ViewModel
{
    // Add properties and methods of SomeViewModel as needed
}
