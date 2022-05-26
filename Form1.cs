using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEAUTO2
{
    public partial class Form1 : Form
    {
        public Form1()
        {   
            //Aceasta metoda este folosita pentru crea controalele
            InitializeComponent();

            //Este folosit pentru a arata ca acesta este un container
            this.IsMdiContainer = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            //Se deschide forman main 
            OpenChildForm(new MainChild());


            
        }
        public bool formIsExist(Form frmOpen)
        {
            //Citeste toate formele deschise
            FormCollection fc = Application.OpenForms;

            //Daca o forma copil este deschise returneaza valoarea true
            foreach (Form frm in fc)
            {
                if (frm.Name == frmOpen.Name)
                {
                    return true;
                }
            }
            //Din caz contrar se returneaza valoarea false
            return false;
        }
        private Form activeForm = null;


        //Din caz daca o forma copil este deshisa ea se inchide pentru a elibera loc pentru urmatoarea 
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ChildFormPanel.Controls.Add(childForm);
            ChildFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Converteaza metoda User_priv_check care verifica dacau utilizator poate sau nu sa acceseze un contorl

            try
            {
                var authform = (Application.OpenForms.OfType<Auth>().Last());

                if (authform.User_priv_check("G1"))
                {
                    OpenChildForm(new Child2());
                }
                else
                {
                    MessageBox.Show("Insufciente permisiuni.");
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show("Logativa!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Converteaza metoda User_priv_check care verifica dacau utilizator poate sau nu sa acceseze un contorl

            try
            {
                var authform = (Application.OpenForms.OfType<Auth>().Last());

                if (authform.User_priv_check("A1"))
                {
                    OpenChildForm(new Child6());
                }
                else
                {
                    MessageBox.Show("Insufciente permisiuni.");
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show("Logativa!");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Converteaza metoda User_priv_check care verifica dacau utilizator poate sau nu sa acceseze un contorl

            try
            {
                var authform = (Application.OpenForms.OfType<Auth>().Last());

                if (authform.User_priv_check("D1"))
                {
                    OpenChildForm(new Child5());
                }
                else
                {
                    MessageBox.Show("Insufciente permisiuni.");
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show("Logativa!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Converteaza metoda User_priv_check care verifica dacau utilizator poate sau nu sa acceseze un contorl

            try
            {
                var authform = (Application.OpenForms.OfType<Auth>().Last());

                if (authform.User_priv_check("Ang"))
                {
                    OpenChildForm(new Child4());
                }
                else
                {
                    MessageBox.Show("Insufciente permisiuni.");
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show("Logativa!");
            }
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            //Converteaza metoda User_priv_check care verifica dacau utilizator poate sau nu sa acceseze un contorl

            try
            {
                var authform = (Application.OpenForms.OfType<Auth>().Last());
            
                if (authform.User_priv_check("M1"))
                {
                    OpenChildForm(new Child3());
                }
                else
                {
                    MessageBox.Show("Insufciente permisiuni.");
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show("Logativa!");
            }
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Converteaza metoda User_priv_check care verifica dacau utilizator poate sau nu sa acceseze un contorl

            try
            {
                var authform = (Application.OpenForms.OfType<Auth>().Last());

                if (authform.User_priv_check("G1"))
                {
                    OpenChildForm(new Child1());
                }
                else
                {
                    MessageBox.Show("Insufciente permisiuni.");
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show("Logativa!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //utilizeaza o metoda care schimba utilizatorul
            newlogin();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Se deschide main form care este accesibila oricarui utilizator 
            OpenChildForm(new MainChild());
        }

        public void newlogin()
        {
            //Deschide forma pentru login care este afisata deasupra "Foreground"
            Auth auth = new Auth();
            auth.Show();

            if (auth.WindowState == FormWindowState.Minimized)
            {
                auth.WindowState = FormWindowState.Normal;
            }

            auth.Activate();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Converteaza metoda User_priv_check care verifica dacau utilizator poate sau nu sa acceseze un contorl

            try
            {
                var authform = (Application.OpenForms.OfType<Auth>().Last());

                if (authform.User_priv_check("M1"))
                {
                    OpenChildForm(new Administration());
                }
                else
                {
                    MessageBox.Show("Insufciente permisiuni. ");
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show("Logativa!");
            }
        }
    }
}
