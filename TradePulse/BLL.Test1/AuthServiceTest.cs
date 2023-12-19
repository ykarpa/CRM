using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Services;
using Moq;
using Presentation.Core;
using Presentation.Services;
using Xunit;

public class AuthServiceTests
{
    [Fact]
    public async Task CheckIfAuthExpired_ShouldReturnTrue_WhenConfigFileNotFound()
    {
        // Arrange
        var userServiceMock = new Mock<UserService>();
        AuthService.UserService = userServiceMock.Object;
        var authService = new AuthService();

        // Act
        var result = await AuthService.CheckIfAuthExpired();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task CheckIfAuthExpired_ShouldReturnTrue_WhenUserDoesNotExist()
    {
        // Arrange
        var userServiceMock = new Mock<UserService>();
        userServiceMock.Setup(us => us.GetUserDetails(It.IsAny<int>())).ReturnsAsync((UserDetailsDTO)null);
        AuthService.UserService = userServiceMock.Object;
        var authService = new AuthService();

        // Create a temporary config file for testing
        var tempConfigFile = Path.Combine(Directory.GetCurrentDirectory(), "tempConfig.json");
        File.WriteAllText(tempConfigFile, "{}");
        AuthServicePrivateMethods.SetConfigPath(tempConfigFile);

        // Act
        var result = await AuthService.CheckIfAuthExpired();

        // Assert
        Assert.True(result);

        // Cleanup
        File.Delete(tempConfigFile);
    }

    [Fact]
    public async Task CheckIfAuthExpired_ShouldReturnFalse_WhenAuthIsNotExpired()
    {
        // Arrange
        var userServiceMock = new Mock<UserService>();
        userServiceMock.Setup(us => us.GetUserDetails(It.IsAny<int>())).ReturnsAsync(new UserDetailsDTO());
        AuthService.UserService = userServiceMock.Object;
        var authService = new AuthService();

        // Create a temporary config file for testing
        var tempConfigFile = Path.Combine(Directory.GetCurrentDirectory(), "tempConfig.json");
        var authConfig = new AuthConfig { LastVisited = DateTime.UtcNow.AddMonths(-1).Ticks / TimeSpan.TicksPerSecond, User = 1 };
        File.WriteAllText(tempConfigFile, JsonSerializer.Serialize(authConfig));
        AuthServicePrivateMethods.SetConfigPath(tempConfigFile);

        // Act
        var result = await AuthService.CheckIfAuthExpired();

        // Assert
        Assert.False(result);

        // Cleanup
        File.Delete(tempConfigFile);
    }

    // Add more tests for other scenarios as needed
}

// AuthServicePrivateMethods is a static class with a private method used for setting the config file path
internal static class AuthServicePrivateMethods
{
    internal static void SetConfigPath(string path)
    {
        typeof(AuthService).GetField("config", BindingFlags.Static | BindingFlags.NonPublic)?.SetValue(null, path);
    }
}
