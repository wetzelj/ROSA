using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //var mainForm = new MainForm();
            //mainForm.Show();
            //this.Hide();
            this.BackColor = this.myDefaultColor;
            MyParentForm.ContextMenuClicked("ShowActionMenu");
        }

        public void ShowAlert()
        {
            this.BackColor = Color.Red; 
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (MyParentForm != null)
            {
                MyParentForm.ContextMenuClicked(e.ClickedItem.Name);
            }
            
            //switch (e.ClickedItem.Name)
            //{
            //    case "menuItemExit":
            //        Application.Exit();
            //        break;

            //    case "menuItemOpenROSAMenu":
            //        var mainForm = new MainForm();
            //        mainForm.Show();
            //        this.Hide();
            //        break;

            //    default:
            //        break;
            //}
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