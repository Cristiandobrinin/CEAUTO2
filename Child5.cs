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
    public partial class Child5 : Form
    {

        SqlConnection sqlConnection = new SqlConnection("Server = REVISION-PC; Database=ceauto;Trusted_Connection=True;");

        public string idcurent;
        public Child5()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //delete 

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Child5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ceautoDataSet.deal_cont' table. You can move, or remove it, as needed.
            this.deal_contTableAdapter.Fill(this.ceautoDataSet.deal_cont);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = dateTimePicker4.Text = textBox5.Text = textBox6.Text  = textBox10.Text = null;
        }

        private void panel_child4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string indate = (dateTimePicker4.Value.Date).ToString("yyyyMMdd");


            string edit_d = "exec addcont '" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + indate + "',null,'"+textBox5.Text+ "'";
            SqlCommand edit_q = new SqlCommand(edit_d, sqlConnection);

            try
            {

                sqlConnection.Open();
                edit_q.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare "+indate+" : " + ex.Message ) ;
            }
            finally
            {
                sqlConnection.Close();
            }

            button5.PerformClick();
            button4.PerformClick();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idcurent = dataGridView1.Rows[e.RowIndex].Cells["idcontractDataGridViewTextBoxColumn"].Value.ToString().Trim() ;

                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["idemplDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["idclientDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["serialDataGridViewTextBoxColumn"].Value.ToString().Trim();
                dateTimePicker4.Text = dataGridView1.Rows[e.RowIndex].Cells["dataintocmiriiDataGridViewTextBoxColumn"].Value.ToString() ;
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["sumaDataGridViewTextBoxColumn"].Value.ToString().Trim();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.deal_contTableAdapter.Fill(this.ceautoDataSet.deal_cont);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string indate = (dateTimePicker4.Value.Date).ToString("dd/MM/yyyy");


            string edit_d = "exec editcont '"+ idcurent +"','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + indate + "',null,'" + textBox5.Text + "'";
            SqlCommand edit_q = new SqlCommand(edit_d, sqlConnection);

            try
            {

                sqlConnection.Open();
                edit_q.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            button5.PerformClick();
            button4.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string edit_d = "exec rmcont '" + idcurent + "'";
            SqlCommand edit_q = new SqlCommand(edit_d, sqlConnection);

            try
            {

                sqlConnection.Open();
                edit_q.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare : " + ex.Message);
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
