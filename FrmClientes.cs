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

            errorProvider1.Clear();

            string nombreBuscado = txtNombreCliente.Text.ToLower().Trim();

            string duiBuscado = mtxtDUI.Text.Replace("-", "").Trim();

            if (string.IsNullOrWhiteSpace(nombreBuscado) && string.IsNullOrWhiteSpace(duiBuscado))
            {
                errorProvider1.SetError(txtNombreCliente, "Ingrese un nombre o DUI para buscar.");
                errorProvider1.SetError(mtxtDUI, "Ingrese un nombre o DUI para buscar.");
                MessageBox.Show("Debe ingresar un criterio de busqueda (Nombre o DUI).", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clientesFiltrados = FrmNuevoCliente.ListaClientes
                .Where(c =>
                    (string.IsNullOrWhiteSpace(nombreBuscado) || c.Nombre.ToLower().Contains(nombreBuscado))
                    &&
                    (string.IsNullOrWhiteSpace(duiBuscado) || c.DUI.Replace("-", "") == duiBuscado)
                ).ToList();

            ActualizarGrid(clientesFiltrados);

            if (clientesFiltrados.Count == 0)
            {
                MessageBox.Show("No se encontraron clientes con los criterios ingresados.", "Sin resultados", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }


        private void ActualizarGrid(List<Cliente> listaAMostrar)
        {
            dgvClientes.Rows.Clear();

            int idIncremental = 1;

            foreach (var cliente in listaAMostrar)
            {
                dgvClientes.Rows.Add(idIncremental, cliente.Nombre, cliente.DUI, cliente.Telefono, cliente.Correo, cliente.Dirección);
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
            errorProvider1.Clear();

            txtNombreCliente.Clear();
            mtxtDUI.Clear();


            ActualizarGrid(FrmNuevoCliente.ListaClientes);


            txtNombreCliente.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                string duiSeleccionado = dgvClientes.SelectedRows[0].Cells["DUI"].Value?.ToString() ?? string.Empty;

                var ClienteAEliminar = FrmNuevoCliente.ListaClientes.FirstOrDefault(c => c.DUI == duiSeleccionado);

                if (ClienteAEliminar != null)
                {
                    var respuesta = MessageBox.Show($"¿Está seguro de eliminar al cliente {ClienteAEliminar.Nombre}?", "Confirmar eliminación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        FrmNuevoCliente.ListaClientes.Remove(ClienteAEliminar);
                        ActualizarGrid(FrmNuevoCliente.ListaClientes);
                        MessageBox.Show("Cliente eliminado exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente de la tabla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                string duiSeleccionado = dgvClientes.SelectedRows[0].Cells["DUI"].Value?.ToString() ?? string.Empty;
                var clienteAEditar = FrmNuevoCliente.ListaClientes.FirstOrDefault(c => c.DUI == duiSeleccionado);

                if (clienteAEditar != null)
                {
                    using (FrmNuevoCliente formulario = new FrmNuevoCliente(clienteAEditar))
                    {
                        formulario.ShowDialog(this);
                    }
                    ActualizarGrid(FrmNuevoCliente.ListaClientes);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente de la tabla para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNombreCliente_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                mtxtDUI.Focus();
            }
        }
    }
}