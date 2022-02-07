using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Linq;
using System.Media;

namespace QueuSystem
{
    public partial class Dashboard : Form
    {
        public static Dashboard instance;
        Connection con = new Connection();
        public Display dis;
        
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
        SoundPlayer _sound;
        public Dashboard()
        {
            InitializeComponent();
            instance = this;
            check = false;
           
            dt = DateTime.Now;
            speech = new SpeechSynthesizer();
            speech.Rate = -3;
           
            //_sound2 = new SoundPlayer(2.wav);
            foreach (CheckBox checkbox in checkedList)
            {

                string Doctor_Name = checkbox.Text;
                string Clinic_No = checkbox.Name;
                string Clinic_Name = checkbox.AccessibleName;
                //string letter = checkbox.AccessibleDescription;
                string oid = checkbox.AccessibleDescription;
                
                l3.Add(Clinic_No);

               

                
            }
            Display ds = new Display();
            dis = ds;
            ds.Show();
            

        }
        int top = 50;
        int left = 100;
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (CheckBox checkbox in checkedList)
            {

                string Doctor_Name = checkbox.Text;
                string Clinic_No = checkbox.Name;
                string Clinic_Name = checkbox.AccessibleName;
                string letter = checkbox.AccessibleDescription;
               
                l3.Add(Clinic_No);

            }
            con.GetClose();

            int Top = 5;
            int left = 100;
            //SqlCommand cmd1 = new SqlCommand("SELECT dbo.Clinc.Name, dbo.Person.Name AS Doctor_Name, dbo.Employee.section, dbo.Clinc.id AS Room_No,dbo.Clinc.ClinicNumber, dbo.Employee.Oid FROM dbo.Person INNER JOIN dbo.Employee ON dbo.Person.Oid = dbo.Employee.Oid INNER JOIN dbo.Clinc ON dbo.Employee.Clinic = dbo.Clinc.id", con.GetConnectionDB());
            //SqlCommand cmd1 = new SqlCommand("Select Name,Clinic_No,Specialist from Doctor", con.GetConnectionDB());
            //SqlCommand cmd1 = new SqlCommand("SELECT Clinc.Name, dbo.Person.FirstName, dbo.Clinc.id AS Room_No, dbo.Clinc.ClinicNumber, dbo.Clinc.ClinicLetter dbo.Person INNER JOIN dbo.Employee ON dbo.Person.Oid = dbo.Employee.Oid INNER JOIN dbo.Clinc ON dbo.Employee.Clinic = dbo.Clinc.id", con.GetConnectionDB());
            SqlCommand cmd1 = new SqlCommand("SELECT dbo.Employee.Oid, dbo.Person.FirstName, dbo.Clinc.Name, dbo.Clinc.ClinicNumber, dbo.Employee.Clinic FROM dbo.Person INNER JOIN dbo.Employee ON dbo.Person.Oid = dbo.Employee.Oid INNER JOIN dbo.Clinc ON dbo.Employee.Clinic = dbo.Clinc.id WHERE(dbo.Clinc.id <> 0)", con.GetConnectionDB());


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
                string OID = dr["Oid"].ToString();
               
