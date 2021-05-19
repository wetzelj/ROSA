
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnuWins = new System.Windows.Forms.Button();
            this.btnClipMon = new System.Windows.Forms.Button();
            this.btnGetUsername = new System.Windows.Forms.Button();
            this.txtUsr = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTakeScreenshot = new System.Windows.Forms.Button();
            this.cmbProcs = new System.Windows.Forms.ComboBox();
            this.btnFindIMPAX = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(92, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "ROSA";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnEnuWins
            // 
            this.btnEnuWins.Location = new System.Drawing.Point(133, 152);
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
            this.btnClipMon.Location = new System.Drawing.Point(30, 210);
            this.btnClipMon.Name = "btnClipMon";
            this.btnClipMon.Size = new System.Drawing.Size(203, 31);
            this.btnClipMon.TabIndex = 3;
            this.btnClipMon.Text = "ClipMon-OFF";
            this.btnClipMon.UseVisualStyleBackColor = false;
            this.btnClipMon.Click += new System.EventHandler(this.btnClipMon_Click);
            // 
            // btnGetUsername
            // 
            this.btnGetUsername.Enabled = false;
            this.btnGetUsername.Location = new System.Drawing.Point(30, 152);
            this.btnGetUsername.Name = "btnGetUsername";
            this.btnGetUsername.Size = new System.Drawing.Size(97, 23);
            this.btnGetUsername.TabIndex = 4;
            this.btnGetUsername.Text = "Grab-TXT";
            this.btnGetUsername.UseVisualStyleBackColor = true;
            this.btnGetUsername.Click += new System.EventHandler(this.btnGetUsername_Click);
            // 
            // txtUsr
            // 
            this.txtUsr.Location = new System.Drawing.Point(133, 152);
            this.txtUsr.Name = "txtUsr";
            this.txtUsr.Size = new System.Drawing.Size(100, 23);
            this.txtUsr.TabIndex = 5;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(133, 181);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 23);
            this.txtPass.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnClose.Location = new System.Drawing.Point(235, -3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(27, 37);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTakeScreenshot
            // 
            this.btnTakeScreenshot.Enabled = false;
            this.btnTakeScreenshot.Location = new System.Drawing.Point(30, 181);
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
            this.cmbProcs.Location = new System.Drawing.Point(30, 93);
            this.cmbProcs.Name = "cmbProcs";
            this.cmbProcs.Size = new System.Drawing.Size(203, 23);
            this.cmbProcs.TabIndex = 9;
            // 
            // btnFindIMPAX
            // 
            this.btnFindIMPAX.Location = new System.Drawing.Point(30, 122);
            this.btnFindIMPAX.Name = "btnFindIMPAX";
            this.btnFindIMPAX.Size = new System.Drawing.Size(203, 23);
            this.btnFindIMPAX.TabIndex = 10;
            this.btnFindIMPAX.Text = "Find IMPAX";
            this.btnFindIMPAX.UseVisualStyleBackColor = true;
            this.btnFindIMPAX.Click += new System.EventHandler(this.btnFindIMPAX_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(77)))), ((int)(((byte)(86)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(-1, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(17, 70);
            this.button1.TabIndex = 12;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(63, 52);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 35);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(88, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "No Notifications";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Lime;
            this.pictureBox1.Location = new System.Drawing.Point(83, 277);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 18);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(263, 269);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
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
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ROSA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnEnuWins;
		private System.Windows.Forms.Button btnClipMon;
		private System.Windows.Forms.Button btnGetUsername;
		private System.Windows.Forms.TextBox txtUsr;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnTakeScreenshot;
		private System.Windows.Forms.ComboBox cmbProcs;
		private System.Windows.Forms.Button btnFindIMPAX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
    }
}