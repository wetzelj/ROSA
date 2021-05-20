using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using FHIRService.Application.Services.FHIR;
using Hl7.Fhir.Model;
using System.Linq;
using System.Runtime.InteropServices;

namespace RosaTEST
{
    public partial class StudyList : Form
    {
        ROSAEvent _ctx;

        public StudyList()
        {                     
            InitializeComponent();          
        }

        private void PatientInfo_Load()
        {
            FHIRDataService svc = new FHIRDataService();
            Patient pat = new Patient();
            pat = svc.GetPatientByID(_ctx.PatientID);
            lblPatientID.Text = pat.Id;
            lblPatientName.Text = pat.Name[0].ToString();
            lblPatientDOB.Text = pat.BirthDate.ToString();
        }


        public void SetCurrentContext(ROSAEvent e)
        {
            _ctx = e;
        }

        public void RenderLoadedData()
        {
            PatientInfo_Load();
            LoadStudyList();
        }

        private void LoadStudyList()
        {
            FHIRDataService svc = new FHIRDataService();
            List<string[]> list = new List<string[]>();

            var studies = svc.GetImagingStudiesByPatientID(_ctx.PatientID);

            foreach (var study in studies)
            {
                var lengthSUID = study.Identifier[0].Value.ToString().Length - 8;
                var StudyUID = study.Identifier[0].Value.ToString().Substring(8, lengthSUID);
                list.Add(new string[] { study.Id, study.Description, study.Series.FirstOrDefault().Modality.Code.ToString(), study.Started, study.NumberOfInstances.ToString(),
                       StudyUID });
                
            }

            DataTable table = ConvertListToDataTable(list);

            table.Columns[0].ColumnName = "Study ID";
            table.Columns[1].ColumnName = "Study Description";
            table.Columns[2].ColumnName = "Modality";
            table.Columns[3].ColumnName = "Study Date";
            table.Columns[4].ColumnName = "# Images";
            
            dataGridView1.DataSource = table;
            
            dataGridView1.Columns[0].MinimumWidth = 125;
            dataGridView1.Columns[1].MinimumWidth = 180;
            dataGridView1.Columns[2].MinimumWidth = 80;
            dataGridView1.Columns[3].MinimumWidth = 125;
            dataGridView1.Columns[4].MinimumWidth = 5;
            dataGridView1.Columns[5].Visible = false;

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

            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = String.Format("https://hackathon.siim.org/vna/stone-webviewer/index.html?study={0}",
                                            dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value),
                UseShellExecute = true
            };

            Process.Start(psInfo);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string strPatientID;
            strPatientID = lblPatientID.Text;
        }
    }
}
