namespace Taller_Automotriz
{
    partial class FrmNuevoVehiculo
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblPlaca = new Label();
            lblMarca = new Label();
            lblModelo = new Label();
            lblAño = new Label();
            lblColor = new Label();
            txtPlaca = new TextBox();
            txtMarca = new TextBox();
            txtModelo = new TextBox();
            txtAño = new TextBox();
            txtColor = new TextBox();
            cmbCliente = new ComboBox();
            lblClienteP = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(214, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(314, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRAR NUEVO VEHÍCULO";
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Location = new Point(45, 80);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(38, 15);
            lblPlaca.TabIndex = 1;
            lblPlaca.Text = "Placa:";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(45, 137);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(46, 15);
            lblMarca.TabIndex = 2;
            lblMarca.Text = " Marca:";
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(45, 184);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(48, 15);
            lblModelo.TabIndex = 3;
            lblModelo.Text = "Modelo";
            // 
            // lblAño
            // 
            lblAño.AutoSize = true;
            lblAño.Location = new Point(45, 240);
            lblAño.Name = "lblAño";
            lblAño.Size = new Size(29, 15);
            lblAño.TabIndex = 4;
            lblAño.Text = "Año";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new Point(38, 296);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(36, 15);
            lblColor.TabIndex = 5;
            lblColor.Text = "Color";
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(164, 80);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(100, 23);
            txtPlaca.TabIndex = 6;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(164, 137);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(100, 23);
            txtMarca.TabIndex = 7;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(164, 184);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(100, 23);
            txtModelo.TabIndex = 8;
            // 
            // txtAño
            // 
            txtAño.Location = new Point(164, 240);
            txtAño.Name = "txtAño";
            txtAño.Size = new Size(100, 23);
            txtAño.TabIndex = 9;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(164, 288);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(100, 23);
            txtColor.TabIndex = 10;
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(164, 342);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(121, 23);
            cmbCliente.TabIndex = 11;
            // 
            // lblClienteP
            // 
            lblClienteP.AutoSize = true;
            lblClienteP.Location = new Point(26, 350);
            lblClienteP.Name = "lblClienteP";
            lblClienteP.Size = new Size(111, 15);
            lblClienteP.TabIndex = 12;
            lblClienteP.Text = " Cliente propietario:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(150, 397);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(480, 397);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmNuevoVehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblClienteP);
            Controls.Add(cmbCliente);
            Controls.Add(txtColor);
            Controls.Add(txtAño);
            Controls.Add(txtModelo);
            Controls.Add(txtMarca);
            Controls.Add(txtPlaca);
            Controls.Add(lblColor);
            Controls.Add(lblAño);
            Controls.Add(lblModelo);
            Controls.Add(lblMarca);
            Controls.Add(lblPlaca);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FrmNuevoVehiculo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar Nuevo Vehículo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblPlaca;
        private Label lblMarca;
        private Label lblModelo;
        private Label lblAño;
        private Label lblColor;
        private TextBox txtPlaca;
        private TextBox txtMarca;
        private TextBox txtModelo;
        private TextBox txtAño;
        private TextBox txtColor;
        private ComboBox cmbCliente;
        private Label lblClienteP;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}