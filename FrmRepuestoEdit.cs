using System;
using System.ComponentModel;
using System.Windows.Forms;
using TallerAutomotriz.Models;
using TallerAutomotriz.Repositorios;

namespace TallerAutomotriz
{
    public partial class FrmRepuestoEdit : Form
    {
        private readonly Repuesto? repuestoExistente;

        public Repuesto? RepuestoGuardado { get; private set; }

        public FrmRepuestoEdit()
        {
            InitializeComponent();

            numPrecio.Maximum = 1000000;
            numCantidad.Maximum = 1000000;

            cmbCategoria.DataSource = Enum.GetValues(typeof(CategoriaRepuesto));
            txtNombre.Validating += txtNombre_Validating;
            numPrecio.Validating += numPrecio_Validating;
            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;

            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        public FrmRepuestoEdit(Repuesto repuestoAEditar) : this()
        {
            repuestoExistente = repuestoAEditar;

            txtNombre.Text = repuestoAEditar.Nombre;
            numPrecio.Value = repuestoAEditar.Precio;
            cmbCategoria.SelectedItem = repuestoAEditar.Categoria;
            numCantidad.Value = repuestoAEditar.CantidadDisponible;
        }

        private void txtNombre_Validating(object? sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNombre, "El nombre no puede estar vacío.");
            }
            else
            {
                errorProvider1.SetError(txtNombre, "");
            }
        }

        private void numPrecio_Validating(object? sender, CancelEventArgs e)
        {
            if (numPrecio.Value <= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(numPrecio, "El precio debe ser mayor a $0.00.");
            }
            else
            {
                errorProvider1.SetError(numPrecio, "");
            }
        }

        private void btnAceptar_Click(object? sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Por favor, corrija los errores marcados en rojo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var categoria = (CategoriaRepuesto)cmbCategoria.SelectedItem!;

                if (repuestoExistente == null)
                {
                    var nuevo = new Repuesto(txtNombre.Text, numPrecio.Value, categoria, (int)numCantidad.Value);

                    ContextoDatos.Repuestos.Agregar(nuevo);
                    RepuestoGuardado = nuevo;
                }
                else
                {
                    if (ContextoDatos.Repuestos.ExisteNombre(txtNombre.Text, repuestoExistente))
                    {
                        MessageBox.Show("El nombre ingresado pertenece a otro repuesto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    repuestoExistente.Nombre = txtNombre.Text;
                    repuestoExistente.Precio = numPrecio.Value;
                    repuestoExistente.Categoria = categoria;
                    repuestoExistente.CantidadDisponible = (int)numCantidad.Value;

                    ContextoDatos.Repuestos.Actualizar(repuestoExistente);
                    RepuestoGuardado = repuestoExistente;
                }

                this.DialogResult = DialogResult.OK;
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

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}