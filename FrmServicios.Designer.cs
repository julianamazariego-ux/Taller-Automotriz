namespace Taller_Automotriz
{
    partial class FrmServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServicios));
            grpInformacion = new GroupBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            txtModelo = new TextBox();
            txtPlaca = new TextBox();
            txtCliente = new TextBox();
            lblModelo = new Label();
            lblPlaca = new Label();
            lblCliente = new Label();
            groupBox2 = new GroupBox();
            chkEscaner = new CheckBox();
            chkAlineacion = new CheckBox();
            chkFrenos = new CheckBox();
            chkAceite = new CheckBox();
            groupBox3 = new GroupBox();
            lblTotal = new Label();
            lblIVA = new Label();
            lblSubtotal = new Label();
            groupBox1 = new GroupBox();
            txtHoras = new TextBox();
            txtRepuestos = new TextBox();
            lblManoD = new Label();
            label2 = new Label();
            lblRepuestos = new Label();
            lblMano = new Label();
            txtManoObra = new TextBox();
            btnLimpiar = new Button();
            btnImprimir = new Button();
            btnGenerar = new Button();
            btnCalcular = new Button();
            pictureBox1 = new PictureBox();
            lblTitulo = new Label();
            panel1 = new Panel();
            errorProvider1 = new ErrorProvider(components);
            grpInformacion.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // grpInformacion
            // 
            grpInformacion.BackColor = Color.Transparent;
            grpInformacion.Controls.Add(lblFecha);
            grpInformacion.Controls.Add(dtpFecha);
            grpInformacion.Controls.Add(txtModelo);
            grpInformacion.Controls.Add(txtPlaca);
            grpInformacion.Controls.Add(txtCliente);
            grpInformacion.Controls.Add(lblModelo);
            grpInformacion.Controls.Add(lblPlaca);
            grpInformacion.Controls.Add(lblCliente);
            grpInformacion.ForeColor = Color.White;
            grpInformacion.Location = new Point(52, 159);
            grpInformacion.Name = "grpInformacion";
            grpInformacion.Size = new Size(376, 395);
            grpInformacion.TabIndex = 0;
            grpInformacion.TabStop = false;
            grpInformacion.Text = "Informacion del Cliente y Vehiculo";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(50, 312);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(185, 28);
            lblFecha.TabIndex = 7;
            lblFecha.Text = "Fecha de Entrada:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(50, 343);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(304, 33);
            dtpFecha.TabIndex = 6;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(50, 232);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(212, 33);
            txtModelo.TabIndex = 5;
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(50, 159);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(212, 33);
            txtPlaca.TabIndex = 4;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(50, 92);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(212, 33);
            txtCliente.TabIndex = 3;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(50, 201);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(165, 28);
            lblModelo.TabIndex = 2;
            lblModelo.Text = "Modelo/Marca:";
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Location = new Point(50, 128);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(154, 28);
            lblPlaca.TabIndex = 1;
            lblPlaca.Text = "Placa/Patente:";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(50, 61);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(86, 28);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(chkEscaner);
            groupBox2.Controls.Add(chkAlineacion);
            groupBox2.Controls.Add(chkFrenos);
            groupBox2.Controls.Add(chkAceite);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(428, 159);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(732, 201);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Servicios Solicitados";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // chkEscaner
            // 
            chkEscaner.AutoSize = true;
            chkEscaner.Location = new Point(13, 163);
            chkEscaner.Name = "chkEscaner";
            chkEscaner.Size = new Size(420, 32);
            chkEscaner.TabIndex = 3;
            chkEscaner.Text = "Diagnóstico Escáner ($25.00)-Full Scan";
            chkEscaner.UseVisualStyleBackColor = true;
            // 
            // chkAlineacion
            // 
            chkAlineacion.AutoSize = true;
            chkAlineacion.Location = new Point(13, 120);
            chkAlineacion.Name = "chkAlineacion";
            chkAlineacion.Size = new Size(342, 32);
            chkAlineacion.TabIndex = 2;
            chkAlineacion.Text = "Alineación y Balanceo ($35.00)";
            chkAlineacion.UseVisualStyleBackColor = true;
            // 
            // chkFrenos
            // 
            chkFrenos.AutoSize = true;
            chkFrenos.Location = new Point(13, 74);
            chkFrenos.Name = "chkFrenos";
            chkFrenos.Size = new Size(605, 32);
            chkFrenos.TabIndex = 1;
            chkFrenos.Text = "Mantenimiento de Frenos ($80.00)-Delanteros y Traseros";
            chkFrenos.UseVisualStyleBackColor = true;
            // 
            // chkAceite
            // 
            chkAceite.AutoSize = true;
            chkAceite.Location = new Point(13, 32);
            chkAceite.Name = "chkAceite";
            chkAceite.Size = new Size(568, 32);
            chkAceite.TabIndex = 0;
            chkAceite.Text = "Cambio de Aceite y Filtro ($45.00)-Premium Synthetic";
            chkAceite.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblTotal);
            groupBox3.Controls.Add(lblIVA);
            groupBox3.Controls.Add(lblSubtotal);
            groupBox3.ForeColor = Color.Transparent;
            groupBox3.Location = new Point(870, 368);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(290, 186);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Enter += groupBox3_Enter;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(6, 129);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(143, 28);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total a Pagar";
            lblTotal.Click += lblTotal_Click;
            // 
            // lblIVA
            // 
            lblIVA.AutoSize = true;
            lblIVA.Location = new Point(8, 76);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(94, 28);
            lblIVA.TabIndex = 1;
            lblIVA.Text = "IVA 13%";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtotal.Location = new Point(6, 29);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(108, 28);
            lblSubtotal.TabIndex = 0;
            lblSubtotal.Text = "Subtotal";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(txtHoras);
            groupBox1.Controls.Add(txtRepuestos);
            groupBox1.Controls.Add(lblManoD);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblRepuestos);
            groupBox1.Controls.Add(lblMano);
            groupBox1.Controls.Add(txtManoObra);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(434, 368);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(429, 186);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Costos Adicionales";
            // 
            // txtHoras
            // 
            txtHoras.Location = new Point(316, 27);
            txtHoras.Name = "txtHoras";
            txtHoras.Size = new Size(100, 33);
            txtHoras.TabIndex = 10;
            // 
            // txtRepuestos
            // 
            txtRepuestos.Location = new Point(316, 74);
            txtRepuestos.Name = "txtRepuestos";
            txtRepuestos.Size = new Size(100, 33);
            txtRepuestos.TabIndex = 9;
            // 
            // lblManoD
            // 
            lblManoD.AutoSize = true;
            lblManoD.Location = new Point(13, 135);
            lblManoD.Name = "lblManoD";
            lblManoD.Size = new Size(258, 28);
            lblManoD.TabIndex = 8;
            lblManoD.Text = "Mano de Obra Adicional:";
            lblManoD.Click += lblManoD_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 80);
            label2.Name = "label2";
            label2.Size = new Size(0, 28);
            label2.TabIndex = 7;
            // 
            // lblRepuestos
            // 
            lblRepuestos.AutoSize = true;
            lblRepuestos.Location = new Point(13, 80);
            lblRepuestos.Name = "lblRepuestos";
            lblRepuestos.Size = new Size(127, 28);
            lblRepuestos.TabIndex = 6;
            lblRepuestos.Text = "Repuestos: ";
            // 
            // lblMano
            // 
            lblMano.AutoSize = true;
            lblMano.Location = new Point(6, 32);
            lblMano.Name = "lblMano";
            lblMano.Size = new Size(218, 28);
            lblMano.TabIndex = 4;
            lblMano.Text = "Mano de Obra Horas";
            lblMano.Click += lblMano_Click;
            // 
            // txtManoObra
            // 
            txtManoObra.Location = new Point(316, 127);
            txtManoObra.Name = "txtManoObra";
            txtManoObra.Size = new Size(100, 33);
            txtManoObra.TabIndex = 5;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Bottom;
            btnLimpiar.Location = new Point(683, 577);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(103, 37);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar ";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Bottom;
            btnImprimir.Location = new Point(831, 577);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(114, 37);
            btnImprimir.TabIndex = 4;
            btnImprimir.Text = "Imprimir ";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click_1;
            // 
            // btnGenerar
            // 
            btnGenerar.Anchor = AnchorStyles.Bottom;
            btnGenerar.Location = new Point(469, 577);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(114, 38);
            btnGenerar.TabIndex = 5;
            btnGenerar.Text = "Generar orden ";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.Anchor = AnchorStyles.Bottom;
            btnCalcular.Location = new Point(321, 577);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(107, 38);
            btnCalcular.TabIndex = 6;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(407, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(73, 74);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.FromArgb(45, 45, 48);
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ButtonHighlight;
            lblTitulo.Location = new Point(511, 44);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(331, 45);
            lblTitulo.TabIndex = 10;
            lblTitulo.Text = "ORDEN DE SERVICIO";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(lblTitulo);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(grpInformacion);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnLimpiar);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(btnImprimir);
            panel1.Controls.Add(btnCalcular);
            panel1.Controls.Add(btnGenerar);
            panel1.Location = new Point(0, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1226, 649);
            panel1.TabIndex = 11;
            panel1.Paint += panel1_Paint;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmServicios
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1227, 685);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmServicios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Servicios ";
            WindowState = FormWindowState.Maximized;
            Load += FrmServicios_Load;
            grpInformacion.ResumeLayout(false);
            grpInformacion.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInformacion;
        private TextBox txtModelo;
        private TextBox txtPlaca;
        private TextBox txtCliente;
        private Label lblModelo;
        private Label lblPlaca;
        private Label lblCliente;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private GroupBox groupBox2;
        private CheckBox chkEscaner;
        private CheckBox chkAlineacion;
        private CheckBox chkFrenos;
        private CheckBox chkAceite;
        private TextBox txtManoObra;
        private Label lblMano;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Label lblIVA;
        private Label lblSubtotal;
        private Label label2;
        private Label lblRepuestos;
        private Label lblTotal;
        private Label lblManoD;
        private TextBox txtHoras;
        private TextBox txtRepuestos;
        private Button btnLimpiar;
        private Button btnImprimir;
        private Button btnGenerar;
        private Button btnCalcular;
        private PictureBox pictureBox1;
        private Label lblTitulo;
        private Panel panel1;
        private ErrorProvider errorProvider1;
    }
}