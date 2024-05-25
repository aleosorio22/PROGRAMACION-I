using CafeElAngel.Data;
using CafeElAngel.Data.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeElAngel
{
    public partial class AgregarReserva : Form
    {
        Reservaciones reservacion = new Reservaciones();
        ConexionDB conec = new ConexionDB();

        public AgregarReserva()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrarReserva_Click(object sender, EventArgs e)
        {
            reservacion.NombreCliente = txtNombreCliente.Text;
            reservacion.EmailCliente = txtEmailCliente.Text;
            reservacion.TelefonoCliente = txtTelefonoCliente.Text;
            reservacion.FechaReservacion = dateTimePickerFechaReservacion.Value.Date;

            // Capturar la hora usando MaskedTextBox
            if (TimeSpan.TryParse(maskedTextBoxHoraReservacion.Text, out TimeSpan horaReservacion))
            {
                reservacion.HoraReservacion = horaReservacion;
            }
            else
            {
                MessageBox.Show("Por favor ingrese una hora válida en el formato HH:mm.");
                return;
            }

            reservacion.NumeroPersonas = int.Parse(txtNumeroPersonas.Text);
            reservacion.Tipo = comboBoxTipo.Text;
            reservacion.Notas = txtNotas.Text;

            string estadoSeleccionado = comboBoxEstado.Text;
            if (estadoSeleccionado == "pendiente" || estadoSeleccionado == "confirmada" || estadoSeleccionado == "cancelada")
            {
                reservacion.Estado = estadoSeleccionado;
            }
            else
            {
                MessageBox.Show("Por favor seleccione un estado válido.");
                return;
            }

            reservacion.FechaCreacion = DateTime.Now;
            reservacion.TomadaPor = txtTomadaPor.Text;

            bool registroExitoso = conec.Insertar(reservacion);
            if (registroExitoso)
            {
                MessageBox.Show("Registro agregado con éxito.");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al agregar el registro.");
            }
        }
    }
}
