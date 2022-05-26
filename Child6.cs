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
    public partial class Child6 : Form
    {
        public Child6()
        {
            InitializeComponent();
        }

        string idcurent;

        private void Child6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ceautoDataSet1.arenda_cont' table. You can move, or remove it, as needed.
            this.arenda_contTableAdapter.Fill(this.ceautoDataSet1.arenda_cont);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idcurent = dataGridView1.Rows[e.RowIndex].Cells["idcontractDataGridViewTextBoxColumn"].Value.ToString().Trim();

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["serialDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["idclientDataGridViewTextBoxColumn"].Value.ToString().Trim();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells["dataintocmiriiDataGridViewTextBoxColumn"].Value.ToString().Trim();
                dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells["datastartDataGridViewTextBoxColumn"].Value.ToString();
                dateTimePicker3.Text = dataGridView1.Rows[e.RowIndex].Cells["dataendDataGridViewTextBoxColumn"].Value.ToString();

                textBox_zi.Text = dataGridView1.Rows[e.RowIndex].Cells["tarifperziDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells["spreplataDataGridViewTextBoxColumn"].Value.ToString().Trim();

            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.arenda_contTableAdapter.Fill(this.ceautoDataSet1.arenda_cont);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            dateTimePicker1.Text = null;
            dateTimePicker2.Text = null;
            dateTimePicker3.Text = null;

            textBox_zi.Text = null;
            textBox11.Text = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string indate = (dateTimePicker1.Value.Date).ToString("yyyyMMdd");

            string startdate = (dateTimePicker2.Value.Date).ToString("yyyyMMdd");

            string enddate = (dateTimePicker3.Value.Date).ToString("yyyyMMdd");

            SqlConnection sqlConnection = new SqlConnection("Server = REVISION-PC; Database=ceauto;Trusted_Connection=True;");


            string edit_d = "exec addcontarenda '" + textBox1.Text + "','" + textBox2.Text + "','" + indate + "','" + startdate + "','"+enddate+"','" + textBox_zi.Text + "','"+textBox11.Text+"'";
            SqlCommand edit_q = new SqlCommand(edit_d, sqlConnection);

            try
            {

                sqlConnection.Open();
                edit_q.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("eroare  : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            button5.PerformClick();
            button4.PerformClick();

        }

        public float calcarenda(float Mperday)
        {
            float spre = 0;

            DateTime start = dateTimePicker2.Value;
            DateTime end = dateTimePicker3.Value;

            TimeSpan diff = end - start ;

            int diffcifr = diff.Days;

            if(diffcifr > 0)
            switch (diffcifr)
            {

                case (1|2):

                    spre = Mperday * diffcifr;

                    break;

                case (3|4|5|6):

                    spre = ((float)(Mperday * diffcifr * 0.75));

                    break;

                case (7|8|9|10|11|12):

                    spre = ((float)(Mperday * diffcifr * 0.65));

                    break;

                default:
                    spre = ((float)(Mperday * diffcifr * 0.55));

                    break;


            }





            return spre;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            string no = textBox_zi.Text;

            double fin = 0;

            if (Int32.TryParse(no,out int f))
            {
            }
            else
            {
                Console.WriteLine("Valoarea introdusa nu este un numar,");
            }

           textBox11.Text = calcarenda(f).ToString();
            
        }

        private void textBox_zi_TextChanged(object sender, EventArgs e)
        {
            button6.PerformClick();
        }
    }
}
