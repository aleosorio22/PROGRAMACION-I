using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFP1.Formularios
{
    public partial class FrmIngreso : Form
    {
        public FrmIngreso()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void resultado_TextChanged(object sender, EventArgs e)
        {

        }

        private void sumar_Click(object sender, EventArgs e)
        {
            comboBoxFacultades.Items.Add("Derecho");
            comboBoxFacultades.Items.Add("Sistemas");
        }

        private void comboBoxFacultades_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(comboBoxFacultades.SelectedItem.ToString());
        }

        private void btnsuma_Click(object sender, EventArgs e)
        {
            if (int.TryParse(n1.Text, out int num1) && int.TryParse(n2.Text, out int num2))
            {
                int result = num1 + num2;
                resultado.Text = result.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa números válidos en ambos campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                n1.Text = string.Empty; n2.Text = string.Empty;
            }

        }
    }
}
