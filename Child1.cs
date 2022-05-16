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

        public void swichconfshow()
        {

            if (checkBox1.Checked)
            {
                lab_con.Show();
                lab_col.Show();
                lab_cor.Show();
                lab_cut.Show();
                lab_ext.Show();
                lab_mot.Show();
                textBox_con.Show();
                textBox_col.Show();
                textBox_cor.Show();
                textBox_cut.Show();
                textBox_ext.Show();
                textBox_mot.Show();
                textBox5.Enabled = false;
            }
            else
            {
                lab_con.Hide();
                lab_col.Hide();
                lab_cor.Hide();
                lab_cut.Hide();
                lab_ext.Hide();
                lab_mot.Hide();
                textBox_con.Hide();
                textBox_col.Hide();
                textBox_cor.Hide();
                textBox_cut.Hide();
                textBox_ext.Hide();
                textBox_mot.Hide();
                textBox5.Enabled = true;
            }

        }

        
        private void Child1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ceautoDataSet1.deal_auto' table. You can move, or remove it, as needed.
            this.deal_autoTableAdapter.Fill(this.ceautoDataSet1.deal_auto);
            // TODO: This line of code loads data into the 'ceautoDataSet.deal_auto' table. You can move, or remove it, as needed.
            this.deal_autoTableAdapter.Fill(this.ceautoDataSet.deal_auto);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            swichconfshow();

        }

        private void panel_add_Paint(object sender, PaintEventArgs e)
        {
            ///stergi
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
