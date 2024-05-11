using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFP1.Formularios;

namespace WFP1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int intentos = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
           // MessageBox.Show("hola");

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            h1.Text = "Bienvenido a la aplicacion";
            FrmIngreso forma = new FrmIngreso();
            forma.Show();
        }

        private void btnInicio_Click_1(object sender, EventArgs e)
        {
            int maxInt = 3;


            string usuario = txtUser.Text.ToLower();
            string contrasena = txtPwd.Text.ToLower();


            if (usuario == string.Empty || contrasena == string.Empty)
            {
                MessageBox.Show("Por favor ingrese un usuario y contrasena");
            }
            else
            {
                if (usuario == "admin" && contrasena == "admin")
                {
                    h1.Text = "¡Bienvenido a la aplicación!";
                    FrmIngreso forma = new FrmIngreso();
                    forma.Show();
                }
                else
                {
                    intentos++;
                    if (intentos == maxInt)
                    {
                        MessageBox.Show("Alcanzaste el maximo de intentos.");
                        btnInicio.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show($"Usuario o contrasena incorrectos, tienes {maxInt - intentos} intentos");
                        txtUser.Text = string.Empty; 
                        txtPwd.Text = string.Empty;
                    }
                }

            }

           
            
        }
    }
}
