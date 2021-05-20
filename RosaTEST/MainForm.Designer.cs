
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEnuWins = new System.Windows.Forms.Button();
			this.btnClipMon = new System.Windows.Forms.Button();
			this.btnGetUsername = new System.Windows.Forms.Button();
			this.txtUsr = new System.Windows.Forms.TextBox();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.btnTakeScreenshot = new System.Windows.Forms.Button();
			this.cmbProcs = new System.Windows.Forms.ComboBox();
			this.btnFindIMPAX = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.settings = new System.Windows.Forms.ToolStripMenuItem();
			this.exit = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label1.Location = new System.Drawing.Point(82, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "R O S A";
			// 
			// btnEnuWins
			// 
			this.btnEnuWins.Location = new System.Drawing.Point(138, 309);
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
			this.btnClipMon.Location = new System.Drawing.Point(35, 367);
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
			this.btnGetUsername.Location = new System.Drawing.Point(35, 309);
			this.btnGetUsername.Name = "btnGetUsername";
			this.btnGetUsername.Size = new System.Drawing.Size(97, 23);
			this.btnGetUsername.TabIndex = 4;
			this.btnGetUsername.Text = "Grab-TXT";
			this.btnGetUsername.UseVisualStyleBackColor = true;
			this.btnGetUsername.Click += new System.EventHandler(this.btnGetUsername_Click);
			// 
			// txtUsr
			// 
			this.txtUsr.Location = new System.Drawing.Point(86, 442);
			this.txtUsr.Name = "txtUsr";
			this.txtUsr.Size = new System.Drawing.Size(100, 23);
			this.txtUsr.TabIndex = 5;
			// 
			// txtPass
			// 
			this.txtPass.Location = new System.Drawing.Point(138, 338);
			this.txtPass.Name = "txtPass";
			this.txtPass.Size = new System.Drawing.Size(100, 23);
			this.txtPass.TabIndex = 6;
			// 
			// btnTakeScreenshot
			// 
			this.btnTakeScreenshot.Enabled = false;
			this.btnTakeScreenshot.Location = new System.Drawing.Point(35, 338);
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
			this.cmbProcs.Location = new System.Drawing.Point(35, 250);
			this.cmbProcs.Name = "cmbProcs";
			this.cmbProcs.Size = new System.Drawing.Size(203, 23);
			this.cmbProcs.TabIndex = 9;
			// 
			// btnFindIMPAX
			// 
			this.btnFindIMPAX.Location = new System.Drawing.Point(35, 279);
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
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.button1.ForeColor = System.Drawing.Color.Transparent;
			this.button1.Location = new System.Drawing.Point(-1, 88);
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
			this.pictureBox2.Location = new System.Drawing.Point(59, 111);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(27, 30);
			this.pictureBox2.TabIndex = 13;
			this.pictureBox2.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.label2.Location = new System.Drawing.Point(86, 113);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(118, 20);
			this.label2.TabIndex = 14;
			this.label2.Text = "No Notifications";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Lime;
			this.pictureBox1.Location = new System.Drawing.Point(86, 418);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 18);
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
			this.pictureBox4.Location = new System.Drawing.Point(229, 6);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(31, 29);
			this.pictureBox4.TabIndex = 17;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settings,
            this.exit});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(118, 48);
			this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
			// 
			// settings
			// 
			this.settings.Name = "settings";
			this.settings.Size = new System.Drawing.Size(117, 22);
			this.settings.Text = "Settings";
			// 
			// exit
			// 
			this.exit.Name = "exit";
			this.exit.Size = new System.Drawing.Size(117, 22);
			this.exit.Text = "Exit App";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
			this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ColumnHeadersVisible = false;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
			this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowFrame;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dataGridView1.Location = new System.Drawing.Point(22, 49);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowHeadersWidth = 40;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(84)))), ((int)(((byte)(96)))));
			this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.RowTemplate.Height = 50;
			this.dataGridView1.RowTemplate.ReadOnly = true;
			this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridView1.ShowCellErrors = false;
			this.dataGridView1.ShowCellToolTips = false;
			this.dataGridView1.ShowEditingIcon = false;
			this.dataGridView1.ShowRowErrors = false;
			this.dataGridView1.Size = new System.Drawing.Size(219, 185);
			this.dataGridView1.TabIndex = 18;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Column1";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
			this.ClientSize = new System.Drawing.Size(263, 246);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.pictureBox4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnEnuWins);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnFindIMPAX);
			this.Controls.Add(this.cmbProcs);
			this.Controls.Add(this.btnTakeScreenshot);
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
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
		private System.Windows.Forms.Button btnTakeScreenshot;
		private System.Windows.Forms.ComboBox cmbProcs;
		private System.Windows.Forms.Button btnFindIMPAX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripMenuItem settings;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}