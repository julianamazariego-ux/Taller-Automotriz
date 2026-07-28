using System;
using System.Drawing;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public class FrmRepuestoEdit : Form
    {
        private TextBox txtNombre;
        private NumericUpDown numPrecio;
        private Button btnOk;
        private Button btnCancel;

        public string RepuestoNombre { get; private set; }
        public decimal RepuestoPrecio { get; private set; }

        public FrmRepuestoEdit()
            : this(string.Empty, 0m)
        {
        }

        public FrmRepuestoEdit(string nombre, decimal precio)
        {
            InitializeComponent();
            txtNombre.Text = nombre;
            numPrecio.Value = precio;
        }

        private void InitializeComponent()
        {
            this.txtNombre = new TextBox();
            this.numPrecio = new NumericUpDown();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new Point(20, 20);
            this.txtNombre.Size = new Size(300, 30);
            this.txtNombre.PlaceholderText = "Nombre del repuesto";
            // 
            // numPrecio
            // 
            this.numPrecio.Location = new Point(20, 65);
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Maximum = 1000000;
            this.numPrecio.Size = new Size(150, 30);
            // 
            // btnOk
            // 
            this.btnOk.Location = new Point(40, 110);
            this.btnOk.Size = new Size(100, 30);
            this.btnOk.Text = "Aceptar";
            this.btnOk.DialogResult = DialogResult.OK;
            this.btnOk.Click += BtnOk_Click;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(170, 110);
            this.btnCancel.Size = new Size(100, 30);
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.DialogResult = DialogResult.Cancel;
            // 
            // FrmRepuestoEdit
            // 
            this.ClientSize = new Size(350, 160);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.numPrecio);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Agregar / Editar Repuesto";
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.ResumeLayout(false);
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            RepuestoNombre = txtNombre.Text.Trim();
            RepuestoPrecio = numPrecio.Value;
            if (string.IsNullOrEmpty(RepuestoNombre))
            {
                MessageBox.Show("Ingrese un nombre para el repuesto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
