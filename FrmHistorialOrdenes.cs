using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TallerAutomotriz.Models;
using TallerAutomotriz.Repositorios;

namespace TallerAutomotriz
{
    public class FrmHistorialOrdenes : Form
    {
        private readonly TextBox txtBuscar = new TextBox();
        private readonly ComboBox cmbEstado = new ComboBox();
        private readonly DateTimePicker dtpDesde = new DateTimePicker();
        private readonly DateTimePicker dtpHasta = new DateTimePicker();
        private readonly DataGridView grid = new DataGridView();
        private readonly Label lblResumen = new Label();

        public FrmHistorialOrdenes()
        {
            Text = "Historial de órdenes";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(1100, 570);
            MinimumSize = new Size(900, 450);

            CrearControles();
            ConfigurarGrid();

            Load += FrmHistorialOrdenes_Load;
        }

        private void CrearControles()
        {
            var lblBuscar = new Label { AutoSize = true, Location = new Point(15, 19), Text = "Buscar:" };
            txtBuscar.Location = new Point(70, 15);
            txtBuscar.Size = new Size(230, 27);
            txtBuscar.PlaceholderText = "Orden, placa o cliente";

            var lblEstado = new Label { AutoSize = true, Location = new Point(315, 19), Text = "Estado:" };
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Location = new Point(365, 15);
            cmbEstado.Size = new Size(125, 28);
            cmbEstado.Items.Add("Todos");
            foreach (var estado in Enum.GetValues<EstadoOrden>())
            {
                cmbEstado.Items.Add(estado);
            }
            cmbEstado.SelectedIndex = 0;

            var lblDesde = new Label { AutoSize = true, Location = new Point(505, 19), Text = "Desde:" };
            dtpDesde.Location = new Point(555, 15);
            dtpDesde.Size = new Size(120, 27);
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.ShowCheckBox = true;
            dtpDesde.Checked = false;

            var lblHasta = new Label { AutoSize = true, Location = new Point(685, 19), Text = "Hasta:" };
            dtpHasta.Location = new Point(732, 15);
            dtpHasta.Size = new Size(120, 27);
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.ShowCheckBox = true;
            dtpHasta.Checked = false;

            var btnBuscar = new Button { Text = "Buscar", Location = new Point(870, 13), Size = new Size(90, 30) };
            btnBuscar.Click += (s, e) => Buscar();

            var btnLimpiar = new Button { Text = "Limpiar", Location = new Point(965, 13), Size = new Size(90, 30) };
            btnLimpiar.Click += (s, e) => LimpiarFiltros();

            grid.Location = new Point(15, 55);
            grid.Size = new Size(1070, 455);
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grid.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) MostrarDetalle();
            };
            grid.CellFormatting += grid_CellFormatting;

            lblResumen.AutoSize = true;
            lblResumen.Location = new Point(15, 527);
            lblResumen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            var btnDetalle = new Button { Text = "Ver detalle", Location = new Point(865, 522), Size = new Size(100, 30) };
            btnDetalle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDetalle.Click += (s, e) => MostrarDetalle();

