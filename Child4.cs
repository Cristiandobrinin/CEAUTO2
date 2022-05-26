using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CEAUTO2
{
    public partial class Child4 : Form
    {

        SqlConnection sqlConnection = new SqlConnection("Server = REVISION-PC; Database=ceauto;Trusted_Connection=True;");

        public Child4()
        {
            InitializeComponent();
        }

        private void Child4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ceautoDataSet.client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.ceautoDataSet.client);

        }

        public string idcurent;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idcurent = dataGridView1.Rows[e.RowIndex].Cells["idclientDataGridViewTextBoxColumn"].Value.ToString().Trim();
              
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["IDNPDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["NumeDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["prenumeDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["emailDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["tellDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["adressaDataGridViewTextBoxColumn"].Value.ToString().Trim();



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string addconf_c = "exec addclient '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "'";

            SqlCommand addconf = new SqlCommand(addconf_c, sqlConnection);
            try
            {

                sqlConnection.Open();
                addconf.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare");
            }
            finally
            {
                sqlConnection.Close();
            }

            button5.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.clientTableAdapter.Fill(this.ceautoDataSet.client);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string addconf_c = "exec rmclient '" + idcurent + "'";

            SqlCommand addconf = new SqlCommand(addconf_c, sqlConnection);
            try
            {

                sqlConnection.Open();
                addconf.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare");
            }
            finally
            {
                sqlConnection.Close();
            }

            button5.PerformClick();
            button4.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string addconf_c = "exec editclient '" + idcurent + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "'";

            SqlCommand addconf = new SqlCommand(addconf_c, sqlConnection);
            try
            {

                sqlConnection.Open();
                addconf.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare");
            }
            finally
            {
                sqlConnection.Close();
            }

            button5.PerformClick();
            button4.PerformClick();
        }
    }
}
