using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RosaTEST
{
    public partial class ROSAWidget : Form
    {
        public ROSAWidget()
        {
            InitializeComponent();

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ROSAWidget_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemExit_Click(object send, EventArgs e)
        {
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "menuItemExit":
                    Application.Exit();
                    break;

                case "menuItemOpenROSAMenu":
                    var mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                    break;

                default:
                    break;
            }
        }
    }
}