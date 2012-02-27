namespace Launcher
{
	partial class Launcher
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.fov = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.res = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.fullscreen = new System.Windows.Forms.CheckBox();
			this.vsync = new System.Windows.Forms.CheckBox();
			this.multi = new System.Windows.Forms.CheckBox();
			this.mipmaps = new System.Windows.Forms.CheckBox();
			this.force = new System.Windows.Forms.CheckBox();
			this.af = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.fovvalue = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.fov)).BeginInit();
			this.SuspendLayout();
			// 
			// fov
			// 
			this.fov.Location = new System.Drawing.Point(122, 234);
			this.fov.Name = "fov";
			this.fov.Size = new System.Drawing.Size(162, 45);
			this.fov.TabIndex = 0;
			this.fov.TickStyle = System.Windows.Forms.TickStyle.None;
			this.fov.Value = 5;
			this.fov.ValueChanged += new System.EventHandler(this.UpdateFOV);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 234);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "FOV";
			// 
			// res
			// 
			this.res.FormattingEnabled = true;
			this.res.Items.AddRange(new object[] {
            "800x600",
            "1024x768",
            "1280x920",
            "1600x900",
            "1920x1080"});
			this.res.Location = new System.Drawing.Point(122, 170);
			this.res.Name = "res";
			this.res.Size = new System.Drawing.Size(111, 21);
			this.res.TabIndex = 2;
			this.res.Text = "1600x900";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 168);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Resolution";
			// 
			// fullscreen
			// 
			this.fullscreen.AutoSize = true;
			this.fullscreen.Location = new System.Drawing.Point(12, 127);
			this.fullscreen.Name = "fullscreen";
			this.fullscreen.Size = new System.Drawing.Size(80, 17);
			this.fullscreen.TabIndex = 4;
			this.fullscreen.Text = "Fullscreen?";
			this.fullscreen.UseVisualStyleBackColor = true;
			// 
			// vsync
			// 
			this.vsync.AutoSize = true;
			this.vsync.Checked = true;
			this.vsync.CheckState = System.Windows.Forms.CheckState.Checked;
			this.vsync.Location = new System.Drawing.Point(12, 104);
			this.vsync.Name = "vsync";
			this.vsync.Size = new System.Drawing.Size(63, 17);
			this.vsync.TabIndex = 5;
			this.vsync.Text = "VSync?";
			this.vsync.UseVisualStyleBackColor = true;
			// 
			// multi
			// 
			this.multi.AutoSize = true;
			this.multi.Checked = true;
			this.multi.CheckState = System.Windows.Forms.CheckState.Checked;
			this.multi.Location = new System.Drawing.Point(12, 81);
			this.multi.Name = "multi";
			this.multi.Size = new System.Drawing.Size(97, 17);
			this.multi.TabIndex = 6;
			this.multi.Text = "MultiSampling?";
			this.multi.UseVisualStyleBackColor = true;
			// 
			// mipmaps
			// 
			this.mipmaps.AutoSize = true;
			this.mipmaps.Checked = true;
			this.mipmaps.CheckState = System.Windows.Forms.CheckState.Checked;
			this.mipmaps.Location = new System.Drawing.Point(12, 58);
			this.mipmaps.Name = "mipmaps";
			this.mipmaps.Size = new System.Drawing.Size(96, 17);
			this.mipmaps.TabIndex = 7;
			this.mipmaps.Text = "Use Mipmaps?";
			this.mipmaps.UseVisualStyleBackColor = true;
			// 
			// force
			// 
			this.force.AutoSize = true;
			this.force.Checked = true;
			this.force.CheckState = System.Windows.Forms.CheckState.Checked;
			this.force.Location = new System.Drawing.Point(12, 35);
			this.force.Name = "force";
			this.force.Size = new System.Drawing.Size(91, 17);
			this.force.TabIndex = 8;
			this.force.Text = "Force 60 fps?";
			this.force.UseVisualStyleBackColor = true;
			// 
			// af
			// 
			this.af.AutoSize = true;
			this.af.Checked = true;
			this.af.CheckState = System.Windows.Forms.CheckState.Checked;
			this.af.Location = new System.Drawing.Point(12, 12);
			this.af.Name = "af";
			this.af.Size = new System.Drawing.Size(123, 17);
			this.af.TabIndex = 9;
			this.af.Text = "Anisotropic Filtering?";
			this.af.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(86, 304);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(158, 53);
			this.button1.TabIndex = 10;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.AutoSize = true;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(303, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(30, 30);
			this.button2.TabIndex = 11;
			this.button2.Text = "X";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// fovvalue
			// 
			this.fovvalue.AutoSize = true;
			this.fovvalue.Location = new System.Drawing.Point(195, 257);
			this.fovvalue.Name = "fovvalue";
			this.fovvalue.Size = new System.Drawing.Size(19, 13);
			this.fovvalue.TabIndex = 12;
			this.fovvalue.Text = "90";
			// 
			// Launcher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(345, 369);
			this.ControlBox = false;
			this.Controls.Add(this.fovvalue);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.af);
			this.Controls.Add(this.force);
			this.Controls.Add(this.mipmaps);
			this.Controls.Add(this.multi);
			this.Controls.Add(this.vsync);
			this.Controls.Add(this.fullscreen);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.res);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.fov);
			this.Name = "Launcher";
			this.Text = "Aren: Rise of the North  DEBUG";
			((System.ComponentModel.ISupportInitialize)(this.fov)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar fov;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox res;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox fullscreen;
		private System.Windows.Forms.CheckBox vsync;
		private System.Windows.Forms.CheckBox multi;
		private System.Windows.Forms.CheckBox mipmaps;
		private System.Windows.Forms.CheckBox force;
		private System.Windows.Forms.CheckBox af;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label fovvalue;
	}
}

