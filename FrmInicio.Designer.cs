namespace Taller_Automotriz
{
    partial class FrmInicio
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
            pictureBox1 = new PictureBox();
            btnAccesoNuevoRegistro = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.cab7fde32b9417310bd7e89b6ce5400c_removebg_preview;
            pictureBox1.Location = new Point(138, -110);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(842, 675);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btnAccesoNuevoRegistro
            // 
            btnAccesoNuevoRegistro.Anchor = AnchorStyles.None;
            btnAccesoNuevoRegistro.BackColor = Color.FromArgb(0, 122, 204);
            btnAccesoNuevoRegistro.Location = new Point(161, 415);
            btnAccesoNuevoRegistro.Margin = new Padding(4, 3, 4, 3);
            btnAccesoNuevoRegistro.Name = "btnAccesoNuevoRegistro";
            btnAccesoNuevoRegistro.Size = new Size(368, 41);
            btnAccesoNuevoRegistro.TabIndex = 1;
            btnAccesoNuevoRegistro.Text = "Nuevo Cliente";
            btnAccesoNuevoRegistro.UseVisualStyleBackColor = false;
            btnAccesoNuevoRegistro.Click += btnAccesoNuevoRegistro_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.FromArgb(45, 45, 48);
            button1.Location = new Point(161, 495);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(368, 42);
            button1.TabIndex = 2;
            button1.Text = "Crear Orden de Trabajo";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.FromArgb(45, 45, 48);
            button2.Location = new Point(593, 494);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(368, 43);
            button2.TabIndex = 3;
            button2.Text = "Generar Factura";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.BackColor = Color.FromArgb(0, 122, 204);
            button3.Location = new Point(593, 415);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(368, 41);
            button3.TabIndex = 4;
            button3.Text = "Nuevo Vehículo";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1125, 653);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnAccesoNuevoRegistro);
            Controls.Add(pictureBox1);
            Font = new Font("Segoe UI", 12F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmInicio";
            Text = "Inicio";
            Load += FrmInicio_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnAccesoNuevoRegistro;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}