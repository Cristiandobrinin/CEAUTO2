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
    public partial class Child2 : Form
    {
        public Child2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
//sterge
        }

        private void dealautoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Child2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ceautoDataSet.arenda_auto' table. You can move, or remove it, as needed.
            this.arenda_autoTableAdapter.Fill(this.ceautoDataSet.arenda_auto);
            // TODO: This line of code loads data into the 'ceautoDataSet.arenda_cont' table. You can move, or remove it, as needed.
            this.arenda_contTableAdapter.Fill(this.ceautoDataSet.arenda_cont);
            // TODO: This line of code loads data into the 'ceautoDataSet1.deal_cont' table. You can move, or remove it, as needed.
            this.deal_contTableAdapter.Fill(this.ceautoDataSet1.deal_cont);

        }
    }
}
