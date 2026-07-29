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
            
            FrmNuevoCliente modalNuevoCliente = new FrmNuevoCliente();

           
            modalNuevoCliente.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        
  
        
            
        {
            
            FrmFacturacion modalFactura = new FrmFacturacion();

           
            modalFactura.ShowDialog();
        }
        
        
        

        private void button3_Click(object sender, EventArgs e)
        {
            
            FrmNuevoVehiculo modalNuevoVehiculo = new FrmNuevoVehiculo();

            
            modalNuevoVehiculo.ShowDialog();
        }
    }
}
