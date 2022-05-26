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
    public partial class Child3 : Form
    {

        SqlConnection sqlConnection = new SqlConnection("Server = REVISION-PC; Database=ceauto;Trusted_Connection=True;");
        

        public Child3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Enabled = false;
            if (e.RowIndex >= 0)
            {


                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id_empl"].Value.ToString().Trim();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["nume"].Value.ToString().Trim();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["prenume"].Value.ToString().Trim();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["tell"].Value.ToString().Trim();
              //  textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["salariu"].Value.ToString().Trim();
              //  textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["addresa"].Value.ToString().Trim();
                

            }
        }

        private void Child3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ceautoDataSet.empl_data' table. You can move, or remove it, as needed.
            //this.empl_dataTableAdapter.Fill(this.ceautoDataSet.empl_data);
            // TODO: This line of code loads data into the 'ceautoDataSet.employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.ceautoDataSet.employee);

        }

        private void button4_Click(object sender, EventArgs e)
        {



            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = null;
            textBox1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.employeeTableAdapter.Fill(this.ceautoDataSet.employee);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string edit_d = "exec addempl '" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "', '" + textBox4.Text + "'";
            SqlCommand edit_q = new SqlCommand(edit_d, sqlConnection);

            try
            {

                sqlConnection.Open();
                edit_q.ExecuteNonQuery();

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox5.Show();
                textBox6.Show();
                textBox7.Show();
                textBox8.Show();

                label10.Show();
                label9.Show();
                label7.Show();
                label5.Show();
            }
            else
            {
                textBox5.Hide();
                textBox6.Hide();
                textBox7.Hide();
                textBox8.Hide();

                label10.Hide();
                label9.Hide();
                label7.Hide();
                label5.Hide();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string edit_d = "exec rmempl '"+textBox1.Text +"'";
            SqlCommand edit_q = new SqlCommand(edit_d, sqlConnection);

            try
            {

                sqlConnection.Open();
                edit_q.ExecuteNonQuery();

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
