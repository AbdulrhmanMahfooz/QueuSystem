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
    public partial class Login : Form
    {
        Connection con = new Connection();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void loginUser()
        {
            string query = "select * from Users where username='"+txt_Username.Text.Trim()+"' and password='"+txt_Password.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con.GetConnectionDB());
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if(dtbl.Rows.Count==1)
            {
                Dashboard dash = new Dashboard();
                this.Hide();
                dash.Show();
            }
            else
            {
                MessageBox.Show("Check your username and Password");
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            loginUser();
        }

        private void txt_Username_KeyDown(object sender, KeyEventArgs e)
        {
            //txt_Password.Focus();
        }

        private void txt_Password_KeyUp(object sender, KeyEventArgs e)
        {
            //txt_Username.Focus();
        }

        private void txt_Username_Enter(object sender, EventArgs e)
        {
            //txt_Password.Focus();
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Password_Enter(object sender, EventArgs e)
        {
            //loginUser()
        }
    }
}
