using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class frmNuevaOrden : Form
    {
        public frmNuevaOrden()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Ocultamos esta ventana primera (no la cerramos, solo la escondemos)
            this.Hide();

            // 2. Abrimos la segunda ventana (Datos del Vehículo)
            FrmNuevaOrden2 ventanaVehiculo = new FrmNuevaOrden2();
            ventanaVehiculo.ShowDialog();

            // 3. LA MAGIA: El código se pausa arriba. Cuando el usuario CIERRA la segunda ventana, 
            // el código continúa aquí abajo y volvemos a mostrar esta primera ventana.
            this.Show();
        }

        private void frmNuevaOrden_Load(object sender, EventArgs e)
        {

        }
    }
}
