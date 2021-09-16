using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Linq;

namespace QueuSystem
{
    public partial class Dashboard : Form
    {
        public static Dashboard instance;
        Connection con = new Connection();
        public Display dis;
        public Calling cal;
        public CheckedListBox checked1;
        public bool check;
        public CheckBox ch;
        public List<CheckBox> checkedList = new List<CheckBox>();
        public List<CheckBox> uncheckedList = new List<CheckBox>();
        public TextBox tt;
        public List<String> l3 = new List<String>();
        public ListViewItem listviewDoctors;
        public ListView lvDoctors;
        public DateTime dt;
        public TextBox tb;
        public Button bt;
        SpeechSynthesizer speech;
        public Dashboard()
        {
            InitializeComponent();
            instance = this;
            check = false;
            tt = textBox1;
            dt = DateTime.Now;
            speech = new SpeechSynthesizer();
            foreach (CheckBox checkbox in checkedList)
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
        int top = 50;
        int left = 100;
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var voice in speech.GetInstalledVoices())
            {
                comboBox1.Items.Add(voice.VoiceInfo.Name);
            }

            foreach (CheckBox checkbox in checkedList)
            {

                string Doctor_Name = checkbox.Text;
                string Clinic_No = checkbox.Name;
                string Clinic_Name = checkbox.AccessibleName;
                string letter = checkbox.AccessibleDescription;
                bt = new Button();
                bt.Left = Left;
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
            con.GetClose();

            int Top = 50;
            int left = 100;
            SqlCommand cmd1 = new SqlCommand("SELECT dbo.Clinc.Name, dbo.Person.FirstName, dbo.Employee.section, dbo.Clinc.id AS Room_No,dbo.Clinc.ClinicNumber FROM dbo.Person INNER JOIN dbo.Employee ON dbo.Person.Oid = dbo.Employee.Oid INNER JOIN dbo.Clinc ON dbo.Employee.Clinic = dbo.Clinc.id", con.GetConnectionDB());
            //SqlCommand cmd1 = new SqlCommand("Select Name,Clinic_No,Specialist from Doctor", con.GetConnectionDB());
            //SqlCommand cmd1 = new SqlCommand("SELECT Clinc.Name, dbo.Person.FirstName, dbo.Clinc.id AS Room_No, dbo.Clinc.ClinicNumber, dbo.Clinc.ClinicLetter dbo.Person INNER JOIN dbo.Employee ON dbo.Person.Oid = dbo.Employee.Oid INNER JOIN dbo.Clinc ON dbo.Employee.Clinic = dbo.Clinc.id", con.GetConnectionDB());

            SqlDataReader dr;
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {

                //string ro = dr["Name"].ToString();
                //string no = dr["Clinic_No"].ToString();
                //string ss = dr["Specialist"].ToString();
                string Clinic_Name = dr["Name"].ToString();
                string Doctor_Name = dr["FirstName"].ToString();
                string Clinic_No = dr["ClinicNumber"].ToString();
                //string letter = dr["ClinicLetter"].ToString();
               
                ch = new CheckBox();
                ch.Left = left;
                ch.Top = Top;
                this.Controls.Add(ch);
                Top += ch.Height + 2;
                ch.Text = Doctor_Name;
                ch.Name = Clinic_No;
                ch.AccessibleName = Clinic_Name;
                //ch.AccessibleDescription = letter;
                if(ch.Checked==true)
                {
                    checkedList.Add(ch);
                   
                }
                else
                {
                    uncheckedList.Add(ch);
                }
                ch.CheckedChanged += new EventHandler(CheckBox_Checked);

                //bt.Click += new EventHandler(this.button_click);

                //l3.Add(bt.Name);
            }


            //da1.SelectCommand = cmd1;
            //DataTable table1 = new DataTable();
            //da1.Fill(table1);
            //checkedListBox1.DataSource = table1;
            //checkedListBox1.DisplayMember = "Name";b 
            //foreach (DataRow row in table1.Rows)
            //{
                
            //    checkedListBox1.Items.Add(row["Name"].ToString());
                
            //}
            //comboBox1.DataSource = table1;
            //comboBox1.DisplayMember = "Name";
            //comboBox1.ValueMember = "id";
            //Display2 d2 = new Display2();
            //d2.Show();
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
              
                Display.instance.callonLoad();
                Console.WriteLine(bt.Name);
                con.GetClose();


            }
        }
        public void updatechecklist()
        {
            foreach (CheckBox checkBox in checkedList)
            {
                if (checkBox.Name == "")
                {
                    checkBox.Name = "000";
                }
                var controls = this.Controls.Find(checkBox.Name, true);
                if (controls != null)
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
                    string[] row = new string[] { checkBox.Text, checkBox.AccessibleName, checkBox.Name };
                    dataGridView1.Rows.Add(row);


                    //var list = new BindingList<string>(l3);
                    //dataGridView1.DataSource = list;


                }

            }
        }

        public void removeButton()
        {
            foreach (CheckBox checkBox in uncheckedList)
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {

                l3.Remove(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Display.instance.l3.Remove(Display.instance.displayData.Rows[e.RowIndex].Cells[0].Value.ToString());
                string exp = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var targetBox = checkedList.Where(o => o.Text == exp).First();
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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Next")
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
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = textBox1.Text + txt_No.Text;
                Display.instance.displayData.Rows[e.RowIndex].Cells[3].Value = textBox1.Text + "-" + txt_No.Text;

                string updateStatus = "Update Appointment set AptStatus='1' where TicketNumber=@ticket AND Oid=@oid ";
                SqlCommand cmd1 = new SqlCommand(updateStatus, con.GetConnectionDB());
                cmd1.Parameters.AddWithValue("@ticket", txt_No.Text);
                cmd1.Parameters.AddWithValue("@oid", txt_Oid.Text);
                cmd1.ExecuteNonQuery();

                //speech.SelectVoice("Microsoft Hoda Desktop");
                //speech.SpeakAsync("مرحبا");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //checked1 = checkedListBox1;
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-84PGKM3\\SQLEXPRESS;Initial Catalog=QueueSystem;Integrated Security=True");
            //{
            //    if (con.State == ConnectionState.Closed)
            //        con.Open();
            //}
            //if (check == false)
            //{
            //    check = true;
            //    Calling.instance.
            //}
            //SqlCommand cmd = new SqlCommand("UPDATE Doctor SET [status] = 'False'", con.GetConnectionDB());
            //cmd.ExecuteNonQuery();
            //SqlCommand cmd1 = new SqlCommand(" Doctors", con);
            //SqlDataAdapter da1 = new SqlDataAdapter();
            //da1.SelectCommand = cmd1;

            //foreach ()
            //{
            //    //Doctors.Add(Convert.ToInt32(row["Clinic_No"]), row["Name"].ToString());
            //    //convert item to string
            //    string checkedItem = item.ToString();
            //    MessageBox.Show(checkedItem.ToString());
            //    //insert item to database
            //    SqlCommand cmd1 = new SqlCommand("UPDATE Doctor SET [status] = 'true' WHERE Name=@status", con.GetConnectionDB());
            //    //cmd.Parameters.AddWithValue("@true", "True");//add item
            //    cmd1.Parameters.AddWithValue("@status", checkedItem);
            //    cmd1.ExecuteNonQuery();
            //}
            // Display.instance.callonLoad();

            //Display2.instance.loadData();
            //Display2.instance.updatedata();

            //        con.GetClose();
            //    }
            //    else
            //    {
           
            //    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            Display ds = new Display();
            dis = ds;
                ds.Show();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void queueBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.queueBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.testDataSet1);

        }

        private void queueDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Calling ds = new Calling();
            cal = ds;
            ds.Show();
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //checked1 = checkedListBox1;
        }
        private void CheckBox_Checked(object sender, EventArgs e)
        {
            //Calling.instance.tb.Text = tt.Text;
            CheckBox ch = (sender as CheckBox);
            if (ch.Checked)
            {
                //MessageBox.Show("You selected: " + ch.Text);
                checkedList.Add(ch);
                uncheckedList.Remove(ch);

                updatechecklist();
                //Calling.instance.updatechecklist();
                Display.instance.updatechecklistDisplay();
                //Display.instance.loadlistview();
            }
            else
            {
                //MessageBox.Show("You Unselected:" + ch.Text);
                checkedList.Remove(ch);
                uncheckedList.Add(ch);
                //Calling.instance.removeButton();
                //Display.instance.removeButtonDisplay();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
