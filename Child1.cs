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
    public partial class Child1 : Form
    {
        public Child1()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection("Server = REVISION-PC; Database=ceauto;Trusted_Connection=True;");


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //sterge nahui
        }

        public void swichconfshow()
        {

            if (checkBox1.Checked||checkBox2.Checked)
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
            // TODO: This line of code loads data into the 'ceautoDataSet.deal_auto' table. You can move, or remove it, as needed.
            this.deal_autoTableAdapter.Fill(this.ceautoDataSet.deal_auto);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string addeal_q = "exec adddeal '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox5.Text + "'," + ((float)numericUpDown1.Value) + " ,'" + comboBox1.Text + "'";


            if (checkBox1.Checked )
            {
                string addconf_c = "exec addconf '" + textBox_con.Text + "','" + textBox_col.Text + "','" + textBox_mot.Text + "','" + textBox_cor.Text + "','" + textBox_cut.Text + "','" + textBox_ext.Text + "'";

                SqlCommand addconf = new SqlCommand(addconf_c, sqlConnection);
                sqlConnection.Open();
                addconf.ExecuteNonQuery();
                sqlConnection.Close();


                addeal_q = "exec adddeal '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox_con.Text + "'," + ((float)numericUpDown1.Value) + " ,'" + comboBox1.Text + "'";
            }

            SqlCommand adddeal = new SqlCommand(addeal_q, sqlConnection);
            sqlConnection.Open();
            adddeal.ExecuteNonQuery();
            sqlConnection.Close();


            DataRow dr = ceautoDataSet.deal_auto.NewRow();

            dr["serial"] = textBox1.Text;
            dr["producer"] = textBox2.Text;
            dr["model"] = textBox3.Text;
            dr["config"] = textBox5.Text;
            dr["price"] = numericUpDown1.Value;
            dr["used"] = comboBox1.Text;
            ceautoDataSet.deal_auto.Rows.Add(dr);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            numericUpDown1.ResetText();
            comboBox1.ResetText();

            textBox_col.Clear();
            textBox_con.Clear();
            textBox_cor.Clear();
            textBox_cut.Clear();
            textBox_ext.Clear();
            textBox_mot.Clear();




        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            checkBox2.Show(); label9.Show();

            textBox1.Enabled = false;

            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["serialDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["producerDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["modelDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["configDataGridViewTextBoxColumn"].Value.ToString().Trim();
                numericUpDown1.Text = dataGridView1.Rows[e.RowIndex].Cells["priceDataGridViewTextBoxColumn"].Value.ToString().Trim();
                
                comboBox1.ResetText();
                comboBox1.SelectedText = dataGridView1.Rows[e.RowIndex].Cells["usedDataGridViewTextBoxColumn"].Value.ToString().Trim();
           
            }
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            { 
                swichconfshow();
                checkBox2.Checked = false;
            }
            else
            {
                swichconfshow();
            }
            
           

        }



        private void button2_Click(object sender, EventArgs e)
        {

            string edit_d = "exec editdeal '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox5.Text + "'," + ((float)numericUpDown1.Value) + " ,'" + comboBox1.Text + "'";

            SqlCommand edit_q = new SqlCommand(edit_d, sqlConnection);
            sqlConnection.Open();
            edit_q.ExecuteNonQuery();
            sqlConnection.Close();

            button5.PerformClick();

            checkBox2.Hide(); label9.Hide();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            numericUpDown1.ResetText();
            comboBox1.ResetText();

            textBox_col.Clear();
            textBox_con.Clear();
            textBox_cor.Clear();
            textBox_cut.Clear();
            textBox_ext.Clear();
            textBox_mot.Clear();

            textBox1.Enabled = true;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.deal_autoTableAdapter.Fill(this.ceautoDataSet.deal_auto);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string addconf_c = "exec rmdeal '" + textBox1.Text + "'";

            SqlCommand addconf = new SqlCommand(addconf_c, sqlConnection);
            sqlConnection.Open();
            addconf.ExecuteNonQuery();
            sqlConnection.Close();

            button5.PerformClick();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                swichconfshow();
                checkBox1.Checked = false;
            }
            else
            {
                swichconfshow();
            }

        }
    }
}
