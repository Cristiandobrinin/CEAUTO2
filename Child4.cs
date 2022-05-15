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
    public partial class Child4 : Form
    {
        public Child4()
        {
            InitializeComponent();
        }

        private void Child4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ceautoDataSet.client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.ceautoDataSet.client);

        }
    }
}
