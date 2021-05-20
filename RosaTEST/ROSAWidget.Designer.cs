
namespace RosaTEST
{
    partial class ROSAWidget
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ROSAWidget));
			this.pictureBoxROSA = new System.Windows.Forms.PictureBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemOpenROSAMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxROSA)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxROSA
			// 
			this.pictureBoxROSA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
			this.pictureBoxROSA.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxROSA.Image")));
			this.pictureBoxROSA.Location = new System.Drawing.Point(32, 15);
			this.pictureBoxROSA.Name = "pictureBoxROSA";
			this.pictureBoxROSA.Size = new System.Drawing.Size(72, 72);
			this.pictureBoxROSA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxROSA.TabIndex = 0;
			this.pictureBoxROSA.TabStop = false;
			this.pictureBoxROSA.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpenROSAMenu,
            this.menuItemExit});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(171, 48);
			this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
			// 
			// menuItemOpenROSAMenu
			// 
			this.menuItemOpenROSAMenu.Name = "menuItemOpenROSAMenu";
			this.menuItemOpenROSAMenu.Size = new System.Drawing.Size(170, 22);
			this.menuItemOpenROSAMenu.Text = "Open ROSA Menu";
			// 
			// menuItemExit
			// 
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.Size = new System.Drawing.Size(170, 22);
			this.menuItemExit.Text = "Exit App";
			// 
			// ROSAWidget
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
			this.ClientSize = new System.Drawing.Size(107, 103);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.pictureBoxROSA);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ROSAWidget";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ROSA";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ROSAWidget_FormClosing);
			this.Shown += new System.EventHandler(this.ROSAWidget_Shown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxROSA)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxROSA;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenROSAMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
    }
}