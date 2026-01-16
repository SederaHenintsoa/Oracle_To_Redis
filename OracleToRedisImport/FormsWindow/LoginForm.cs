using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OracleToRedisImport.Auth;

namespace OracleToRedisImport.FormsWindow
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthService auth = new AuthService();
            if (auth.Authentifier(username.Text, password.Text))
            {
                MainForm f = new MainForm();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Identifiant incorrectes:", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
