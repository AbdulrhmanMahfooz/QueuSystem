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
using System.Speech.Synthesis;

namespace QueuSystem

{
    public partial class Calling : Form
    {
        public static Calling instance;
        public TextBox tb;
        public Button bt;
        SpeechSynthesizer speech;
        Connection con = new Connection();
        public List<String> l3 = new List<String>();
        public ListViewItem listviewDoctors;
        public ListView lvDoctors;
        public DateTime dt;
        
        
        public Calling()
        {
            InitializeComponent();
            instance = this;
            tb = txt_No;
            bt = button;
            
            dt = DateTime.Now;
            speech = new SpeechSynthesizer();
            foreach (CheckBox checkbox in Dashboard.instance.checkedList)
            {

                string Doctor_Name = checkbox.Text;
                string Clinic_No = checkbox.Name;
                string Clinic_Name = checkbox.AccessibleName;
                string letter = checkbox.AccessibleDescription;
                bt = new Button();
                bt.Left = left;
                bt.Top = top;
                this.Controls.Add(bt);
                top += bt.Height + 2;
                bt.Text = Doctor_Name;
                bt.Name = Clinic_No;
                bt.Click += new EventHandler(this.button_click);

                listviewDoctors = new ListViewItem(Doctor_Name);
                
                listviewDoctors.Name = Clinic_No;
                listviewDoctors.SubItems.Add(Clinic_Name);
                listviewDoctors.SubItems.Add(Clinic_No);
                listviewDoctors.SubItems.Add("");
                listView1.Items.Add(listviewDoctors);

                l3.Add(bt.Name);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-84PGKM3\\SQLEXPRESS;Initial Catalog=QueueSystem;Integrated Security=True");

            SqlCommand cmd1 = new SqlCommand("Select MIN(ticketnumber)from getTicket where ticketnumber !='0' AND ticketnumber !='' ",con.GetConnectionDB());
            //con.Open();
            con.GetConnectionDB();
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                txt_No.Text = dr.GetValue(0).ToString();
            }
            con.GetClose();
            //con.Close();
        }
       Button button = new Button();
        int top = 50;
        int left = 100;
        private void Calling_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-84PGKM3\\SQLEXPRESS;Initial Catalog=QueueSystem;Integrated Security=True");
            //{
            //    if (con.State == ConnectionState.Closed)
            //        con.Open();
            //}
            //con.GetConnectionDB();
            //string sql = "select Name, Clinic_No from Doctor where [status]='true' ";
            //SqlCommand cmd = new SqlCommand(sql, con.GetConnectionDB());
            //SqlDataReader rd;
            //rd = cmd.ExecuteReader();
            foreach(var voice in speech.GetInstalledVoices())
            {
                comboBox1.Items.Add(voice.VoiceInfo.Name);
            }
            
            //while (rd.Read())
            foreach(CheckBox checkbox in Dashboard.instance.checkedList)
            {

                string Doctor_Name = checkbox.Text;
                string Clinic_No = checkbox.Name;
                string Clinic_Name = checkbox.AccessibleName;
                string letter = checkbox.AccessibleDescription;
                bt = new Button();
                bt.Left = left;
                bt.Top = top;
                this.Controls.Add(bt);
                top += bt.Height + 2;
                bt.Text =Doctor_Name;
                bt.Name = Clinic_No;
                bt.Click += new EventHandler(this.button_click);

                listviewDoctors = new ListViewItem(Doctor_Name);
                listviewDoctors.Name = Clinic_No;
                listviewDoctors.SubItems.Add(Clinic_Name);
                listviewDoctors.SubItems.Add(Clinic_No);
                listviewDoctors.SubItems.Add("");
                listView1.Items.Add(listviewDoctors);
                l3.Add(bt.Name);

            }
            con.GetClose();
            
        }

