namespace Taller_Automotriz
{
    partial class FrmNuevaOrden2
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtAño = new TextBox();
            txtMarca = new TextBox();
            label5 = new Label();
            txtModelo = new TextBox();
            label6 = new Label();
            txtKilometraje = new TextBox();
            lblTitulo = new Label();
            pictureBox1 = new PictureBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            cmbEstado = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(65, 289);
            label3.Name = "label3";
            label3.Size = new Size(163, 23);
            label3.TabIndex = 15;
            label3.Text = "Estado del Vehiculo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(406, 148);
            label2.Name = "label2";
            label2.Size = new Size(45, 23);
            label2.TabIndex = 14;
            label2.Text = "Año:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(65, 148);
            label1.Name = "label1";
            label1.Size = new Size(61, 23);
            label1.TabIndex = 13;
            label1.Text = "Marca:";
            label1.Click += label1_Click;
            // 
            // txtAño
            // 
            txtAño.Location = new Point(519, 146);
            txtAño.Name = "txtAño";
            txtAño.Size = new Size(136, 27);
            txtAño.TabIndex = 10;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(143, 146);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(206, 27);
            txtMarca.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(65, 204);
            label5.Name = "label5";
            label5.Size = new Size(72, 23);
            label5.TabIndex = 17;
            label5.Text = "Modelo:";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(143, 202);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(206, 27);
            txtModelo.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(406, 204);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 19;
            label6.Text = "Kilometraje:";
            // 
            // txtKilometraje
            // 
            txtKilometraje.Location = new Point(519, 202);
            txtKilometraje.Name = "txtKilometraje";
            txtKilometraje.Size = new Size(136, 27);
            txtKilometraje.TabIndex = 20;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.FromArgb(45, 45, 48);
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = SystemColors.ButtonHighlight;
            lblTitulo.Location = new Point(214, 46);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(332, 41);
            lblTitulo.TabIndex = 21;
            lblTitulo.Text = "DATOS DEL VEHÍCULO";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = Properties.Resources.cab7fde32b9417310bd7e89b6ce5400c_removebg_preview;
            pictureBox1.Location = new Point(139, 46);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(458, 430);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(0, 124, 204);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(214, 414);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(126, 30);
            btnGuardar.TabIndex = 23;
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
            btnCancelar.Location = new Point(394, 414);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(145, 30);
            btnCancelar.TabIndex = 24;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(261, 289);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(151, 28);
            cmbEstado.TabIndex = 25;
            // 
            // FrmNuevaOrden2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(732, 502);
            Controls.Add(cmbEstado);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblTitulo);
            Controls.Add(txtKilometraje);
            Controls.Add(label6);
            Controls.Add(txtModelo);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAño);
            Controls.Add(txtMarca);
            Controls.Add(pictureBox1);
            Name = "FrmNuevaOrden2";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nueva Orden";
            Load += FrmNuevaOrden2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtAño;
        private TextBox txtMarca;
        private Label label5;
        private TextBox txtModelo;
        private Label label6;
        private TextBox txtKilometraje;
        private Label lblTitulo;
        private PictureBox pictureBox1;
        private Button btnGuardar;
        private Button btnCancelar;
        private ComboBox cmbEstado;
    }
}