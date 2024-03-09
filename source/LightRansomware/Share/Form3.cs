using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace UltraShine
{
	// Token: 0x0200000D RID: 13
	[DesignerGenerated]
	public partial class Form3 : Form
	{
		// Token: 0x06000061 RID: 97
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SetWindowsHookEx(int id, Form3.LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);

		// Token: 0x06000062 RID: 98
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool UnhookWindowsHookEx(IntPtr hook);

		// Token: 0x06000063 RID: 99
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);

		// Token: 0x06000064 RID: 100
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string name);

		// Token: 0x06000065 RID: 101
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern short GetAsyncKeyState(Keys key);

		// Token: 0x06000066 RID: 102 RVA: 0x000038BC File Offset: 0x00001ABC
		public Form3()
		{
			base.Load += this.Form3_Load;
			try
			{
				ProcessModule mainModule = Process.GetCurrentProcess().MainModule;
				this.objKeyboardProcess = new Form3.LowLevelKeyboardProc(this.captureKey);
				this.ptrHook = Form3.SetWindowsHookEx(13, this.objKeyboardProcess, Form3.GetModuleHandle(mainModule.ModuleName), 0U);
				this.InitializeComponent();
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003944 File Offset: 0x00001B44
		private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
		{
			IntPtr intPtr;
			try
			{
				if (nCode >= 0)
				{
					Form3.KBDLLHOOKSTRUCT kbdllhookstruct = (Form3.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(Form3.KBDLLHOOKSTRUCT));
					if (kbdllhookstruct.key == Keys.RWin || kbdllhookstruct.key == Keys.LWin)
					{
						return (IntPtr)1;
					}
					if (kbdllhookstruct.key == Keys.ControlKey || kbdllhookstruct.key == Keys.Escape)
					{
						return (IntPtr)1;
					}
					if (kbdllhookstruct.key == Keys.ControlKey || kbdllhookstruct.key == Keys.Down)
					{
						return (IntPtr)1;
					}
					if (kbdllhookstruct.key == Keys.Alt || kbdllhookstruct.key == Keys.Tab)
					{
						return (IntPtr)1;
					}
					if (kbdllhookstruct.key == Keys.F2)
					{
						return (IntPtr)1;
					}
				}
				intPtr = Form3.CallNextHookEx(this.ptrHook, nCode, wp, lp);
			}
			catch (Exception ex)
			{
			}
			return intPtr;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000371C File Offset: 0x0000191C
		private void Form3_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x04000050 RID: 80
		private IntPtr ptrHook;

		// Token: 0x04000051 RID: 81
		private Form3.LowLevelKeyboardProc objKeyboardProcess;

		// Token: 0x02000015 RID: 21
		private struct KBDLLHOOKSTRUCT
		{
			// Token: 0x0400006E RID: 110
			public Keys key;

			// Token: 0x0400006F RID: 111
			public int scanCode;

			// Token: 0x04000070 RID: 112
			public int flags;

			// Token: 0x04000071 RID: 113
			public int time;

			// Token: 0x04000072 RID: 114
			public IntPtr extra;
		}

		// Token: 0x02000016 RID: 22
		// (Invoke) Token: 0x060000C2 RID: 194
		private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
	}
}
