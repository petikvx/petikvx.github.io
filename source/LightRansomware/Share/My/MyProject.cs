using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace UltraShine.My
{
	// Token: 0x02000004 RID: 4
	[StandardModule]
	[HideModuleName]
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	internal sealed class MyProject
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020DA File Offset: 0x000002DA
		[HelpKeyword("My.Computer")]
		internal static MyComputer Computer
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_ComputerObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020E6 File Offset: 0x000002E6
		[HelpKeyword("My.Application")]
		internal static MyApplication Application
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_AppObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020F2 File Offset: 0x000002F2
		[HelpKeyword("My.User")]
		internal static User User
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_UserObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020FE File Offset: 0x000002FE
		[HelpKeyword("My.Forms")]
		internal static MyProject.MyForms Forms
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyFormsObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000210A File Offset: 0x0000030A
		[HelpKeyword("My.WebServices")]
		internal static MyProject.MyWebServices WebServices
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyWebServicesObjectProvider.GetInstance;
			}
		}

		// Token: 0x04000001 RID: 1
		private static readonly MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();

		// Token: 0x04000002 RID: 2
		private static readonly MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();

		// Token: 0x04000003 RID: 3
		private static readonly MyProject.ThreadSafeObjectProvider<User> m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<User>();

		// Token: 0x04000004 RID: 4
		private static MyProject.ThreadSafeObjectProvider<MyProject.MyForms> m_MyFormsObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyForms>();

		// Token: 0x04000005 RID: 5
		private static readonly MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();

		// Token: 0x0200000F RID: 15
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
		internal sealed class MyForms
		{
			// Token: 0x0600009F RID: 159 RVA: 0x00005324 File Offset: 0x00003524
			[DebuggerHidden]
			private static T Create__Instance__<T>(T Instance) where T : Form, new()
			{
				if (Instance == null || Instance.IsDisposed)
				{
					if (MyProject.MyForms.m_FormBeingCreated != null)
					{
						if (MyProject.MyForms.m_FormBeingCreated.ContainsKey(typeof(T)))
						{
							throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
						}
					}
					else
					{
						MyProject.MyForms.m_FormBeingCreated = new Hashtable();
					}
					MyProject.MyForms.m_FormBeingCreated.Add(typeof(T), null);
					try
					{
						return new T();
					}
					catch (TargetInvocationException ex) when (ex.InnerException != null)
					{
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", new string[] { ex.InnerException.Message }), ex.InnerException);
					}
					finally
					{
						MyProject.MyForms.m_FormBeingCreated.Remove(typeof(T));
					}
				}
				return Instance;
			}

			// Token: 0x060000A0 RID: 160 RVA: 0x00005428 File Offset: 0x00003628
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance) where T : Form
			{
				instance.Dispose();
				instance = default(T);
			}

			// Token: 0x060000A1 RID: 161 RVA: 0x0000222B File Offset: 0x0000042B
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyForms()
			{
			}

			// Token: 0x060000A2 RID: 162 RVA: 0x0000543D File Offset: 0x0000363D
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x060000A3 RID: 163 RVA: 0x0000544B File Offset: 0x0000364B
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x060000A4 RID: 164 RVA: 0x00005453 File Offset: 0x00003653
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyProject.MyForms);
			}

			// Token: 0x060000A5 RID: 165 RVA: 0x0000545F File Offset: 0x0000365F
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x060000A6 RID: 166 RVA: 0x00005467 File Offset: 0x00003667
			// (set) Token: 0x060000AA RID: 170 RVA: 0x000054CB File Offset: 0x000036CB
			public Form1 Form1
			{
				get
				{
					this.m_Form1 = MyProject.MyForms.Create__Instance__<Form1>(this.m_Form1);
					return this.m_Form1;
				}
				set
				{
					if (value != this.m_Form1)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<Form1>(ref this.m_Form1);
					}
				}
			}

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x060000A7 RID: 167 RVA: 0x00005480 File Offset: 0x00003680
			// (set) Token: 0x060000AB RID: 171 RVA: 0x000054F0 File Offset: 0x000036F0
			public Form2 Form2
			{
				get
				{
					this.m_Form2 = MyProject.MyForms.Create__Instance__<Form2>(this.m_Form2);
					return this.m_Form2;
				}
				set
				{
					if (value != this.m_Form2)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<Form2>(ref this.m_Form2);
					}
				}
			}

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x060000A8 RID: 168 RVA: 0x00005499 File Offset: 0x00003699
			// (set) Token: 0x060000AC RID: 172 RVA: 0x00005515 File Offset: 0x00003715
			public Form3 Form3
			{
				get
				{
					this.m_Form3 = MyProject.MyForms.Create__Instance__<Form3>(this.m_Form3);
					return this.m_Form3;
				}
				set
				{
					if (value != this.m_Form3)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<Form3>(ref this.m_Form3);
					}
				}
			}

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x060000A9 RID: 169 RVA: 0x000054B2 File Offset: 0x000036B2
			// (set) Token: 0x060000AD RID: 173 RVA: 0x0000553A File Offset: 0x0000373A
			public Form4 Form4
			{
				get
				{
					this.m_Form4 = MyProject.MyForms.Create__Instance__<Form4>(this.m_Form4);
					return this.m_Form4;
				}
				set
				{
					if (value != this.m_Form4)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<Form4>(ref this.m_Form4);
					}
				}
			}

			// Token: 0x04000063 RID: 99
			[ThreadStatic]
			private static Hashtable m_FormBeingCreated;

			// Token: 0x04000064 RID: 100
			[EditorBrowsable(EditorBrowsableState.Never)]
			public Form1 m_Form1;

			// Token: 0x04000065 RID: 101
			[EditorBrowsable(EditorBrowsableState.Never)]
			public Form2 m_Form2;

			// Token: 0x04000066 RID: 102
			[EditorBrowsable(EditorBrowsableState.Never)]
			public Form3 m_Form3;

			// Token: 0x04000067 RID: 103
			[EditorBrowsable(EditorBrowsableState.Never)]
			public Form4 m_Form4;
		}

		// Token: 0x02000010 RID: 16
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
		internal sealed class MyWebServices
		{
			// Token: 0x060000AE RID: 174 RVA: 0x0000543D File Offset: 0x0000363D
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x060000AF RID: 175 RVA: 0x0000544B File Offset: 0x0000364B
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x060000B0 RID: 176 RVA: 0x0000555F File Offset: 0x0000375F
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			internal new Type GetType()
			{
				return typeof(MyProject.MyWebServices);
			}

			// Token: 0x060000B1 RID: 177 RVA: 0x0000545F File Offset: 0x0000365F
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x060000B2 RID: 178 RVA: 0x0000556C File Offset: 0x0000376C
			[DebuggerHidden]
			private static T Create__Instance__<T>(T instance) where T : new()
			{
				T t;
				if (instance == null)
				{
					t = new T();
				}
				else
				{
					t = instance;
				}
				return t;
			}

			// Token: 0x060000B3 RID: 179 RVA: 0x0000558C File Offset: 0x0000378C
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance)
			{
				instance = default(T);
			}

			// Token: 0x060000B4 RID: 180 RVA: 0x0000222B File Offset: 0x0000042B
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyWebServices()
			{
			}
		}

		// Token: 0x02000011 RID: 17
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		internal sealed class ThreadSafeObjectProvider<T> where T : new()
		{
			// Token: 0x1700001E RID: 30
			// (get) Token: 0x060000B5 RID: 181 RVA: 0x00005595 File Offset: 0x00003795
			internal T GetInstance
			{
				[DebuggerHidden]
				get
				{
					if (MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null)
					{
						MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = new T();
					}
					return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
				}
			}

			// Token: 0x060000B6 RID: 182 RVA: 0x0000222B File Offset: 0x0000042B
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ThreadSafeObjectProvider()
			{
			}

			// Token: 0x04000068 RID: 104
			[CompilerGenerated]
			[ThreadStatic]
			private static T m_ThreadStaticValue;
		}
	}
}
