using System.Security.Cryptography;
using Moq;
using Presentation.Services;
using Xunit;

public class PasswordServiceTests
{
    [Fact]
    public void EncodePassword_ShouldEncodePassword()
    {
        // Організація
        string password = "MySecretPassword";

        // Мокування правильного класу CryptoService
        var cryptoServiceMock = new Mock<Presentation.Services.CryptoService>();
        cryptoServiceMock.Setup(cs => cs.Encrypt(It.IsAny<string>())).Returns("EncryptedPassword");

        PasswordService.CryptoService = cryptoServiceMock.Object;

        // Дія
        string encodedPassword = PasswordService.EncodePassword(password);

        // Перевірка
        Assert.NotNull(encodedPassword);
        Assert.Contains("EncryptedPassword", encodedPassword);
    }

    [Fact]
    public void Verify_ShouldVerifyPassword()
    {
        // Організація
        string password = "MySecretPassword";
        string encodedPassword = "SomeSalt__3__3__3EncryptedPassword";

        // Мокування правильного класу CryptoService
        var cryptoServiceMock = new Mock<Presentation.Services.CryptoService>();
        cryptoServiceMock.Setup(cs => cs.Decrypt(It.IsAny<string>())).Returns("MySecretPassword");

        PasswordService.CryptoService = cryptoServiceMock.Object;

        // Дія
        bool result = PasswordService.Verify(password, encodedPassword);

        // Перевірка
        Assert.True(result);
    }
}
