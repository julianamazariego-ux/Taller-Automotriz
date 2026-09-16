namespace Taller_Automotriz
{
    partial class FrmNuevoCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevoCliente));
            lblTitulo = new Label();
            lblNombreC = new Label();
            lblDUI = new Label();
            lblTelefono = new Label();
            lblCorreo = new Label();
            lblDirección = new Label();
            txtNombre = new TextBox();
            txtCorreo = new TextBox();
            txtDirección = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            mtxtDUI = new MaskedTextBox();
            mtxtTelefono = new MaskedTextBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(276, 61);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(445, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRAR NUEVO CLIENTE";
            // 
            // lblNombreC
            // 
            lblNombreC.AutoSize = true;
            lblNombreC.ForeColor = Color.White;
            lblNombreC.Location = new Point(98, 182);
            lblNombreC.Margin = new Padding(4, 0, 4, 0);
            lblNombreC.Name = "lblNombreC";
            lblNombreC.Size = new Size(163, 25);
            lblNombreC.TabIndex = 1;
            lblNombreC.Text = "Nombre completo:";
            // 
            // lblDUI
            // 
            lblDUI.AutoSize = true;
            lblDUI.ForeColor = Color.White;
            lblDUI.Location = new Point(98, 242);
            lblDUI.Margin = new Padding(4, 0, 4, 0);
            lblDUI.Name = "lblDUI";
            lblDUI.Size = new Size(42, 25);
            lblDUI.TabIndex = 2;
            lblDUI.Text = "DUI";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.ForeColor = Color.White;
            lblTelefono.Location = new Point(98, 307);
            lblTelefono.Margin = new Padding(4, 0, 4, 0);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(79, 25);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "Telefono";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.ForeColor = Color.White;
            lblCorreo.Location = new Point(98, 371);
            lblCorreo.Margin = new Padding(4, 0, 4, 0);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(157, 25);
            lblCorreo.TabIndex = 4;
            lblCorreo.Text = "Correo electronico";
            // 
            // lblDirección
            // 
            lblDirección.AutoSize = true;
            lblDirección.ForeColor = Color.White;
            lblDirección.Location = new Point(98, 439);
            lblDirección.Margin = new Padding(4, 0, 4, 0);
            lblDirección.Name = "lblDirección";
            lblDirección.Size = new Size(85, 25);
            lblDirección.TabIndex = 5;
            lblDirección.Text = "Dirección";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(286, 182);
            txtNombre.Margin = new Padding(4, 5, 4, 5);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(501, 31);
            txtNombre.TabIndex = 0;
            txtNombre.KeyDown += Campos_KeyDown;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(286, 365);
            txtCorreo.Margin = new Padding(4, 5, 4, 5);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(501, 31);
            txtCorreo.TabIndex = 3;
            txtCorreo.KeyDown += Campos_KeyDown;
            // 
            // txtDirección
            // 
            txtDirección.Location = new Point(286, 433);
            txtDirección.Margin = new Padding(4, 5, 4, 5);
            txtDirección.Name = "txtDirección";
            txtDirección.Size = new Size(501, 31);
            txtDirección.TabIndex = 4;
            txtDirección.KeyDown += Campos_KeyDown;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(0, 124, 204);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(107, 533);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(107, 38);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(192, 57, 43);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(240, 533);
            btnCancelar.Margin = new Padding(4, 5, 4, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 38);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.cab7fde32b9417310bd7e89b6ce5400c_removebg_preview;
            pictureBox1.Location = new Point(-5, -12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(940, 685);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(107, 43);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(148, 84);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // mtxtDUI
            // 
            mtxtDUI.Location = new Point(286, 239);
            mtxtDUI.Mask = "00000000-0";
            mtxtDUI.Name = "mtxtDUI";
            mtxtDUI.Size = new Size(150, 31);
            mtxtDUI.TabIndex = 1;
            mtxtDUI.KeyDown += Campos_KeyDown;
            // 
            // mtxtTelefono
            // 
            mtxtTelefono.Location = new Point(286, 304);
            mtxtTelefono.Mask = "0000-0000";
            mtxtTelefono.Name = "mtxtTelefono";
            mtxtTelefono.Size = new Size(150, 31);
            mtxtTelefono.TabIndex = 2;
            mtxtTelefono.KeyDown += Campos_KeyDown;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmNuevoCliente
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(924, 668);
            Controls.Add(mtxtTelefono);
            Controls.Add(mtxtDUI);
            Controls.Add(pictureBox2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtDirección);
            Controls.Add(txtCorreo);
            Controls.Add(txtNombre);
            Controls.Add(lblDirección);
            Controls.Add(lblCorreo);
            Controls.Add(lblTelefono);
            Controls.Add(lblDUI);
            Controls.Add(lblNombreC);
            Controls.Add(lblTitulo);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmNuevoCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar Nuevo Cliente";
            Load += FrmNuevoCliente_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNombreC;
        private Label lblDUI;
        private Label lblTelefono;
        private Label lblCorreo;
        private Label lblDirección;
        private TextBox txtNombre;
        private TextBox txtCorreo;
        private TextBox txtDirección;
        private Button btnGuardar;
        private Button btnCancelar;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private MaskedTextBox mtxtDUI;
        private MaskedTextBox mtxtTelefono;
        private ErrorProvider errorProvider1;
    }
}