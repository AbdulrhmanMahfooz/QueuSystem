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
    public partial class Appointements : Form
    {
        Connection con = new Connection(); 
        DataTable dt = new DataTable();
       
        public Appointements()
        {
            InitializeComponent();
            
        }

        private void Appointements_Load(object sender, EventArgs e)
        {
            SqlDataAdapter query = new SqlDataAdapter("Select id, Name from specialist",con.GetConnectionDB());
            query.Fill(dt);
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "Please Select Specialist";
            dt.Rows.InsertAt(row, 0);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";


            SqlCommand query1 = new SqlCommand("Select id, Name from Doctor where specialist=@as", con.GetConnectionDB());
            query1.Parameters.AddWithValue("@as", row["id"]);
            con.GetClose();
        }
    }
}
