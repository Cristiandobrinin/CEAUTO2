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
          
        }

        public Boolean LUCREAZA = true;

     

        public bool checkconf()
        {
            Boolean found = false;

            foreach (DataGridViewRow row in this.dataGridView2.Rows)
            {
                if (row.Cells[0].Value.Equals(textBox_con.Text))
                {

                    found = true;

                    break;
                }


            }

            return found;
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
            // TODO: This line of code loads data into the 'ceautoDataSet.conf_auto' table. You can move, or remove it, as needed.
            this.conf_autoTableAdapter.Fill(this.ceautoDataSet.conf_auto);
            // TODO: This line of code loads data into the 'ceautoDataSet.deal_auto' table. You can move, or remove it, as needed.
            this.deal_autoTableAdapter.Fill(this.ceautoDataSet.deal_auto);

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                dataGridView2.Show();
                dataGridView1.Hide();


                panel2.Show();

                swichconfshow();
                checkBox1.Checked = false;


                 LUCREAZA = false;
            }
            else
            {


                LUCREAZA = true;



                panel2.Hide();

                dataGridView1.Show();
                dataGridView2.Hide();

                swichconfshow();


                textBox_col.Clear();
                textBox_con.Clear();
                textBox_cor.Clear();
                textBox_cut.Clear();
                textBox_ext.Clear();
                textBox_mot.Clear();
            }

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           

            if (e.RowIndex >= 0)
            {


                textBox_col.Text = dataGridView2.Rows[e.RowIndex].Cells["color"].Value.ToString().Trim();
                textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn4"].Value.ToString().Trim();
                textBox_cor.Text = dataGridView2.Rows[e.RowIndex].Cells["body"].Value.ToString().Trim();
                textBox_mot.Text = dataGridView2.Rows[e.RowIndex].Cells["engine"].Value.ToString().Trim();
                textBox_cut.Text = dataGridView2.Rows[e.RowIndex].Cells["box"].Value.ToString().Trim();
                textBox_ext.Text = dataGridView2.Rows[e.RowIndex].Cells["extras"].Value.ToString().Trim();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LUCREAZA && textBox1.Enabled )

            { 
                string addeal_q = "exec adddeal '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox5.Text + "'," + ((float)numericUpDown1.Value) + " ,'" + comboBox1.Text + "'";


                if (checkBox1.Checked )
                {
                    string addconf_c = "exec addconf '" + textBox_con.Text + "','" + textBox_col.Text + "','" + textBox_mot.Text + "','" + textBox_cor.Text + "','" + textBox_cut.Text + "','" + textBox_ext.Text + "'";

                    SqlCommand addconf = new SqlCommand(addconf_c, sqlConnection);
                    try
                    {

                        sqlConnection.Open();
                        addconf.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("eroare : "+ex.Message+"");
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }


                    addeal_q = "exec adddeal '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox_con.Text + "'," + ((float)numericUpDown1.Value) + " ,'" + comboBox1.Text + "'";
                }

                SqlCommand adddeal = new SqlCommand(addeal_q, sqlConnection);
                try
                {

                    sqlConnection.Open();
                    adddeal.ExecuteNonQuery();

                }
                catch (Exception ex) 
                {
                    MessageBox.Show("eroare");
                }
                finally
                {
                    sqlConnection.Close();
                }


                DataRow dr = ceautoDataSet.deal_auto.NewRow();

               
                try
                {

                    dr["serial"] = textBox1.Text;
                    dr["producer"] = textBox2.Text;
                    dr["model"] = textBox3.Text;
                    dr["config"] = textBox5.Text;
                    dr["price"] = numericUpDown1.Value;
                    dr["used"] = comboBox1.Text;
                    ceautoDataSet.deal_auto.Rows.Add(dr);

                }
                catch
                {

                }


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
            else
            {

                if(!LUCREAZA)
                {
                    MessageBox.Show("Nu functioneaza in timp ce se editeaza configuri");
                }
                else
                if (!textBox1.Enabled)
                {
                    MessageBox.Show("Nu poate fi adaugat deoarece exista in baza de date");
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            checkBox2.Show();

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
            if (LUCREAZA)
            {
                string edit_d = "exec editdeal '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox5.Text + "'," + ((float)numericUpDown1.Value) + " ,'" + comboBox1.Text + "'";

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

                checkBox2.Hide();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
      

            if (LUCREAZA)
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.deal_autoTableAdapter.Fill(this.ceautoDataSet.deal_auto);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string addconf_c = "exec rmdeal '" + textBox1.Text + "'";

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

 

  

        private void button6_Click(object sender, EventArgs e)
        {
            this.conf_autoTableAdapter.Fill(this.ceautoDataSet.conf_auto);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            textBox_col.Clear();
            textBox_con.Clear();
            textBox_cor.Clear();
            textBox_cut.Clear();
            textBox_ext.Clear();
            textBox_mot.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (checkconf())
            {
                MessageBox.Show("Row already exists");

            }

            else
            {

                string addconf_c = "exec addconf '" + textBox_con.Text + "','" + textBox_col.Text + "','" + textBox_mot.Text + "','" + textBox_cor.Text + "','" + textBox_cut.Text + "','" + textBox_ext.Text + "'";

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


            }

          
        }

      

        private void button8_Click(object sender, EventArgs e)
        {
            if (!checkconf())
            {
                MessageBox.Show("Row already exists");

            }

            else
            { 

             string addconf_c = "exec rmconf '" + textBox_con.Text + "'";

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

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string editconf;

            if (checkBox3.Checked)
            { 
                editconf = "exec editconf '" + textBox_con.Text + "','" + textBox_col.Text + "','" + textBox_mot.Text + "','" + textBox_cor.Text + "','" + textBox_cut.Text + "','" + textBox_ext.Text + "'";
            }
            else
            {
                editconf = "exec editconf_tobase '"+ textBox5.Text +"'" + textBox_con.Text + "','" + textBox_col.Text + "','" + textBox_mot.Text + "','" + textBox_cor.Text + "','" + textBox_cut.Text + "','" + textBox_ext.Text + "'";
            }

            SqlCommand edconf = new SqlCommand(editconf, sqlConnection);
            try
            {

                sqlConnection.Open();
                edconf.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked)
            {
                textBox5.Enabled = false;
                textBox_con.Text = textBox5.Text;

            }
            else
            {
                textBox_con.Clear();
            }    
        }
    }
}
