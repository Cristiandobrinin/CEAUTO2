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

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.conf_autoTableAdapter.FillBy(this.ceautoDataSet.conf_auto);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
