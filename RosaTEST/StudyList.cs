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
        }

        private void StudyList_Load()
        {
            List<string[]> list = new List<string[]>();
            list.Add(new string[] { "StudyID", "StudyDescription", "Modality", "StudyDate" });
            list.Add(new string[] { "a123456789", "XR Chest", "XR", "2021-05-01" });
            list.Add(new string[] { "b123456789", "US Abdomen", "US", "2021-05-03" });

            DataTable table = ConvertListToDataTable(list);
            dataGridView1.DataSource = table;
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
    }
}
