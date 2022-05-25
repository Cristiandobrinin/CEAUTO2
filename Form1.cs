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
            InitializeComponent();






            this.IsMdiContainer = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            OpenChildForm(new MainChild());
        }
        public bool formIsExist(Form frmOpen)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == frmOpen.Name)
                {
                    return true;
                }
            }

            return false;
        }
        private Form activeForm = null;
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
            Auth auth = new Auth();

            auth.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MainChild());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Administration());
        }
    }
}
