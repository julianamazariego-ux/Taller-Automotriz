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
    public partial class FrmOrdenes : Form
    {
        public FrmOrdenes()
        {
            InitializeComponent();

            button2.Click += button2_Click;
        }

        private void FrmOrdenes_Load(object sender, EventArgs e)
        {
            MostrarOrdenes();
        }

        private void MostrarOrdenes()
        {
            try
            {
                var tabla = new DataTable();
                tabla.Columns.Add("ID_Orden");
                tabla.Columns.Add("Cliente");
                tabla.Columns.Add("Vehiculo");
                tabla.Columns.Add("Servicio_Requerido");
                tabla.Columns.Add("Fecha_Ingreso");
                tabla.Columns.Add("Mecanico");
                tabla.Columns.Add("Total");
                tabla.Columns.Add("Estado");

                foreach (var orden in ContextoDatos.Ordenes.ObtenerAbiertas())
                {
                    tabla.Rows.Add(
                        orden.NumeroOrden,
                        orden.Vehiculo?.Cliente?.Nombre ?? "(sin cliente)",
                        orden.Vehiculo?.ToString() ?? orden.VehiculoPlaca,
                        string.Join(", ", orden.Servicios.Select(s => s.Descripcion)),
                        orden.FechaIngreso.ToString("yyyy-MM-dd"),
                        orden.Mecanico?.Nombre ?? "(sin mecánico)",
                        $"${orden.Total:F2}",
                        orden.Estado.ToString());
                }

                dataGridView1.DataSource = tabla;
                ConfigurarGridOrdenes(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private OrdenTrabajo? ObtenerOrdenSeleccionada()
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return null;

            string numero = dataGridView1.SelectedRows[0].Cells["ID_Orden"].Value?.ToString() ?? string.Empty;
            return ContextoDatos.Ordenes.ObtenerPorNumero(numero);
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            var orden = ObtenerOrdenSeleccionada();

            if (orden == null)
            {
                MessageBox.Show("Seleccione una orden de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string accionAvanzar = orden.Estado == EstadoOrden.Pendiente
                ? "Iniciar el trabajo"
                : "Marcar como finalizada";

            var respuesta = MessageBox.Show(
                $"Orden {orden.NumeroOrden} - estado actual: {orden.Estado}\n\n" +
                $"Sí: {accionAvanzar}\n" +
                "No: Cancelar la orden\n" +
                "Cancelar: no hacer nada",
                "Actualizar orden",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Cancel)
                return;

            try
            {
                if (respuesta == DialogResult.Yes)
                {
                    if (orden.Estado == EstadoOrden.Pendiente)
                        orden.IniciarTrabajo();
                    else
                        orden.FinalizarOrden();
                }
                else
                {
                    orden.CancelarOrden();
                }

                ContextoDatos.Ordenes.Actualizar(orden);
                MostrarOrdenes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar la orden: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGridOrdenes(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(224, 224, 224);

            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 57, 85);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.ColumnHeadersHeight = 40;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.RowHeadersVisible = false;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            grid.RowTemplate.Height = 35;

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 249);

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}