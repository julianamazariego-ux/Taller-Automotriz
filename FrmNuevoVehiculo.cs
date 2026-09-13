using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmNuevoVehiculo : Form
    {
        public string[] DatosCapturados;

        public FrmNuevoVehiculo()
        {
            InitializeComponent();
        }

        private void FrmNuevoVehiculo_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            DatosCapturados = new string[]
            {
    "1", 
    txtPlaca.Text,
    txtMarca.Text,
    txtModelo.Text,
    txtAnio.Text,
    txtColor.Text,
    cmbCliente.Text
            };

            
            this.DialogResult = DialogResult.OK;

           
            this.Close();
            MessageBox.Show("¡Vehículo guardado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


            this.Close();
        }

        private void lblPlaca_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
