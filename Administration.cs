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
using System.Security.Cryptography;
namespace CEAUTO2
{
    public partial class Administration : Form
    {

        SqlConnection sqlConnection = new SqlConnection("Server = REVISION-PC; Database=ceauto;Trusted_Connection=True;");

        public Administration()
        {
            InitializeComponent();
        }

        static string sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }


        private void Administration_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ceautoDataSet.logins' table. You can move, or remove it, as needed.
            this.loginsTableAdapter.Fill(this.ceautoDataSet.logins);

        }

        public string toserv()
        {


            switch (comboBox1.Text)
            {
                case "Angajat Dealer":

                    return "D1";

                    break;
                case "Angajat Arenda":

                    return "A1";
                    break;

                case "Manager":

                    return "M1";
                    break;

                case "Oaspete":
                    return "G1";
                    break;
                default:

                    MessageBox.Show("Privilegii invalide");

                    return null;
                    break;


            }
        }

            public string fromserv(string thing)
            {


                switch (thing)
                {
                    case "D1":

                        return "Angajat Dealer";

                        break;
                    case "A1":

                        return "Angajat Arenda";
                        break;

                    case "M1":

                        return "Manager";
                        break;

                     case "G1":

                    return "Oaspete";
                    break;

                default:

                        MessageBox.Show("Privilegii invalide");

                        return null;
                        break;


                }



            }

        private void button2_Click(object sender, EventArgs e)
        {

            string login = textBox1.Text;
            string password = sha256(textBox2.Text);
            string priv = toserv();

            string addacc = "exec editpriv '" + login + "','" + password + "', '" + priv + "'";

            SqlCommand addacc_q = new SqlCommand(addacc, sqlConnection);

            if (textBox1.Enabled)
                try
                {

                    sqlConnection.Open();
                    addacc_q.ExecuteNonQuery();
                    button4.PerformClick();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("eroare : " + ex.Message + "");



                }
                finally
                {
                    sqlConnection.Close();
                    button5.PerformClick();
                    button4.PerformClick();

                }
            else

            {
                MessageBox.Show("NU see poate de adaugat in edit mode");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.loginsTableAdapter.Fill(this.ceautoDataSet.logins);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = comboBox1.Text = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {


                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["loginsDataGridViewTextBoxColumn"].Value.ToString().Trim();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["passwdDataGridViewTextBoxColumn"].Value.ToString().Trim();
                comboBox1.Text = fromserv(dataGridView1.Rows[e.RowIndex].Cells["privilegesDataGridViewTextBoxColumn"].Value.ToString().Trim());


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string login = textBox1.Text;
            string password = sha256(textBox2.Text);
            string priv = toserv();

            string addacc = "exec addlogin '" + login + "','" + password + "', '" + priv + "'";

            SqlCommand addacc_q = new SqlCommand(addacc, sqlConnection);

            if (textBox1.Enabled)
                try
                {

                    sqlConnection.Open();
                    addacc_q.ExecuteNonQuery();
                    button4.PerformClick();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("eroare : " + ex.Message + "");



                }
                finally
                {
                    sqlConnection.Close();
                    button5.PerformClick();
                    button4.PerformClick();

                }
            else

            {
                MessageBox.Show("NU see poate de adaugat in edit mode");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = sha256(textBox2.Text);
            string priv = toserv();

            string rmacc = "exec rmlogin '"+textBox1.Text+"'";

            SqlCommand addacc_q = new SqlCommand(rmacc, sqlConnection);

            if (textBox1.Enabled)
                try
                {

                    sqlConnection.Open();
                    addacc_q.ExecuteNonQuery();
                    button4.PerformClick();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("eroare : " + ex.Message + "");



                }
                finally
                {
                    sqlConnection.Close();
                    button5.PerformClick();
                    button4.PerformClick();

                }
            else

            {
                MessageBox.Show("NU see poate de adaugat in edit mode");
            }
        }
    }
}
