using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{


    public partial class FrmNuevoMecanico : Form
    {
        public string[] DatosCapturados;

        public string IdAEditar = "";

        public enum Especialidades
        {
            General,
            Electromecanica,
            Frenos,
            Transmision,
            Enderezado
        }

        public void CargarMecanico(string[] mecanico)
        {
            IdAEditar = mecanico[0];
            txtNombre.Text = mecanico[1];
            cmbEspecialidad.Text = mecanico[2];
            mtxTelefono.Text = mecanico[3];
            cmbEstado.Text = mecanico[4];
        }
        public FrmNuevoMecanico()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmNuevoMecanico_Load(object sender, EventArgs e)
        {
            cmbEspecialidad.DataSource = Enum.GetValues<Especialidades>();
            cmbEspecialidad.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool hayErrores = false;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre es obligatorio.");
                hayErrores = true;
            }
            else if (FrmMecanicos.listaMecanicos.Any(m => m[1].ToUpper() == txtNombre.Text.ToUpper() && m[0] != IdAEditar))
            {
                errorProvider1.SetError(txtNombre, "Este mecánico ya está registrado.");
                hayErrores = true;
            }

            if (string.IsNullOrWhiteSpace(cmbEspecialidad.Text))
            {
                errorProvider1.SetError(cmbEspecialidad, "Seleccione una especialidad.");
                hayErrores = true;
            }

            if (!mtxTelefono.MaskFull)
            {
                errorProvider1.SetError(mtxTelefono, "Ingrese el teléfono completo.");
                hayErrores = true;
            }

            if (string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                errorProvider1.SetError(cmbEstado, "Seleccione el estado del mecánico.");
                hayErrores = true;
            }

            if (hayErrores) return;

            string idFinal = string.IsNullOrEmpty(IdAEditar) ? (FrmMecanicos.listaMecanicos.Count + 1).ToString() : IdAEditar;

            DatosCapturados = new string[]
            {
    idFinal,
    txtNombre.Text,
    cmbEspecialidad.Text,
    mtxTelefono.Text,
    cmbEstado.Text
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FrmNuevoMecanico_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; 
                SendKeys.Send("{TAB}"); 
            }
        }
    }
}
