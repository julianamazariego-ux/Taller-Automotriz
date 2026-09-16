namespace Taller_Automotriz
{
    partial class FrmNuevoMecanico
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNombre = new TextBox();
            cmbEspecialidad = new ComboBox();
            mtxTelefono = new MaskedTextBox();
            cmbEstado = new ComboBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.cab7fde32b9417310bd7e89b6ce5400c_removebg_preview;
            pictureBox1.Location = new Point(96, -23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(793, 700);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.System;
            label1.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(298, 46);
            label1.Name = "label1";
            label1.Size = new Size(384, 45);
            label1.TabIndex = 15;
            label1.Text = "REGISTRAR MECANICO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 185);
            label2.Name = "label2";
            label2.Size = new Size(162, 25);
            label2.TabIndex = 16;
            label2.Text = "Nombre Completo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 271);
            label3.Name = "label3";
            label3.Size = new Size(109, 25);
            label3.TabIndex = 17;
            label3.Text = "Especialidad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(96, 359);
            label4.Name = "label4";
            label4.Size = new Size(79, 25);
            label4.TabIndex = 18;
            label4.Text = "Telefono";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(96, 440);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 19;
            label5.Text = "Estado";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(298, 179);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(520, 31);
            txtNombre.TabIndex = 0;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // cmbEspecialidad
            // 
            cmbEspecialidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEspecialidad.FormattingEnabled = true;
            cmbEspecialidad.Location = new Point(298, 263);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(394, 33);
            cmbEspecialidad.TabIndex = 2;
            cmbEspecialidad.SelectedIndexChanged += cmbEspecialidad_SelectedIndexChanged;
            // 
            // mtxTelefono
            // 
            mtxTelefono.Location = new Point(298, 353);
            mtxTelefono.Mask = "0000-0000";
            mtxTelefono.Name = "mtxTelefono";
            mtxTelefono.Size = new Size(266, 31);
            mtxTelefono.TabIndex = 3;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmbEstado.Location = new Point(298, 432);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(182, 33);
            cmbEstado.TabIndex = 4;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(192, 57, 43);
            btnCancelar.Location = new Point(272, 567);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 34);
            btnCancelar.TabIndex = 24;
            btnCancelar.TabStop = false;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Highlight;
            btnGuardar.Location = new Point(96, 567);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 34);
            btnGuardar.TabIndex = 25;
            btnGuardar.TabStop = false;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmNuevoMecanico
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(926, 670);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(cmbEstado);
            Controls.Add(mtxTelefono);
            Controls.Add(cmbEspecialidad);
            Controls.Add(txtNombre);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            ForeColor = Color.White;
            KeyPreview = true;
            Name = "FrmNuevoMecanico";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmNuevoMecanico";
            Load += FrmNuevoMecanico_Load;
            KeyPress += FrmNuevoMecanico_KeyPress;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNombre;
        private ComboBox cmbEspecialidad;
        private MaskedTextBox mtxTelefono;
        private ComboBox cmbEstado;
        private Button btnCancelar;
        private Button btnGuardar;
        private ErrorProvider errorProvider1;
    }
}