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
    public partial class Display2 : Form
    {
        public static Display2 instance;
        public Display2()
        {
            InitializeComponent();
            instance = this;
        }

        private void Display2_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = Properties.Resources.img1;
            //timer1.Start();
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-84PGKM3\\SQLEXPRESS;Initial Catalog=QueueSystem;Integrated Security=True");
            //{
            //    if (con.State == ConnectionState.Closed)
            //        con.Open();
            //}
            //string sql = "select Room_No from RoomNumber where [status]='true' AND Room_No !='Null'";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //SqlDataReader rd;
            //rd = cmd.ExecuteReader();
            //int top = 100;
            //int left = 780;
            //while (rd.Read())
            //{
            //    string ro = rd["Room_No"].ToString();

            //    Button button = new Button();
            //    button.Left = left;
            //    button.Top = top;
            //    button.Height = 100;
            //    button.Width = 130;
            //    button.FlatStyle = FlatStyle.Flat;
            //    this.Controls.Add(button);
            //    top += button.Height + 2;
            //    button.Text = ro;
            //    button.Name = ro;
            //}
            loadData();


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.label1.Text = dt.ToString("yyyy-MM-dd");
            this.label2.Text = dt.ToString("hh:mm tt");
        }
        public void loadData()
        {
            pictureBox1.Image = Properties.Resources.img1;
            timer1.Start();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-84PGKM3\\SQLEXPRESS;Initial Catalog=QueueSystem;Integrated Security=True");
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
            }
            string sql = "select Room_No from RoomNumber where [status]='true' AND Room_No !='Null'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            int top = 100;
            int left = 780;
            while (rd.Read())
            {
                string ro = rd["Room_No"].ToString();

                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Height = 100;
                button.Width = 130;
                button.FlatStyle = FlatStyle.Flat;
                this.Controls.Add(button);
                top += button.Height + 2;
                button.Text = ro;
                button.Name = ro;
            }
           

        }
        public void updatedata()
        {
            Display2 d2 = new Display2();
            d2.Refresh();
        }
    }
}
