using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OfficeRepositary.Repositaries
{
	public class EncryptionDecryptionService
	{
		public string PasswordEncryption(string TextPassword)
		{
			// Get the bytes of the string
			byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(TextPassword);
			byte[] passwordBytes = Encoding.UTF8.GetBytes("");

			// Hash the password with SHA256
			passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

			byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

			string encryptedResult = Convert.ToBase64String(bytesEncrypted);
			return encryptedResult;
		}

		public string PasswordDecryption(string EncryptedPassword)
		{
			// Get the bytes of the string
			byte[] bytesToBeDecrypted = Convert.FromBase64String(EncryptedPassword);
			byte[] passwordBytesdecrypt = Encoding.UTF8.GetBytes("");
			passwordBytesdecrypt = SHA256.Create().ComputeHash(passwordBytesdecrypt);

			byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytesdecrypt);

			string decryptedResult = Encoding.UTF8.GetString(bytesDecrypted);

			return decryptedResult;
		}
		private byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
		{
			byte[] encryptedBytes = null;

			// Set your salt here, change it to meet your flavor:
			// The salt bytes must be at least 8 bytes.
			byte[] saltBytes = new byte[] { 2, 1, 7, 3, 6, 4, 8, 5 };

			using (MemoryStream ms = new MemoryStream())
			{
				using (RijndaelManaged AES = new RijndaelManaged())
				{
					AES.KeySize = 256;
					AES.BlockSize = 128;

					var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
					AES.Key = key.GetBytes(AES.KeySize / 8);
					AES.IV = key.GetBytes(AES.BlockSize / 8);

					AES.Mode = CipherMode.CBC;

					using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
					{
						cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
						cs.Close();
					}
					encryptedBytes = ms.ToArray();
				}
			}

			return encryptedBytes;
		}
		//Decryption
		private byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
		{
			byte[] decryptedBytes = null;

			// Set your salt here, change it to meet your flavor:
			// The salt bytes must be at least 8 bytes.
			byte[] saltBytes = new byte[] { 2, 1, 7, 3, 6, 4, 8, 5 };

			using (MemoryStream ms = new MemoryStream())
			{
				using (RijndaelManaged AES = new RijndaelManaged())
				{
					AES.KeySize = 256;
					AES.BlockSize = 128;

					var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
					AES.Key = key.GetBytes(AES.KeySize / 8);
					AES.IV = key.GetBytes(AES.BlockSize / 8);

					AES.Mode = CipherMode.CBC;

					using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
					{
						cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
						cs.Close();
					}
					decryptedBytes = ms.ToArray();
				}
			}

			return decryptedBytes;
		}
		private string base64Encode(string data)
		{
			try
			{
				byte[] encData_byte = new byte[data.Length];
				encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
				string encodedData = Convert.ToBase64String(encData_byte);
				return encodedData;
			}
			catch (Exception e)
			{
				throw new Exception("Error in base64Encode" + e.Message);
			}
		}
		private string base64Decode2(string sData)
		{
			System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
			System.Text.Decoder utf8Decode = encoder.GetDecoder();
			byte[] todecode_byte = Convert.FromBase64String(sData);
			int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
			char[] decoded_char = new char[charCount];
			utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
			string result = new String(decoded_char);
			return result;
		}
		private string Decrypt(string cipherText)
		{
			string EncryptionKey = "c5687fc88969c44d";
			byte[] cipherBytes = Convert.FromBase64String(cipherText);
			using (Aes encryptor = Aes.Create())
			{
				Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes(16);
				using (MemoryStream ms = new MemoryStream())
				{
					using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
					{
						cs.Write(cipherBytes, 0, cipherBytes.Length);
						cs.Close();
					}
					cipherText = Encoding.Unicode.GetString(ms.ToArray());
				}
			}
			return cipherText;
		}
		private string Decrypt(string cipherText, string EncryptionKey)
		{
			byte[] cipherBytes = Convert.FromBase64String(cipherText);
			using (Aes encryptor = Aes.Create())
			{
				Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes(16);
				using (MemoryStream ms = new MemoryStream())
				{
					using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
					{
						cs.Write(cipherBytes, 0, cipherBytes.Length);
						cs.Close();
					}
					cipherText = Encoding.Unicode.GetString(ms.ToArray());
				}
			}
			return cipherText;
		}
		private string base64Decode(string sData) //Decode    
		{
			try
			{
				var encoder = new System.Text.UTF8Encoding();
				System.Text.Decoder utf8Decode = encoder.GetDecoder();
				byte[] todecodeByte = Convert.FromBase64String(sData);
				int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
				char[] decodedChar = new char[charCount];
				utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
				string result = new String(decodedChar);

				return result;
			}
			catch (Exception ex)
			{
				throw new Exception("Error in base64Decode" + ex.Message);
			}
		}
	}
}
