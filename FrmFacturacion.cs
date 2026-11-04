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
    public partial class FrmFacturacion : Form
    {
        private const int FilasMinimas = 15;

        private readonly ErrorProvider errores = new ErrorProvider();

        private OrdenTrabajo? ordenCargada;

        public FrmFacturacion()
        {
            InitializeComponent();

            textBox3.Leave += textBox3_Leave;
            textBox3.KeyDown += textBox3_KeyDown;
            button2.Click += button2_Click;
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            foreach (var caja in new[] { textBox1, textBox2, textBox5, textBox6, textBox7, textBox8 })
            {
                SoloLectura(caja);
            }

            textBox1.Width = 60;
            dataGridView1.ReadOnly = true;

            LimpiarFormulario();
        }
        private static void SoloLectura(TextBox caja)
        {
            caja.BackColor = caja.BackColor;
            caja.ReadOnly = true;
        }

        private void textBox3_Leave(object? sender, EventArgs e)
        {
            CargarOrden();
        }

        private void textBox3_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CargarOrden();
            }
        }

        private void CargarOrden()
        {
            errores.Clear();

            string numero = textBox3.Text.Trim();
            if (numero.Length == 0)
            {
                LimpiarDetalle();
                return;
            }

            var orden = ContextoDatos.Ordenes.ObtenerPorNumero(numero);
            if (orden == null)
            {
                LimpiarDetalle();

                var porFacturar = ContextoDatos.Ordenes.ObtenerPorFacturar();
                errores.SetError(textBox3, porFacturar.Count == 0
                    ? "No existe esa orden. No hay órdenes finalizadas por facturar."
                    : "No existe esa orden. Por facturar: " + string.Join(", ", porFacturar.Select(o => o.NumeroOrden)));
                return;
            }

            MostrarOrden(orden);
        }

        private void MostrarOrden(OrdenTrabajo orden)
        {
            ordenCargada = orden;

            textBox2.Text = orden.Vehiculo?.Cliente?.Nombre ?? "(sin cliente)";
            textBox5.Text = orden.Vehiculo != null
                ? $"{orden.Vehiculo.Marca} {orden.Vehiculo.Modelo} {orden.Vehiculo.Anio} - {orden.VehiculoPlaca}"
                : orden.VehiculoPlaca;

            DateTime fecha = orden.FechaEntrega ?? DateTime.Now;
            textBox6.Text = fecha.Day.ToString("D2");
            textBox8.Text = fecha.Month.ToString("D2");
            textBox7.Text = fecha.Year.ToString();

            textBox1.Text = (orden.Folio ?? ContextoDatos.Ordenes.GenerarSiguienteFolio()).ToString();

            dataGridView1.Rows.Clear();

            foreach (var servicio in orden.Servicios)
            {
                dataGridView1.Rows.Add(1, servicio.Descripcion, Dinero(servicio.CostoManoObra), Dinero(servicio.CostoManoObra));
            }

            foreach (var repuesto in orden.Repuestos)
            {
                dataGridView1.Rows.Add(repuesto.Cantidad, repuesto.NombreRepuesto, Dinero(repuesto.PrecioUnitario), Dinero(repuesto.Subtotal));
            }

            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add("", "SUBTOTAL", "", Dinero(orden.Total));
            dataGridView1.Rows.Add("", "IVA (13%)", "", Dinero(orden.Iva));
            dataGridView1.Rows.Add("", "TOTAL A PAGAR", "", Dinero(orden.TotalConIva));

            RellenarFilasVacias();

            if (orden.Estado != EstadoOrden.Finalizada)
            {
                errores.SetError(textBox3, MensajeNoFacturable(orden));
            }
        }

        private static string MensajeNoFacturable(OrdenTrabajo orden)
        {
            return orden.Estado switch
            {
                EstadoOrden.Pendiente or EstadoOrden.EnProceso =>
                    $"La orden está {orden.Estado}. Primero márquela como finalizada en Órdenes abiertas.",
                EstadoOrden.Entregada =>
                    $"La orden ya fue facturada (folio {orden.Folio}).",
                EstadoOrden.Cancelada =>
                    "La orden está cancelada y no se puede facturar.",
                _ => "La orden no se puede facturar."
            };
        }

        private static string Dinero(decimal monto) => "$" + monto.ToString("F2");

        private void RellenarFilasVacias()
        {
            while (dataGridView1.Rows.Count < FilasMinimas)
            {
                dataGridView1.Rows.Add();
            }
        }

        private void LimpiarDetalle()
        {
            ordenCargada = null;

            textBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox1.Text = ContextoDatos.Ordenes.GenerarSiguienteFolio().ToString();

            dataGridView1.Rows.Clear();
            RellenarFilasVacias();
        }

        private void LimpiarFormulario()
        {
            errores.Clear();
            textBox3.Clear();
            LimpiarDetalle();
            textBox3.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ordenCargada == null || ordenCargada.NumeroOrden != textBox3.Text.Trim())
            {
                CargarOrden();
            }

            if (ordenCargada == null)
            {
                MessageBox.Show("Escriba el número de una orden existente (por ejemplo ORD-00001) y pulse Enter.",
                                "Falta la orden", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ordenCargada.Estado != EstadoOrden.Finalizada)
            {
                MessageBox.Show(MensajeNoFacturable(ordenCargada), "No se puede facturar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Facturar la orden {ordenCargada.NumeroOrden} por ${ordenCargada.TotalConIva:F2} (IVA incluido)?",
                "Confirmar factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                string numero = ordenCargada.NumeroOrden;
                int folio = ContextoDatos.Ordenes.Facturar(ordenCargada);

                MessageBox.Show($"La factura ha sido guardada y registrada exitosamente.\n\nOrden: {numero}\nFolio: {folio}",
                                "Factura Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo guardar la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }
    }
}