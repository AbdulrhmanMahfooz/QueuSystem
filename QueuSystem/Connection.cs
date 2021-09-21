using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QueuSystem
{
   public class Connection
    {
        private SqlConnection con;

        public SqlConnection GetConnectionDB()
        {
            //con = new SqlConnection("Data Source=DESKTOP-TCE86V6\\SQLEXPRESS,1433;Initial Catalog=HMS;Persist Security Info=True;User ID=HMSserver;Password=123456");
            con = new SqlConnection("Data Source=192.168.2.201\\SQLEXPRESS,1433;Initial Catalog=HMS;Persist Security Info=True;User ID=HMSserver;Password=123456");
            //con = new SqlConnection("Data Source=DESKTOP-84PGKM3\\SQLEXPRESS;Initial Catalog=QueueSystem;Integrated Security=True");
            if (con.State==ConnectionState.Closed)
            {
                //con.Close();
                con.Open();
            }
            else
            {
                con.Close();
            }
            return con;
        }
        public void GetClose()
        {
            if(con!=null)
            {
                con.Close();
            }
        }
    }
}
