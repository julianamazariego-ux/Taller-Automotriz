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
        public FrmServicios()
        {
            InitializeComponent();
        }

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


            if (chkAceite.Checked) subtotalServicios += 45.00;
            if (chkFrenos.Checked) subtotalServicios += 80.00;
            if (chkAlineacion.Checked) subtotalServicios += 35.00;
            if (chkEscaner.Checked) subtotalServicios += 25.00;


            double.TryParse(txtHoras.Text, out double horas);
            double tarifaHora = 30.00;
            double costoHoras = horas * tarifaHora;

            double.TryParse(txtRepuestos.Text, out double repuestos);
            double.TryParse(txtManoObra.Text, out double manoObraAdicional);


            label1.Text = "$" + costoHoras.ToString("F2");


            double subtotalGeneral = subtotalServicios + costoHoras + repuestos + manoObraAdicional;
            double iva = subtotalGeneral * 0.13;
            double totalPagar = subtotalGeneral + iva;


            lblSubtotal.Text = "$" + subtotalGeneral.ToString("F2");
            lblIVA.Text = "$" + iva.ToString("F2");
            lblTotal.Text = "$" + totalPagar.ToString("F2");
        }

        private void lblMano_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCliente.Text) || string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                MessageBox.Show("Por favor, ingresa el nombre del cliente y la placa antes de generar la orden.",
                                "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string mensaje = $"¡Orden generada con éxito!\n\n" +
                             $"Cliente: {txtCliente.Text}\n" +
                             $"Placa: {txtPlaca.Text}\n" +
                             $"Fecha: {dtpFecha.Value.ToShortDateString()}\n" +
                             $"Total a Cobrar: {lblTotal.Text}";

            MessageBox.Show(mensaje, "Orden #1184 Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {

            if (lblTotal.Text == "$0.00" || string.IsNullOrEmpty(lblTotal.Text))
            {
                MessageBox.Show("Primero debes realizar el cálculo de los servicios para imprimir la factura.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            MessageBox.Show("Enviando documento a la impresora predeterminada...",
                            "Imprimiendo Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtTotalP_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
