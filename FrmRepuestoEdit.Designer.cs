namespace Taller_Automotriz
{
    partial class FrmRepuestoEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNombre = new TextBox();
            numPrecio = new NumericUpDown();
            cmbCategoria = new ComboBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            label4 = new Label();
            numCantidad = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
          
            label1.AutoSize = true;
            label1.Location = new Point(210, 110);
            label1.Name = "label1";
            label1.Size = new Size(82, 25);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
           
            label2.AutoSize = true;
            label2.Location = new Point(210, 165);
            label2.Name = "label2";
            label2.Size = new Size(64, 25);
            label2.TabIndex = 1;
            label2.Text = "Precio:";
            
            label3.AutoSize = true;
            label3.Location = new Point(210, 266);
            label3.Name = "label3";
            label3.Size = new Size(92, 25);
            label3.TabIndex = 2;
            label3.Text = "Categoria:";
            
            txtNombre.Location = new Point(416, 110);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(180, 31);
            txtNombre.TabIndex = 3;
            
            numPrecio.DecimalPlaces = 2;
            numPrecio.Location = new Point(416, 165);
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(180, 31);
            numPrecio.TabIndex = 4;
            
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(414, 266);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(182, 33);
            cmbCategoria.TabIndex = 5;
            
            btnAceptar.Location = new Point(173, 357);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(112, 34);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            
            btnCancelar.Location = new Point(484, 357);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 34);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
                        errorProvider1.ContainerControl = this;
            
            label4.AutoSize = true;
            label4.Location = new Point(210, 218);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 8;
            label4.Text = "Cantidad:";
            
            numCantidad.Location = new Point(416, 218);
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(180, 31);
            numCantidad.TabIndex = 9;
            
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numCantidad);
            Controls.Add(label4);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(cmbCategoria);
            Controls.Add(numPrecio);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmRepuestoEdit";
            Text = "FrmRepuestoEdit";
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNombre;
        private NumericUpDown numPrecio;
        private ComboBox cmbCategoria;
        private Button btnAceptar;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
        private Label label4;
        private NumericUpDown numCantidad;
    }
}