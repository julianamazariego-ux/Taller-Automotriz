using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmRepuestos : Form
    {
        public FrmRepuestos()
        {
            InitializeComponent();
        }

        private void EstilizarFormulario()
        {
            // --- Estilo del Formulario ---
            // Usamos un fondo oscuro más suave (gris carbón)
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Font = new Font("Roboto Light", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.Gainsboro; // Texto claro pero no blanco puro

            // --- Estilo del Label ---
            labelBuscar.ForeColor = Color.Silver;
            labelBuscar.Font = new Font("Roboto Medium", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            // --- Estilo del TextBox de búsqueda ---
            txtBuscar.BackColor = Color.FromArgb(30, 30, 30); // Fondo oscuro
            txtBuscar.ForeColor = Color.Gainsboro; // Texto claro
            txtBuscar.BorderStyle = BorderStyle.FixedSingle; // Un borde más sutil
        }

        private void EstilizarDataGridView()
        {
            // --- Configuración Fundamental del DataGridView ---
            dgvRepuestos.AllowUserToAddRows = false; // Importante para evitar la fila vacía al final
            dgvRepuestos.RowHeadersVisible = false;  // Oculta el marcador de selección de fila a la izquierda
            dgvRepuestos.GridColor = Color.FromArgb(50, 50, 50); // Color de las líneas del grid
            dgvRepuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Las columnas ocupan todo el ancho
            dgvRepuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Se selecciona toda la fila

            // --- Estilo del Encabezado (Headers) ---
            DataGridViewCellStyle headerStyle = dgvRepuestos.ColumnHeadersDefaultCellStyle;
            headerStyle.BackColor = Color.FromArgb(30, 30, 30); // Fondo oscuro
            headerStyle.ForeColor = Color.Gainsboro; // Texto claro
            headerStyle.Font = new Font("Roboto Medium", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centrar el texto

            // --- Estilo de las Filas ---
            DataGridViewCellStyle rowStyle = dgvRepuestos.DefaultCellStyle;
            rowStyle.BackColor = Color.FromArgb(35, 35, 35); // Fondo oscuro
            rowStyle.ForeColor = Color.Gainsboro; // Texto claro
            rowStyle.SelectionBackColor = Color.FromArgb(60, 60, 60); // Fondo al seleccionar
            rowStyle.SelectionForeColor = Color.White; // Texto al seleccionar
            dgvRepuestos.RowTemplate.Height = 30; // Filas más altas para menos hacinamiento

            // --- Estilo de las Filas Alternas para legibilidad ---
            dgvRepuestos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void FrmRepuestos_Load(object sender, EventArgs e)
        {
            EstilizarDataGridView();

            // 1. ELIMINACIÓN SEGURA DE LA COLUMNA DE TEXTO (Evita el error System.ArgumentException)
            // Revisamos posibles nombres que el diseñador le pudo dar a la columna
            if (dgvRepuestos.Columns.Contains("colSeleccion"))
            {
                dgvRepuestos.Columns.Remove("colSeleccion");
            }
            else if (dgvRepuestos.Columns.Contains("Seleccionar"))
            {
                dgvRepuestos.Columns.Remove("Seleccionar");
            }

            // 2. CREACIÓN DEL CHECKBOX VISUAL
            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
            chkCol.Name = "colSeleccionCheck";
            chkCol.HeaderText = "Seleccionar";
            dgvRepuestos.Columns.Insert(0, chkCol); // Lo insertamos en la primera posición (índice 0)

            // 3. ALINEACIÓN DEL PRECIO (De forma segura)
            if (dgvRepuestos.Columns.Contains("colPrecio"))
            {
                dgvRepuestos.Columns["colPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (dgvRepuestos.Columns.Contains("Precio"))
            {
                dgvRepuestos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // 4. CARGA DE DATOS DESDE GITHUB / CARPETA LOCAL
            string rutaArchivo = System.IO.Path.Combine(Application.StartupPath, "Datos", "repuestos.csv");

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);

                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');

                    if (datos.Length == 3)
                    {
                        dgvRepuestos.Rows.Add(false, datos[0], datos[1], datos[2]);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontró el archivo de inventario en la carpeta Datos.");
            }


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.ToLower();

            foreach (DataGridViewRow fila in dgvRepuestos.Rows)
            {
                if (fila.Cells["colArticulo"].Value != null)
                {
                    string articulo = fila.Cells["colArticulo"].Value.ToString().ToLower();
                    fila.Visible = articulo.Contains(busqueda);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
