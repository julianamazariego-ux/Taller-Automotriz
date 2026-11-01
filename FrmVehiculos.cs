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

    public partial class FrmVehiculos : Form


    {

        public FrmVehiculos()
        {
            InitializeComponent();


            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.FormBorderStyle = FormBorderStyle.None;


            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {

                    control.ForeColor = System.Drawing.Color.White;
                    control.BackColor = System.Drawing.Color.Transparent;
                }
                else if (control is Button)
                {
                    Button btn = (Button)control;
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;


                    if (btn.Name == "btnNuevo")
                    {
                        btn.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
                        btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 150, 220);
                    }
                    else if (btn.Name == "btnEliminar")
                    {
                        btn.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
                        btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(200, 40, 50);
                    }
                    else if (btn.Name == "btnBuscar")
                    {
                        btn.BackColor = System.Drawing.Color.FromArgb(0, 70, 140);
                        btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 90, 170);
                    }
                    else if (btn.Name == "btnLimpiarFiltros")
                    {
                        btn.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
                        btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(250, 140, 50);
                    }
                    else
                    {

                        btn.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
                        btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(60, 60, 65);
                    }
                }
            }


            dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(45, 45, 48);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(62, 62, 66);
        }
        

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            ActualizarGrid(ContextoDatos.Vehiculos.ObtenerTodos());

            cmbFiltroMarca.DataSource = Enum.GetValues<MarcaVehiculo>();
            cmbFiltroMarca.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmNuevoVehiculo modalVehiculo = new FrmNuevoVehiculo())
            {
                if (modalVehiculo.ShowDialog() == DialogResult.OK)
                {
                    ActualizarGrid(ContextoDatos.Vehiculos.ObtenerTodos());
                }
            }
        }

        private void ActualizarGrid(IEnumerable<Vehiculo> listaAMostrar)
        {
            dataGridView1.Rows.Clear();

            int idIncremental = 1;

            foreach (var vehiculo in listaAMostrar)
            {
                dataGridView1.Rows.Add(
                    idIncremental,
                    vehiculo.Placa,
                    vehiculo.Marca.ToString(),
                    vehiculo.Modelo,
                    vehiculo.Anio,
                    vehiculo.Color,
                    vehiculo.Cliente?.Nombre ?? "(sin cliente)");
                idIncremental++;
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscarPlaca.Clear();
            txtFiltroAnio.Clear();
            cmbFiltroMarca.SelectedIndex = -1;

            ActualizarGrid(ContextoDatos.Vehiculos.ObtenerTodos());
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            int? anioBuscado = null;
            if (!string.IsNullOrWhiteSpace(txtFiltroAnio.Text))
            {
                if (!int.TryParse(txtFiltroAnio.Text, out int anioIngresado))
                {
                    MessageBox.Show("Ingrese un año válido en números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                anioBuscado = anioIngresado;
            }

            MarcaVehiculo? marcaFiltro = cmbFiltroMarca.SelectedItem is MarcaVehiculo marcaElegida
                ? marcaElegida
                : (MarcaVehiculo?)null;

            ActualizarGrid(ContextoDatos.Vehiculos.Buscar(txtBuscarPlaca.Text, marcaFiltro, anioBuscado));
        }
    }
}