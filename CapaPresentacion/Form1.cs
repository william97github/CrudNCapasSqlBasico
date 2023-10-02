using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CNusuario objetoCN = new CNusuario();
        private string idUsuario = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarDatosUsuario();
        }

        private void MostrarDatosUsuario()
        {
            try
            {
                CNusuario objeto = new CNusuario();
                dataGridView1.DataSource = objeto.MostrarUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo mostrar los datos por: " + ex);
            }
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text != "" && txtclave.Text != "")
            {
                try
                {
                    objetoCN.InsertarUsuario(txtusuario.Text, txtclave.Text);
                    MessageBox.Show("Se inserto correctamente");
                    MostrarDatosUsuario();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex);
                }
            }
            else
            {
                MessageBox.Show("Ingrese datos validos");
            }
                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idUsuario = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtusuario.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtclave.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo seleccionar los datos por: " + ex);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text != "" && txtclave.Text != "") {
                try
                {
                    objetoCN.EditarUsuario(txtusuario.Text, txtclave.Text, idUsuario);
                    MessageBox.Show("Se edito correctamente");
                    MostrarDatosUsuario();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por: " + ex);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro a editar");
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idUsuario = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                objetoCN.EliminarUsuario(idUsuario);
                MessageBox.Show("Eliminado correctamente");
                MostrarDatosUsuario();
                limpiar();
            }
            else
                MessageBox.Show("Seleccione un registro por favor");
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtbuscar.Text != "") {
                try
                {
                    CNusuario objeto = new CNusuario();
                    dataGridView1.DataSource = objeto.BuscarUsuario(txtbuscar.Text);
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al burcar: " + ex);
                }
            }
            else
            {
                MostrarDatosUsuario();
            }
        }

        public void limpiar()
        {
            txtbuscar.Clear();
            txtusuario.Clear();
            txtclave.Clear();
        }
    }
}
