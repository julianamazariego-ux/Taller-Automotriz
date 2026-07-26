namespace Taller_Automotriz
{
    partial class FrmVehiculos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            lblBuscarV = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
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
            lblBuscarV.Location = new Point(92, 162);
            lblBuscarV.Margin = new Padding(4, 0, 4, 0);
            lblBuscarV.Name = "lblBuscarV";
            lblBuscarV.Size = new Size(137, 25);
            lblBuscarV.TabIndex = 1;
            lblBuscarV.Text = "Buscar vehículo:";
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Location = new Point(237, 159);
            txtBuscar.Margin = new Padding(4, 5, 4, 5);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(678, 31);
            txtBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(925, 155);
            btnBuscar.Margin = new Padding(4, 5, 4, 5);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(107, 38);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dataGridView1.Location = new Point(94, 276);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1054, 185);
            dataGridView1.TabIndex = 4;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.MinimumWidth = 8;
            Id.Name = "Id";
            Id.Width = 150;
            // 
            // placa
            // 
            placa.HeaderText = "Placa";
            placa.MinimumWidth = 8;
            placa.Name = "placa";
            placa.Width = 150;
            // 
            // marca
            // 
            marca.HeaderText = "Marca";
            marca.MinimumWidth = 8;
            marca.Name = "marca";
            marca.Width = 150;
            // 
            // modelo
            // 
            modelo.HeaderText = "Modelo";
            modelo.MinimumWidth = 8;
            modelo.Name = "modelo";
            modelo.Width = 150;
            // 
            // año
            // 
            año.HeaderText = "Año";
            año.MinimumWidth = 8;
            año.Name = "año";
            año.Width = 150;
            // 
            // Color
            // 
            Color.HeaderText = "Color";
            Color.MinimumWidth = 8;
            Color.Name = "Color";
            Color.Width = 150;
            // 
            // Cliente
            // 
            Cliente.HeaderText = "Cliente Propiedario";
            Cliente.MinimumWidth = 8;
            Cliente.Name = "Cliente";
            Cliente.Width = 150;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Location = new Point(92, 531);
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
            btnEliminar.Anchor = AnchorStyles.Top;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Location = new Point(453, 531);
            btnEliminar.Margin = new Padding(4, 5, 4, 5);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(107, 38);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Location = new Point(299, 531);
            btnEditar.Margin = new Padding(4, 5, 4, 5);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(107, 38);
            btnEditar.TabIndex = 7;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // FrmVehiculos
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1237, 651);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(btnNuevo);
            Controls.Add(dataGridView1);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
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
        private TextBox txtBuscar;
        private Button btnBuscar;
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
    }
}