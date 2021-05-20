
namespace RosaTEST
{
    partial class StudyList
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudyList));
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblPatientID = new System.Windows.Forms.Label();
			this.lblPatientName = new System.Windows.Forms.Label();
			this.lblPatientDOB = new System.Windows.Forms.Label();
			this.StudyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.StudyDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Modality = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnPACS = new System.Windows.Forms.Button();
			this.btnEMR = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.GridColor = System.Drawing.SystemColors.Window;
			this.dataGridView1.Location = new System.Drawing.Point(12, 88);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.dataGridView1.RowTemplate.Height = 25;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(501, 215);
			this.dataGridView1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Patient ID:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(5, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "Patient Name:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label3.Location = new System.Drawing.Point(5, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 19);
			this.label3.TabIndex = 3;
			this.label3.Text = "Patient DOB:";
			this.label3.UseMnemonic = false;
			// 
			// lblPatientID
			// 
			this.lblPatientID.AutoSize = true;
			this.lblPatientID.Location = new System.Drawing.Point(116, 20);
			this.lblPatientID.Name = "lblPatientID";
			this.lblPatientID.Size = new System.Drawing.Size(38, 15);
			this.lblPatientID.TabIndex = 4;
			this.lblPatientID.Text = "label4";
			// 
			// lblPatientName
			// 
			this.lblPatientName.AutoSize = true;
			this.lblPatientName.Location = new System.Drawing.Point(116, 38);
			this.lblPatientName.Name = "lblPatientName";
			this.lblPatientName.Size = new System.Drawing.Size(38, 15);
			this.lblPatientName.TabIndex = 5;
			this.lblPatientName.Text = "label5";
			// 
			// lblPatientDOB
			// 
			this.lblPatientDOB.AutoSize = true;
			this.lblPatientDOB.Location = new System.Drawing.Point(116, 57);
			this.lblPatientDOB.Name = "lblPatientDOB";
			this.lblPatientDOB.Size = new System.Drawing.Size(38, 15);
			this.lblPatientDOB.TabIndex = 6;
			this.lblPatientDOB.Text = "label6";
			// 
			// StudyID
			// 
			this.StudyID.HeaderText = "Study ID";
			this.StudyID.Name = "StudyID";
			this.StudyID.ReadOnly = true;
			// 
			// StudyDesc
			// 
			this.StudyDesc.HeaderText = "Study Description";
			this.StudyDesc.Name = "StudyDesc";
			this.StudyDesc.ReadOnly = true;
			// 
			// Modality
			// 
			this.Modality.HeaderText = "Modality";
			this.Modality.Name = "Modality";
			this.Modality.ReadOnly = true;
			// 
			// btnPACS
			// 
			this.btnPACS.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnPACS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPACS.BackgroundImage")));
			this.btnPACS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnPACS.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnPACS.Location = new System.Drawing.Point(86, 309);
			this.btnPACS.Name = "btnPACS";
			this.btnPACS.Size = new System.Drawing.Size(62, 41);
			this.btnPACS.TabIndex = 7;
			this.btnPACS.UseVisualStyleBackColor = false;
			this.btnPACS.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnEMR
			// 
			this.btnEMR.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnEMR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEMR.BackgroundImage")));
			this.btnEMR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnEMR.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnEMR.Location = new System.Drawing.Point(228, 24);
			this.btnEMR.Name = "btnEMR";
			this.btnEMR.Size = new System.Drawing.Size(49, 41);
			this.btnEMR.TabIndex = 8;
			this.btnEMR.UseVisualStyleBackColor = false;
			this.btnEMR.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.lblPatientDOB);
			this.groupBox1.Controls.Add(this.lblPatientID);
			this.groupBox1.Controls.Add(this.lblPatientName);
			this.groupBox1.Location = new System.Drawing.Point(12, 1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 81);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// StudyList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(525, 352);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnEMR);
			this.Controls.Add(this.btnPACS);
			this.Controls.Add(this.dataGridView1);
			this.Name = "StudyList";
			this.Text = "Study List";
			this.Load += new System.EventHandler(this.StudyList_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPatientID;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblPatientDOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudyDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modality;
        private System.Windows.Forms.Button btnPACS;
        private System.Windows.Forms.Button btnEMR;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}