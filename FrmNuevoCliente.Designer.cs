namespace Taller_Automotriz
{
    partial class FrmNuevoCliente
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
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(211, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(294, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRAR NUEVO CLIENTE";
            // 
            // lblNombreC
            // 
            lblNombreC.AutoSize = true;
            lblNombreC.Location = new Point(36, 87);
            lblNombreC.Name = "lblNombreC";
            lblNombreC.Size = new Size(108, 15);
            lblNombreC.TabIndex = 1;
            lblNombreC.Text = "Nombre completo:";
            // 
            // lblDui
            // 
            lblDui.AutoSize = true;
            lblDui.Location = new Point(36, 142);
            lblDui.Name = "lblDui";
            lblDui.Size = new Size(26, 15);
            lblDui.TabIndex = 2;
            lblDui.Text = "DUI";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(36, 187);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(53, 15);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "Telefono";
            // 
            // lblCorreoE
            // 
            lblCorreoE.AutoSize = true;
            lblCorreoE.Location = new Point(36, 228);
            lblCorreoE.Name = "lblCorreoE";
            lblCorreoE.Size = new Size(105, 15);
            lblCorreoE.TabIndex = 4;
            lblCorreoE.Text = "Correo electronico";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(36, 288);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 5;
            lblDireccion.Text = "Direccion";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(258, 98);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(247, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtDUI
            // 
            txtDUI.Location = new Point(258, 142);
            txtDUI.Name = "txtDUI";
            txtDUI.Size = new Size(247, 23);
            txtDUI.TabIndex = 7;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(258, 187);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(247, 23);
            txtTelefono.TabIndex = 8;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(258, 228);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(247, 23);
            txtCorreo.TabIndex = 9;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(258, 288);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(247, 23);
            txtDireccion.TabIndex = 10;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(211, 375);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(511, 375);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmNuevoCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FrmNuevoCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar Nuevo Cliente";
            Load += FrmNuevoCliente_Load;
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
    }
}