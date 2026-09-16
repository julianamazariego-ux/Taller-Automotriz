using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmNuevoCliente : Form
    {
        public static List<Cliente> ListaClientes = new List<Cliente>();
        public FrmNuevoCliente()
        {
            InitializeComponent();
        }

        private void FrmNuevoCliente_KeyDown(object? sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private Cliente? clienteExistente;

        public FrmNuevoCliente(Cliente cliente) : this()
        {
            this.clienteExistente = cliente;

            txtNombre.Text = cliente.Nombre;
            mtxtDUI.Text = cliente.DUI;
            mtxtTelefono.Text = cliente.Telefono;
            txtCorreo.Text = cliente.Correo;
            txtDirección.Text = cliente.Dirección;
        }
        private static readonly Regex RegexCorreo = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        private void FrmNuevoCliente_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;

            txtNombre.TextChanged += ValidarFormulario;
            mtxtDUI.TextChanged += ValidarFormulario;
            mtxtTelefono.TextChanged += ValidarFormulario;
            txtCorreo.TextChanged += ValidarFormulario;
            txtDirección.TextChanged += ValidarFormulario;
        }

        private void ValidarFormulario(object? sender, EventArgs e)
        {
            bool nombreOK = !string.IsNullOrWhiteSpace(txtNombre.Text);
            bool duiOK = mtxtDUI.MaskCompleted;
            bool telefonoOK = mtxtTelefono.MaskCompleted;
            bool correoOK = !string.IsNullOrWhiteSpace(txtCorreo.Text) && RegexCorreo.IsMatch(txtCorreo.Text);
            bool direcciónOK = !string.IsNullOrWhiteSpace(txtDirección.Text);

            errorProvider1.SetError(txtNombre, nombreOK ? "" : "Ingrese el nombre");
            errorProvider1.SetError(mtxtDUI, duiOK ? "" : "Ingrese el DUI");
            errorProvider1.SetError(mtxtTelefono, telefonoOK ? "" : "Ingrese el telefono");
            errorProvider1.SetError(txtCorreo, correoOK ? "" : "Correo no valido");
            errorProvider1.SetError(txtDirección, direcciónOK ? "" : "Ingrese la dirección");

            btnGuardar.Enabled = nombreOK && duiOK && telefonoOK && correoOK && direcciónOK;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteExistente == null && ListaClientes.Any(c => c.DUI == mtxtDUI.Text))
                {
                    MessageBox.Show("Ya existe un cliente regisstrado con este DUI.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (clienteExistente != null)
                {
                    clienteExistente.Nombre = txtNombre.Text.Trim();
                    clienteExistente.DUI = mtxtDUI.Text;
                    clienteExistente.Telefono = mtxtTelefono.Text;
                    clienteExistente.Correo = txtCorreo.Text.Trim();
                    clienteExistente.Dirección = txtDirección.Text.Trim();

                    MessageBox.Show("Cliente actualizado exitosamemte.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Cliente nuevoCliente = new Cliente
                    {
                        Nombre = txtNombre.Text.Trim(),
                        DUI = mtxtDUI.Text,
                        Telefono = mtxtTelefono.Text,
                        Correo = txtCorreo.Text.Trim(),
                        Dirección = txtDirección.Text.Trim()
                    };
                    ListaClientes.Add(nuevoCliente);
                    MessageBox.Show("Cliente registrado exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
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

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            mtxtDUI.Clear();
            mtxtTelefono.Clear();
            txtCorreo.Clear();
            txtDirección.Clear();

            errorProvider1.Clear();
            btnGuardar.Enabled = false;

            txtNombre.Focus();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Campos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }

    public class Cliente
    {
        public string Nombre { get; set; } = string.Empty;
        public string DUI { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Dirección { get; set; } = string.Empty;
    }
}
