using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace UltraShine
{
	// Token: 0x02000008 RID: 8
	public class AES
	{
		// Token: 0x02000012 RID: 18
		public class AES
		{
			// Token: 0x060000B7 RID: 183 RVA: 0x0000222B File Offset: 0x0000042B
			[DebuggerNonUserCode]
			public AES()
			{
			}

			// Token: 0x060000B8 RID: 184 RVA: 0x000055B2 File Offset: 0x000037B2
			public static byte[] decrypt(byte[] byte_ciphertext, byte[] key)
			{
				return new RijndaelManaged
				{
					KeySize = 128
				}.CreateDecryptor(key, key).TransformFinalBlock(byte_ciphertext, 0, byte_ciphertext.Length);
			}

			// Token: 0x060000B9 RID: 185 RVA: 0x000055D5 File Offset: 0x000037D5
			public static byte[] encrypt(byte[] data, byte[] key)
			{
				return new RijndaelManaged
				{
					KeySize = 128
				}.CreateEncryptor(key, key).TransformFinalBlock(data, 0, data.Length);
			}

			// Token: 0x060000BA RID: 186 RVA: 0x000055F8 File Offset: 0x000037F8
			public static byte[] generateKey()
			{
				RijndaelManaged rijndaelManaged = new RijndaelManaged();
				rijndaelManaged.KeySize = 128;
				rijndaelManaged.GenerateKey();
				return rijndaelManaged.Key;
			}
		}
	}
}
