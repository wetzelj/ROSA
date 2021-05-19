﻿
namespace RosaTEST
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnEnuWins = new System.Windows.Forms.Button();
			this.btnClipMon = new System.Windows.Forms.Button();
			this.btnGetUsername = new System.Windows.Forms.Button();
			this.txtUsr = new System.Windows.Forms.TextBox();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnTakeScreenshot = new System.Windows.Forms.Button();
			this.cmbProcs = new System.Windows.Forms.ComboBox();
			this.btnFindIMPAX = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label1.Location = new System.Drawing.Point(47, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(161, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hi, I\'m ROSA";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label2.Location = new System.Drawing.Point(32, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(199, 30);
			this.label2.TabIndex = 1;
			this.label2.Text = "I\'ll be your Assistant";
			// 
			// btnEnuWins
			// 
			this.btnEnuWins.Location = new System.Drawing.Point(5, 245);
			this.btnEnuWins.Name = "btnEnuWins";
			this.btnEnuWins.Size = new System.Drawing.Size(100, 23);
			this.btnEnuWins.TabIndex = 2;
			this.btnEnuWins.Text = "EnumW";
			this.btnEnuWins.UseVisualStyleBackColor = true;
			this.btnEnuWins.Click += new System.EventHandler(this.btnEnuWins_Click);
			// 
			// btnClipMon
			// 
			this.btnClipMon.BackColor = System.Drawing.Color.DarkOrange;
			this.btnClipMon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnClipMon.Location = new System.Drawing.Point(56, 74);
			this.btnClipMon.Name = "btnClipMon";
			this.btnClipMon.Size = new System.Drawing.Size(140, 37);
			this.btnClipMon.TabIndex = 3;
			this.btnClipMon.Text = "ClipMon-OFF";
			this.btnClipMon.UseVisualStyleBackColor = false;
			this.btnClipMon.Click += new System.EventHandler(this.btnClipMon_Click);
			// 
			// btnGetUsername
			// 
			this.btnGetUsername.Enabled = false;
			this.btnGetUsername.Location = new System.Drawing.Point(32, 187);
			this.btnGetUsername.Name = "btnGetUsername";
			this.btnGetUsername.Size = new System.Drawing.Size(100, 23);
			this.btnGetUsername.TabIndex = 4;
			this.btnGetUsername.Text = "Grab-TXT";
			this.btnGetUsername.UseVisualStyleBackColor = true;
			this.btnGetUsername.Click += new System.EventHandler(this.btnGetUsername_Click);
			// 
			// txtUsr
			// 
			this.txtUsr.Location = new System.Drawing.Point(138, 187);
			this.txtUsr.Name = "txtUsr";
			this.txtUsr.Size = new System.Drawing.Size(100, 23);
			this.txtUsr.TabIndex = 5;
			// 
			// txtPass
			// 
			this.txtPass.Location = new System.Drawing.Point(138, 216);
			this.txtPass.Name = "txtPass";
			this.txtPass.Size = new System.Drawing.Size(100, 23);
			this.txtPass.TabIndex = 6;
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.Black;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnClose.ForeColor = System.Drawing.Color.White;
			this.btnClose.Location = new System.Drawing.Point(235, 9);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(28, 32);
			this.btnClose.TabIndex = 7;
			this.btnClose.Text = "x";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnTakeScreenshot
			// 
			this.btnTakeScreenshot.Enabled = false;
			this.btnTakeScreenshot.Location = new System.Drawing.Point(35, 216);
			this.btnTakeScreenshot.Name = "btnTakeScreenshot";
			this.btnTakeScreenshot.Size = new System.Drawing.Size(97, 23);
			this.btnTakeScreenshot.TabIndex = 8;
			this.btnTakeScreenshot.Text = "Screenshot";
			this.btnTakeScreenshot.UseVisualStyleBackColor = true;
			this.btnTakeScreenshot.Click += new System.EventHandler(this.btnTakeScreenshot_Click);
			// 
			// cmbProcs
			// 
			this.cmbProcs.FormattingEnabled = true;
			this.cmbProcs.Location = new System.Drawing.Point(5, 128);
			this.cmbProcs.Name = "cmbProcs";
			this.cmbProcs.Size = new System.Drawing.Size(246, 23);
			this.cmbProcs.TabIndex = 9;
			// 
			// btnFindIMPAX
			// 
			this.btnFindIMPAX.Location = new System.Drawing.Point(32, 157);
			this.btnFindIMPAX.Name = "btnFindIMPAX";
			this.btnFindIMPAX.Size = new System.Drawing.Size(206, 23);
			this.btnFindIMPAX.TabIndex = 10;
			this.btnFindIMPAX.Text = "Find IMPAX";
			this.btnFindIMPAX.UseVisualStyleBackColor = true;
			this.btnFindIMPAX.Click += new System.EventHandler(this.btnFindIMPAX_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Lime;
			this.pictureBox1.Location = new System.Drawing.Point(73, 252);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 50);
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(263, 269);
			this.Controls.Add(this.btnEnuWins);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnFindIMPAX);
			this.Controls.Add(this.cmbProcs);
			this.Controls.Add(this.btnTakeScreenshot);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.txtPass);
			this.Controls.Add(this.txtUsr);
			this.Controls.Add(this.btnGetUsername);
			this.Controls.Add(this.btnClipMon);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ROSA";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnEnuWins;
		private System.Windows.Forms.Button btnClipMon;
		private System.Windows.Forms.Button btnGetUsername;
		private System.Windows.Forms.TextBox txtUsr;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnTakeScreenshot;
		private System.Windows.Forms.ComboBox cmbProcs;
		private System.Windows.Forms.Button btnFindIMPAX;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}