using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNuevaOrden modalOrden = new frmNuevaOrden();
            modalOrden.ShowDialog();
        }

        private void btnAccesoNuevoRegistro_Click(object sender, EventArgs e)
        {
            // 1. Instanciamos el formulario que hizo Juliana
            FrmNuevoCliente modalNuevoCliente = new FrmNuevoCliente();

            // 2. Lo abrimos en modo MODAL (ShowDialog en lugar de Show)
            // Esto congela la pantalla de atrás hasta que se cierre esta ventanita
            modalNuevoCliente.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Instanciamos el formulario de Vehículo
            FrmNuevoVehiculo modalNuevoVehiculo = new FrmNuevoVehiculo();

            // 2. Lo abrimos en modo MODAL
            modalNuevoVehiculo.ShowDialog();
        }
    }
}
