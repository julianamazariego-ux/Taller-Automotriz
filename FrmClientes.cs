using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Windows.Forms;
using TallerAutomotriz.Models;
using TallerAutomotriz.Repositorios;

namespace TallerAutomotriz
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
            ActualizarGrid(ContextoDatos.Clientes.ObtenerTodos());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmNuevoCliente formulario = new FrmNuevoCliente())
            {
                formulario.ShowDialog(this);
            }

            ActualizarGrid(ContextoDatos.Clientes.ObtenerTodos());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            string nombreBuscado = txtNombreCliente.Text.Trim();
            string duiBuscado = mtxtDUI.Text.Replace("-", "").Trim();

            if (string.IsNullOrWhiteSpace(nombreBuscado) && string.IsNullOrWhiteSpace(duiBuscado))
            {
                errorProvider1.SetError(txtNombreCliente, "Ingrese un nombre o DUI para buscar.");
                errorProvider1.SetError(mtxtDUI, "Ingrese un nombre o DUI para buscar.");
                MessageBox.Show("Debe ingresar un criterio de busqueda (Nombre o DUI).", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clientesFiltrados = ContextoDatos.Clientes.Buscar(nombreBuscado, duiBuscado);

            ActualizarGrid(clientesFiltrados);

            if (clientesFiltrados.Count == 0)
            {
                MessageBox.Show("No se encontraron clientes con los criterios ingresados.", "Sin resultados", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ActualizarGrid(IEnumerable<Cliente> listaAMostrar)
        {
            dgvClientes.Rows.Clear();

            int idIncremental = 1;

            foreach (var cliente in listaAMostrar)
            {
                dgvClientes.Rows.Add(idIncremental, cliente.Nombre, cliente.Dui, cliente.Telefono, cliente.Correo, cliente.Direccion);
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

            ActualizarGrid(ContextoDatos.Clientes.ObtenerTodos());

            txtNombreCliente.Focus();
        }

        // Devuelve el cliente de la fila seleccionada (buscándolo por DUI en el repositorio) o null.
        private Cliente? ObtenerClienteSeleccionado()
        {
            if (dgvClientes.SelectedRows.Count == 0)
                return null;

            string duiSeleccionado = dgvClientes.SelectedRows[0].Cells["Dui"].Value?.ToString() ?? string.Empty;
            return ContextoDatos.Clientes.Obtener(c => c.Dui == duiSeleccionado);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var clienteAEliminar = ObtenerClienteSeleccionado();

            if (clienteAEliminar == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la tabla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ContextoDatos.Vehiculos.ObtenerPorCliente(clienteAEliminar.Id).Count > 0)
            {
                MessageBox.Show("No se puede eliminar al cliente porque tiene vehículos registrados.\nElimine primero sus vehículos.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var respuesta = MessageBox.Show($"¿Está seguro de eliminar al cliente {clienteAEliminar.Nombre}?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    ContextoDatos.Clientes.Eliminar(clienteAEliminar);
                    ActualizarGrid(ContextoDatos.Clientes.ObtenerTodos());
                    MessageBox.Show("Cliente eliminado exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo eliminar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var clienteAEditar = ObtenerClienteSeleccionado();

            if (clienteAEditar == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la tabla para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FrmNuevoCliente formulario = new FrmNuevoCliente(clienteAEditar))
            {
                formulario.ShowDialog(this);
            }
            ActualizarGrid(ContextoDatos.Clientes.ObtenerTodos());
        }


        private void txtNombreCliente_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                mtxtDUI.Focus();
            }
        }

        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}