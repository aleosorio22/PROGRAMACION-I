using ProyectoFinalP1A.Data;
using ProyectoFinalP1A.Data.Models;
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
    public partial class Main : Form
    {
        Producto prod = new Producto();

        ConnectionDB conec = new ConnectionDB();
 
        public Main()
        {
            InitializeComponent();

            // Configurar el ComboBox para el estado del producto
            comboBoxEstado.Items.Add("activo");
            comboBoxEstado.Items.Add("inactivo");
            comboBoxEstado.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prod.nombreProducto = txtNombre.Text;
            prod.categoria = txtCategoria.Text;
            prod.areaProduccion = comboBoxProduccion.Text;
            prod.precio = decimal.Parse(txtPrecio.Text);

            string estadoSeleccionado = comboBoxEstado.Text;
            if (estadoSeleccionado == "activo")
            {
                prod.estado = true;
            }
            else if (estadoSeleccionado == "inactivo")
            {
                prod.estado = false;
            }
            else
            {
                MessageBox.Show("Por favor seleccione un estado válido.");
                return;
            }

            prod.fechaCreacion = DateTime.Now;

            bool registroExitoso = conec.Insertar(prod);
            if (registroExitoso)
            {
                MessageBox.Show("Registro agregado con exito");
            }
            else
            {
                MessageBox.Show("Ocurrio un error al agregar el registro");
            }

        }

        private void testConection_Click(object sender, EventArgs e)
        {
            if (conec.ProbarConexion())
            {
                MessageBox.Show("Conexion exitosa, por ahora...");
            }
            else
            {
                MessageBox.Show("Avivese, haga bien la conexion");
            }
        }
    }
}
