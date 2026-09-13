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
        public static List<string[]> listaVehiculos = new List<string[]>();

        public FrmVehiculos()
        {
            InitializeComponent();


            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.FormBorderStyle = FormBorderStyle.None;


            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {

                    control.ForeColor = System.Drawing.Color.White;
                    control.BackColor = System.Drawing.Color.Transparent;
                }
                else if (control is Button)
                {

                    Button btn = (Button)control;
                    btn.ForeColor = System.Drawing.Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
                }
            }


            dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(45, 45, 48);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(62, 62, 66);
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {



            FrmNuevoVehiculo modalVehiculo = new FrmNuevoVehiculo();


            if (modalVehiculo.ShowDialog() == DialogResult.OK)
            {

                listaVehiculos.Add(modalVehiculo.DatosCapturados);


                dataGridView1.Rows.Add(modalVehiculo.DatosCapturados);
            }
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscarPlaca.Clear();
            txtFiltroAnio.Clear();
            cmbFiltroMarca.SelectedIndex = -1;

            dataGridView1.Rows.Clear();
            foreach (var vehiculo in listaVehiculos)
            {
                dataGridView1.Rows.Add(vehiculo);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            
            var resultados = listaVehiculos.AsEnumerable();

            
            if (!string.IsNullOrWhiteSpace(txtBuscarPlaca.Text))
            {
                resultados = resultados.Where(v => v[1].ToUpper().Contains(txtBuscarPlaca.Text.ToUpper()));
            }

            
            if (cmbFiltroMarca.SelectedIndex != -1)
            {
                resultados = resultados.Where(v => v[2] == cmbFiltroMarca.Text);
            }

           
            if (!string.IsNullOrWhiteSpace(txtFiltroAnio.Text))
            {
                if (int.TryParse(txtFiltroAnio.Text, out int anioBuscado))
                {
                    resultados = resultados.Where(v => v[4] == anioBuscado.ToString());
                }
                else
                {
                    MessageBox.Show("Ingrese un año válido en números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

         
            dataGridView1.Rows.Clear();
            foreach (var vehiculo in resultados)
            {
                dataGridView1.Rows.Add(vehiculo);
            }
        }
    }
}