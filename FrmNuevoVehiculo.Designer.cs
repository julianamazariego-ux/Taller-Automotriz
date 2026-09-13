namespace Taller_Automotriz
{
    partial class FrmNuevoVehiculo
    {
        
        private System.ComponentModel.IContainer components = null;

        
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevoVehiculo));
            lblTitulo = new Label();
            lblPlaca = new Label();
            lblMarca = new Label();
            lblModelo = new Label();
            lblAño = new Label();
            lblColor = new Label();
            txtPlaca = new TextBox();
            txtModelo = new TextBox();
            cmbCliente = new ComboBox();
            lblClienteP = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            errorProvider1 = new ErrorProvider(components);
            cmbMarca = new ComboBox();
            cmbColor = new ComboBox();
            mtxAnio = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.FromArgb(45, 45, 48);
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ButtonHighlight;
            lblTitulo.Location = new Point(314, 73);
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
            lblPlaca.Location = new Point(165, 188);
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
            lblMarca.Location = new Point(155, 254);
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
            lblModelo.Location = new Point(165, 325);
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
            lblAño.Location = new Point(165, 398);
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
            lblColor.Location = new Point(165, 469);
            lblColor.Margin = new Padding(4, 0, 4, 0);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(55, 25);
            lblColor.TabIndex = 5;
            lblColor.Text = "Color";
            // 
            // txtPlaca
            // 
            txtPlaca.BackColor = Color.White;
            txtPlaca.BorderStyle = BorderStyle.FixedSingle;
            txtPlaca.ForeColor = Color.Black;
            txtPlaca.Location = new Point(373, 179);
            txtPlaca.Margin = new Padding(4, 5, 4, 5);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(340, 31);
            txtPlaca.TabIndex = 6;
            // 
            // txtModelo
            // 
            txtModelo.BackColor = Color.White;
            txtModelo.BorderStyle = BorderStyle.FixedSingle;
            txtModelo.ForeColor = Color.Black;
            txtModelo.Location = new Point(373, 317);
            txtModelo.Margin = new Padding(4, 5, 4, 5);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(340, 31);
            txtModelo.TabIndex = 8;
            // 
            // cmbCliente
            // 
            cmbCliente.BackColor = Color.White;
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.ForeColor = Color.Black;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Items.AddRange(new object[] { "Juan Perez", "Carlos Augusto", "Christian Cedillos" });
            cmbCliente.Location = new Point(373, 531);
            cmbCliente.Margin = new Padding(4, 5, 4, 5);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(339, 33);
            cmbCliente.TabIndex = 11;
            // 
            // lblClienteP
            // 
            lblClienteP.AutoSize = true;
            lblClienteP.ForeColor = Color.White;
            lblClienteP.Location = new Point(155, 543);
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
            btnGuardar.Location = new Point(165, 627);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(108, 38);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(192, 57, 43);
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(314, 627);
            btnCancelar.Margin = new Padding(4, 5, 4, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(108, 38);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = Properties.Resources.cab7fde32b9417310bd7e89b6ce5400c_removebg_preview;
            pictureBox1.Location = new Point(4, -46);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(960, 795);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(133, 44);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(140, 107);
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // cmbMarca
            // 
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Items.AddRange(new object[] { "Toyota", "Nissan", "Honda", "Ford", "Kia" });
            cmbMarca.Location = new Point(373, 246);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(274, 33);
            cmbMarca.TabIndex = 17;
            // 
            // cmbColor
            // 
            cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "Blanco", "Negro", "Rojo", "Azul", "Gris", "Plata" });
            cmbColor.Location = new Point(373, 461);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(265, 33);
            cmbColor.TabIndex = 18;
            // 
            // mtxAnio
            // 
            mtxAnio.Location = new Point(373, 380);
            mtxAnio.Mask = "0000";
            mtxAnio.Name = "mtxAnio";
            mtxAnio.Size = new Size(150, 31);
            mtxAnio.TabIndex = 19;
            // 
            // FrmNuevoVehiculo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(887, 731);
            Controls.Add(mtxAnio);
            Controls.Add(cmbColor);
            Controls.Add(cmbMarca);
            Controls.Add(pictureBox2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblClienteP);
            Controls.Add(cmbCliente);
            Controls.Add(txtModelo);
            Controls.Add(txtPlaca);
            Controls.Add(lblColor);
            Controls.Add(lblAño);
            Controls.Add(lblModelo);
            Controls.Add(lblMarca);
            Controls.Add(lblPlaca);
            Controls.Add(lblTitulo);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmNuevoVehiculo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar Nuevo Vehículo";
            Load += FrmNuevoVehiculo_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
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
        private TextBox txtModelo;
        private ComboBox cmbCliente;
        private Label lblClienteP;
        private Button btnGuardar;
        private Button btnCancelar;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ErrorProvider errorProvider1;
        private ComboBox cmbMarca;
        private ComboBox cmbColor;
        private MaskedTextBox mtxAnio;
    }
}