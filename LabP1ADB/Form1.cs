using LabP1ADB.Data;
using LabP1ADB.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabP1ADB
{
    public partial class Form1 : Form
    {
        DBconnectionP1A connection = new DBconnectionP1A();
        catalogo_consolas_cs consola = new catalogo_consolas_cs();

        List<catalogo_consolas_cs> todos = new List<catalogo_consolas_cs> ();

        cursor cursor1 = new cursor ();

        private DBconnectionP1A conexionDB;
        private string[] catalogoCompanias = {
            "Atari",
            "Coleco",
            "Mattel",
            "Microsoft",
            "Nintendo",
            "Ouya Inc",
            "Sega",
            "Sony"
        };

        public Form1()
        {
            InitializeComponent();
            conexionDB = new DBconnectionP1A();
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxCompania.Items.AddRange(catalogoCompanias);
        }

        private void test_Click(object sender, EventArgs e)
        {
            if (conexionDB.ProbarConexion())
            {
                MessageBox.Show("Conexion exitosa, por ahora...");
            }
            else
            {
                MessageBox.Show("Avivese, haga bien la conexion");
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                consola.NombreConsola = txtNombreConsola.Text;
                consola.Compania = comboBoxCompania.Text;
                consola.AnioLanzamiento = int.Parse(dateTimePickerAnio.Value.Year.ToString());
                consola.Generacion = byte.Parse(txtGen.Text);

                conexionDB.Insertar(consola);
                MessageBox.Show("Consola agregada exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la consola: " + ex.Message);
            }
        }

        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            todos = conexionDB.ObtenerConsolas();
            dataGridView1.DataSource = todos;

            if (todos.Count > 0)
            {
                cursor1.totalRegistros = todos.Count;
                MessageBox.Show("Total de registros: " + cursor1.totalRegistros);
            }
            else
            {
                MessageBox.Show("No hay registros");
            }
        }

        private void MostrarRegistros()
        {
            if (cursor1.current >= 0 && cursor1.current < cursor1.totalRegistros)
            { 
                catalogo_consolas_cs con = todos[cursor1.current];
                txtID.Text = con.IdConsola.ToString();
                txtNombreConsola.Text = con.NombreConsola;
                comboBoxCompania.Text = con.Compania;
                dateTimePickerAnio.Text = con.AnioLanzamiento.ToString();
                txtGen.Value = Convert.ToDecimal(con.Generacion);

                cursor1.current++;

                if(cursor1.current >= cursor1.totalRegistros)
                {
                    cursor1.current = 0;
                    MessageBox.Show("Fin de los registros");
                }

            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            MostrarRegistros();
        }
    }
}
