namespace Taller_Automotriz
{
    partial class FrmServicios
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
            txtTotalP = new TextBox();
            txtIVA = new TextBox();
            txtSubtotal = new TextBox();
            lblTotal = new Label();
            lblIVA = new Label();
            lblSubtotal = new Label();
            groupBox1 = new GroupBox();
            label1 = new Label();
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
            grpInformacion.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
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
            grpInformacion.Location = new Point(12, 12);
            grpInformacion.Name = "grpInformacion";
            grpInformacion.Size = new Size(247, 344);
            grpInformacion.TabIndex = 0;
            grpInformacion.TabStop = false;
            grpInformacion.Text = "Informacion del Cliente y Vehiculo";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(19, 235);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(118, 17);
            lblFecha.TabIndex = 7;
            lblFecha.Text = "Fecha de Entrada:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(15, 265);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(212, 25);
            dtpFecha.TabIndex = 6;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(15, 192);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(212, 25);
            txtModelo.TabIndex = 5;
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(15, 116);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(212, 25);
            txtPlaca.TabIndex = 4;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(15, 52);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(212, 25);
            txtCliente.TabIndex = 3;
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Location = new Point(15, 163);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(105, 17);
            lblModelo.TabIndex = 2;
            lblModelo.Text = "Modelo/Marca:";
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Location = new Point(15, 96);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(99, 17);
            lblPlaca.TabIndex = 1;
            lblPlaca.Text = "Placa/Patente:";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(15, 32);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(55, 17);
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
            groupBox2.Location = new Point(265, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(518, 193);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Servicios Solicitados";
            // 
            // chkEscaner
            // 
            chkEscaner.AutoSize = true;
            chkEscaner.Location = new Point(13, 163);
            chkEscaner.Name = "chkEscaner";
            chkEscaner.Size = new Size(270, 21);
            chkEscaner.TabIndex = 3;
            chkEscaner.Text = "Diagnóstico Escáner ($25.00)-Full Scan";
            chkEscaner.UseVisualStyleBackColor = true;
            // 
            // chkAlineacion
            // 
            chkAlineacion.AutoSize = true;
            chkAlineacion.Location = new Point(13, 120);
            chkAlineacion.Name = "chkAlineacion";
            chkAlineacion.Size = new Size(222, 21);
            chkAlineacion.TabIndex = 2;
            chkAlineacion.Text = "Alineación y Balanceo ($35.00)";
            chkAlineacion.UseVisualStyleBackColor = true;
            // 
            // chkFrenos
            // 
            chkFrenos.AutoSize = true;
            chkFrenos.Location = new Point(13, 74);
            chkFrenos.Name = "chkFrenos";
            chkFrenos.Size = new Size(388, 21);
            chkFrenos.TabIndex = 1;
            chkFrenos.Text = "Mantenimiento de Frenos ($80.00)-Delanteros y Traseros";
            chkFrenos.UseVisualStyleBackColor = true;
            // 
            // chkAceite
            // 
            chkAceite.AutoSize = true;
            chkAceite.Location = new Point(13, 32);
            chkAceite.Name = "chkAceite";
            chkAceite.Size = new Size(367, 21);
            chkAceite.TabIndex = 0;
            chkAceite.Text = "Cambio de Aceite y Filtro ($45.00)-Premium Synthetic";
            chkAceite.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtTotalP);
            groupBox3.Controls.Add(txtIVA);
            groupBox3.Controls.Add(txtSubtotal);
            groupBox3.Controls.Add(lblTotal);
            groupBox3.Controls.Add(lblIVA);
            groupBox3.Controls.Add(lblSubtotal);
            groupBox3.ForeColor = Color.Transparent;
            groupBox3.Location = new Point(568, 211);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(215, 145);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Enter += groupBox3_Enter;
            // 
            // txtTotalP
            // 
            txtTotalP.Location = new Point(118, 91);
            txtTotalP.Name = "txtTotalP";
            txtTotalP.Size = new Size(100, 25);
            txtTotalP.TabIndex = 5;
            // 
            // txtIVA
            // 
            txtIVA.Location = new Point(118, 55);
            txtIVA.Name = "txtIVA";
            txtIVA.Size = new Size(100, 25);
            txtIVA.TabIndex = 4;
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(118, 21);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.Size = new Size(100, 25);
            txtSubtotal.TabIndex = 3;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(8, 99);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(92, 17);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total a Pagar";
            lblTotal.Click += lblTotal_Click;
            // 
            // lblIVA
            // 
            lblIVA.AutoSize = true;
            lblIVA.Location = new Point(8, 66);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(62, 17);
            lblIVA.TabIndex = 1;
            lblIVA.Text = "IVA 13%";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtotal.Location = new Point(8, 23);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(75, 18);
            lblSubtotal.TabIndex = 0;
            lblSubtotal.Text = "Subtotal";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtHoras);
            groupBox1.Controls.Add(txtRepuestos);
            groupBox1.Controls.Add(lblManoD);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblRepuestos);
            groupBox1.Controls.Add(lblMano);
            groupBox1.Controls.Add(txtManoObra);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(265, 211);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(297, 145);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Costos Adicionales";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(151, 21);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 11;
            label1.Text = "$0.00";
            // 
            // txtHoras
            // 
            txtHoras.Location = new Point(201, 16);
            txtHoras.Name = "txtHoras";
            txtHoras.Size = new Size(82, 25);
            txtHoras.TabIndex = 10;
            // 
            // txtRepuestos
            // 
            txtRepuestos.Location = new Point(183, 58);
            txtRepuestos.Name = "txtRepuestos";
            txtRepuestos.Size = new Size(100, 25);
            txtRepuestos.TabIndex = 9;
            // 
            // lblManoD
            // 
            lblManoD.AutoSize = true;
            lblManoD.Location = new Point(7, 105);
            lblManoD.Name = "lblManoD";
            lblManoD.Size = new Size(165, 17);
            lblManoD.TabIndex = 8;
            lblManoD.Text = "Mano de Obra Adicional:";
            lblManoD.Click += lblManoD_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 80);
            label2.Name = "label2";
            label2.Size = new Size(0, 17);
            label2.TabIndex = 7;
            // 
            // lblRepuestos
            // 
            lblRepuestos.AutoSize = true;
            lblRepuestos.Location = new Point(6, 63);
            lblRepuestos.Name = "lblRepuestos";
            lblRepuestos.Size = new Size(80, 17);
            lblRepuestos.TabIndex = 6;
            lblRepuestos.Text = "Repuestos: ";
            // 
            // lblMano
            // 
            lblMano.AutoSize = true;
            lblMano.Location = new Point(6, 21);
            lblMano.Name = "lblMano";
            lblMano.Size = new Size(139, 17);
            lblMano.TabIndex = 4;
            lblMano.Text = "Mano de Obra Horas";
            lblMano.Click += lblMano_Click;
            // 
            // txtManoObra
            // 
            txtManoObra.Location = new Point(183, 99);
            txtManoObra.Name = "txtManoObra";
            txtManoObra.Size = new Size(100, 25);
            txtManoObra.TabIndex = 5;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(618, 393);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar ";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(425, 393);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(75, 23);
            btnImprimir.TabIndex = 4;
            btnImprimir.Text = "Imprimir ";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(230, 393);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(75, 23);
            btnGenerar.TabIndex = 5;
            btnGenerar.Text = "Generar orden ";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(74, 393);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(75, 23);
            btnCalcular.TabIndex = 6;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // FrmServicios
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 3, 10);
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(795, 455);
            Controls.Add(btnLimpiar);
            Controls.Add(btnImprimir);
            Controls.Add(btnGenerar);
            Controls.Add(btnCalcular);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(grpInformacion);
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
        private TextBox txtTotalP;
        private TextBox txtIVA;
        private TextBox txtSubtotal;
        private Button btnLimpiar;
        private Button btnImprimir;
        private Button btnGenerar;
        private Button btnCalcular;
        private Label label1;
    }
}