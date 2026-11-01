using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TallerAutomotriz.Models;
using TallerAutomotriz.Repositorios;

namespace TallerAutomotriz
{
    public partial class FrmMecanicos : Form
    {
        public FrmMecanicos()
        {
            InitializeComponent();
        }

        private void ActualizarTabla()
        {
            MostrarMecanicos(ContextoDatos.Mecanicos.ObtenerTodos());
        }

        private void MostrarMecanicos(IEnumerable<Mecanico> lista)
        {
            dataGridView1.Rows.Clear();

            int idIncremental = 1;

            foreach (var mecanico in lista)
            {
                int fila = dataGridView1.Rows.Add(
                    idIncremental,
                    mecanico.Nombre,
                    mecanico.Especialidad.ToString(),
                    mecanico.Telefono,
                    mecanico.Disponible ? "Activo" : "Inactivo");

                dataGridView1.Rows[fila].Tag = mecanico;
                idIncremental++;
            }
        }

        private Mecanico? ObtenerMecanicoSeleccionado()
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return null;

            return dataGridView1.SelectedRows[0].Tag as Mecanico;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            EspecialidadMecanico? especialidadBuscada = cmbFiltro.SelectedItem is EspecialidadMecanico elegida
                ? elegida
                : (EspecialidadMecanico?)null;

            MostrarMecanicos(ContextoDatos.Mecanicos.Buscar(txtBusqueda.Text, especialidadBuscada));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmMecanicos_Load(object sender, EventArgs e)
        {
            cmbFiltro.DataSource = Enum.GetValues<EspecialidadMecanico>();
            cmbFiltro.SelectedIndex = -1;

            ActualizarTabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FrmNuevoMecanico ventanaNuevo = new FrmNuevoMecanico())
            {
                if (ventanaNuevo.ShowDialog() == DialogResult.OK)
                {
                    ActualizarTabla();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mecanicoAEliminar = ObtenerMecanicoSeleccionado();

            if (mecanicoAEliminar == null)
            {
                MessageBox.Show("Selecciona un mecánico de la tabla (haciendo clic en la flechita de la izquierda) para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ContextoDatos.Ordenes.ObtenerTodos().Any(o => o.MecanicoId == mecanicoAEliminar.Id))
            {
                MessageBox.Show("No se puede eliminar al mecánico porque tiene órdenes de trabajo asignadas.\nPuede marcarlo como Inactivo.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Seguro que deseas eliminar a este mecánico?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    ContextoDatos.Mecanicos.Eliminar(mecanicoAEliminar);
                    ActualizarTabla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo eliminar al mecánico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            cmbFiltro.SelectedIndex = -1;
            ActualizarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var mecanicoAEditar = ObtenerMecanicoSeleccionado();

            if (mecanicoAEditar == null)
            {
                MessageBox.Show("Selecciona toda la fila del mecánico desde la flechita izquierda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (FrmNuevoMecanico ventanaEdit = new FrmNuevoMecanico())
            {
                ventanaEdit.CargarMecanico(mecanicoAEditar);

                if (ventanaEdit.ShowDialog() == DialogResult.OK)
                {
                    ActualizarTabla();
                }
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}