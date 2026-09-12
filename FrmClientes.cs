using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // REQUISITO: Indispensable para usar consultas LINQ
using System.Text;
using System.Windows.Forms;
using static Taller_Automotriz.frmNuevaOrden;

namespace Taller_Automotriz
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            // Al cargar la ventana, llenamos la tabla con la lista temporal que ya existe
            ActualizarGrid(frmNuevaOrden.listaClientes);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmNuevoCliente formulario = new FrmNuevoCliente())
            {
                formulario.ShowDialog(this);
            }

            // Refrescamos la tabla por si el usuario agregó un cliente nuevo en esa ventana
            ActualizarGrid(frmNuevaOrden.listaClientes);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Suponiendo que a tu TextBox de búsqueda le pusiste "txtBuscar"
            string textoBusqueda = txtBuscar.Text.ToLower().Trim();

            // REQUISITO: Uso de consulta LINQ para filtrar clientes por Nombre o DUI
            var clientesFiltrados = frmNuevaOrden.listaClientes
                .Where(c => c.Nombre.ToLower().Contains(textoBusqueda) || c.DUI.Contains(textoBusqueda))
                .ToList();

           
            ActualizarGrid(clientesFiltrados);
        }

        
        private void ActualizarGrid(List<ClienteTemporal> listaAMostrar)
        {
            dgvClientes.Rows.Clear(); 

            int idIncremental = 1; 

            foreach (var cliente in listaAMostrar)
            {
       
                dgvClientes.Rows.Add(idIncremental, cliente.Nombre, cliente.DUI, cliente.Telefono, cliente.Correo);
                idIncremental++;
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}