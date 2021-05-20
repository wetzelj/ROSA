using System;
using System.Drawing;
using System.Windows.Forms;

namespace RosaTEST
{
	public partial class ROSAWidget : Form
    {
        public MainForm MyParentForm;
        Color myDefaultColor;

		public ROSAWidget()
        {
            InitializeComponent();
            this.myDefaultColor = this.BackColor;
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.LawnGreen )
                MyParentForm.ContextMenuClicked("ShowActionMenu");
            else
                MyParentForm.ContextMenuClicked("OpenMainFormWithoutActions");
            //var mainForm = new MainForm();
            //mainForm.Show();
            //this.Hide();
            this.BackColor = this.myDefaultColor;
            
        }

        public void ShowAlert()
        {
            this.BackColor = Color.LawnGreen; 
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (MyParentForm != null)
            {
                MyParentForm.ContextMenuClicked(e.ClickedItem.Name);
            }
            
            
        }


		private void ROSAWidget_Shown(object sender, EventArgs e)
		{
			//frmActions = new MainForm();

			//frmActions.StartPosition = FormStartPosition.Manual;
			//frmActions.Location = frmMenuPosition;

			//frmActions.Owner = this;
			//frmActions.Visible = false;
		}

		private void ROSAWidget_FormClosing(object sender, FormClosingEventArgs e)
		{
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                //this.Visible = false;
            }
        }
	}


}