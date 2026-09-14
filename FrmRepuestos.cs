using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmRepuestos : Form
    {
        private List<Repuesto> repuestos = new List<Repuesto>();
        private readonly string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repuestos.json");

        public FrmRepuestos()
        {
            InitializeComponent();
            btnAgregar.Click += BtnAgregar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            FormClosing += FrmRepuestos_FormClosing;
        }

        private void FrmRepuestos_Load(object sender, EventArgs e)
        {
            CargarRepuestos();
            bool forzarActualizacion = repuestos.Count == 0 || (repuestos.Count > 0 && repuestos[0].CantidadDisponible == 0);

            if (forzarActualizacion)
            {
                repuestos.Clear();
                repuestos.Add(new Repuesto { Nombre = "Filtro de aceite", Precio = 45.00m, Categoria = CategoriaRepuesto.Filtros, CantidadDisponible = 15 });
                repuestos.Add(new Repuesto { Nombre = "Pastillas de freno", Precio = 80.00m, Categoria = CategoriaRepuesto.Pastillas, CantidadDisponible = 8 });
                repuestos.Add(new Repuesto { Nombre = "Aceite Premium 5W-30", Precio = 35.00m, Categoria = CategoriaRepuesto.Varias, CantidadDisponible = 20 });
                repuestos.Add(new Repuesto { Nombre = "Batería 60 Amper", Precio = 120.00m, Categoria = CategoriaRepuesto.Electrico, CantidadDisponible = 5 });
                repuestos.Add(new Repuesto { Nombre = "Bujías NGK", Precio = 15.00m, Categoria = CategoriaRepuesto.Bujias, CantidadDisponible = 40 });
                repuestos.Add(new Repuesto { Nombre = "Correa de distribución", Precio = 85.00m, Categoria = CategoriaRepuesto.Varias, CantidadDisponible = 4 });
                repuestos.Add(new Repuesto { Nombre = "Mangueras radiador", Precio = 25.00m, Categoria = CategoriaRepuesto.Mangueras, CantidadDisponible = 12 });
                repuestos.Add(new Repuesto { Nombre = "Termostato", Precio = 40.00m, Categoria = CategoriaRepuesto.Sensores, CantidadDisponible = 6 });
                repuestos.Add(new Repuesto { Nombre = "Válvula solenoide", Precio = 60.00m, Categoria = CategoriaRepuesto.Sensores, CantidadDisponible = 7 });
                repuestos.Add(new Repuesto { Nombre = "Filtro combustible", Precio = 20.00m, Categoria = CategoriaRepuesto.Filtros, CantidadDisponible = 10 });
                repuestos.Add(new Repuesto { Nombre = "Sensor oxígeno", Precio = 75.00m, Categoria = CategoriaRepuesto.Sensores, CantidadDisponible = 3 });
                repuestos.Add(new Repuesto { Nombre = "Pastillas freno traseras", Precio = 65.00m, Categoria = CategoriaRepuesto.Pastillas, CantidadDisponible = 9 });
                repuestos.Add(new Repuesto { Nombre = "Discos de freno", Precio = 95.00m, Categoria = CategoriaRepuesto.Pastillas, CantidadDisponible = 6 });
                repuestos.Add(new Repuesto { Nombre = "Bomba agua", Precio = 110.00m, Categoria = CategoriaRepuesto.Varias, CantidadDisponible = 2 });
                repuestos.Add(new Repuesto { Nombre = "Alternador", Precio = 180.00m, Categoria = CategoriaRepuesto.Electrico, CantidadDisponible = 2 });
                GuardarRepuestos();
            }
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

            foreach (var r in repuestos)
            {
                var item = new ListViewItem(r.Nombre);
                item.SubItems.Add($"${r.Precio:F2}");
                item.SubItems.Add(r.Categoria.ToString());
                item.SubItems.Add(r.CantidadDisponible.ToString());
                item.Tag = r;
                listViewRepuestos.Items.Add(item);
            }
        }

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            using var f = new FrmRepuestoEdit();
            if (f.ShowDialog() == DialogResult.OK)
            {
                repuestos.Add(f.RepuestoCreado);
                GuardarRepuestos();
                RefreshList();
            }
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            if (listViewRepuestos.SelectedItems.Count == 0) return;
            var item = listViewRepuestos.SelectedItems[0];
            var rep = (Repuesto)item.Tag;

            using var f = new FrmRepuestoEdit(rep);
            if (f.ShowDialog() == DialogResult.OK)
            {
                rep.Nombre = f.RepuestoCreado.Nombre;
                rep.Precio = f.RepuestoCreado.Precio;
                rep.Categoria = f.RepuestoCreado.Categoria;
                rep.CantidadDisponible = f.RepuestoCreado.CantidadDisponible;

                GuardarRepuestos();
                RefreshList();
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (listViewRepuestos.SelectedItems.Count == 0) return;
            var item = listViewRepuestos.SelectedItems[0];
            var rep = (Repuesto)item.Tag;
            var resp = MessageBox.Show($"Eliminar '{rep.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                repuestos.Remove(rep);
                GuardarRepuestos();
                RefreshList();
            }
        }

        private void GuardarRepuestos()
        {
            try
            {
                var json = JsonSerializer.Serialize(repuestos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(rutaArchivo, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar repuestos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRepuestos()
        {
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    var json = File.ReadAllText(rutaArchivo);
                    var loaded = JsonSerializer.Deserialize<List<Repuesto>>(json);
                    if (loaded != null && loaded.Count > 0)
                    {
                        repuestos = loaded;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar repuestos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmRepuestos_FormClosing(object? sender, FormClosingEventArgs e)
        {
            GuardarRepuestos();
        }

        private void listViewRepuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}