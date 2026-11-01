using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TallerAutomotriz.Models;
using TallerAutomotriz.Repositorios;

namespace TallerAutomotriz
{
    public partial class FrmNuevoMecanico : Form
    {
        private Mecanico? mecanicoExistente;

        public Mecanico? MecanicoGuardado { get; private set; }

        public void CargarMecanico(Mecanico mecanico)
        {
            mecanicoExistente = mecanico;
            txtNombre.Text = mecanico.Nombre;
            mtxTelefono.Text = mecanico.Telefono;
            cmbEstado.Text = mecanico.Disponible ? "Activo" : "Inactivo";
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
            cmbEspecialidad.DataSource = Enum.GetValues<EspecialidadMecanico>();

            if (mecanicoExistente != null)
                cmbEspecialidad.SelectedItem = mecanicoExistente.Especialidad;
            else
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
            

            if (cmbEspecialidad.SelectedItem is not EspecialidadMecanico)
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

            if (!string.IsNullOrWhiteSpace(txtNombre.Text)
                && cmbEspecialidad.SelectedItem is EspecialidadMecanico especialidadElegida
                && mtxTelefono.MaskFull
                && ContextoDatos.Mecanicos.ExisteMecanico(txtNombre.Text, especialidadElegida, mtxTelefono.Text, mecanicoExistente))
            {
                errorProvider1.SetError(txtNombre, "Ya existe un mecánico con el mismo nombre, especialidad y teléfono.");
                hayErrores = true;
            }

            if (hayErrores) return;

            try
            {
                var especialidad = (EspecialidadMecanico)cmbEspecialidad.SelectedItem!;
                bool disponible = cmbEstado.Text == "Activo";

                if (mecanicoExistente == null)
                {
                    var nuevo = new Mecanico
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Telefono = mtxTelefono.Text,
                        Especialidad = especialidad,
                        Disponible = disponible
                    };

                    ContextoDatos.Mecanicos.Agregar(nuevo);
                    MecanicoGuardado = nuevo;
                }
                else
                {
                    mecanicoExistente.Nombre = txtNombre.Text.Trim();
                    mecanicoExistente.Telefono = mtxTelefono.Text;
                    mecanicoExistente.Especialidad = especialidad;
                    mecanicoExistente.Disponible = disponible;

                    ContextoDatos.Mecanicos.Actualizar(mecanicoExistente);
                    MecanicoGuardado = mecanicoExistente;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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