using LabP1ADB.Data.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabP1ADB.Data
{
    internal class DBconnectionP1A
    {
        string connectionString = "server=localhost;Database=prueba;Uid=root;Pwd=Telecastercustom2005";
        MySqlConnection connection;

        //constructor
        public DBconnectionP1A()
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

        //insertar
        public void Insertar(catalogo_consolas_cs consola)
        {
            try
            {
                string query = "INSERT INTO catalogo_consolas (nombre_consola, compania, anio_lanzamiento, generacion) VALUES (@NombreConsola, @Compania, @AnioLanzamiento, @Generacion)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NombreConsola", consola.NombreConsola);
                cmd.Parameters.AddWithValue("@Compania", consola.Compania);
                cmd.Parameters.AddWithValue("@AnioLanzamiento", consola.AnioLanzamiento);
                cmd.Parameters.AddWithValue("@Generacion", consola.Generacion);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message);
            }   
            finally
            {
                connection.Close();
            }
        }

        //leer por id
        public DataRow LeerPorId(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM catalogo_consolas WHERE id_consola = @ID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public List<catalogo_consolas_cs> ObtenerConsolas()
        {
            List<catalogo_consolas_cs> consolas = new List<catalogo_consolas_cs>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM catalogo_consolas";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        catalogo_consolas_cs consola = new catalogo_consolas_cs
                        {
                            IdConsola = reader.GetInt32("id_consola"),
                            NombreConsola = reader.GetString("nombre_consola"),
                            Compania = reader.GetString("compania"),
                            AnioLanzamiento = reader.GetInt32("anio_lanzamiento"),
                            Generacion = reader.GetByte("generacion")
                        };

                        consolas.Add(consola);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return consolas;
        }
    }
}
