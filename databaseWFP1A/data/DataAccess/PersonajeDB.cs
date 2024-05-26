using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace databaseWFP1A.data.DataAccess
{
    internal class PersonajeDB
    {
        private string connectionString = "server=localhost;Database=prueba;Uid=root;Pwd=Telecastercustom2005";

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

        //metodo leer personajes
        public DataTable LeerPersonajes()
        {
            DataTable personajes = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM personajes_dragon_ball";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(personajes);
                    }
                }
            }

            return personajes;
        }

        public DataTable FiltrarPersonajesPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable personajesFiltrados = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM personajes_dragon_ball WHERE fecha_creacion BETWEEN @fechaInicio AND @fechaFin";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(personajesFiltrados);
                    }
                }
            }

            return personajesFiltrados;
        }

        //filtrar por historia
        public DataTable BuscarPersonajePorHistoria(string palabrasClave)
        {
            DataTable PersonajesFiltrados = new DataTable();

            using (MySqlConnection conection = new MySqlConnection(connectionString))
            {
                conection.Open();

                string sql = "SELECT * FROM personajes_dragon_ball WHERE historia LIKE @palabrasClave";
                using (MySqlCommand command = new MySqlCommand(sql, conection))
                {
                    command.Parameters.AddWithValue("@palabrasClave", "%" + palabrasClave + "%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command)) 
                    {
                        adapter.Fill(PersonajesFiltrados);
                    }
                }
            }

            return PersonajesFiltrados;
        }



        // Método para crear un nuevo personaje
        public int CrearPersonaje(string nombre, string raza, int nivelPoder, DateTime fechaCreacion, string historia)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO personajes_dragon_ball (nombre, raza, nivel_poder, fecha_creacion, historia) VALUES (@nombre, @raza, @nivelPoder, @fechaCreacion, @historia)";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@raza", raza);
                    command.Parameters.AddWithValue("@nivelPoder", nivelPoder);
                    command.Parameters.AddWithValue("@fechaCreacion", fechaCreacion);
                    command.Parameters.AddWithValue("@historia", historia);



                    return command.ExecuteNonQuery();
                }
            }
        }


        //Busca un personaje por su ID
        public DataTable BuscarPersonajePorId(int id)
        {
            DataTable personaje = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM personajes_dragon_ball WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(personaje);
                    }
                }
            }

            return personaje;
        }

        //eliminar por ID
        public bool EliminarPersonajePorId(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM personajes_dragon_ball WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }

        }

        //Actualizar datos por ID
        public bool ActualizarPersonaje(int id, string nombre, string raza, int nivelPoder, DateTime fechaCreacion, string historia)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "UPDATE personajes_dragon_ball SET nombre = @nombre, raza = @raza, nivel_poder = @nivel_poder, fecha_creacion = @fecha_creacion, historia = @historia WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@raza", raza);
                    command.Parameters.AddWithValue("@nivel_poder", nivelPoder);
                    command.Parameters.AddWithValue("@fecha_creacion", fechaCreacion);
                    command.Parameters.AddWithValue("@historia", historia);


                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

//        MySqlConnection
//MySqlCommand
//command.Parameters.AddWithValue
//@param
//ExecuteNonQuery
//MySqlDataAdapter
//adapter.Fill(personajes)


    }
}
