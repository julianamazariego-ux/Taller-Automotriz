using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmOrdenes : Form
    {
        public FrmOrdenes()
        {
            InitializeComponent();
        }

        private void FrmOrdenes_Load(object sender, EventArgs e)
        {
            string rutaArchivo = Path.Combine(Application.StartupPath, "Datos", "ordenes_taller.csv");
            CargarOrdenesDesdeCSV(rutaArchivo, dataGridView1);
        }

        private void CargarOrdenesDesdeCSV(string rutaArchivo, DataGridView grid)
        {
            DataTable tabla = new DataTable();

            try
            {
                if (File.Exists(rutaArchivo))
                {
                    string[] lineas = File.ReadAllLines(rutaArchivo);

                    if (lineas.Length > 0)
                    {
                        string[] encabezados = lineas[0].Split(',');
                        foreach (string encabezado in encabezados)
                        {
                            tabla.Columns.Add(encabezado.Trim());
                        }

                        for (int i = 1; i < lineas.Length; i++)
                        {
                            string[] celdas = lineas[i].Split(',');
                            tabla.Rows.Add(celdas);
                        }
                    }
                }
                else
                {
                    tabla.Columns.Add("ID_Orden");
                    tabla.Columns.Add("Cliente");
                    tabla.Columns.Add("Vehiculo");
                    tabla.Columns.Add("Servicio_Requerido");
                    tabla.Columns.Add("Fecha_Ingreso");
                    tabla.Columns.Add("Estado");
                }

                int idTemporal = 1;
                foreach (var ordenNueva in frmNuevaOrden.listaOrdenes)
                {
                    tabla.Rows.Add(
                        "TEMP-" + idTemporal.ToString("D3"), 
                        ordenNueva.DUI,                      
                        ordenNueva.Placa,                    
                        ordenNueva.Servicio.ToString(),      
                        DateTime.Now.ToString("yyyy-MM-dd"), 
                        "Abierta"                            
                    );
                    idTemporal++;
                }

                
                grid.DataSource = tabla;
                ConfigurarGridOrdenes(grid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGridOrdenes(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(224, 224, 224);

            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 57, 85);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.ColumnHeadersHeight = 40;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.RowHeadersVisible = false;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            grid.RowTemplate.Height = 35;

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 249);

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}