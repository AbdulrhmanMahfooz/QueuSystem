using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QueuSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void btn_Baby_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-84PGKM3\\SQLEXPRESS;Initial Catalog=QueueSystem;Integrated Security=True");

            SqlCommand cmd1 = new SqlCommand("Select MAX(ticketnumber+1)from getTicket where discription='Baby'", con);
            con.Open();

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                txt_No.Text = dr.GetValue(0).ToString();
            }
            con.Close();
            
            con.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO getTicket(ticketnumber,datefull,time,discription) Values(@ticketnumber,@datefull,@time,@discription)", con);
            cmd2.Parameters.AddWithValue("@ticketnumber", txt_No.Text);
            cmd2.Parameters.AddWithValue("@datefull", txt_Date.Text);
            cmd2.Parameters.AddWithValue("@time", txt_Time.Text);
            cmd2.Parameters.AddWithValue("@discription", btn_Baby.Text);
            cmd2.ExecuteNonQuery();
            con.Close();
            if (printPreviewDialog1.ShowDialog()==DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.txt_Date.Text = dt.ToString("yyyy-MM-dd");
            this.txt_Time.Text = dt.ToString("hh:mm tt");
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("مستشفى أكتوبر كلينيك|6 أكتوبر الحي المتميز", new Font("Arial", 36, FontStyle.Bold), Brushes.Black, 25, 50);
            e.Graphics.DrawString(txt_No.Text, new Font("Arial", 100, FontStyle.Bold), Brushes.Black, 200, 400);
            e.Graphics.DrawString(txt_Date.Text, new Font("Arial", 40, FontStyle.Bold), Brushes.Black, 150, 600);
            e.Graphics.DrawString(txt_Time.Text, new Font("Arial", 40, FontStyle.Bold), Brushes.Black, 150, 700);
        }

        private void btn_Others_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-84PGKM3\\SQLEXPRESS;Initial Catalog=QueueSystem;Integrated Security=True");

            SqlCommand cmd1 = new SqlCommand("Select MAX(ticketnumber+1)from getTicket where discription='Other'", con);
            con.Open();

            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                txt_No.Text = dr.GetValue(0).ToString();
            }
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO getTicket(ticketnumber,datefull,time,discription) Values(@ticketnumber,@datefull,@time,@discription)", con);
            cmd2.Parameters.AddWithValue("@ticketnumber", txt_No.Text);
            cmd2.Parameters.AddWithValue("@datefull", txt_Date.Text);
            cmd2.Parameters.AddWithValue("@time", txt_Time.Text);
            cmd2.Parameters.AddWithValue("@discription", btn_Others.Text);
            cmd2.ExecuteNonQuery();
            con.Close();
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
