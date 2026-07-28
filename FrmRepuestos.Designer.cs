namespace Taller_Automotriz
{
    partial class FrmRepuestos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewRepuestos;
        private System.Windows.Forms.ColumnHeader columnHeaderNombre;
        private System.Windows.Forms.ColumnHeader columnHeaderPrecio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label labelTitle;

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
            this.listViewRepuestos = new System.Windows.Forms.ListView();
            this.columnHeaderNombre = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderPrecio = new System.Windows.Forms.ColumnHeader();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // listViewRepuestos
            // 
            this.listViewRepuestos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewRepuestos.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.listViewRepuestos.ForeColor = System.Drawing.Color.White;
            this.listViewRepuestos.FullRowSelect = true;
            this.listViewRepuestos.GridLines = false;
            this.listViewRepuestos.HideSelection = false;
            this.listViewRepuestos.Location = new System.Drawing.Point(20, 60);
            this.listViewRepuestos.Name = "listViewRepuestos";
            this.listViewRepuestos.Size = new System.Drawing.Size(760, 320);
            this.listViewRepuestos.TabIndex = 0;
            this.listViewRepuestos.UseCompatibleStateImageBehavior = false;
            this.listViewRepuestos.View = System.Windows.Forms.View.Details;
            this.listViewRepuestos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNombre,
            this.columnHeaderPrecio});
            // 
            // columnHeaderNombre
            // 
            this.columnHeaderNombre.Text = "Nombre";
            this.columnHeaderNombre.Width = 520;
            // 
            // columnHeaderPrecio
            // 
            this.columnHeaderPrecio.Text = "Precio";
            this.columnHeaderPrecio.Width = 200;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(120, 390);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(150, 35);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "+ Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Location = new System.Drawing.Point(325, 390);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(150, 35);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(530, 390);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 35);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(20, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(140, 25);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Lista de repuestos";
            // 
            // FrmRepuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.listViewRepuestos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRepuestos";
            this.Text = "Repuestos";
            this.Load += new System.EventHandler(this.FrmRepuestos_Load);
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