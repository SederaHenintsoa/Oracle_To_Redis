using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CooperativeAgentApp.Services;

namespace CooperativeAgentApp.Forms
{
    public partial class LoginForm : Form
    {
        AuthService auth = new AuthService();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var agent = auth.Login(username.Text, password.Text);

            if (agent == null)
            {
                lblMessage.Text = "Login ou mot de passe incorrecte";
                return;
            }
            MessageBox.Show("Bienvenu :" + agent.username);
            
            
            
        }
    }
}
