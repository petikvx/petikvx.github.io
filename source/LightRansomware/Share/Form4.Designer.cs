﻿namespace UltraShine
{
	// Token: 0x0200000E RID: 14
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class Form4 : global::System.Windows.Forms.Form
	{
		// Token: 0x0600006A RID: 106 RVA: 0x00003A38 File Offset: 0x00001C38
		[global::System.Diagnostics.DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && this.components != null)
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003A78 File Offset: 0x00001C78
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.Timer1 = new global::System.Windows.Forms.Timer(this.components);
			base.SuspendLayout();
			this.Timer1.Enabled = true;
			this.Timer1.Interval = 60000;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(10, 10);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form4";
			base.Opacity = 0.0;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.WindowState = global::System.Windows.Forms.FormWindowState.Minimized;
			base.ResumeLayout(false);
		}

		// Token: 0x04000052 RID: 82
		private global::System.ComponentModel.IContainer components;
	}
}