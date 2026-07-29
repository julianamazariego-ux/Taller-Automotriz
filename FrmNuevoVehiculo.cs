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
        public FrmNuevoVehiculo()
        {
            InitializeComponent();
        }

        private void FrmNuevoVehiculo_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("¡Vehículo guardado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            this.Close();
        }

        private void lblPlaca_Click(object sender, EventArgs e)
        {

        }
    }
}
