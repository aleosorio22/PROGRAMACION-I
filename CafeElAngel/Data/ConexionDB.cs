using CafeElAngel.Data.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeElAngel.Data
{
    internal class ConexionDB
    {
        string connectionString = "server=localhost;database=cafe_el_angel;user=root;password=Telecastercustom2005";
        MySqlConnection connection;

        //constructor
        public ConexionDB()
        {
            connection = new MySqlConnection(connectionString);
        }


        //insertar
        public bool Insertar(Reservaciones reservacion)
        {
            try
            {
                string query = "INSERT INTO reservaciones (nombre_cliente, email_cliente, telefono_cliente, fecha_reservacion, hora_reservacion, numero_personas, tipo, notas, estado, fecha_creacion, tomada_por) VALUES (@nombreCliente, @emailCliente, @telefonoCliente, @fechaReservacion, @horaReservacion, @numeroPersonas, @tipo, @notas, @estado, @fechaCreacion, @tomadaPor)";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@nombreCliente", reservacion.NombreCliente);
                command.Parameters.AddWithValue("@emailCliente", reservacion.EmailCliente);
                command.Parameters.AddWithValue("@telefonoCliente", reservacion.TelefonoCliente);
                command.Parameters.AddWithValue("@fechaReservacion", reservacion.FechaReservacion);
                command.Parameters.AddWithValue("@horaReservacion", reservacion.HoraReservacion);
                command.Parameters.AddWithValue("@numeroPersonas", reservacion.NumeroPersonas);
                command.Parameters.AddWithValue("@tipo", reservacion.Tipo);
                command.Parameters.AddWithValue("@notas", reservacion.Notas);
                command.Parameters.AddWithValue("@estado", reservacion.Estado);
                command.Parameters.AddWithValue("@fechaCreacion", reservacion.FechaCreacion);
                command.Parameters.AddWithValue("@tomadaPor", reservacion.TomadaPor);

                connection.Open();
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
