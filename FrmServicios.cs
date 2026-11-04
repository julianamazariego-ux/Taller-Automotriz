using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TallerAutomotriz.Models;
using TallerAutomotriz.Repositorios;

namespace TallerAutomotriz
{
    public partial class FrmServicios : Form
    {
        private const decimal PrecioAceite = 45.00m;
        private const decimal PrecioFrenos = 80.00m;
        private const decimal PrecioAlineacion = 35.00m;
        private const decimal PrecioEscaner = 25.00m;
        private const decimal TarifaHora = 30.00m;

        public FrmServicios()
        {
            InitializeComponent();

            txtPlaca.Leave += txtPlaca_Leave;
        }

        private void FrmServicios_Load(object sender, EventArgs e)
        {
            txtCliente.MaxLength = 50;
            txtPlaca.MaxLength = 8;
            txtModelo.MaxLength = 30;

            txtCliente.ReadOnly = true;
            txtModelo.ReadOnly = true;
        }

        private void txtPlaca_Leave(object? sender, EventArgs e)
        {
            var vehiculo = string.IsNullOrWhiteSpace(txtPlaca.Text)
                ? null
                : ContextoDatos.Vehiculos.BuscarPorPlaca(txtPlaca.Text);

            if (vehiculo == null)
            {
                txtCliente.Clear();
                txtModelo.Clear();
                return;
            }

            txtCliente.Text = vehiculo.Cliente?.Nombre ?? string.Empty;
            txtModelo.Text = $"{vehiculo.Marca} {vehiculo.Modelo} {vehiculo.Anio}";
            errorProvider1.SetError(txtPlaca, "");
        }

        private Vehiculo? ValidarVehiculo()
        {
            errorProvider1.Clear();

            string placa = txtPlaca.Text.Trim();
            if (string.IsNullOrWhiteSpace(placa))
            {
                errorProvider1.SetIconPadding(txtPlaca, -18);
                errorProvider1.SetError(txtPlaca, "Ingrese la placa o patente del vehículo.");
                return null;
            }

            if (placa.Length < 5)
            {
                errorProvider1.SetIconPadding(txtPlaca, -18);
                errorProvider1.SetError(txtPlaca, "La placa debe tener al menos 5 caracteres.");
                return null;
            }

            var vehiculo = ContextoDatos.Vehiculos.BuscarPorPlaca(placa);
            if (vehiculo == null)
            {
                errorProvider1.SetIconPadding(txtPlaca, -18);
                errorProvider1.SetError(txtPlaca, "No existe un vehículo registrado con esa placa. Regístrelo primero en Vehículos.");
                return null;
            }

            txtCliente.Text = vehiculo.Cliente?.Nombre ?? string.Empty;
            txtModelo.Text = $"{vehiculo.Marca} {vehiculo.Modelo} {vehiculo.Anio}";
            return vehiculo;
        }

        private bool ValidarServicios()
        {
            bool esValido = true;

            bool tieneServicios = chkAceite.Checked || chkFrenos.Checked ||
                                  chkAlineacion.Checked || chkEscaner.Checked;

            decimal.TryParse(txtRepuestos.Text, out decimal repuestos);
            decimal.TryParse(txtManoObra.Text, out decimal adicional);
            decimal.TryParse(txtHoras.Text, out decimal horas);

            if (repuestos < 0) { errorProvider1.SetError(txtRepuestos, "No puede ser negativo."); esValido = false; }
            if (adicional < 0) { errorProvider1.SetError(txtManoObra, "No puede ser negativo."); esValido = false; }
            if (horas < 0) { errorProvider1.SetError(txtHoras, "No puede ser negativo."); esValido = false; }

            if (esValido && !tieneServicios && repuestos == 0 && adicional == 0 && horas == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un servicio o ingresar horas/costos adicionales.",
                                "Validación de Servicios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                esValido = false;
            }

            return esValido;
        }

        private List<(string Descripcion, decimal Costo)> ObtenerServiciosSeleccionados()
        {
            var lista = new List<(string Descripcion, decimal Costo)>();

            if (chkAceite.Checked) lista.Add(("Cambio de aceite y filtro", PrecioAceite));
            if (chkFrenos.Checked) lista.Add(("Mantenimiento de frenos", PrecioFrenos));
            if (chkAlineacion.Checked) lista.Add(("Alineación y balanceo", PrecioAlineacion));
            if (chkEscaner.Checked) lista.Add(("Diagnóstico con escáner", PrecioEscaner));

            decimal.TryParse(txtHoras.Text, out decimal horas);
            if (horas > 0)
                lista.Add(($"Mano de obra ({horas} h x ${TarifaHora:F2})", horas * TarifaHora));

            decimal.TryParse(txtManoObra.Text, out decimal manoObraAdicional);
            if (manoObraAdicional > 0)
                lista.Add(("Mano de obra adicional", manoObraAdicional));

            return lista;
        }

