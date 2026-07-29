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
           
            FrmNuevaOrden2 ventana2 = new FrmNuevaOrden2();
            ventana2.ShowDialog();
        }
        

        private void frmNuevaOrden_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
