using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TallerAutomotriz.Models;
using TallerAutomotriz.Repositorios;

namespace TallerAutomotriz
{
    public partial class FrmRepuestos : Form
    {
        public FrmRepuestos()
        {
            InitializeComponent();
            btnAgregar.Click += BtnAgregar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
        }

        private void FrmRepuestos_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            listViewRepuestos.Items.Clear();
            listViewRepuestos.Columns.Clear();

            listViewRepuestos.Columns.Add("Nombre", 150);
            listViewRepuestos.Columns.Add("Precio", 80);
            listViewRepuestos.Columns.Add("Categoría", 100);
            listViewRepuestos.Columns.Add("Disponibles", 100);

            foreach (var r in ContextoDatos.Repuestos.ObtenerTodos())
            {
                var item = new ListViewItem(r.Nombre);
                item.SubItems.Add($"${r.Precio:F2}");
                item.SubItems.Add(r.Categoria.ToString());
                item.SubItems.Add(r.CantidadDisponible.ToString());
                item.Tag = r;
                listViewRepuestos.Items.Add(item);
            }
        }

        // Devuelve el repuesto de la fila seleccionada o null.
        private Repuesto? ObtenerRepuestoSeleccionado()
        {
            if (listViewRepuestos.SelectedItems.Count == 0)
                return null;

            return listViewRepuestos.SelectedItems[0].Tag as Repuesto;
        }

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            // El formulario guarda el repuesto en el repositorio; aquí solo se refresca la lista.
            using var f = new FrmRepuestoEdit();
            if (f.ShowDialog() == DialogResult.OK)
            {
                RefreshList();
            }
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            var rep = ObtenerRepuestoSeleccionado();
            if (rep == null) return;

            using var f = new FrmRepuestoEdit(rep);
            if (f.ShowDialog() == DialogResult.OK)
            {
                RefreshList();
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            var rep = ObtenerRepuestoSeleccionado();
            if (rep == null) return;

            var resp = MessageBox.Show($"Eliminar '{rep.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                try
                {
                    ContextoDatos.Repuestos.Eliminar(rep);
                    RefreshList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo eliminar el repuesto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listViewRepuestos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}