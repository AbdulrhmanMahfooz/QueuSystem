using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Speech.Synthesis;


namespace QueuSystem
{

    public partial class Display : Form
    {
        public static Display instance;
        public TextBox tb;
        SpeechSynthesizer speech;
        Connection con = new Connection();
        public List<TextBox> l1 = new List<TextBox>();
        public List<Label> l2 = new List<Label>();
        public List<String> l3 = new List<String>();
        public Button bt;
        public Label lb;
        public ListView lv;
        public ListViewItem lvi;
        public ListViewItem lvi2;
        public DataGridView displayData;
        
        public Display()
        {
            InitializeComponent();
            instance = this;
            //tb = txt_No;
            bt = button;
            lb = lab;
            tb = txt;
            //lv = listView1;
            //lvi = item;
            //lv = listView1;
            displayData = dataGridView1;
            speech = new SpeechSynthesizer();
            //tb = tt;
            foreach (CheckBox checkbox in Dashboard.instance.checkedList)
            {

                string ro = checkbox.Text;
                string no = checkbox.Name;
                string ss = checkbox.AccessibleName;
                //Label for doctor name
                //lb = new Label();
                //lb.Left = left;
                //lb.Top = top;
                //this.Controls.Add(lb);
                //top += lb.Height + 2;
                //lb.Text = ro;
                //lb.Name = no;
                //lb.Font = new Font("Arial", 12, FontStyle.Regular);
                ////label for clinic name
                //lb.Left = left1;
                //lb.Top = top1;
                //this.Controls.Add(lb);
                //top1 += lb.Height + 30;
                //lb.Text = ss;
                //lb.Name = no;
                //lb.Font = new Font("Arial", 12, FontStyle.Regular);
                //l3.Add(lb.Name);
                ////Label for clinic No
                //lb = new Label();
                //lb.Left = left2;
                //lb.Top = top2;
                //this.Controls.Add(lb);
                //top1 += lb.Height + 2;
                //lb.Text = no;
                //lb.Name = no;
                //lb.Font = new Font("Arial", 12, FontStyle.Regular);
                ////Label for patint No
                //lb = new Label();
                //lb.Left = left3;
                //lb.Top = top3;
                //this.Controls.Add(lb);
                //top3 += lb.Height + 2;
                //lb.Text = "";
                //lb.Name = no;
                //lb.Font = new Font("Arial", 12, FontStyle.Regular);
                //ListView
                //lvi = new ListViewItem(ro);
                //lvi.Name = no;
                //lvi.SubItems.Add(ss);
                //lvi.SubItems.Add(no);
                //lvi.SubItems.Add("");
                //listView1.Items.Add(lvi);

                //lvi2 = new ListViewItem(no);
                //lvi2.SubItems.Add(no);
                //listView1.Items.Add(lvi2);
            }

        }
        Label lab = new Label();
        Button button = new Button();
        TextBox txt = new TextBox();
        ListViewItem item = new ListViewItem();
        int top = 125;
        int left = 1;
        //
        int top1 = 125;
        int left1 = 160;
        //
        int top2 = 125;
        int left2 = 290;

        int top3 = 125;
        int left3 = 421;
        public List<TextBox> getvalue()
        {
            return l1;
        }


        public void Display_Load(object sender, EventArgs e)
        {
            timer1.Start();
            callonLoad();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.label5.Text = dt.ToString("yyyy-MM-dd");
            this.label6.Text = dt.ToString("hh:mm tt");
        }

