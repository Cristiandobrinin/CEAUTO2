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
    public partial class Child6 : Form
    {
        public Child6()
        {
            InitializeComponent();
        }

        private void Child6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ceautoDataSet1.arenda_cont' table. You can move, or remove it, as needed.
            this.arenda_contTableAdapter.Fill(this.ceautoDataSet1.arenda_cont);

        }
    }
}
