using MySql.Data.MySqlClient;
using ProyectoFinalP1A.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalP1A.Data
{
    internal class ConnectionDB
    {
        string connectionString = "server=localhost;database=cafe_el_angel;user=root;password=Telecastercustom2005";
        private MySqlConnection connection;

        //constructor
        public ConnectionDB()
        {
            connection = new MySqlConnection(connectionString);
        }


        public bool ProbarConexion()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Insertar(Producto producto)
        {
            try
            {
                string query = "INSERT INTO menu (nombre_producto, categoria, area_produccion, precio, estado_producto, descripcion, fecha_creacion) VALUES (@nombreProducto, @categoria, @areaProduccion, @precio, @estadoProducto, @descripcion, @fechaCreacion)";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@nombreProducto", producto.nombreProducto);
                command.Parameters.AddWithValue("@categoria", producto.categoria);
                command.Parameters.AddWithValue("@areaProduccion", producto.areaProduccion);
                command.Parameters.AddWithValue("@precio", producto.precio);
                command.Parameters.AddWithValue("@estadoProducto", producto.estado);
                command.Parameters.AddWithValue("@descripcion", producto.descripcion);
                command.Parameters.AddWithValue("@fechaCreacion", producto.fechaCreacion);

                connection.Open();
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro:" + ex.Message);
                return false;
            }
            finally
            {
                connection.Close(); 
            }
        }


    }
}
