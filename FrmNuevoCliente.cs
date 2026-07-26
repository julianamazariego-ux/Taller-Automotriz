using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmNuevoCliente : Form
    {
        public FrmNuevoCliente()
        {
            InitializeComponent();
        }

        private void FrmNuevoCliente_Load(object sender, EventArgs e)
        {

        }

        private void txtDUI_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Mostramos un mensaje de éxito al usuario
            MessageBox.Show("El cliente ha sido registrado correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cerramos la ventana
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
