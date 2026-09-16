using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Taller_Automotriz.FrmNuevoMecanico;

namespace Taller_Automotriz
{
    public partial class FrmMecanicos : Form
    {
        public static List<string[]> listaMecanicos = new List<string[]>();
        public FrmMecanicos()
        {
            InitializeComponent();
        }




        private void ActualizarTabla()
        {
            dataGridView1.Rows.Clear();

            foreach (var mecanico in listaMecanicos)
            {
                dataGridView1.Rows.Add(mecanico);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();


            string especialidadBuscada = cmbFiltro.SelectedIndex != -1 ? cmbFiltro.Text : "";


            string nombreBuscado = txtBusqueda.Text.ToLower().Trim();


            var mecanicosFiltrados = listaMecanicos.Where(m =>
                (string.IsNullOrWhiteSpace(nombreBuscado) || m[1].ToLower().Contains(nombreBuscado)) &&
                (string.IsNullOrWhiteSpace(especialidadBuscada) || m[2] == especialidadBuscada)
            ).ToList();


            foreach (var mecanico in mecanicosFiltrados)
            {
                dataGridView1.Rows.Add(mecanico);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmMecanicos_Load(object sender, EventArgs e)
        {

            cmbFiltro.DataSource = Enum.GetValues<Especialidades>();
            cmbFiltro.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmNuevoMecanico ventanaNuevo = new FrmNuevoMecanico();

            if (ventanaNuevo.ShowDialog() == DialogResult.OK)
            {
                listaMecanicos.Add(ventanaNuevo.DatosCapturados);
                ActualizarTabla();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Seguro que deseas eliminar a este mecánico?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    string idSeleccionado = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


                    var mecanicoAEliminar = listaMecanicos.FirstOrDefault(m => m[0] == idSeleccionado);
                    if (mecanicoAEliminar != null)
                    {
                        listaMecanicos.Remove(mecanicoAEliminar);
                        ActualizarTabla();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un mecánico de la tabla (haciendo clic en la flechita de la izquierda) para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idSeleccionado = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                int indice = listaMecanicos.FindIndex(m => m[0] == idSeleccionado);

                if (indice >= 0)
                {
                    FrmNuevoMecanico ventanaEdit = new FrmNuevoMecanico();
                    ventanaEdit.CargarMecanico(listaMecanicos[indice]);

                    if (ventanaEdit.ShowDialog() == DialogResult.OK)
                    {
                        listaMecanicos[indice] = ventanaEdit.DatosCapturados;
                        ActualizarTabla();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona toda la fila del mecánico desde la flechita izquierda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
