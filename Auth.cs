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

            //Se ascund butuanele care raspund pentru functia de inregistrare
            textBox3.Hide(); label3.Hide(); button2.Hide();


        }
        //Connectiune sql cu informatia despre server si baza de date care v-a fi utilizata
        SqlConnection sqlConnection = new SqlConnection("Server = REVISION-PC; Database=ceauto;Trusted_Connection=True;");


            //Instantierea la parametrii care vor fi folosite in logare si inregistrare
            string login, password, priv = "G1";

            Boolean Logged = false;
            
        private void Auth_Load(object sender, EventArgs e)
        {

           

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            //buttonul sign in va afisa controalele ascunse care vor fi utilizate pentru inregistrare
            textBox3.Show(); label3.Show();button2.Show(); button_login.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //buttonul login v-a ascunde controalele afisate care s-a utilizat pentru inregistrare
            textBox3.Hide(); label3.Hide();button_login.Show(); button2.Hide();
        }

        //Algoritm de criptografie dupa standatrul sha256 care corespunde la cerintile minime pentru criptare
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //buttonul login va citi informatia din textbox-uri si le va atribui la variabile 
        private void button_login_Click(object sender, EventArgs e)
        {  
            

            login = textBox1.Text;
            //parola citita din textbox se incipteaza 
            password = sha256(textBox2.Text);

          
            
            
            

         
            //Mesaj care v-a fi afisat in cauza daca utilizatorul nu a introdus nimic
            if (string.IsNullOrEmpty(login))
            { MessageBox.Show("Intorduceti loginul") ; }
             else
            {
            
                //din caz daca utilizatorul a fost introdus login-ul si parola care a fost encriptata se trimite spre server printr-o procedura
            string querylogin = "exec loginto '"+login+"','"+password+"'";
            SqlDataAdapter sdq = new SqlDataAdapter(querylogin,sqlConnection);
               
                
                //#### Se poate de facut altfel
            DataTable dt = new DataTable();
            sdq.Fill(dt);

                
                
            if(dt.Rows.Count > 0)
            {


                    DataRow[] r = dt.Select();


                    Logged = true;

                   priv = (r[0][2].ToString()).Trim();

                    this.Hide();

                }
                else
            { 
                    MessageBox.Show("Login sau parola incorecta.");
                
            }

            }
            

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            { button_login.PerformClick();}
        }

        public void button2_Click(object sender, EventArgs e)
        {

            login = textBox1.Text;
            //parola citita din textbox se incipteaza 
            password = sha256(textBox2.Text);

            priv = "G1";

            //nu roleaza programul daca utilizatoru nu a repetat parola corect
            if (textBox2.Text == textBox3.Text)
            {

                //executa o precedura de stocare
                string querysigin = "exec addlogin '" + login + "','" + password + "', '"+priv+"'"; //comanda spre executie
                SqlCommand signin = new SqlCommand(querysigin, sqlConnection);
                sqlConnection.Open();
                signin.ExecuteNonQuery();
                sqlConnection.Close(); 


                //####necesita exceptii


                MessageBox.Show("Utilizatorul a fost inregistrat."); //Mesaj de confirmare 
            }

            else
            {
                //mesaj daca parolele nu coincid
                MessageBox.Show("Passwords doens't match");
            }


        }


        public Boolean User_priv_check(string requirements)
        {

            

            Boolean granted = false;
            if(Logged)
            switch (requirements)
            {

                case "G1":

                    granted = true;
                    break;

                case "Ang":

                    if (String.Equals(priv, "A1") | String.Equals(priv, "M1") | String.Equals(priv, "C1")|String.Equals(priv, "D1"))
                    { granted = true;}
                    break;

                case "D1":

                    if(!String.Equals(priv, "G1") && !String.Equals(priv, "A1")) { granted = true; }

                    break;

                case "A1":
                    if (!String.Equals(priv,"G1") && !String.Equals(priv, "D1")) { granted = true; }
                      
                    break;

                case "M1":
                    if (String.Equals(priv, "M1") | String.Equals(priv, "C1")) { granted = true; }
                        break;

                case "C1":
                    if (String.Equals(priv, "C1")) { granted = true; }
                        break;

                    default:

                        granted = false;
                        break;

            }

                

            return granted;

        }



    }
}
