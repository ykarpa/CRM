using System;
using Presentation.Services;
using Xunit;

public class CryptoServiceTests
{
    [Fact]
    public void Encrypt_ShouldEncryptData()
    {
        // Arrange
        string data = "HelloWorld";
        var cryptoService = new CryptoService();

        // Act
        string encryptedData = cryptoService.Encrypt(data);

        // Assert
        Assert.NotNull(encryptedData);
        Assert.NotEqual(data, encryptedData);
    }

    [Fact]
    public void Decrypt_ShouldDecryptData()
    {
        // Arrange
        string data = "HelloWorld";
        var cryptoService = new CryptoService();
        string encryptedData = cryptoService.Encrypt(data);

        // Act
        string decryptedData = cryptoService.Decrypt(encryptedData);

        // Assert
        Assert.NotNull(decryptedData);
        Assert.Equal(data, decryptedData);
    }
}
