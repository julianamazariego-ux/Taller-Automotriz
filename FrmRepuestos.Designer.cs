namespace Taller_Automotriz
{
    partial class FrmRepuestos
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
            labelBuscar = new Label();
            txtBuscar = new TextBox();
            dgvRepuestos = new DataGridView();
            colSeleccion = new DataGridViewTextBoxColumn();
            colArticulo = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            pictureBox1 = new PictureBox();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelBuscar
            // 
            labelBuscar.AutoSize = true;
            labelBuscar.Font = new Font("Segoe UI", 11F);
            labelBuscar.ForeColor = SystemColors.ButtonHighlight;
            labelBuscar.Location = new Point(95, 194);
            labelBuscar.Name = "labelBuscar";
            labelBuscar.Size = new Size(151, 25);
            labelBuscar.TabIndex = 0;
            labelBuscar.Text = "Buscar repuesto:";
            labelBuscar.Click += label1_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(267, 195);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(549, 27);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // dgvRepuestos
            // 
            dgvRepuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRepuestos.Columns.AddRange(new DataGridViewColumn[] { colSeleccion, colArticulo, colCategoria, colPrecio });
            dgvRepuestos.Location = new Point(95, 296);
            dgvRepuestos.Name = "dgvRepuestos";
            dgvRepuestos.RowHeadersWidth = 51;
            dgvRepuestos.Size = new Size(736, 188);
            dgvRepuestos.TabIndex = 2;
            dgvRepuestos.CellContentClick += dataGridView1_CellContentClick;
            // 
            // colSeleccion
            // 
            colSeleccion.HeaderText = "Seleccionar";
            colSeleccion.MinimumWidth = 6;
            colSeleccion.Name = "colSeleccion";
            colSeleccion.Width = 125;
            // 
            // colArticulo
            // 
            colArticulo.HeaderText = "Artículo";
            colArticulo.MinimumWidth = 6;
            colArticulo.Name = "colArticulo";
            colArticulo.Width = 125;
            // 
            // colCategoria
            // 
            colCategoria.HeaderText = "Categoria";
            colCategoria.MinimumWidth = 6;
            colCategoria.Name = "colCategoria";
            colCategoria.Width = 125;
            // 
            // colPrecio
            // 
            colPrecio.HeaderText = "Precio";
            colPrecio.MinimumWidth = 6;
            colPrecio.Name = "colPrecio";
            colPrecio.Width = 125;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = Properties.Resources.cab7fde32b9417310bd7e89b6ce5400c_removebg_preview;
            pictureBox1.Location = new Point(159, -12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(624, 562);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.FromArgb(45, 45, 48);
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ButtonHighlight;
            lblTitulo.Location = new Point(378, 96);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(172, 37);
            lblTitulo.TabIndex = 18;
            lblTitulo.Text = "REPUESTOS:";
            // 
            // FrmRepuestos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(914, 600);
            Controls.Add(lblTitulo);
            Controls.Add(dgvRepuestos);
            Controls.Add(txtBuscar);
            Controls.Add(labelBuscar);
            Controls.Add(pictureBox1);
            Margin = new Padding(2);
            Name = "FrmRepuestos";
            Text = "FrmRepuestos";
            Load += FrmRepuestos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvRepuestos;
        private DataGridViewTextBoxColumn colSeleccion;
        private DataGridViewTextBoxColumn colArticulo;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colPrecio;
        private PictureBox pictureBox1;
        private Label lblTitulo;
    }
}