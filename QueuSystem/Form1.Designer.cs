
namespace QueuSystem
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_Baby = new System.Windows.Forms.Button();
            this.txt_No = new System.Windows.Forms.TextBox();
            this.btn_Others = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.txt_Date = new System.Windows.Forms.TextBox();
            this.txt_Time = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Baby
            // 
            this.btn_Baby.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Baby.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Baby.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Baby.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btn_Baby.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Baby.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Baby.Location = new System.Drawing.Point(271, 12);
            this.btn_Baby.Name = "btn_Baby";
            this.btn_Baby.Size = new System.Drawing.Size(237, 129);
            this.btn_Baby.TabIndex = 2;
            this.btn_Baby.Text = "Pediatric";
            this.btn_Baby.UseVisualStyleBackColor = true;
            this.btn_Baby.Click += new System.EventHandler(this.btn_Baby_Click);
            // 
            // txt_No
            // 
            this.txt_No.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_No.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_No.Location = new System.Drawing.Point(271, 291);
            this.txt_No.Name = "txt_No";
            this.txt_No.ReadOnly = true;
            this.txt_No.Size = new System.Drawing.Size(237, 43);
            this.txt_No.TabIndex = 3;
            this.txt_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Others
            // 
            this.btn_Others.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Others.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Others.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_Others.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btn_Others.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Others.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Others.Location = new System.Drawing.Point(271, 156);
            this.btn_Others.Name = "btn_Others";
            this.btn_Others.Size = new System.Drawing.Size(237, 129);
            this.btn_Others.TabIndex = 4;
            this.btn_Others.Text = "Others";
            this.btn_Others.UseVisualStyleBackColor = true;
            this.btn_Others.Click += new System.EventHandler(this.btn_Others_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // txt_Date
            // 
            this.txt_Date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Date.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Date.Location = new System.Drawing.Point(128, 347);
            this.txt_Date.Name = "txt_Date";
            this.txt_Date.ReadOnly = true;
            this.txt_Date.Size = new System.Drawing.Size(490, 43);
            this.txt_Date.TabIndex = 5;
            this.txt_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Time
            // 
            this.txt_Time.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Time.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Time.Location = new System.Drawing.Point(128, 403);
            this.txt_Time.Name = "txt_Time";
            this.txt_Time.ReadOnly = true;
            this.txt_Time.Size = new System.Drawing.Size(490, 43);
            this.txt_Time.TabIndex = 6;
            this.txt_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_Time);
            this.Controls.Add(this.txt_Date);
            this.Controls.Add(this.btn_Others);
            this.Controls.Add(this.txt_No);
            this.Controls.Add(this.btn_Baby);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Baby;
        private System.Windows.Forms.TextBox txt_No;
        private System.Windows.Forms.Button btn_Others;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox txt_Date;
        private System.Windows.Forms.TextBox txt_Time;
    }
}