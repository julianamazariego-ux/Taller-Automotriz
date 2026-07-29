namespace Taller_Automotriz
{
    partial class FrmRepuestos
    {
       
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewRepuestos;
        private System.Windows.Forms.ColumnHeader columnHeaderNombre;
        private System.Windows.Forms.ColumnHeader columnHeaderPrecio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label labelTitle;

        
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
            listViewRepuestos = new ListView();
            columnHeaderNombre = new ColumnHeader();
            columnHeaderPrecio = new ColumnHeader();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            labelTitle = new Label();
            SuspendLayout();
            // 
            // listViewRepuestos
            // 
            listViewRepuestos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewRepuestos.BackColor = Color.FromArgb(30, 30, 30);
            listViewRepuestos.Columns.AddRange(new ColumnHeader[] { columnHeaderNombre, columnHeaderPrecio });
            listViewRepuestos.ForeColor = Color.White;
            listViewRepuestos.FullRowSelect = true;
            listViewRepuestos.Location = new Point(20, 60);
            listViewRepuestos.Name = "listViewRepuestos";
            listViewRepuestos.Size = new Size(760, 320);
            listViewRepuestos.TabIndex = 0;
            listViewRepuestos.UseCompatibleStateImageBehavior = false;
            listViewRepuestos.View = View.Details;
            listViewRepuestos.SelectedIndexChanged += listViewRepuestos_SelectedIndexChanged;
            // 
            // columnHeaderNombre
            // 
            columnHeaderNombre.Text = "Nombre";
            columnHeaderNombre.Width = 520;
            // 
            // columnHeaderPrecio
            // 
            columnHeaderPrecio.Text = "Precio";
            columnHeaderPrecio.Width = 200;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Bottom;
            btnAgregar.BackColor = Color.FromArgb(0, 122, 204);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(120, 390);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(150, 35);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "+ Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom;
            btnEditar.BackColor = Color.FromArgb(60, 60, 60);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(325, 390);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(150, 35);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom;
            btnEliminar.BackColor = Color.FromArgb(200, 50, 50);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(530, 390);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 35);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(20, 22);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(155, 25);
            labelTitle.TabIndex = 4;
            labelTitle.Text = "Lista de repuestos";
            // 
            // FrmRepuestos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 450);
            Controls.Add(labelTitle);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(listViewRepuestos);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmRepuestos";
            Text = "Repuestos";
            Load += FrmRepuestos_Load;
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