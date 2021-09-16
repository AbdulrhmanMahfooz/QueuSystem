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
    public partial class TicketDashboard : Form
    {
        Connection conn = new Connection();
        public TicketDashboard()
        {
            InitializeComponent();
           
        }
      
        //private void button1_Click(object sender, EventArgs e)
        //{   //Data Source=.;Initial Catalog=Test;Integrated Security=True
        //    SqlConnection con = new SqlConnection("Data Source=DESKTOP-84PGKM3\\SQLEXPRESS;Initial Catalog=QueueSystem;Integrated Security=True");
            
        //    SqlCommand cmd1 = new SqlCommand("Select MAX(ticketnumber+1)from getTicket where discription='Baby'", con);
        //    con.Open();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataTable dt = new DataTable();
        //    da.SelectCommand = cmd1;
        //    dt.Clear();
        //    da.Fill(dt);
        //    dataGridView1.DataSource = dt;
        //    SqlDataReader dr = cmd1.ExecuteReader();
        //    while(dr.Read())
        //    {
        //        textBox1.Text = dr.GetValue(0).ToString();
        //    }

        //    con.Close();
           
        //}
      

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    var dateTime = DateTime.Now;
           //label3.Text = dateTime.ToLongDateString();
        //    label2.Text = "مستشفى أكتوبر كلينيك | مدينة 6 أكتوبر الحي المتميز";
        //}

        

     

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("مستشفى أكتوبر كلينيك",new Font("Arial",20,FontStyle.Bold),Brushes.Black,130,130);
        }

        private void TicketDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btn_baby_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-84PGKM3\\SQLEXPRESS;Initial Catalog=QueueSystem;Integrated Security=True");

            SqlCommand cmd1 = new SqlCommand("Select MAX(ticketnumber+1)from getTicket where discription='Baby'", con);
            con.Open();
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //da.SelectCommand = cmd1;
            //dt.Clear();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
               txt_No.Text = dr.GetValue(0).ToString();
            }

            con.Close();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //var dateTime = DateTime.Now;
            label4.Text = DateTime.Now.ToString();
            label5.Text = "مستشفى أكتوبر كلينيك | مدينة 6 أكتوبر الحي المتميز";
        }
    }
}
