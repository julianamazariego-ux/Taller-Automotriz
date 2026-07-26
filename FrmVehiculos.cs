using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmVehiculos : Form
    {
        public FrmVehiculos()
        {
            InitializeComponent();

            // 1. EL FONDO Y LA VENTANA
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.FormBorderStyle = FormBorderStyle.None;

            // 2. TEXTOS Y BOTONES (Búsqueda automática)
            // Este truco recorre todo el formulario y pinta las cosas sin importar cómo se llamen.
            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {
                    // Si es un texto, lo pone blanco y con fondo transparente
                    control.ForeColor = System.Drawing.Color.White;
                    control.BackColor = System.Drawing.Color.Transparent;
                }
                else if (control is Button)
                {
                    // Si es un botón, le quita el borde feo y le pone letra blanca
                    Button btn = (Button)control;
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
                }
            }

            // 3. LA MAGIA DE LA TABLA
            dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(45, 45, 48);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;

            // Colores del Encabezado (Azul)
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

            // Colores de las Filas (Grises)
            dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(62, 62, 66);
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            // Evento vacío (lo dejamos tal cual lo tenías)
        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            // Evento vacío (lo dejamos tal cual lo tenías)
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevoVehiculo modalVehiculo = new FrmNuevoVehiculo();
            modalVehiculo.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}