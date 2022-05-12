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
    public partial class Auth : Form
    {
        public Auth()
        {
            
            InitializeComponent();
            textBox3.Hide(); label3.Hide(); button2.Hide();
            

        }

            SqlConnection sqlConnection = new SqlConnection("Server = REVISION-PC; Database=ceauto;Trusted_Connection=True;");
            
            string login, password, priv;

        private void Auth_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        { 
            textBox3.Show(); label3.Show();button2.Show(); button_login.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Hide(); label3.Hide();button_login.Show(); button2.Hide();
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

        private void button_login_Click(object sender, EventArgs e)
        {  
            

            login = textBox1.Text;

            password = sha256(textBox2.Text);

            priv = "G1";


         
            
            if (string.IsNullOrEmpty(login))
            { MessageBox.Show("Intorduceti loginul") ; }

            string querylogin = "exec loginto '"+login+"','"+password+"'";
            SqlDataAdapter sdq = new SqlDataAdapter(querylogin,sqlConnection);

            DataTable dt = new DataTable();
            sdq.Fill(dt);
            
            if(dt.Rows.Count > 0)
            { MessageBox.Show("let's go"); }
                else
            { MessageBox.Show("let's gon't"); }

        }
        private void button2_Click(object sender, EventArgs e)
        {

            login = textBox1.Text;

            password = sha256(textBox2.Text);

            priv = "G1";

            if (textBox2.Text == textBox3.Text)
            {

                MessageBox.Show("F");
                string querysigin = "exec addlogin '" + login + "','" + password + "', '"+priv+"'";
                SqlCommand signin = new SqlCommand(querysigin, sqlConnection);
                sqlConnection.Open();
                signin.ExecuteNonQuery();
                sqlConnection.Close();
            }

            else
            {

                MessageBox.Show("Passwords doens't match");
            }


        }

    }
}
