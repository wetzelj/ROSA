using System;
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
    public partial class StudyList : Form
    {
        ROSAEvent _ctx;

        public StudyList()
        {
            InitializeComponent();
          
        }

        private void StudyList_Load(object sender, EventArgs e)
        {
            PatientInfo_Load();
            LoadFakeStudyList();
        }

        private void PatientInfo_Load()
        {
            lblPatientID.Text = "siimRavi";
            lblPatientName.Text = "Ravi SIIM";
            lblPatientDOB.Text = "1992-02-29";
        }


        public void SetCurrentContext(ROSAEvent e)
        {
            _ctx = e;
        }

        public void RenderLoadedData(DataTable dataFromFHIR = null)
        {
            LoadFakeStudyList();
        }

        private void LoadFakeStudyList()
        {
                     

            List<string[]> list = new List<string[]>();
            //list.Add(new string[] { "StudyID", "StudyDescription", "Modality", "StudyDate" });
            list.Add(new string[] { "a123456789", "XR Chest", "XR", "2021-05-01" });
            list.Add(new string[] { "b123456789", "US Abdomen", "US", "2021-05-03" });
            list.Add(new string[] { "c987654321", "NM PET CT", "NM", "2021-05-10" });

            DataTable table = ConvertListToDataTable(list);
            table.Columns[0].ColumnName = "Study ID";
            table.Columns[1].ColumnName = "Study Description";
            table.Columns[2].ColumnName = "Modality";
            table.Columns[3].ColumnName = "Study Date";
            //table.Columns[DataGridViewColumn[1]].ColumnName = "Study ID";
            dataGridView1.DataSource = table;
            
            dataGridView1.Columns[0].MinimumWidth = 125;
            dataGridView1.Columns[1].MinimumWidth = 180;
            dataGridView1.Columns[2].MinimumWidth = 80;
            dataGridView1.Columns[3].MinimumWidth = 125;

        }

        static DataTable ConvertListToDataTable(List<string[]> list)
        {
            DataTable table = new DataTable();

            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string strStudyID;
            strStudyID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            MessageBox.Show(String.Format("StudyID: {0}", strStudyID));
            
            //launch exam
            ProcessStartInfo psInfo = new ProcessStartInfo { FileName = "https://hackathon.siim.org/vna/web-viewer/app/viewer.html?series=4dcf5369-ecd612a6-7a3063c8-97930113-7ec3903e", UseShellExecute = true };
            Process.Start(psInfo);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string strPatientID;
            strPatientID = lblPatientID.Text;
            MessageBox.Show(String.Format("PatientID: {0}", strPatientID));
        }
    }
}
