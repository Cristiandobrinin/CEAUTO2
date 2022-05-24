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
    public partial class Administration : Form
    {
        public Administration()
        {
            InitializeComponent();
        }

        private void Administration_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ceautoDataSet.logins' table. You can move, or remove it, as needed.
            this.loginsTableAdapter.Fill(this.ceautoDataSet.logins);

        }
    }
}
