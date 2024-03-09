using System;
using System.Runtime.InteropServices;

namespace UltraShine
{
	// Token: 0x0200000A RID: 10
	public class Desktop
	{
		// Token: 0x0600001A RID: 26
		[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "FindWindowA", ExactSpelling = true, SetLastError = true)]
		private static extern int FindWindow([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpClassName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpWindowName);

		// Token: 0x0600001B RID: 27
		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

		// Token: 0x0600001C RID: 28 RVA: 0x000024B4 File Offset: 0x000006B4
		public static void DesktopIconsHide()
		{
			string text = null;
			string text2 = "Program Manager";
			IntPtr intPtr = (IntPtr)Desktop.FindWindow(ref text, ref text2);
			if (!(intPtr == (IntPtr)0))
			{
				Desktop.ShowWindow(intPtr, 0);
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000024F0 File Offset: 0x000006F0
		public static void DesktopIconsShow()
		{
			string text = null;
			string text2 = "Program Manager";
			IntPtr intPtr = (IntPtr)Desktop.FindWindow(ref text, ref text2);
			if (!(intPtr == (IntPtr)0))
			{
				Desktop.ShowWindow(intPtr, 9);
			}
		}

		// Token: 0x0400000B RID: 11
		private const int SW_HIDE = 0;

		// Token: 0x0400000C RID: 12
		private const int SW_RESTORE = 9;
	}
}
