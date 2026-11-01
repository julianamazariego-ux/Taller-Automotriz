using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TallerAutomotriz.Models;
using TallerAutomotriz.Repositorios;

namespace TallerAutomotriz
{
    public partial class FrmNuevoCliente : Form
    {
        
        private readonly Cliente? clienteExistente;

        public FrmNuevoCliente()
        {
            InitializeComponent();
        }

        public FrmNuevoCliente(Cliente cliente) : this()
        {
            clienteExistente = cliente;

            txtNombre.Text = cliente.Nombre;
            mtxtDUI.Text = cliente.Dui;
            mtxtTelefono.Text = cliente.Telefono;
            txtCorreo.Text = cliente.Correo;
            txtDirección.Text = cliente.Direccion;
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
                
                if (ContextoDatos.Clientes.ExisteDui(mtxtDUI.Text, clienteExistente))
                {
                    MessageBox.Show("Ya existe un cliente registrado con este DUI.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (clienteExistente != null)
                {
                    clienteExistente.Nombre = txtNombre.Text.Trim();
                    clienteExistente.Dui = mtxtDUI.Text;
                    clienteExistente.Telefono = mtxtTelefono.Text;
                    clienteExistente.Correo = txtCorreo.Text.Trim();
                    clienteExistente.Direccion = txtDirección.Text.Trim();

                    ContextoDatos.Clientes.Actualizar(clienteExistente);

                    MessageBox.Show("Cliente actualizado exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var nuevoCliente = new Cliente(
                        txtNombre.Text.Trim(),
                        mtxtDUI.Text,
                        mtxtTelefono.Text,
                        txtDirección.Text.Trim(),
                        txtCorreo.Text.Trim());

                    ContextoDatos.Clientes.Agregar(nuevoCliente);

                    MessageBox.Show("Cliente registrado exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}