            var btnCerrar = new Button { Text = "Cerrar", Location = new Point(975, 522), Size = new Size(100, 30) };
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.DialogResult = DialogResult.Cancel;

            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblEstado);
            Controls.Add(cmbEstado);
            Controls.Add(lblDesde);
            Controls.Add(dtpDesde);
            Controls.Add(lblHasta);
            Controls.Add(dtpHasta);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(grid);
            Controls.Add(lblResumen);
            Controls.Add(btnDetalle);
            Controls.Add(btnCerrar);

            AcceptButton = btnBuscar;
            CancelButton = btnCerrar;
        }

        private void ConfigurarGrid()
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(224, 224, 224);

            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 57, 85);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.ColumnHeadersHeight = 40;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.RowHeadersVisible = false;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            grid.RowTemplate.Height = 32;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 249);

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;
        }

        private void FrmHistorialOrdenes_Load(object? sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            EstadoOrden? estado = cmbEstado.SelectedItem is EstadoOrden estadoElegido
                ? estadoElegido
                : (EstadoOrden?)null;

            DateTime? desde = dtpDesde.Checked ? dtpDesde.Value.Date : (DateTime?)null;
            DateTime? hasta = dtpHasta.Checked ? dtpHasta.Value.Date : (DateTime?)null;

            if (desde != null && hasta != null && desde > hasta)
            {
                MessageBox.Show("La fecha \"Desde\" no puede ser posterior a la fecha \"Hasta\".",
                                "Fechas no válidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ordenes = ContextoDatos.Ordenes.Buscar(txtBuscar.Text, estado, desde, hasta);
            MostrarOrdenes(ordenes);
        }

        private void LimpiarFiltros()
        {
            txtBuscar.Clear();
            cmbEstado.SelectedIndex = 0;
            dtpDesde.Checked = false;
            dtpHasta.Checked = false;
            Buscar();
        }

        private void MostrarOrdenes(List<OrdenTrabajo> ordenes)
        {
            var tabla = new DataTable();
            tabla.Columns.Add("ID_Orden");
            tabla.Columns.Add("Cliente");
            tabla.Columns.Add("Vehiculo");
            tabla.Columns.Add("Servicios");
            tabla.Columns.Add("Ingreso");
            tabla.Columns.Add("Entrega");
            tabla.Columns.Add("Mecanico");
            tabla.Columns.Add("Total");
            tabla.Columns.Add("Estado");
            tabla.Columns.Add("Folio");

            foreach (var orden in ordenes)
            {
                tabla.Rows.Add(
                    orden.NumeroOrden,
                    orden.Vehiculo?.Cliente?.Nombre ?? "(sin cliente)",
                    orden.Vehiculo?.ToString() ?? orden.VehiculoPlaca,
                    string.Join(", ", orden.Servicios.Select(s => s.Descripcion)),
                    orden.FechaIngreso.ToString("yyyy-MM-dd"),
                    orden.FechaEntrega?.ToString("yyyy-MM-dd") ?? "-",
                    orden.Mecanico?.Nombre ?? "(sin mecánico)",
                    $"${orden.TotalConIva:F2}",
                    orden.Estado.ToString(),
                    orden.Folio?.ToString() ?? "-");
            }

            grid.DataSource = tabla;

            int totalGuardadas = ContextoDatos.Ordenes.ObtenerTodos().Count;
            decimal facturado = ordenes
                .Where(o => o.Estado == EstadoOrden.Entregada)
                .Sum(o => o.TotalConIva);

            lblResumen.Text = $"Mostrando {ordenes.Count} de {totalGuardadas} órdenes   |   Facturado (entregadas): ${facturado:F2}";
        }

        private void grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (grid.Columns[e.ColumnIndex].Name != "Estado") return;

            e.CellStyle.ForeColor = e.Value?.ToString() switch
            {
                "Entregada" => Color.SeaGreen,
                "Cancelada" => Color.Firebrick,
                "Finalizada" => Color.DarkCyan,
                "EnProceso" => Color.DarkOrange,
                _ => Color.Black
            };
        }

        private OrdenTrabajo? ObtenerOrdenSeleccionada()
        {
            if (grid.SelectedRows.Count == 0)
                return null;

            string numero = grid.SelectedRows[0].Cells["ID_Orden"].Value?.ToString() ?? string.Empty;
            return ContextoDatos.Ordenes.ObtenerPorNumero(numero);
        }

        private void MostrarDetalle()
        {
            var orden = ObtenerOrdenSeleccionada();
            if (orden == null)
            {
                MessageBox.Show("Seleccione una orden de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var detalle = new StringBuilder();
            detalle.AppendLine($"Orden {orden.NumeroOrden}  -  {orden.Estado}");
            detalle.AppendLine();
            detalle.AppendLine($"Cliente: {orden.Vehiculo?.Cliente?.Nombre ?? "(sin cliente)"}");
            detalle.AppendLine($"Vehículo: {orden.Vehiculo?.ToString() ?? orden.VehiculoPlaca}");
            detalle.AppendLine($"Mecánico: {orden.Mecanico?.Nombre ?? "(sin mecánico)"}");
            detalle.AppendLine($"Ingreso: {orden.FechaIngreso:yyyy-MM-dd}");
            detalle.AppendLine($"Entrega: {(orden.FechaEntrega.HasValue ? orden.FechaEntrega.Value.ToString("yyyy-MM-dd") : "-")}");
            detalle.AppendLine($"Diagnóstico: {orden.Diagnostico}");
            detalle.AppendLine();

            detalle.AppendLine("Servicios:");
            foreach (var servicio in orden.Servicios)
            {
                detalle.AppendLine($"   - {servicio.Descripcion}: ${servicio.CostoManoObra:F2}");
            }

            if (orden.Repuestos.Count > 0)
            {
                detalle.AppendLine("Repuestos:");
                foreach (var repuesto in orden.Repuestos)
                {
                    detalle.AppendLine($"   - {repuesto.Cantidad} x {repuesto.NombreRepuesto}: ${repuesto.Subtotal:F2}");
                }
            }

            detalle.AppendLine();
            detalle.AppendLine($"Subtotal: ${orden.Total:F2}");
            detalle.AppendLine($"IVA (13%): ${orden.Iva:F2}");
            detalle.AppendLine($"Total: ${orden.TotalConIva:F2}");

            if (orden.Folio.HasValue)
            {
                detalle.AppendLine($"Folio de factura: {orden.Folio}");
            }

            MessageBox.Show(detalle.ToString(), $"Detalle de {orden.NumeroOrden}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}