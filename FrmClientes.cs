using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmNuevoCliente formulario = new FrmNuevoCliente())
            {
                formulario.ShowDialog(this);
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            dgvClientes.Rows.Add(15);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
   
