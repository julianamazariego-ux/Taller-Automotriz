using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public enum EstadoOrden
    {
        Pendiente,
        EnProceso,
        Completado
    }

    public struct RegistroServicio
    {
        public string Cliente { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public EstadoOrden Estado { get; set; }
    }

    public partial class FrmServicios : Form
    {
        private readonly List<RegistroServicio> listaOrdenes = new List<RegistroServicio>();

        public FrmServicios()
        {
            InitializeComponent();
        }

        private void FrmServicios_Load(object sender, EventArgs e)
        {
            txtCliente.MaxLength = 50;
            txtPlaca.MaxLength = 8;
            txtModelo.MaxLength = 30;
        }

        private bool ValidarCampos()
        {
            errorProvider1.Clear();
            bool esValido = true;

            string cliente = txtCliente.Text.Trim();
            if (string.IsNullOrWhiteSpace(cliente))
            {
                errorProvider1.SetIconPadding(txtCliente, -18);
                errorProvider1.SetError(txtCliente, "Ingrese el nombre del cliente.");
                esValido = false;
            }
            else if (!Regex.IsMatch(cliente, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                errorProvider1.SetIconPadding(txtCliente, -18);
                errorProvider1.SetError(txtCliente, "El nombre del cliente solo debe contener letras.");
                esValido = false;
            }
            else if (cliente.Length < 3)
            {
                errorProvider1.SetIconPadding(txtCliente, -18);
                errorProvider1.SetError(txtCliente, "El nombre debe contener al menos 3 letras.");
                esValido = false;
            }

            string placa = txtPlaca.Text.Trim();
            if (string.IsNullOrWhiteSpace(placa))
            {
                errorProvider1.SetIconPadding(txtPlaca, -18);
                errorProvider1.SetError(txtPlaca, "Ingrese la placa o patente del vehículo.");
                esValido = false;
            }
            else if (placa.Length < 5)
            {
                errorProvider1.SetIconPadding(txtPlaca, -18);
                errorProvider1.SetError(txtPlaca, "La placa debe tener al menos 5 caracteres.");
                esValido = false;
            }

            string modelo = txtModelo.Text.Trim();
            if (string.IsNullOrWhiteSpace(modelo))
            {
                errorProvider1.SetIconPadding(txtModelo, -18);
                errorProvider1.SetError(txtModelo, "Ingrese la marca y modelo del vehículo.");
                esValido = false;
            }
            else if (Regex.IsMatch(modelo, @"^\d+$"))
            {
                errorProvider1.SetIconPadding(txtModelo, -18);
                errorProvider1.SetError(txtModelo, "El modelo/marca no puede contener solo números.");
                esValido = false;
            }

            bool tieneServicios = chkAceite.Checked || chkFrenos.Checked ||
                                  chkAlineacion.Checked || chkEscaner.Checked;

            double.TryParse(txtRepuestos.Text, out double repuestos);
            double.TryParse(txtManoObra.Text, out double adicional);
            double.TryParse(txtHoras.Text, out double horas);

            if (!tieneServicios && repuestos == 0 && adicional == 0 && horas == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un servicio o ingresar horas/costos adicionales.",
                                "Validación de Servicios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                esValido = false;
            }

            return esValido;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                double subtotalServicios = 0;

                if (chkAceite.Checked) subtotalServicios += 45.00;
                if (chkFrenos.Checked) subtotalServicios += 80.00;
                if (chkAlineacion.Checked) subtotalServicios += 35.00;
                if (chkEscaner.Checked) subtotalServicios += 25.00;

                double.TryParse(txtHoras.Text, out double horas);
                double tarifaHora = 30.00;
                double costoHoras = horas * tarifaHora;

                double.TryParse(txtRepuestos.Text, out double repuestos);
                double.TryParse(txtManoObra.Text, out double manoObraAdicional);

                double subtotalGeneral = subtotalServicios + costoHoras + repuestos + manoObraAdicional;
                double iva = subtotalGeneral * 0.13;
                double totalPagar = subtotalGeneral + iva;

                lblSubtotal.Text = "$" + subtotalGeneral.ToString("F2");
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
                if (!ValidarCampos()) return;

                if (lblTotal.Text == "$0.00" || string.IsNullOrEmpty(lblTotal.Text))
                {
                    btnCalcular_Click(sender, e);
                }

                string totalTexto = lblTotal.Text.Replace("$", "");
                double.TryParse(totalTexto, out double totalPagar);

                RegistroServicio nuevaOrden = new RegistroServicio
                {
                    Cliente = txtCliente.Text.Trim(),
                    Placa = txtPlaca.Text.Trim().ToUpper(),
                    Modelo = txtModelo.Text.Trim(),
                    Fecha = dtpFecha.Value,
                    Total = totalPagar,
                    Estado = EstadoOrden.Pendiente
                };

                listaOrdenes.Add(nuevaOrden);

                double acumuladoTotal = listaOrdenes.Sum(o => o.Total);
                int cantidadOrdenes = listaOrdenes.Count;
                double mayorOrden = listaOrdenes.Max(o => o.Total);

                string mensaje = $"¡Orden registrada con éxito!\n\n" +
                                 $"Cliente: {nuevaOrden.Cliente}\n" +
                                 $"Placa: {nuevaOrden.Placa}\n" +
                                 $"Fecha: {nuevaOrden.Fecha.ToShortDateString()}\n" +
                                 $"Total: ${nuevaOrden.Total:F2}\n" +
                                 $"Estado: {nuevaOrden.Estado}\n\n" +
                                 $"--- [Resumen del Sistema - LINQ] ---\n" +
                                 $"Órdenes en sesión: {cantidadOrdenes}\n" +
                                 $"Monto total acumulado: ${acumuladoTotal:F2}\n" +
                                 $"Orden de mayor valor: ${mayorOrden:F2}";

                MessageBox.Show(mensaje, "Orden Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
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
            txtCliente.Focus();
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