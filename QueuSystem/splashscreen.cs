using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueuSystem
{
    public partial class splashscreen : Form
    {
        public static splashscreen instance;
        Label lbNo;
        Label lbclinic;
        public splashscreen( string no, string clinic, string letter)
        {
            InitializeComponent();
            lbNo = new Label();
            lbclinic = new Label();
            lbNo.Text = no;
            lbclinic.Text = clinic;
            //instance = this;
            label2.Text = letter+"-"+no;
            label4.Text = clinic;
            this.BackColor = Color.AliceBlue;
            //this.TransparencyKey = Color.AliceBlue;
            //lbNo = label2;
            //lbclinic = label4;
        }

        private void splashscreen_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
        }

        private void splashscreen_Shown(object sender, EventArgs e)
        {
            timer1 = new Timer();
            timer1.Interval = 3000; timer1.Start();
            timer1.Tick += timer1_Tick;
        }
    }
}
