using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalP1A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = string.Empty;
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if(txtUser.Text ==  string.Empty)
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPwd_Enter(object sender, EventArgs e)
        {
            if(txtPwd.Text == "CONTRASEÑA")
            {
                txtPwd.Text = string.Empty;
                txtPwd.ForeColor = Color.LightGray;
            }
        }

        private void txtPwd_Leave(object sender, EventArgs e)
        {
            if (txtPwd.Text == string.Empty)
            {
                txtPwd.Text = "CONTRASEÑA";
                txtPwd.ForeColor = Color.DimGray;
                txtPwd.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pwd = txtPwd.Text;

            if (user == "root" &&  pwd == "root")
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contrasena incorrectos, intente de nuevo");
            }

        }
    }
}


