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
    public partial class Child2 : Form
    {

        SqlConnection sqlConnection = new SqlConnection("Server = REVISION-PC; Database=ceauto;Trusted_Connection=True;");

        public Child2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {


                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["serialDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["producerDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["modelDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["configDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["tarifminDataGridViewTextBoxColumn"].Value.ToString().Trim();


            }

            textBox1.Enabled = false;
            
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


        }

        private void button4_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox1.Enabled = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.arenda_autoTableAdapter.Fill(this.ceautoDataSet.arenda_auto);
        }

        private void button1_Click(object sender, EventArgs e)
        {



            string addarenda_Q = "exec addarenda '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox4.Text + "'";

            SqlCommand addarenda = new SqlCommand(addarenda_Q, sqlConnection);

            if(textBox1.Enabled)
            try
            {

                sqlConnection.Open();
                addarenda.ExecuteNonQuery();
                    button4.PerformClick();
            }
            catch (Exception ex)
            {

                MessageBox.Show("eroare : " + ex.Message + "");

               

            }
            finally
            {
                sqlConnection.Close();

            }
            else

            {
                MessageBox.Show("NU see poate de adaugat in edit mode");
            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            string editarenda_Q = "exec editarenda '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox4.Text + "'";

            SqlCommand addarenda = new SqlCommand(editarenda_Q, sqlConnection);

            
                try
                {

                    sqlConnection.Open();
                    addarenda.ExecuteNonQuery();
                     button4.PerformClick();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("eroare : " + ex.Message + "");

                    button4.PerformClick();

                }
                finally
                {
                    sqlConnection.Close();
                    button5.PerformClick();
                }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            string rmarenda = "exec rmarenda '" + textBox1.Text + "'";

            SqlCommand edarenda = new SqlCommand(rmarenda, sqlConnection);


            try
            {

                sqlConnection.Open();
                edarenda.ExecuteNonQuery();
                button4.PerformClick();

            }
            catch (Exception ex)
            {

                MessageBox.Show("eroare : " + ex.Message + "");

                button4.PerformClick();

            }
            finally
            {
                sqlConnection.Close();
                button5.PerformClick();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Records";

                try
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }

                    //Getting the location and file name of the excel to save from user. 
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 2;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Export Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
    }
}
