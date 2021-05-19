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
    public partial class StudyList : Form
    {
        public StudyList()
        {
            InitializeComponent();
            PatientInfo_Load();
            StudyList_Load();
        }

        private void PatientInfo_Load()
        {
            lblPatientID.Text = "siimRavi";
            lblPatientName.Text = "Ravi SIIM";
            lblPatientDOB.Text = "1992-02-29";
        }


        private void StudyList_Load()
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
            dataGridView1.Columns[0].MinimumWidth = 100;
            dataGridView1.Columns[1].MinimumWidth = 150;
            dataGridView1.Columns[2].MinimumWidth = 100;
            dataGridView1.Columns[3].MinimumWidth = 100;

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

        }
    }
}
