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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevoCliente));
            lblTitulo = new Label();
            lblNombreC = new Label();
            lblDui = new Label();
            lblTelefono = new Label();
            lblCorreoE = new Label();
            lblDireccion = new Label();
            txtNombre = new TextBox();
            txtDUI = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtDireccion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            // lblDui
            // 
            lblDui.AutoSize = true;
            lblDui.ForeColor = Color.White;
            lblDui.Location = new Point(98, 242);
            lblDui.Margin = new Padding(4, 0, 4, 0);
            lblDui.Name = "lblDui";
            lblDui.Size = new Size(42, 25);
            lblDui.TabIndex = 2;
            lblDui.Text = "DUI";
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
            // lblCorreoE
            // 
            lblCorreoE.AutoSize = true;
            lblCorreoE.ForeColor = Color.White;
            lblCorreoE.Location = new Point(98, 371);
            lblCorreoE.Margin = new Padding(4, 0, 4, 0);
            lblCorreoE.Name = "lblCorreoE";
            lblCorreoE.Size = new Size(157, 25);
            lblCorreoE.TabIndex = 4;
            lblCorreoE.Text = "Correo electronico";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.ForeColor = Color.White;
            lblDireccion.Location = new Point(98, 439);
            lblDireccion.Margin = new Padding(4, 0, 4, 0);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(85, 25);
            lblDireccion.TabIndex = 5;
            lblDireccion.Text = "Direccion";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(286, 182);
            txtNombre.Margin = new Padding(4, 5, 4, 5);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(501, 31);
            txtNombre.TabIndex = 6;
            // 
            // txtDUI
            // 
            txtDUI.Location = new Point(286, 236);
            txtDUI.Margin = new Padding(4, 5, 4, 5);
            txtDUI.Name = "txtDUI";
            txtDUI.Size = new Size(208, 31);
            txtDUI.TabIndex = 7;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(286, 301);
            txtTelefono.Margin = new Padding(4, 5, 4, 5);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(208, 31);
            txtTelefono.TabIndex = 8;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(286, 365);
            txtCorreo.Margin = new Padding(4, 5, 4, 5);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(501, 31);
            txtCorreo.TabIndex = 9;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(286, 433);
            txtDireccion.Margin = new Padding(4, 5, 4, 5);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(501, 31);
            txtDireccion.TabIndex = 10;
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
            // FrmNuevoCliente
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(924, 668);
            Controls.Add(pictureBox2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtDireccion);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtDUI);
            Controls.Add(txtNombre);
            Controls.Add(lblDireccion);
            Controls.Add(lblCorreoE);
            Controls.Add(lblTelefono);
            Controls.Add(lblDui);
            Controls.Add(lblNombreC);
            Controls.Add(lblTitulo);
            Controls.Add(pictureBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmNuevoCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar Nuevo Cliente";
            Load += FrmNuevoCliente_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNombreC;
        private Label lblDui;
        private Label lblTelefono;
        private Label lblCorreoE;
        private Label lblDireccion;
        private TextBox txtNombre;
        private TextBox txtDUI;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtDireccion;
        private Button btnGuardar;
        private Button btnCancelar;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}