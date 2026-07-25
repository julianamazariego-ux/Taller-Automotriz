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
            lblTitulo.Location = new Point(238, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(255, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTIÓN DE VEHÍCULOS";
            // 
            // lblBuscarV
            // 
            lblBuscarV.AutoSize = true;
            lblBuscarV.Location = new Point(30, 85);
            lblBuscarV.Name = "lblBuscarV";
            lblBuscarV.Size = new Size(93, 15);
            lblBuscarV.TabIndex = 1;
            lblBuscarV.Text = "Buscar vehículo:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(193, 77);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(331, 23);
            txtBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(592, 77);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, placa, marca, modelo, año, Color, Cliente });
            dataGridView1.Location = new Point(30, 142);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(725, 79);
            dataGridView1.TabIndex = 4;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.Name = "Id";
            // 
            // placa
            // 
            placa.HeaderText = "Placa";
            placa.Name = "placa";
            // 
            // marca
            // 
            marca.HeaderText = "Marca";
            marca.Name = "marca";
            // 
            // modelo
            // 
            modelo.HeaderText = "Modelo";
            modelo.Name = "modelo";
            // 
            // año
            // 
            año.HeaderText = "Año";
            año.Name = "año";
            // 
            // Color
            // 
            Color.HeaderText = "Color";
            Color.Name = "Color";
            // 
            // Cliente
            // 
            Cliente.HeaderText = "Cliente Propiedario";
            Cliente.Name = "Cliente";
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(30, 382);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(112, 23);
            btnNuevo.TabIndex = 5;
            btnNuevo.Text = "Nuevo Vehiculo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(636, 382);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(326, 382);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 7;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // FrmVehiculos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(btnNuevo);
            Controls.Add(dataGridView1);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscarV);
            Controls.Add(lblTitulo);
            Name = "FrmVehiculos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Vehículos";
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