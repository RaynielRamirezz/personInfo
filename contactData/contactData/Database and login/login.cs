using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contactData.Database_and_login
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (userTextbox.Text == "Admin" || userTextbox.Text ==  "admin" 
                && passwordTextbox.Text == "1234")
            {
                info object1 = new info();
                this.Hide();
                object1.ShowDialog();
                this.Close();
                
                //System.Windows.Forms.Application.Exit();

            }
            else
            {
                MessageBox.Show("Wrong username or password");             
            }
        }

        
    }
}