        public void button_click(object sender, EventArgs e)
        {
            //Get the button clicked
            bt = sender as Button;
            //Display.instance.lvi.SubItems.Add("test");
            if (MessageBox.Show("Call Next for Clinic No" + bt.Name, "Call Next", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //SqlConnection con = new SqlConnection("Data Source=DESKTOP-84PGKM3\\SQLEXPRESS;Initial Catalog=QueueSystem;Integrated Security=True");
                //{
                //    if (con.State == ConnectionState.Closed)
                //        con.Open();
                //}
                string sql = "select min(getTicket) from appointments where Clinic_No=@no";
                SqlCommand cmd = new SqlCommand(sql, con.GetConnectionDB());
                cmd.Parameters.AddWithValue("@no", bt.Name);
                //cmd.Parameters.AddWithValue("@date", dt.ToString("yyyy-MM-dd"));
                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    txt_No.Text = rd.GetValue(0).ToString();
                }
                //int column = 1; // Which column to use

                //foreach (ListViewItem item in Display.instance.lv.Items)
                //{
                //    // string text = Display.instance.lvi.SubItems[column].item;
                //    string Name = item.Name;
                //    string text = item.Text;
                //    var x1 = item.Index.ToString();
                //    Console.WriteLine(Name);
                //    Console.WriteLine(text);
                //    Console.WriteLine(x1 + "##########################");

                //    if (bt.Name == Name)
                //    {
                //        //string number = txt_No.Text;
                //        //item.Text = txt_No.Text;

                //        //item.SubItems[0].Text = Name;
                //        //Display.instance.lv.Items[item.Index].SubItems[2].Text = Name;

                //        Display.instance.lv.Items[item.Index].SubItems.Add(txt_No.Text);
                //            //.Add(txt_No.Text);
                //        //    //    //Display.instance.lvi.SubItems.Add(txt_No.Text);
                //        //    //    //Display.instance.lb.Text = txt_No.Text;
                //        //    //    //Display.instance.lv.Items.Add(txt_No.Text);
                //        //    //    //Console.WriteLine(Display.instance.lb.Text);
                //        //    //    //Console.WriteLine(Display.instance.lvi.Name);
                //        //    //}
                //        //}
                //        //if (bt.Name==Display.instance.lvi.Name)
                //        //{
                //        //    string number = txt_No.Text;
                //        //    Display.instance.lvi.SubItems.Add(number);
                //        //    //Display.instance.lvi.SubItems.Add(txt_No.Text);
                //        //    //Display.instance.lb.Text = txt_No.Text;
                //        //    //Display.instance.lv.Items.Add(txt_No.Text);
                //        //    //Console.WriteLine(Display.instance.lb.Text);
                //        //    //Console.WriteLine(Display.instance.lvi.Name);
                //    }
                   
                    // display button details
                    //speech.SelectVoice("Microsoft Server Speech Text to Speech Voice (en-US, Helen)");
                    //speech.SpeakAsync("Customer Number"+txt_No.Text+"Room Number" + bt.Name);


                //}
                //MessageBox.Show(bt.Name + " Clicked");
                //Display ds = new Display();
                //ds.Refresh();
                //var x = Dashboard.instance.dis.l1;
                //foreach (var i in x)
                //{
                //    if (i.Name == bt.Name)
                //    {
                //        i.Text = txt_No.Text;
                //    }
                //    Console.WriteLine(i.Name + "#####################");
                //}
                //Display.instance.GetTextBoxes();
                Display.instance.callonLoad();
                Console.WriteLine(bt.Name);
                con.GetClose();


            }
        }
       public void updatechecklist()
        {
            foreach(CheckBox checkBox in Dashboard.instance.checkedList)
            {
                if(checkBox.Name=="")
                {
                    checkBox.Name = "000";
                }
                var controls = this.Controls.Find(checkBox.Name, true);
                if(controls != null)
                {
                    foreach (var control in controls)
                        if (control is Button)
                            control.Visible = true;
                }
                if (!l3.Contains(checkBox.Text))
                {
                    Console.WriteLine(checkBox.Text);
                    //bt = new Button();
                    //bt.Left = left;
                    //bt.Top = top;
                    //this.Controls.Add(bt);
                    //top += bt.Height + 2;
                    //bt.Text = checkBox.Text;
                    //bt.Name = checkBox.Name;
                    //bt.Click += new EventHandler(this.button_click);
                    l3.Add(checkBox.Text);

                    listviewDoctors = new ListViewItem(checkBox.Text);

                    listviewDoctors.Name = checkBox.Name;
                    listviewDoctors.SubItems.Add(checkBox.AccessibleName);
                    listviewDoctors.SubItems.Add(checkBox.Name);
                    listviewDoctors.SubItems.Add("");
                    listView1.Items.Add(listviewDoctors);

                    bt = new Button();
                    bt.Text = "Test";
                    string[] row = new string[] { checkBox.Text, checkBox.AccessibleName, checkBox.Name};
                    dataGridView1.Rows.Add(row);

                    
                    //var list = new BindingList<string>(l3);
                    //dataGridView1.DataSource = list;


                }
                
            }
        }
        public void removeButton()
        {
            foreach (CheckBox checkBox in Dashboard.instance.uncheckedList)
            {
                if (l3.Contains(checkBox.Text))
                {
                    //var controls = this.Controls.Find(checkBox.Name, true);
                    //foreach (var control in controls)
                    //    if (control is Button)
                    //        control.Visible = false;
                    //l3.Remove(checkBox.Text);
                    foreach (ListViewItem item in Display.instance.lv.Items)
                    {
                        // string text = Display.instance.lvi.SubItems[column].item;
                        //string Name = item.Name;
                        //string text = item.Text;
                        //var x1 = item.Index.ToString();
                        //Console.WriteLine(Name);
                        //Console.WriteLine(text);
                        //Console.WriteLine(x1 + "##########################");
                        //if (i == Name)
                        //{
                        //    //string number = txt_No.Text;
                        //    //item.Text = txt_No.Text;

                        //    //item.SubItems[0].Text = Name;
                        //    Display.instance.lv.Items[item.Index].Remove();

                        //    //Display.instance.lv.Items[item.Index].SubItems.Add(txt_No.Text);
                        //}

                        Display.instance.lv.Items[item.Index].Remove();
                        l3.Remove(checkBox.Name);
                        Display.instance.l3.Remove(checkBox.Name);

                    }

                }

            }
        }

