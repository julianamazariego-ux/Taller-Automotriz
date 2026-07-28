using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmServicios : Form
    {

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void FrmServicios_Load(object sender, EventArgs e)
        {

        }

        private void lblManoD_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double subtotalServicios = 0;

            // 1. Suma de servicios seleccionados (CheckBoxes)
            if (chkAceite.Checked) subtotalServicios += 45.00;
            if (chkFrenos.Checked) subtotalServicios += 80.00;
            if (chkAlineacion.Checked) subtotalServicios += 35.00;
            if (chkEscaner.Checked) subtotalServicios += 25.00;

            // 2. Cálculo de Costos Adicionales
            double.TryParse(txtHoras.Text, out double horas);
            double tarifaHora = 30.00; // Tarifa por hora
            double costoHoras = horas * tarifaHora;

            double.TryParse(txtRepuestos.Text, out double repuestos);
            double.TryParse(txtManoObra.Text, out double manoObraAdicional);

            // Muestra el costo de la mano de obra por horas
            label1.Text = "$" + costoHoras.ToString("F2");

            // 3. Cálculos finales
            double subtotalGeneral = subtotalServicios + costoHoras + repuestos + manoObraAdicional;
            double iva = subtotalGeneral * 0.13;
            double totalPagar = subtotalGeneral + iva;

            // 4. Mostrar resultados en los Labels
            lblSubtotal.Text = "$" + subtotalGeneral.ToString("F2");
            lblIVA.Text = "$" + iva.ToString("F2");
            lblTotal.Text = "$" + totalPagar.ToString("F2");
        }

        private void lblMano_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            // 1. Validar que al menos el nombre del cliente y placa estén ingresados
            if (string.IsNullOrWhiteSpace(txtCliente.Text) || string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                MessageBox.Show("Por favor, ingresa el nombre del cliente y la placa antes de generar la orden.",
                                "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Mostrar un mensaje simulando la creación del archivo u orden
            string mensaje = $"¡Orden generada con éxito!\n\n" +
                             $"Cliente: {txtCliente.Text}\n" +
                             $"Placa: {txtPlaca.Text}\n" +
                             $"Fecha: {dtpFecha.Value.ToShortDateString()}\n" +
                             $"Total a Cobrar: {lblTotal.Text}";

            MessageBox.Show(mensaje, "Orden #1184 Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==========================================
        // CÓDIGO DEL BOTÓN IMPRIMIR FACTURA
        // ==========================================
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Confirmar si el total es mayor a cero antes de imprimir
            if (lblTotal.Text == "$0.00" || string.IsNullOrEmpty(lblTotal.Text))
            {
                MessageBox.Show("Primero debes realizar el cálculo de los servicios para imprimir la factura.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simular el proceso de envío a la impresora
            MessageBox.Show("Enviando documento a la impresora predeterminada...",
                            "Imprimiendo Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
    }
    }
}
