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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.FromArgb(45, 45, 48);
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ButtonHighlight;
            lblTitulo.Location = new Point(265, 46);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(402, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRAR NUEVO VEHÍCULO";
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.ForeColor = Color.White;
            lblPlaca.Location = new Point(146, 119);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(47, 20);
            lblPlaca.TabIndex = 1;
            lblPlaca.Text = "Placa:";
            lblPlaca.Click += lblPlaca_Click;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(138, 172);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(57, 20);
            lblMarca.TabIndex = 2;
            lblMarca.Text = " Marca:";
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.ForeColor = Color.White;
            lblModelo.Location = new Point(146, 229);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(61, 20);
            lblModelo.TabIndex = 3;
            lblModelo.Text = "Modelo";
            // 
            // lblAño
            // 
            lblAño.AutoSize = true;
            lblAño.ForeColor = Color.White;
            lblAño.Location = new Point(146, 287);
            lblAño.Name = "lblAño";
            lblAño.Size = new Size(36, 20);
            lblAño.TabIndex = 4;
            lblAño.Text = "Año";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.ForeColor = Color.White;
            lblColor.Location = new Point(146, 344);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(45, 20);
            lblColor.TabIndex = 5;
            lblColor.Text = "Color";
            // 
            // txtPlaca
            // 
            txtPlaca.BackColor = Color.White;
            txtPlaca.BorderStyle = BorderStyle.FixedSingle;
            txtPlaca.ForeColor = Color.Black;
            txtPlaca.Location = new Point(312, 112);
            txtPlaca.Margin = new Padding(3, 4, 3, 4);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(272, 27);
            txtPlaca.TabIndex = 6;
            // 
            // txtMarca
            // 
            txtMarca.BackColor = Color.White;
            txtMarca.BorderStyle = BorderStyle.FixedSingle;
            txtMarca.ForeColor = Color.Black;
            txtMarca.Location = new Point(312, 166);
            txtMarca.Margin = new Padding(3, 4, 3, 4);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(272, 27);
            txtMarca.TabIndex = 7;
            // 
            // txtModelo
            // 
            txtModelo.BackColor = Color.White;
            txtModelo.BorderStyle = BorderStyle.FixedSingle;
            txtModelo.ForeColor = Color.Black;
            txtModelo.Location = new Point(312, 222);
            txtModelo.Margin = new Padding(3, 4, 3, 4);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(272, 27);
            txtModelo.TabIndex = 8;
            // 
            // txtAño
            // 
            txtAño.BackColor = Color.White;
            txtAño.BorderStyle = BorderStyle.FixedSingle;
            txtAño.ForeColor = Color.Black;
            txtAño.Location = new Point(312, 280);
            txtAño.Margin = new Padding(3, 4, 3, 4);
            txtAño.Name = "txtAño";
            txtAño.Size = new Size(272, 27);
            txtAño.TabIndex = 9;
            // 
            // txtColor
            // 
            txtColor.BackColor = Color.White;
            txtColor.BorderStyle = BorderStyle.FixedSingle;
            txtColor.ForeColor = Color.Black;
            txtColor.Location = new Point(312, 337);
            txtColor.Margin = new Padding(3, 4, 3, 4);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(272, 27);
            txtColor.TabIndex = 10;
            // 
            // cmbCliente
            // 
            cmbCliente.BackColor = Color.White;
            cmbCliente.ForeColor = Color.Black;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(312, 394);
            cmbCliente.Margin = new Padding(3, 4, 3, 4);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(272, 28);
            cmbCliente.TabIndex = 11;
            // 
            // lblClienteP
            // 
            lblClienteP.AutoSize = true;
            lblClienteP.ForeColor = Color.White;
            lblClienteP.Location = new Point(138, 403);
            lblClienteP.Name = "lblClienteP";
            lblClienteP.Size = new Size(141, 20);
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
            btnGuardar.Location = new Point(344, 457);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(86, 30);
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
            btnCancelar.Location = new Point(659, 457);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 30);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = Properties.Resources.cab7fde32b9417310bd7e89b6ce5400c_removebg_preview;
            pictureBox1.Location = new Point(166, -11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(624, 562);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // FrmNuevoVehiculo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(914, 600);
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
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmNuevoVehiculo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar Nuevo Vehículo";
            Load += FrmNuevoVehiculo_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}