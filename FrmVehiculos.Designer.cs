namespace Taller_Automotriz
{
    partial class FrmVehiculos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            lblBuscarV = new Label();
            txtBuscarPlaca = new TextBox();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            placa = new DataGridViewTextBoxColumn();
            marca = new DataGridViewTextBoxColumn();
            modelo = new DataGridViewTextBoxColumn();
            año = new DataGridViewTextBoxColumn();
            Color = new DataGridViewTextBoxColumn();
            Cliente = new DataGridViewTextBoxColumn();
            btnNuevo = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            label1 = new Label();
            cmbFiltroMarca = new ComboBox();
            label2 = new Label();
            txtFiltroAnio = new TextBox();
            btnLimpiarFiltros = new Button();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(437, 32);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(388, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTIÓN DE VEHÍCULOS";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // lblBuscarV
            // 
            lblBuscarV.AutoSize = true;
            lblBuscarV.Location = new Point(92, 130);
            lblBuscarV.Margin = new Padding(4, 0, 4, 0);
            lblBuscarV.Name = "lblBuscarV";
            lblBuscarV.Size = new Size(141, 25);
            lblBuscarV.TabIndex = 1;
            lblBuscarV.Text = "Buscar por Placa";
            // 
            // txtBuscarPlaca
            // 
            txtBuscarPlaca.BorderStyle = BorderStyle.FixedSingle;
            txtBuscarPlaca.Location = new Point(263, 128);
            txtBuscarPlaca.Margin = new Padding(4, 5, 4, 5);
            txtBuscarPlaca.Name = "txtBuscarPlaca";
            txtBuscarPlaca.Size = new Size(184, 31);
            txtBuscarPlaca.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, placa, marca, modelo, año, Color, Cliente });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(91, 290);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1044, 185);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.MinimumWidth = 8;
            Id.Name = "Id";
            // 
            // placa
            // 
            placa.HeaderText = "Placa";
            placa.MinimumWidth = 8;
            placa.Name = "placa";
            // 
            // marca
            // 
            marca.HeaderText = "Marca";
            marca.MinimumWidth = 8;
            marca.Name = "marca";
            // 
            // modelo
            // 
            modelo.HeaderText = "Modelo";
            modelo.MinimumWidth = 8;
            modelo.Name = "modelo";
            // 
            // año
            // 
            año.HeaderText = "Año";
            año.MinimumWidth = 8;
            año.Name = "año";
            // 
            // Color
            // 
            Color.HeaderText = "Color";
            Color.MinimumWidth = 8;
            Color.Name = "Color";
            // 
            // Cliente
            // 
            Cliente.HeaderText = "Cliente Propiedario";
            Cliente.MinimumWidth = 8;
            Cliente.Name = "Cliente";
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Bottom;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Location = new Point(92, 549);
            btnNuevo.Margin = new Padding(4, 5, 4, 5);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(160, 38);
            btnNuevo.TabIndex = 5;
            btnNuevo.Text = "Nuevo Vehiculo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Location = new Point(453, 549);
            btnEliminar.Margin = new Padding(4, 5, 4, 5);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(107, 38);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Location = new Point(299, 549);
            btnEditar.Margin = new Padding(4, 5, 4, 5);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(107, 38);
            btnEditar.TabIndex = 7;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(501, 129);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 8;
            label1.Text = "Filtrar por marcas";
            // 
            // cmbFiltroMarca
            // 
            cmbFiltroMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroMarca.FormattingEnabled = true;
            cmbFiltroMarca.Location = new Point(657, 127);
            cmbFiltroMarca.Name = "cmbFiltroMarca";
            cmbFiltroMarca.Size = new Size(244, 33);
            cmbFiltroMarca.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 190);
            label2.Name = "label2";
            label2.Size = new Size(127, 25);
            label2.TabIndex = 10;
            label2.Text = "Filtrar por Año";
            // 
            // txtFiltroAnio
            // 
            txtFiltroAnio.Location = new Point(263, 187);
            txtFiltroAnio.Name = "txtFiltroAnio";
            txtFiltroAnio.Size = new Size(184, 31);
            txtFiltroAnio.TabIndex = 11;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(501, 190);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(112, 34);
            btnLimpiarFiltros.TabIndex = 12;
            btnLimpiarFiltros.Text = "Limpiar";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(639, 190);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(112, 34);
            btnBuscar.TabIndex = 13;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // FrmVehiculos
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1227, 651);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(txtFiltroAnio);
            Controls.Add(label2);
            Controls.Add(cmbFiltroMarca);
            Controls.Add(label1);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(btnNuevo);
            Controls.Add(dataGridView1);
            Controls.Add(txtBuscarPlaca);
            Controls.Add(lblBuscarV);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmVehiculos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Vehículos";
            Load += FrmVehiculos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblBuscarV;
        private TextBox txtBuscarPlaca;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn placa;
        private DataGridViewTextBoxColumn marca;
        private DataGridViewTextBoxColumn modelo;
        private DataGridViewTextBoxColumn año;
        private DataGridViewTextBoxColumn Color;
        private DataGridViewTextBoxColumn Cliente;
        private Button btnNuevo;
        private Button btnEliminar;
        private Button btnEditar;
        private Label label1;
        private ComboBox cmbFiltroMarca;
        private Label label2;
        private TextBox txtFiltroAnio;
        private Button btnLimpiarFiltros;
        private Button btnBuscar;
    }
}