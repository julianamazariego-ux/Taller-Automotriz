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
            txtNombre = new TextBox();
            numPrecio = new NumericUpDown();
            btnOk = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            SuspendLayout();
            
            txtNombre.Location = new Point(20, 20);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre del repuesto";
            txtNombre.Size = new Size(300, 31);
            txtNombre.TabIndex = 0;
            
            numPrecio.DecimalPlaces = 2;
            numPrecio.Location = new Point(20, 65);
            numPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(150, 31);
            numPrecio.TabIndex = 1;
           
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(40, 110);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(100, 30);
            btnOk.TabIndex = 2;
            btnOk.Text = "Aceptar";
            btnOk.Click += BtnOk_Click;
            
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(170, 110);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancelar";
          
            AcceptButton = btnOk;
            CancelButton = btnCancel;
            ClientSize = new Size(350, 160);
            Controls.Add(txtNombre);
            Controls.Add(numPrecio);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FrmRepuestoEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar / Editar Repuesto";
            Load += FrmRepuestoEdit_Load;
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ResumeLayout(false);
            PerformLayout();
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

        private void FrmRepuestoEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
