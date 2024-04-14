using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFcarro
{
    public partial class Form1 : Form
    {

        clase8_POO.Clases.Carro carr = new("Ferrari", 2024);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            MessageBox.Show(carr.EncenderCarro());
            btnAcelerar.Visible = true;
        }

        private void btnAcelerar_Click(object sender, EventArgs e)
        {
            kph.Text = "Velocidad = " + carr.Acelerar();
        }
    }
}
