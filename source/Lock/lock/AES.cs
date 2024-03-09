using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace ShellLocker
{
	// Token: 0x02000008 RID: 8
	public class AES
	{
		// Token: 0x02000012 RID: 18
		public class AES
		{
			// Token: 0x060000B5 RID: 181 RVA: 0x00002213 File Offset: 0x00000413
			[DebuggerNonUserCode]
			public AES()
			{
			}

			// Token: 0x060000B6 RID: 182 RVA: 0x00005276 File Offset: 0x00003476
			public static byte[] decrypt(byte[] byte_ciphertext, byte[] key)
			{
				return new RijndaelManaged
				{
					KeySize = 128
				}.CreateDecryptor(key, key).TransformFinalBlock(byte_ciphertext, 0, byte_ciphertext.Length);
			}

			// Token: 0x060000B7 RID: 183 RVA: 0x00005299 File Offset: 0x00003499
			public static byte[] encrypt(byte[] data, byte[] key)
			{
				return new RijndaelManaged
				{
					KeySize = 128
				}.CreateEncryptor(key, key).TransformFinalBlock(data, 0, data.Length);
			}

			// Token: 0x060000B8 RID: 184 RVA: 0x000052BC File Offset: 0x000034BC
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
