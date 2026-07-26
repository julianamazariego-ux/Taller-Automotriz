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
            lblTitulo.BackColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(331, 27);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(476, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRAR NUEVO VEHÍCULO";
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.ForeColor = Color.White;
            lblPlaca.Location = new Point(113, 146);
            lblPlaca.Margin = new Padding(4, 0, 4, 0);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(56, 25);
            lblPlaca.TabIndex = 1;
            lblPlaca.Text = "Placa:";
            lblPlaca.Click += lblPlaca_Click;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(103, 213);
            lblMarca.Margin = new Padding(4, 0, 4, 0);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(69, 25);
            lblMarca.TabIndex = 2;
            lblMarca.Text = " Marca:";
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.ForeColor = Color.White;
            lblModelo.Location = new Point(113, 284);
            lblModelo.Margin = new Padding(4, 0, 4, 0);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(74, 25);
            lblModelo.TabIndex = 3;
            lblModelo.Text = "Modelo";
            // 
            // lblAño
            // 
            lblAño.AutoSize = true;
            lblAño.ForeColor = Color.White;
            lblAño.Location = new Point(113, 356);
            lblAño.Margin = new Padding(4, 0, 4, 0);
            lblAño.Name = "lblAño";
            lblAño.Size = new Size(45, 25);
            lblAño.TabIndex = 4;
            lblAño.Text = "Año";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.ForeColor = Color.White;
            lblColor.Location = new Point(113, 427);
            lblColor.Margin = new Padding(4, 0, 4, 0);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(55, 25);
            lblColor.TabIndex = 5;
            lblColor.Text = "Color";
            // 
            // txtPlaca
            // 
            txtPlaca.BackColor = Color.FromArgb(62, 62, 66);
            txtPlaca.BorderStyle = BorderStyle.FixedSingle;
            txtPlaca.ForeColor = Color.White;
            txtPlaca.Location = new Point(303, 140);
            txtPlaca.Margin = new Padding(4, 5, 4, 5);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(141, 31);
            txtPlaca.TabIndex = 6;
            // 
            // txtMarca
            // 
            txtMarca.BackColor = Color.FromArgb(62, 62, 66);
            txtMarca.BorderStyle = BorderStyle.FixedSingle;
            txtMarca.ForeColor = Color.White;
            txtMarca.Location = new Point(303, 207);
            txtMarca.Margin = new Padding(4, 5, 4, 5);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(141, 31);
            txtMarca.TabIndex = 7;
            // 
            // txtModelo
            // 
            txtModelo.BackColor = Color.FromArgb(62, 62, 66);
            txtModelo.BorderStyle = BorderStyle.FixedSingle;
            txtModelo.ForeColor = Color.White;
            txtModelo.Location = new Point(303, 278);
            txtModelo.Margin = new Padding(4, 5, 4, 5);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(141, 31);
            txtModelo.TabIndex = 8;
            // 
            // txtAño
            // 
            txtAño.BackColor = Color.FromArgb(62, 62, 66);
            txtAño.BorderStyle = BorderStyle.FixedSingle;
            txtAño.ForeColor = Color.White;
            txtAño.Location = new Point(303, 350);
            txtAño.Margin = new Padding(4, 5, 4, 5);
            txtAño.Name = "txtAño";
            txtAño.Size = new Size(141, 31);
            txtAño.TabIndex = 9;
            // 
            // txtColor
            // 
            txtColor.BackColor = Color.FromArgb(62, 62, 66);
            txtColor.BorderStyle = BorderStyle.FixedSingle;
            txtColor.ForeColor = Color.White;
            txtColor.Location = new Point(303, 421);
            txtColor.Margin = new Padding(4, 5, 4, 5);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(141, 31);
            txtColor.TabIndex = 10;
            // 
            // cmbCliente
            // 
            cmbCliente.BackColor = Color.FromArgb(62, 62, 66);
            cmbCliente.ForeColor = Color.White;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(303, 493);
            cmbCliente.Margin = new Padding(4, 5, 4, 5);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(339, 33);
            cmbCliente.TabIndex = 11;
            // 
            // lblClienteP
            // 
            lblClienteP.AutoSize = true;
            lblClienteP.ForeColor = Color.White;
            lblClienteP.Location = new Point(103, 501);
            lblClienteP.Margin = new Padding(4, 0, 4, 0);
            lblClienteP.Name = "lblClienteP";
            lblClienteP.Size = new Size(167, 25);
            lblClienteP.TabIndex = 12;
            lblClienteP.Text = " Cliente propietario:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(0, 124, 204);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(113, 571);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(107, 38);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(62, 62, 66);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(258, 571);
            btnCancelar.Margin = new Padding(4, 5, 4, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 38);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmNuevoVehiculo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(1143, 750);
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
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmNuevoVehiculo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar Nuevo Vehículo";
            Load += FrmNuevoVehiculo_Load;
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