        public void updateListView()
        {
            foreach(ListViewItem item in Display.instance.lv.Items)
            {
                var controls= this.Controls.Find(item.Name, true);
               
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
               
                l3.Remove(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Display.instance.l3.Remove(Display.instance.displayData.Rows[e.RowIndex].Cells[0].Value.ToString());
                string exp = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var targetBox = Dashboard.instance.checkedList.Where(o => o.Text == exp).First();
                targetBox.Checked = false;
                var i = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                foreach (ListViewItem item in Display.instance.lv.Items)
                {
                    // string text = Display.instance.lvi.SubItems[column].item;
                    string Name = item.Name;
                    string text = item.Text;
                    var x1 = item.Index.ToString();
                    Console.WriteLine(Name);
                    Console.WriteLine(text);
                    Console.WriteLine(x1 + "##########################");
                    if (i == Name)
                {
                    //string number = txt_No.Text;
                    //item.Text = txt_No.Text;

                    //item.SubItems[0].Text = Name;
                        Display.instance.lv.Items[item.Index].Remove();
                       
                        //Display.instance.lv.Items[item.Index].SubItems.Add(txt_No.Text);
                    }
                


            }
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                Display.instance.displayData.Rows.RemoveAt(e.RowIndex);
                
            }
            if(dataGridView1.Columns[e.ColumnIndex].Name=="Next")
            {
                //foreach (CheckBox checkbox in Dashboard.instance.checkedList)
                //{

                //    string Doctor_Name = checkbox.Text;
                //    string Clinic_No = checkbox.Name;
                //    string Clinic_Name = checkbox.AccessibleName;
                //    string letter = checkbox.AccessibleDescription;
                //}
                  string sql = "SELECT dbo.Clinc.id, dbo.Clinc.ClinicLetter, dbo.Clinc.ClinicNumber, MIN(dbo.Appointment.TicketNumber) AS Ticket, dbo.Event.StartOn, dbo.Appointment.AptStatus, dbo.Appointment.Oid FROM dbo.Clinc INNER JOIN dbo.Appointment ON dbo.Clinc.id = dbo.Appointment.clinc INNER JOIN dbo.Event ON dbo.Appointment.Oid = dbo.Event.Oid GROUP BY dbo.Clinc.id, dbo.Clinc.ClinicLetter, dbo.Clinc.ClinicNumber, dbo.Event.StartOn, dbo.Appointment.AptStatus, dbo.Appointment.Oid HAVING(dbo.Appointment.AptStatus = 0) AND(dbo.Clinc.ClinicNumber = @no)";
                SqlCommand cmd = new SqlCommand(sql, con.GetConnectionDB());
                var i = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                dt.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@no", i);
                //cmd.Parameters.AddWithValue("@date", dt);
                SqlDataReader rd;

               rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    txt_No.Text = rd.GetValue(3).ToString();
                   textBox1.Text = rd.GetValue(1).ToString();
                    txt_Oid.Text = rd.GetValue(6).ToString();
                }
                con.GetClose();
                dataGridView1.Rows[e.RowIndex].Cells[3].Value =textBox1.Text + txt_No.Text;
                Display.instance.displayData.Rows[e.RowIndex].Cells[3].Value = textBox1.Text+"-" + txt_No.Text;

                string updateStatus = "Update Appointment set AptStatus='1' where TicketNumber=@ticket AND Oid=@oid ";
                SqlCommand cmd1 = new SqlCommand(updateStatus, con.GetConnectionDB());
                cmd1.Parameters.AddWithValue("@ticket", txt_No.Text);
                cmd1.Parameters.AddWithValue("@oid", txt_Oid.Text);
                cmd1.ExecuteNonQuery();

                //speech.SelectVoice("Microsoft Hoda Desktop");
                //speech.SpeakAsync("مرحبا");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
