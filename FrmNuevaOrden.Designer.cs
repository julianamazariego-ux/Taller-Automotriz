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
            txtNombre = new TextBox();
            txtCorreo = new TextBox();
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
            mtxTelefono = new MaskedTextBox();
            mtxDUI = new MaskedTextBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(291, 164);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(302, 27);
            txtNombre.TabIndex = 0;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(291, 314);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(302, 27);
            txtCorreo.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(63, 166);
            label1.Name = "label1";
            label1.Size = new Size(154, 23);
            label1.TabIndex = 5;
            label1.Text = "Nombre completo:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(63, 242);
            label2.Name = "label2";
            label2.Size = new Size(167, 23);
            label2.TabIndex = 6;
            label2.Text = "Telefono(WhatsApp):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(63, 317);
            label3.Name = "label3";
            label3.Size = new Size(155, 23);
            label3.TabIndex = 7;
            label3.Text = "Correo electrónico:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(63, 402);
            label4.Name = "label4";
            label4.Size = new Size(206, 23);
            label4.TabIndex = 8;
            label4.Text = "Documento de Identidad:";
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
            btnGuardar.Location = new Point(197, 491);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(126, 30);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Continuar";
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
            btnCancelar.Location = new Point(375, 491);
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
            pictureBox2.Margin = new Padding(2, 2, 2, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(78, 69);
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // mtxTelefono
            // 
            mtxTelefono.Location = new Point(291, 238);
            mtxTelefono.Mask = "0000-0000";
            mtxTelefono.Name = "mtxTelefono";
            mtxTelefono.Size = new Size(141, 27);
            mtxTelefono.TabIndex = 18;
            // 
            // mtxDUI
            // 
            mtxDUI.Location = new Point(291, 402);
            mtxDUI.Mask = "00000000-0";
            mtxDUI.Name = "mtxDUI";
            mtxDUI.Size = new Size(141, 27);
            mtxDUI.TabIndex = 19;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmNuevaOrden
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(722, 578);
            Controls.Add(mtxDUI);
            Controls.Add(mtxTelefono);
            Controls.Add(pictureBox2);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblTitulo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCorreo);
            Controls.Add(txtNombre);
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

        private TextBox txtNombre;
        private TextBox txtCorreo;
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
        private MaskedTextBox mtxTelefono;
        private ErrorProvider errorProvider1;
    }
}