        TextBox tt = new TextBox();
        public void callonLoad()
        {
            con.GetConnectionDB();
            //updatechecklistDisplay();
            Console.WriteLine(l1);
            con.GetClose();

            pictureBox1.Image = Properties.Resources.img1;
            wmp.URL = "October Clinic .mp4";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            wmp.uiMode = "None";
        }
        public void updatechecklistDisplay()
        {
            foreach (CheckBox checkBox in Dashboard.instance.checkedList)
            {
                var controls = this.Controls.Find(checkBox.Name, true);
                if (controls != null)
                {
                    foreach (var control in controls)
                        if (control is Label)
                            control.Visible = true;
                }
                if (!l3.Contains(checkBox.Text))
                {
                    //Console.WriteLine(checkBox.Text);
                    //lb = new Label();
                    //lb.Left = left;
                    //lb.Top = top;
                    //this.Controls.Add(lb);
                    //top += lb.Height + 2;
                    //lb.Text = checkBox.Text;
                    //lb.Name = checkBox.Name;
                    //lb.Font = new Font("Arial", 12, FontStyle.Regular);

                    //bt.Click += new EventHandler(this.button_click);
                    //lb = new Label();
                    //lb.Left = left1;
                    //lb.Top = top1;
                    //this.Controls.Add(lb);
                    //top1 += lb.Height + 2;
                    //lb.Height = 50;
                    //lb.Width = 123;
                    //lb.Text = checkBox.AccessibleName;
                    //lb.Name = checkBox.Name;
                    //lb.Font = new Font("Arial", 12, FontStyle.Regular);



                    //lb = new Label();
                    //lb.Left = left2;
                    //lb.Top = top2;
                    //this.Controls.Add(lb);
                    //top2 += lb.Height + 2;
                    //lb.Height = 50;
                    //lb.Width = 123;
                    //lb.Text = checkBox.Name;
                    //lb.Name = checkBox.Name;
                    //lb.Font = new Font("Arial", 12, FontStyle.Regular);

                    //lb = new Label();
                    //lb.Left = left3;
                    //lb.Top = top3;
                    //this.Controls.Add(lb);
                    //top3 += lb.Height + 2;
                    //lb.Height = 50;
                    //lb.Width = 123;
                    //lb.Text = "";
                    //lb.Name = checkBox.Name;
                    //lb.Font = new Font("Arial", 12, FontStyle.Regular);

                    //lvi = new ListViewItem(checkBox.Text);
                    //lvi.Name = checkBox.Name;
                    //lvi.SubItems.Add(checkBox.AccessibleName);
                    //lvi.SubItems.Add(checkBox.Name);
                    //listView1.Items.Add(lvi);

                    string[] row = new string[] { checkBox.Text, checkBox.AccessibleName, checkBox.Name };
                    dataGridView1.Rows.Add(row);

                    l3.Add(checkBox.Text);
                }

            }
        }
        public void removeButtonDisplay()
        {
            foreach (CheckBox checkBox in Dashboard.instance.uncheckedList)
            {
                if (l3.Contains(checkBox.Text))
                {
                    var controls = this.Controls.Find(checkBox.Name, true);
                    var labels = this.Controls.Find(checkBox.Name, true);
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

                        //Display.instance.lv.Items[item.Index].Remove();


                    }
                    //l3.Remove(checkBox.Name);
                    //foreach (var control in controls)
                    //    if (control is Label)
                    //        control.Visible = false;
                    //listView1.Items.RemoveAt(selected)
                    //listView1.Items.RemoveByKey(Name);
                    //foreach (var control in labels)
                    //    if (control is Label)
                    //        control.Visible=false;
                    //l3.Remove(checkBox.Text);

                }
                //if (l3.Contains(checkBox.Text))
                //{
                //    var controls = this.Controls.Find(checkBox.Name, true);
                //    //var labels = this.Controls.Find(checkBox.Name, true);
                //    foreach (var control in controls)
                //        if (control is TextBox)
                //            control.Visible = false;
                //    //foreach (var control in labels)
                //    //    if (control is Label)
                //    //        control.Visible=false;
                //    //l3.Remove(checkBox.Text);

                //}

            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void wmp_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            wmp.settings.setMode("loop", true);
            if (wmp.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                wmp.Ctlcontrols.play();

            }
        }

        
        private void Display_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
   
}






