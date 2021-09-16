
namespace QueuSystem
{
    partial class TicketDashboard
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
            this.btn_baby = new System.Windows.Forms.Button();
            this.txt_No = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_baby
            // 
            this.btn_baby.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_baby.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_baby.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_baby.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btn_baby.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_baby.Location = new System.Drawing.Point(405, 12);
            this.btn_baby.Name = "btn_baby";
            this.btn_baby.Size = new System.Drawing.Size(237, 104);
            this.btn_baby.TabIndex = 0;
            this.btn_baby.Text = "Baby";
            this.btn_baby.UseVisualStyleBackColor = true;
            this.btn_baby.Click += new System.EventHandler(this.btn_baby_Click);
            // 
            // txt_No
            // 
            this.txt_No.Location = new System.Drawing.Point(189, 195);
            this.txt_No.Name = "txt_No";
            this.txt_No.ReadOnly = true;
            this.txt_No.Size = new System.Drawing.Size(239, 20);
            this.txt_No.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(402, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 3;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // TicketDashboard
            // 
            this.ClientSize = new System.Drawing.Size(654, 353);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_No);
            this.Controls.Add(this.btn_baby);
            this.Name = "TicketDashboard";
            this.Load += new System.EventHandler(this.TicketDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btn_baby;
        private System.Windows.Forms.TextBox txt_No;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer2;
    }
}