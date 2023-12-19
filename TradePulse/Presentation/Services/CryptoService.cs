using System;
using System.Text;

namespace Presentation.Services
{
	public class CryptoService
	{
		public virtual string Encrypt(string data)
		{
			byte[] passwordBytes = Encoding.UTF8.GetBytes(data);
			return Convert.ToBase64String(passwordBytes);
		}
		public virtual string Decrypt(string decodedData)
		{
			byte[] encodedBytes = Convert.FromBase64String(decodedData);
			return Encoding.UTF8.GetString(encodedBytes);
		}
	}
}