                ch = new CheckBox();
                ch.Left = left;
                ch.Top = Top;
                this.Controls.Add(ch);
                Top += ch.Height + 2;
                ch.Text = Doctor_Name;
                ch.Name = Clinic_No;
                ch.AccessibleName = Clinic_Name;
                ch.AccessibleDescription = OID;
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

            }


           
            con.GetClose();
        }

       
        public void updatechecklist()
        {
            foreach (CheckBox checkBox in checkedList)
            {
                if (checkBox.Name == "")
                {
                    checkBox.Name = "-";
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
                    l3.Add(checkBox.Text);
                    string[] row = new string[] { checkBox.Text, checkBox.AccessibleName, checkBox.Name };
                    dataGridView1.Rows.Add(row);



                }

            }
        }

        public void removeButton()
        {
            foreach (CheckBox checkBox in uncheckedList)
            {
                if (l3.Contains(checkBox.Text))
                {
                  
                    foreach (ListViewItem item in Display.instance.lv.Items)
                    {
                       

                        Display.instance.lv.Items[item.Index].Remove();
                        l3.Remove(checkBox.Name);
                        Display.instance.l3.Remove(checkBox.Name);

                    }

                }

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
        
        

       

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

       

        private void queueDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                ch.Enabled = false;
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
                ch.Enabled = true;
                //Calling.instance.removeButton();
                //Display.instance.removeButtonDisplay();
            }
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {

                l3.Remove(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Display.instance.l3.Remove(Display.instance.displayData.Rows[e.RowIndex].Cells[0].Value.ToString());
                string exp = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var targetBox = checkedList.Where(o => o.Text == exp).First();
                targetBox.Checked = false;
                var i = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                //foreach (ListViewItem item in Display.instance.lv.Items)
                //{
                //    // string text = Display.instance.lvi.SubItems[column].item;
                //    string Name = item.Name;
                //    string text = item.Text;
                //    var x1 = item.Index.ToString();
                //    Console.WriteLine(Name);
                //    Console.WriteLine(text);
                //    Console.WriteLine(x1 + "##########################");
                //    if (i == Name)
                //    {
                //        //string number = txt_No.Text;
                //        //item.Text = txt_No.Text;

                //        //item.SubItems[0].Text = Name;
                //        Display.instance.lv.Items[item.Index].Remove();

                //        //Display.instance.lv.Items[item.Index].SubItems.Add(txt_No.Text);
                //    }



                //}
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
                
                string sql = "SELECT TOP (1) dbo.Clinc.ClinicLetter, dbo.Clinc.ClinicNumber, MIN(dbo.Appointment.TicketNumber) AS Ticket, CAST(CONVERT(date, dbo.Event.StartOn) AS varchar) AS Date1, dbo.Appointment.AptStatus, dbo.Appointment.Oid,dbo.Appointment.Complete FROM dbo.Clinc INNER JOIN dbo.Appointment ON dbo.Clinc.id = dbo.Appointment.clinc INNER JOIN dbo.Event ON dbo.Appointment.Oid = dbo.Event.Oid GROUP BY dbo.Clinc.ClinicLetter, dbo.Clinc.ClinicNumber, dbo.Event.StartOn, dbo.Appointment.AptStatus, dbo.Appointment.Oid, CAST(CONVERT(date, dbo.Event.StartOn) AS varchar),dbo.Appointment.Complete HAVING (dbo.Appointment.Complete = 0) AND(dbo.Clinc.ClinicNumber = @no) AND(CAST(CONVERT(date, dbo.Event.StartOn) AS varchar) = @date) AND(MIN(dbo.Appointment.TicketNumber) <> 0)";
                //string sql = "SELECT TOP (1) dbo.Clinc.ClinicLetter, dbo.Clinc.ClinicNumber, MIN(dbo.Appointment.TicketNumber) AS Ticket, CAST(CONVERT(date, dbo.Event.StartOn) AS varchar) AS Date1, dbo.Appointment.AptStatus, dbo.Appointment.Oid,dbo.Appointment.Doctor dbo.Clinc INNER JOIN dbo.Appointment ON dbo.Clinc.id = dbo.Appointment.clinc INNER JOIN dbo.Event ON dbo.Appointment.Oid = dbo.Event.Oid GROUP BY dbo.Clinc.ClinicLetter, dbo.Clinc.ClinicNumber, dbo.Event.StartOn, dbo.Appointment.AptStatus, dbo.Appointment.Oid, CAST(CONVERT(date, dbo.Event.StartOn) AS varchar), dbo.Appointment.Doctor HAVING(dbo.Appointment.AptStatus = 0) AND(MIN(dbo.Appointment.TicketNumber) <> 0) AND(dbo.Appointment.Doctor = @oid) AND (dbo.Clinc.ClinicNumber = @no) AND(CAST(CONVERT(date, dbo.Event.StartOn) AS varchar) = @date) ";
                SqlCommand cmd = new SqlCommand(sql, con.GetConnectionDB());
                var i = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string sdt = dt.Year + "-" + dt.Month.ToString("D2") + "-" + dt.Day.ToString("D2");
                dt.ToString("dd-MM-yyyy");
                string.Format("{0:dd-MM-yyyy}", dt);
                cmd.Parameters.AddWithValue("@no", i);
                cmd.Parameters.AddWithValue("@date", sdt);
                //foreach(CheckBox checoid in checkedList)
                //{
                //    if(checoid.AccessibleDescription==)
                //}
                SqlDataReader rd;
               
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    txt_No.Text = rd.GetValue(2).ToString();
                    txt_letter.Text = rd.GetValue(0).ToString();
                    txt_Oid.Text = rd.GetValue(5).ToString();
                    //txt_CLinic_No.Text = rd.GetValue(1).ToString();
                }
                con.GetClose();
                var number = txt_No.Text;
                var letter = txt_letter.Text;
                txt_CLinic_No.Text = i;
                
                if (txt_No.Text == "")
                {
                    MessageBox.Show("There is no more patint");
                }
                else
                {
                    //splashscreen.instance.lbNo.Text = number;
                    //splashscreen.instance.lbclinic.Text = i.ToString();
                   // try
                   // {
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = letter + number;
                        Display.instance.displayData.Rows[e.RowIndex].Cells[3].Value = letter + "-" + number;
                        Display.instance.showSplashScreen(number, i.ToString(), txt_letter.Text);
                        //splashscreen spl = new splashscreen(no: number, clinic: i.ToString(), letter: txt_letter.Text);
                        //spl.Show();
                        //spl.Refresh();
                        
                        _sound = new SoundPlayer("announcement.wav");
                        _sound.PlaySync();
                        _sound = new SoundPlayer("customer.wav");
                        _sound.PlaySync();
                        _sound = new SoundPlayer("Number.wav");
                        _sound.PlaySync();

                        _sound.Stop();

                        _sound = new SoundPlayer(txt_letter.Text + ".wav");
                        _sound.PlaySync();
                        //speech.SpeakAsync(txt_letter.Text);
                        _sound = new SoundPlayer(txt_No.Text + ".wav");
                        _sound.PlaySync();
                        _sound = new SoundPlayer("GoTo.wav");
                        _sound.PlaySync();
                        _sound = new SoundPlayer("Clinic_Number.wav");
                        _sound.PlaySync();
                        _sound = new SoundPlayer(i.ToString() + ".wav");
                        _sound.PlaySync();
                    string updateStatus = "Update Appointment set Complete=1 where TicketNumber=@ticket AND Oid=@oid ";
                    SqlCommand cmd1 = new SqlCommand(updateStatus, con.GetConnectionDB());
                    cmd1.Parameters.AddWithValue("@ticket", txt_No.Text);
                    cmd1.Parameters.AddWithValue("@oid", txt_Oid.Text);
                    cmd1.ExecuteNonQuery();

                    txt_letter.Clear();
                        txt_No.Clear();
                        txt_Oid.Clear();
                    //}
                    //catch
                    //{
                     //   MessageBox.Show("error");
                   // }
                   
                    //txt_CLinic_No.Clear();
                }
                //speech.SelectVoice("Microsoft Hoda Desktop");
                
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
