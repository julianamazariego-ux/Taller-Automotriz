using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public enum CategoriaRepuesto
    {
        Filtros,
        Bujias,
        Pastillas,
        Mangueras,
        Sensores,
        Electrico,
        Varias
    }

    public partial class FrmRepuestoEdit : Form
    {
        public Repuesto RepuestoCreado { get; private set; }

        public FrmRepuestoEdit()
        {
            InitializeComponent();

            cmbCategoria.DataSource = Enum.GetValues(typeof(CategoriaRepuesto));
            txtNombre.Validating += txtNombre_Validating;
            numPrecio.Validating += numPrecio_Validating;
            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;

            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        }

        public FrmRepuestoEdit(Repuesto repuestoAEditar) : this()
        {
            txtNombre.Text = repuestoAEditar.Nombre;
            numPrecio.Value = repuestoAEditar.Precio;
            cmbCategoria.SelectedItem = repuestoAEditar.Categoria;
            numCantidad.Value = repuestoAEditar.CantidadDisponible;
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
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

        private void numPrecio_Validating(object sender, CancelEventArgs e)
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                RepuestoCreado = new Repuesto();
                RepuestoCreado.Nombre = txtNombre.Text;
                RepuestoCreado.Precio = numPrecio.Value;
                RepuestoCreado.Categoria = (CategoriaRepuesto)cmbCategoria.SelectedItem;
                RepuestoCreado.CantidadDisponible = (int)numCantidad.Value;

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Por favor, corrija los errores marcados en rojo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}