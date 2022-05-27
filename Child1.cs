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

        //Aici se afla conectionstringul cu denumirea la server si numele la baza de date
        SqlConnection sqlConnection = new SqlConnection("Server = REVISION-PC; Database=ceauto;Trusted_Connection=True;");

        //V-a fi folosit pentru a declansa niste evenimente

        Boolean LUCREAZA = true;

        //Este folosit pentru a afisa sau ascunde niste controale 
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
            // Incarca informata in datagridview
            this.conf_autoTableAdapter.Fill(this.ceautoDataSet.conf_auto);
            // Incarca informata in datagridview
            this.deal_autoTableAdapter.Fill(this.ceautoDataSet.deal_auto);

        }

        //Un swich care transfromeaza forma 
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

        //Daca faci click pe datagridview informatia v-a fi copiata in campurile respective
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

            {   //Daca butonul adauga lucreaza si foma nu e in stare de editare se genereaza un string care v-a executa procedurile
                string addeal_q = "exec adddeal '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox5.Text + "'," + ((float)numericUpDown1.Value) + " ,'" + comboBox1.Text + "'";

                //Daca checkboxul "Adauga configuratie" este activat atunci se adauga con figuratie si 
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

                //Executa un sting generati mai in sus
                SqlCommand adddeal = new SqlCommand(addeal_q, sqlConnection);
                try
                {

                    sqlConnection.Open();
                    adddeal.ExecuteNonQuery();

                }
                catch (Exception ex) 
                {
                    //Din caz de esec ne afiseaza eroare
                    MessageBox.Show("eroare");
                }
                finally
                {
                    sqlConnection.Close();
                }
                //In caz orice caz conectiunea se inchide

                //Se creaza un rind de date 
                DataRow dr = ceautoDataSet.deal_auto.NewRow();

               //incearca sa faca puch la informatie in rindul local
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

                //se curata controalele
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
                //din caz daca nu lucreaza sau e in editare el afiseaza mesajele respective
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
            //se afiseaza controlul pentru o noua forma
            checkBox2.Show();

            //Se dezactiveaza metoda de introducere a seriei (cheii primare)
            textBox1.Enabled = false;

            //Daca se alege randul -1 atunci da eroare
            if (e.RowIndex >= 0)
            {
                //Se introduce din tabel in casete pentru modificare
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["serialDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["producerDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["modelDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["configDataGridViewTextBoxColumn"].Value.ToString().Trim();
                numericUpDown1.Text = dataGridView1.Rows[e.RowIndex].Cells["priceDataGridViewTextBoxColumn"].Value.ToString().Trim();
                
                comboBox1.ResetText();
                comboBox1.SelectedText = dataGridView1.Rows[e.RowIndex].Cells["usedDataGridViewTextBoxColumn"].Value.ToString().Trim();
           
            }
            

        }

        //Nu da voie sa se modifice si sa se adauga simultan
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
            //Daca controlul lucreaza 
            if (LUCREAZA)
            { 
                //Atunci se creaza comanda folosind informatia din casetele
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

                //Face refresh in tabel
                button5.PerformClick();

                checkBox2.Hide();

            }
        }

        //Raspune de resetarea la toate controlalele
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

        //Raspunde de refresh (Actuakizeaza datele dupa baza de date
        private void button5_Click(object sender, EventArgs e)
        {
            this.deal_autoTableAdapter.Fill(this.ceautoDataSet.deal_auto);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Creaza o comnada care v-a sterge 
            string addconf_c = "exec rmdeal '" + textBox1.Text + "'";

            //Comanda se pregateste pentru executie
            SqlCommand addconf = new SqlCommand(addconf_c, sqlConnection);
            try
            { //comanda se executa
                sqlConnection.Open();
                addconf.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare");
            }
            finally
            {   //in orice caz conectiune see inchide
                sqlConnection.Close();
            }

            //Se face reset
            button5.PerformClick();
        }

 

  
        //Face refresh la tableul config
        private void button6_Click(object sender, EventArgs e)
        {
            this.conf_autoTableAdapter.Fill(this.ceautoDataSet.conf_auto);
        }

        //Reseteaza casetele
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

                //creaza o comanda folosind inforematia din casete 
                string addconf_c = "exec addconf '" + textBox_con.Text + "','" + textBox_col.Text + "','" + textBox_mot.Text + "','" + textBox_cor.Text + "','" + textBox_cut.Text + "','" + textBox_ext.Text + "'";
                
                //comanda se pregateste pentru executie
                SqlCommand addconf = new SqlCommand(addconf_c, sqlConnection);
                try
                {
                    //Se deschide conectiunea
                    sqlConnection.Open();
                    //Se executaa comanda
                    addconf.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("eroare");
                }
                finally
                {
                    //In orice caz se inchide conectiunea
                    sqlConnection.Close();
                }


          
        }

      

        private void button8_Click(object sender, EventArgs e)
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

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {   //se deschide aplicatia excel cu un worksheet gol
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Records";

                //copie denumirile la coloane si copie informatia din datagridview in celulele respective
                try
                {
                    for (int i = 0; i < dataGridView2.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dataGridView2.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            if (dataGridView2.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }

                    //Face save la acest document 
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 2;

                    //in caz de success afiseaza mesajul dat
                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Success");
                    }
                }
                catch (System.Exception ex)
                {
                    //In caz contrar v-a afisa eroarea
                    MessageBox.Show(ex.Message);
                }

                finally
                {   //la sfarsit se v-a inchide aplicatia excell si se v-a golii spatiul de munca
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }
            }   //In caz contrar v-a afisa eroarea
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void panel_add_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
