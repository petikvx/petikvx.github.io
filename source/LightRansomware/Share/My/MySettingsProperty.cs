using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace UltraShine.My
{
	// Token: 0x02000007 RID: 7
	[StandardModule]
	[HideModuleName]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal sealed class MySettingsProperty
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002224 File Offset: 0x00000424
		[HelpKeyword("My.Settings")]
		internal static MySettings Settings
		{
			get
			{
				return MySettings.Default;
			}
		}
	}
}
