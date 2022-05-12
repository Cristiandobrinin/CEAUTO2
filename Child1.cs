using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEAUTO2
{
    public partial class Child1 : Form
    {
        public Child1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //sterge nahui
        }

        private void Child1_Load(object sender, EventArgs e)
        {
            logo1.Show();
            add1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add1.Show(); logo1.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
