namespace Taller_Automotriz
{
    partial class frmNuevaOrden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaOrden));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            fileSystemWatcher1 = new FileSystemWatcher();
            lblTitulo = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            mtxDUI = new MaskedTextBox();
            errorProvider1 = new ErrorProvider(components);
            label5 = new Label();
            txtPlaca = new TextBox();
            cmbTipoServicio = new ComboBox();
            txtDescripcion = new TextBox();
            txtCostoEstimado = new TextBox();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(63, 166);
            label1.Name = "label1";
            label1.Size = new Size(43, 23);
            label1.TabIndex = 5;
            label1.Text = "DUI:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(303, 166);
            label2.Name = "label2";
            label2.Size = new Size(54, 23);
            label2.TabIndex = 6;
            label2.Text = "Placa:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(63, 214);
            label3.Name = "label3";
            label3.Size = new Size(134, 23);
            label3.TabIndex = 7;
            label3.Text = "Tipo de Servicio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(63, 256);
            label4.Name = "label4";
            label4.Size = new Size(208, 23);
            label4.TabIndex = 8;
            label4.Text = "Descripcion del Problema:";
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.FromArgb(45, 45, 48);
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = SystemColors.ButtonHighlight;
            lblTitulo.Location = new Point(229, 65);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(380, 41);
            lblTitulo.TabIndex = 9;
            lblTitulo.Text = "AGREGAR NUEVA ORDEN";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(0, 124, 204);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(196, 514);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(126, 30);
            btnGuardar.TabIndex = 14;
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
            btnCancelar.Location = new Point(372, 514);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(125, 30);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = Properties.Resources.cab7fde32b9417310bd7e89b6ce5400c_removebg_preview;
            pictureBox1.Location = new Point(49, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(624, 562);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(127, 46);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(78, 69);
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // mtxDUI
            // 
            mtxDUI.Location = new Point(112, 162);
            mtxDUI.Mask = "00000000-0";
            mtxDUI.Name = "mtxDUI";
            mtxDUI.Size = new Size(141, 27);
            mtxDUI.TabIndex = 19;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(399, 214);
            label5.Name = "label5";
            label5.Size = new Size(133, 23);
            label5.TabIndex = 20;
            label5.Text = "Costo Estimado:";
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(385, 162);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(125, 27);
            txtPlaca.TabIndex = 21;
            // 
            // cmbTipoServicio
            // 
            cmbTipoServicio.FormattingEnabled = true;
            cmbTipoServicio.Location = new Point(206, 209);
            cmbTipoServicio.Name = "cmbTipoServicio";
            cmbTipoServicio.Size = new Size(151, 28);
            cmbTipoServicio.TabIndex = 22;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(72, 295);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(507, 165);
            txtDescripcion.TabIndex = 23;
            // 
            // txtCostoEstimado
            // 
            txtCostoEstimado.Location = new Point(538, 213);
            txtCostoEstimado.Name = "txtCostoEstimado";
            txtCostoEstimado.Size = new Size(125, 27);
            txtCostoEstimado.TabIndex = 24;
            // 
            // frmNuevaOrden
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(722, 578);
            Controls.Add(txtCostoEstimado);
            Controls.Add(txtDescripcion);
            Controls.Add(cmbTipoServicio);
            Controls.Add(txtPlaca);
            Controls.Add(label5);
            Controls.Add(mtxDUI);
            Controls.Add(pictureBox2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblTitulo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            MaximizeBox = false;
            Name = "frmNuevaOrden";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nueva Orden";
            Load += frmNuevaOrden_Load;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private FileSystemWatcher fileSystemWatcher1;
        private Label lblTitulo;
        private Button btnGuardar;
        private Button btnCancelar;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private MaskedTextBox mtxDUI;
        private ErrorProvider errorProvider1;
        private Label label5;
        private TextBox txtCostoEstimado;
        private TextBox txtDescripcion;
        private ComboBox cmbTipoServicio;
        private TextBox txtPlaca;
    }
}