        private decimal ObtenerMontoRepuestos()
        {
            decimal.TryParse(txtRepuestos.Text, out decimal repuestos);
            return repuestos > 0 ? repuestos : 0;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (!ValidarServicios()) return;

                decimal subtotal = ObtenerServiciosSeleccionados().Sum(s => s.Costo) + ObtenerMontoRepuestos();
                decimal iva = Math.Round(subtotal * OrdenTrabajo.TasaIva, 2);
                decimal totalPagar = subtotal + iva;

                lblSubtotal.Text = "$" + subtotal.ToString("F2");
                lblIVA.Text = "$" + iva.ToString("F2");
                lblTotal.Text = "$" + totalPagar.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado durante el cálculo: {ex.Message}",
                                "Error de Ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                var vehiculo = ValidarVehiculo();
                if (vehiculo == null) return;

                if (!ValidarServicios()) return;

                var activos = ContextoDatos.Mecanicos.ObtenerDisponibles();
                if (activos.Count == 0)
                {
                    MessageBox.Show("No hay mecánicos activos. Registre o active uno en la pantalla de Mecánicos.",
                                    "Sin mecánicos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var selector = new FrmSeleccionarMecanico(activos);
                if (selector.ShowDialog(this) != DialogResult.OK || selector.MecanicoSeleccionado == null)
                    return;

                var orden = new OrdenTrabajo(
                    string.Empty,
                    vehiculo,
                    selector.MecanicoSeleccionado,
                    "Orden generada desde la pantalla de Servicios.")
                {
                    FechaIngreso = dtpFecha.Value
                };

                foreach (var servicio in ObtenerServiciosSeleccionados())
                    orden.AgregarServicio(servicio.Descripcion, servicio.Costo);

                decimal repuestos = ObtenerMontoRepuestos();
                if (repuestos > 0)
                    orden.AgregarRepuesto("Repuestos varios", 1, repuestos);

                ContextoDatos.Ordenes.Agregar(orden);

                lblSubtotal.Text = "$" + orden.Total.ToString("F2");
                lblIVA.Text = "$" + orden.Iva.ToString("F2");
                lblTotal.Text = "$" + orden.TotalConIva.ToString("F2");

                var todas = ContextoDatos.Ordenes.ObtenerTodos();
                decimal acumuladoTotal = todas.Sum(o => o.TotalConIva);
                int cantidadOrdenes = todas.Count;
                decimal mayorOrden = todas.Max(o => o.TotalConIva);

                string mensaje = $"¡Orden registrada con éxito!\n\n" +
                                 $"Orden: {orden.NumeroOrden}\n" +
                                 $"Cliente: {txtCliente.Text}\n" +
                                 $"Placa: {vehiculo.Placa}\n" +
                                 $"Mecánico: {selector.MecanicoSeleccionado.Nombre}\n" +
                                 $"Fecha: {orden.FechaIngreso.ToShortDateString()}\n" +
                                 $"Subtotal: ${orden.Total:F2}\n" +
                                 $"IVA (13%): ${orden.Iva:F2}\n" +
                                 $"Total: ${orden.TotalConIva:F2}\n" +
                                 $"Estado: {orden.Estado}\n\n" +
                                 $"--- [Resumen del Sistema - LINQ] ---\n" +
                                 $"Órdenes registradas: {cantidadOrdenes}\n" +
                                 $"Monto total acumulado: ${acumuladoTotal:F2}\n" +
                                 $"Orden de mayor valor: ${mayorOrden:F2}";

                MessageBox.Show(mensaje, "Orden Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar la orden: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtCliente.Clear();
            txtPlaca.Clear();
            txtModelo.Clear();

            chkAceite.Checked = false;
            chkFrenos.Checked = false;
            chkAlineacion.Checked = false;
            chkEscaner.Checked = false;

            txtHoras.Clear();
            txtRepuestos.Clear();
            txtManoObra.Clear();

            lblSubtotal.Text = "$0.00";
            lblIVA.Text = "$0.00";
            lblTotal.Text = "$0.00";

            dtpFecha.Value = DateTime.Now;
            errorProvider1.Clear();
            txtPlaca.Focus();
        }

        private void ImprimirDocumento_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Font fuenteTitulo = new Font("Arial", 16, FontStyle.Bold))
            using (Font fuenteSubtitulo = new Font("Arial", 12, FontStyle.Bold))
            using (Font fuenteTexto = new Font("Arial", 10, FontStyle.Regular))
            using (Font fuenteTotal = new Font("Arial", 11, FontStyle.Bold))
            {
                Brush pincel = Brushes.Black;
                float x = 50;
                float y = 50;
                float lineSpacing = 25;

                e.Graphics.DrawString("TALLER AUTOMOTRIZ - ORDEN DE SERVICIO", fuenteTitulo, pincel, x, y);
                y += lineSpacing * 2;

                e.Graphics.DrawString($"Fecha: {dtpFecha.Value.ToShortDateString()}", fuenteTexto, pincel, x, y); y += lineSpacing;
                e.Graphics.DrawString($"Cliente: {txtCliente.Text}", fuenteTexto, pincel, x, y); y += lineSpacing;
                e.Graphics.DrawString($"Placa/Patente: {txtPlaca.Text}", fuenteTexto, pincel, x, y); y += lineSpacing;
                e.Graphics.DrawString($"Modelo/Marca: {txtModelo.Text}", fuenteTexto, pincel, x, y); y += lineSpacing * 2;

                e.Graphics.DrawString("DETALLE DE SERVICIOS Y COSTOS:", fuenteSubtitulo, pincel, x, y); y += lineSpacing;
                e.Graphics.DrawLine(Pens.Black, x, y, x + 400, y); y += 10;

                if (chkAceite.Checked) { e.Graphics.DrawString("- Cambio de Aceite y Filtro: $45.00", fuenteTexto, pincel, x, y); y += lineSpacing; }
                if (chkFrenos.Checked) { e.Graphics.DrawString("- Mantenimiento de Frenos: $80.00", fuenteTexto, pincel, x, y); y += lineSpacing; }
                if (chkAlineacion.Checked) { e.Graphics.DrawString("- Alineación y Balanceo: $35.00", fuenteTexto, pincel, x, y); y += lineSpacing; }
                if (chkEscaner.Checked) { e.Graphics.DrawString("- Diagnóstico Escáner: $25.00", fuenteTexto, pincel, x, y); y += lineSpacing; }

                if (!string.IsNullOrEmpty(txtHoras.Text) && txtHoras.Text != "0")
                {
                    e.Graphics.DrawString($"- Mano de Obra (Horas): {txtHoras.Text} hrs", fuenteTexto, pincel, x, y); y += lineSpacing;
                }
                if (!string.IsNullOrEmpty(txtRepuestos.Text) && txtRepuestos.Text != "0")
                {
                    e.Graphics.DrawString($"- Repuestos: ${txtRepuestos.Text}", fuenteTexto, pincel, x, y); y += lineSpacing;
                }
                if (!string.IsNullOrEmpty(txtManoObra.Text) && txtManoObra.Text != "0")
                {
                    e.Graphics.DrawString($"- Mano de Obra Adicional: ${txtManoObra.Text}", fuenteTexto, pincel, x, y); y += lineSpacing;
                }

                y += 15;
                e.Graphics.DrawLine(Pens.Black, x, y, x + 400, y); y += 15;

                e.Graphics.DrawString($"Subtotal: {lblSubtotal.Text}", fuenteTexto, pincel, x, y); y += lineSpacing;
                e.Graphics.DrawString($"IVA (13%): {lblIVA.Text}", fuenteTexto, pincel, x, y); y += lineSpacing;
                e.Graphics.DrawString($"TOTAL A PAGAR: {lblTotal.Text}", fuenteTotal, pincel, x, y);
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e) { }
        private void groupBox3_Enter(object sender, EventArgs e) { }
        private void lblManoD_Click(object sender, EventArgs e) { }
        private void lblTotal_Click(object sender, EventArgs e) { }
        private void lblMano_Click(object sender, EventArgs e) { }
        private void txtTotalP_TextChanged(object sender, EventArgs e) { }
        private void lblTitulo_Click(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            if (lblTotal.Text == "$0.00" || string.IsNullOrEmpty(lblTotal.Text))
            {
                MessageBox.Show("Primero debes realizar el cálculo de los servicios para imprimir la factura.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += ImprimirDocumento_PrintPage;

                PrintPreviewDialog vistaPrevia = new PrintPreviewDialog
                {
                    Document = pd,
                    Width = 800,
                    Height = 600
                };

                vistaPrevia.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar a la impresora: {ex.Message}",
                                "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}