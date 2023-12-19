using System.Security.Cryptography;
using Presentation.Services;

public class PasswordService
{
    public static CryptoService CryptoService { get; set; }
    private static int SaltSize { get; set; } = 3;
	private static string Delimiter { get; set; } = "3__3__3";
	public static string EncodePassword(string password)
	{
		var salt = RandomNumberGenerator.GetBytes(SaltSize);
		string encoded = CryptoService.Encrypt(password);

		return string.Join(string.Empty, salt) + Delimiter + encoded;
	}

	public static bool Verify(string password, string encodedPassword)
	{
		try
		{
			string encoded = encodedPassword.Split(Delimiter)[1];
			string decoded = DecodePassword(encoded)!;
			return password == decoded;
		}
		catch
		{
			return false;
		}
	}

	private static string? DecodePassword(string decodedPassword)
	{
		try
		{
			return CryptoService.Decrypt(decodedPassword);
		}
		catch
		{
			return null;
		}
	}
}