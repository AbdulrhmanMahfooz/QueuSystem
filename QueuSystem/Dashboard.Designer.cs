﻿
namespace QueuSystem
{
    partial class Dashboard
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Next = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_Oid = new System.Windows.Forms.TextBox();
            this.txt_letter = new System.Windows.Forms.TextBox();
            this.txt_No = new System.Windows.Forms.TextBox();
            this.txt_CLinic_No = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Next,
            this.Delete});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(217, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(608, 463);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "اسم الدكتور";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "العيادة";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "رقم العيادة";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "رقم المريض";
            this.Column4.Name = "Column4";
            // 
            // Next
            // 
            this.Next.HeaderText = "التالي";
            this.Next.Name = "Next";
            this.Next.Text = "التالي";
            this.Next.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "إغلاق";
            this.Delete.Name = "Delete";
            this.Delete.Text = "إغلاق";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // txt_Oid
            // 
            this.txt_Oid.Location = new System.Drawing.Point(704, 154);
            this.txt_Oid.Name = "txt_Oid";
            this.txt_Oid.Size = new System.Drawing.Size(121, 20);
            this.txt_Oid.TabIndex = 20;
            this.txt_Oid.Visible = false;
            // 
            // txt_letter
            // 
            this.txt_letter.Location = new System.Drawing.Point(685, 154);
            this.txt_letter.Name = "txt_letter";
            this.txt_letter.Size = new System.Drawing.Size(100, 20);
            this.txt_letter.TabIndex = 19;
            this.txt_letter.Visible = false;
            // 
            // txt_No
            // 
            this.txt_No.Location = new System.Drawing.Point(685, 154);
            this.txt_No.Name = "txt_No";
            this.txt_No.Size = new System.Drawing.Size(128, 20);
            this.txt_No.TabIndex = 17;
            this.txt_No.Visible = false;
            // 
            // txt_CLinic_No
            // 
            this.txt_CLinic_No.Location = new System.Drawing.Point(725, 154);
            this.txt_CLinic_No.Name = "txt_CLinic_No";
            this.txt_CLinic_No.Size = new System.Drawing.Size(100, 20);
            this.txt_CLinic_No.TabIndex = 21;
            this.txt_CLinic_No.Visible = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 463);
            this.Controls.Add(this.txt_CLinic_No);
            this.Controls.Add(this.txt_Oid);
            this.Controls.Add(this.txt_letter);
            this.Controls.Add(this.txt_No);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Next;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.TextBox txt_Oid;
        private System.Windows.Forms.TextBox txt_letter;
        private System.Windows.Forms.TextBox txt_No;
        private System.Windows.Forms.TextBox txt_CLinic_No;
    }
}

