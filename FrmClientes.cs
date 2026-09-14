using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();

            ConfigurarGrid();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {

            ActualizarGrid(FrmNuevoCliente.ListaClientes);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmNuevoCliente formulario = new FrmNuevoCliente())
            {
                formulario.ShowDialog(this);
            }


            ActualizarGrid(FrmNuevoCliente.ListaClientes);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {


            string nombreBuscado = txtNombreCliente.Text.ToLower().Trim();

            string duiBuscado = mtxDUI.Text.Replace("-", "").Trim();

            var clientesFiltrados = FrmNuevoCliente.ListaClientes
                .Where(c =>
                    (string.IsNullOrWhiteSpace(nombreBuscado) || c.Nombre.ToLower().Contains(nombreBuscado))
                    &&
                    (string.IsNullOrWhiteSpace(duiBuscado) || c.DUI.Replace("-", "") == duiBuscado)
                ).ToList();



            ActualizarGrid(clientesFiltrados);
        }


        private void ActualizarGrid(List<Cliente> listaAMostrar)
        {
            dgvClientes.Rows.Clear();

            int idIncremental = 1;

            foreach (var cliente in listaAMostrar)
            {
                dgvClientes.Rows.Add(idIncremental, cliente.Nombre, cliente.DUI, cliente.Telefono, cliente.Correo);
                idIncremental++;
            }
        }


        private void ConfigurarGrid()
        {

            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvClientes.GridColor = Color.DimGray;
            dgvClientes.RowHeadersVisible = false;


            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvClientes.ColumnHeadersHeight = 35;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            dgvClientes.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvClientes.DefaultCellStyle.ForeColor = Color.White;
            dgvClientes.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);


            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 102, 204);
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvClientes.RowTemplate.Height = 30;


            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AllowUserToAddRows = false;
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            
            txtNombreCliente.Clear();
            mtxDUI.Clear();

            
            ActualizarGrid(FrmNuevoCliente.ListaClientes);

         
            txtNombreCliente.Focus();
        }
    }
}