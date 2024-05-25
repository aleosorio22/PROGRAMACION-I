using databaseWFP1A.data.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace databaseWFP1A
{
    public partial class Form1 : Form
    {
        //variable de instancia ref a la clase perosonajeDB
        private PersonajeDB personaje;
        // Lista de razas
        private string[] razasDragonBall = {
            "Android",
            "Bio-Android",
            "Humana",
            "Humano",
            "Majin",
            "Namekuseijin",
            "Saiyajin",
            "Saiyajin/Humano",
            "Saiyajin/Saiyajin"
        };

        public Form1()
        {
            InitializeComponent();
            personaje = new PersonajeDB();
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            if (personaje.ProbarConexion())
            {
                MessageBox.Show("Conexion exitosa, por ahora...");
            }
            else
            {
                MessageBox.Show("Avivese, haga bien la conexion");
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            DataTable dt = personaje.LeerPersonajes();
            dataGridViewPersonajes.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtName.Text;
                string raza = comboBoxRaza.Text;
                int nivelPoder = (int)txtPower.Value;
                DateTime fechaCreacion = dateTimePickerFechaCreacion.Value;
                string historia = txtHistoria.Text;

                int respuesta = personaje.CrearPersonaje(nombre, raza, nivelPoder, fechaCreacion, historia);
                if (respuesta > 0)
                {
                    MessageBox.Show("Personaje Creado con exito");
                    dataGridViewPersonajes.DataSource = personaje.LeerPersonajes();
                }
                else
                {
                    MessageBox.Show("Algo hiciste mal chato...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error> {ex.Message}");
            }
            


        }


        private void BuscarPorId()
        {
            try
            {
                int IdPersonaje = int.Parse(txtID.Text);
                DataTable personajeEcontrado = personaje.BuscarPersonajePorId(IdPersonaje);
                if (personajeEcontrado.Rows.Count > 0)
                {
                    string nombre = personajeEcontrado.Rows[0]["nombre"].ToString();
                    string raza = personajeEcontrado.Rows[0]["raza"].ToString();
                    int nivelPoder = int.Parse(personajeEcontrado.Rows[0]["nivel_poder"].ToString());
                    DateTime fechaCreacion = DateTime.Parse(personajeEcontrado.Rows[0]["fecha_creacion"].ToString());
                    string historia = personajeEcontrado.Rows[0]["historia"].ToString();


                    txtName.Text = nombre;
                    comboBoxRaza.Text = raza;
                    txtPower.Value = nivelPoder;
                    dateTimePickerFechaCreacion.Value = fechaCreacion;
                    txtHistoria.Text = historia;
                }
                else
                {
                    MessageBox.Show("Codigo no encontrado");
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Por favor introduzca un ID valido no sea sonso");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error: {ex.Message}");
            }
            
        }

        //eliminar por ID
        private void BuscarYEliminarPorId()
        {
            try
            {
                int IdPersonaje = int.Parse(txtID.Text);
                DataTable personajeEncontrado = personaje.BuscarPersonajePorId(IdPersonaje);

                if (personajeEncontrado.Rows.Count > 0)
                {
                    string nombre = personajeEncontrado.Rows[0]["nombre"].ToString();
                    string raza = personajeEncontrado.Rows[0]["raza"].ToString();
                    int nivelPoder = int.Parse(personajeEncontrado.Rows[0]["nivel_poder"].ToString());

                    txtName.Text = nombre;
                    comboBoxRaza.Text = raza;
                    txtPower.Value = nivelPoder;

                    // Preguntar si desea eliminar el personaje
                    DialogResult result = MessageBox.Show($"¿Estás seguro que deseas eliminar al personaje {nombre}?",
                                                          "Confirmación de eliminación",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        bool eliminado = personaje.EliminarPersonajePorId(IdPersonaje);
                        if (eliminado)
                        {
                            MessageBox.Show("Personaje eliminado correctamente.");
                            // Limpiar los campos
                            txtID.Clear();
                            txtName.Clear();
                            comboBoxRaza.SelectedIndex = -1;
                            txtPower.Value = 0;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el personaje.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Personaje no encontrado.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, introduce un ID válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        //actualiar por ID
        private void ActualizarPersonaje()
        {
            try
            {
                int IdPersonaje = int.Parse(txtID.Text);
                string nombre = txtName.Text;
                string raza = comboBoxRaza.Text;
                int nivelPoder = (int)txtPower.Value;
                DateTime fechaCreacion = dateTimePickerFechaCreacion.Value;
                string historia = txtHistoria.Text;

                // Preguntar si desea actualizar el personaje
                DialogResult result = MessageBox.Show("¿Estás seguro que deseas actualizar los datos de este personaje?",
                                                      "Confirmación de actualización",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool actualizado = personaje.ActualizarPersonaje(IdPersonaje, nombre, raza, nivelPoder, fechaCreacion, historia);

                    if (actualizado)
                    {
                        MessageBox.Show("Personaje actualizado correctamente.");
                        dataGridViewPersonajes.DataSource = personaje.LeerPersonajes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el personaje. Verifica que el ID sea correcto.");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, introduce un ID y nivel de poder válidos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        //buscar por historia
        private void BuscarPorHistoria()
        {
            try
            {
                string palabrasClave = txtPalabrasClave.Text;

                if (string.IsNullOrWhiteSpace(palabrasClave))
                {
                    MessageBox.Show("Por favor, introduce palabras clave para la búsqueda.");
                    return;
                }

                DataTable personajesFiltrados = personaje.BuscarPersonajePorHistoria(palabrasClave);

                if (personajesFiltrados.Rows.Count > 0)
                {
                    dataGridViewPersonajes.DataSource = personajesFiltrados;
                }
                else
                {
                    MessageBox.Show("No se encontraron personajes con esas palabras clave en la historia.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al buscar los personajes: {ex.Message}");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxRaza.Items.AddRange(razasDragonBall);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPorId(); 
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            BuscarPorId();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BuscarYEliminarPorId();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizarPersonaje();
        }

        private void btnFiltrarPorFecha_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimePickerInicio.Value;
            DateTime fechaFin = dateTimePickerFin.Value;

            try
            {
                DataTable personajesFiltrados = personaje.FiltrarPersonajesPorFecha(fechaInicio, fechaFin);

                if (personajesFiltrados.Rows.Count > 0)
                {
                    dataGridViewPersonajes.DataSource = personajesFiltrados;
                }
                else
                {
                    MessageBox.Show("No se encontraron personajes en el rango de fechas especificado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al filtrar los personajes: {ex.Message}");
            }
        }

        private void btnHistoria_Click(object sender, EventArgs e)
        {
            BuscarPorHistoria();
        }
    }
}
