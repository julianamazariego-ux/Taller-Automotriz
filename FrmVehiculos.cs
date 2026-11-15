using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                else if (control is Button btn)
                {
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;

                    if (btn.Name == "btnNuevo")
                    {
                        btn.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
                        btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(45, 150, 220);
                    }
                    else if (btn.Name == "btnEliminar" || btn.Text.Contains("Eliminar", StringComparison.OrdinalIgnoreCase))
                    {
                        btn.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
                        btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(200, 40, 50);
                        btn.Click -= btnEliminar_Click;
                        btn.Click += btnEliminar_Click;
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

                        if (btn.Name == "btnEditar" || btn.Text.Contains("Editar", StringComparison.OrdinalIgnoreCase))
                        {
                            btn.Click -= btnEditar_Click;
                            btn.Click += btnEditar_Click;
                        }
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

            GestorFotosVehiculo.ConfigurarColumnaFoto(dataGridView1);

            // Con un solo clic en la columna de fotografía se abre el visor para verla en grande y descargarla
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.CellMouseEnter += DataGridView1_CellMouseEnter;
        }

        private void DataGridView1_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                dataGridView1.Columns[e.ColumnIndex].Name == "colFotoVehiculo")
            {
                dataGridView1.Cursor = Cursors.Hand;
            }
            else
            {
                dataGridView1.Cursor = Cursors.Default;
            }
        }

        private void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "colFotoVehiculo" &&
                dataGridView1.Rows[e.RowIndex].Tag is Vehiculo vehiculo)
            {
                if (GestorFotosVehiculo.MostrarVisorFotoVehiculo(this, vehiculo))
                {
                    ActualizarGrid(ContextoDatos.Vehiculos.ObtenerTodos());
                }
            }
        }

        private Vehiculo? ObtenerVehiculoSeleccionado()
        {
            DataGridViewRow? fila = dataGridView1.CurrentRow;
            if (fila == null && dataGridView1.SelectedRows.Count > 0)
                fila = dataGridView1.SelectedRows[0];

            if (fila == null) return null;

            if (fila.Tag is Vehiculo vTag)
                return vTag;

            string? placa = fila.Cells[1]?.Value?.ToString();
            if (!string.IsNullOrWhiteSpace(placa))
                return ContextoDatos.Vehiculos.BuscarPorPlaca(placa);

            return null;
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            var vehiculo = ObtenerVehiculoSeleccionado();
            if (vehiculo == null)
            {
                MessageBox.Show("Seleccione un vehículo de la tabla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (GestorFotosVehiculo.EditarVehiculoConModal(this, vehiculo))
            {
                ActualizarGrid(ContextoDatos.Vehiculos.ObtenerTodos());
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            var vehiculo = ObtenerVehiculoSeleccionado();
            if (vehiculo == null)
            {
                MessageBox.Show("Seleccione un vehículo de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Está seguro que desea eliminar el vehículo con placa '{vehiculo.Placa}' ({vehiculo.Marca} {vehiculo.Modelo})?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    GestorFotosVehiculo.EliminarVehiculoDeRepositorio(vehiculo);
                    ActualizarGrid(ContextoDatos.Vehiculos.ObtenerTodos());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo eliminar el vehículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            var placasExistentes = ContextoDatos.Vehiculos.ObtenerTodos()
                .Select(v => v.Placa)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            string fotoSeleccionada = "auto_reciente_azul.png";

            using (FrmNuevoVehiculo modalVehiculo = new FrmNuevoVehiculo())
            {
                GestorFotosVehiculo.PrepararModalNuevoVehiculo(modalVehiculo, foto => fotoSeleccionada = foto);

                if (modalVehiculo.ShowDialog() == DialogResult.OK)
                {
                    var todos = ContextoDatos.Vehiculos.ObtenerTodos();
                    var recienCreado = todos.FirstOrDefault(v => !placasExistentes.Contains(v.Placa))
                                       ?? todos.LastOrDefault();

                    if (recienCreado != null)
                    {
                        GestorFotosVehiculo.AsignarFotoAPlaca(recienCreado.Placa, fotoSeleccionada);
                    }

                    ActualizarGrid(todos);
                }
            }
        }

        private void ActualizarGrid(IEnumerable<Vehiculo> listaAMostrar)
        {
            dataGridView1.Rows.Clear();

            int idIncremental = 1;

            foreach (var vehiculo in listaAMostrar)
            {
                Image miniatura = GestorFotosVehiculo.ObtenerMiniaturaVehiculo(vehiculo);

                int rowIndex = dataGridView1.Rows.Add(
                    idIncremental,
                    vehiculo.Placa,
                    vehiculo.Marca.ToString(),
                    vehiculo.Modelo,
                    vehiculo.Anio,
                    vehiculo.Color,
                    vehiculo.Cliente?.Nombre ?? "(sin cliente)",
                    miniatura);

                dataGridView1.Rows[rowIndex].Tag = vehiculo;
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