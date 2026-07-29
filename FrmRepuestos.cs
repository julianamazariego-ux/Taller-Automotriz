using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;

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

        private void EstilizarFormulario()
        {
            
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Font = new Font("Roboto Light", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.Gainsboro;

           
            labelBuscar.ForeColor = Color.Silver;
            labelBuscar.Font = new Font("Roboto Medium", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

           
            txtBuscar.BackColor = Color.FromArgb(30, 30, 30); 
            txtBuscar.ForeColor = Color.Gainsboro;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle; 
        }

        private void EstilizarDataGridView()
        {
           
            dgvRepuestos.AllowUserToAddRows = false; 
            dgvRepuestos.RowHeadersVisible = false;  
            dgvRepuestos.GridColor = Color.FromArgb(50, 50, 50); 
            dgvRepuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            dgvRepuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect; 

            
            DataGridViewCellStyle headerStyle = dgvRepuestos.ColumnHeadersDefaultCellStyle;
            headerStyle.BackColor = Color.FromArgb(30, 30, 30); 
            headerStyle.ForeColor = Color.Gainsboro; 
            headerStyle.Font = new Font("Roboto Medium", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 

            
            DataGridViewCellStyle rowStyle = dgvRepuestos.DefaultCellStyle;
            rowStyle.BackColor = Color.FromArgb(35, 35, 35); 
            rowStyle.ForeColor = Color.Gainsboro;
            rowStyle.SelectionBackColor = Color.FromArgb(60, 60, 60); 
            rowStyle.SelectionForeColor = Color.White; 
            dgvRepuestos.RowTemplate.Height = 30; 

           
            dgvRepuestos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void FrmRepuestos_Load(object sender, EventArgs e)
        {

            CargarRepuestos();


            if (repuestos.Count == 0 || repuestos.Count == 3)
            {
                repuestos.Clear();
                repuestos.Add(new Repuesto { Nombre = "Filtro de aceite", Precio = 45.00m });
                repuestos.Add(new Repuesto { Nombre = "Pastillas de freno", Precio = 80.00m });
                repuestos.Add(new Repuesto { Nombre = "Aceite Premium 5W-30", Precio = 35.00m });
                repuestos.Add(new Repuesto { Nombre = "Batería 60 Amper", Precio = 120.00m });
                repuestos.Add(new Repuesto { Nombre = "Bujías NGK", Precio = 15.00m });
                repuestos.Add(new Repuesto { Nombre = "Correa de distribución", Precio = 85.00m });
                repuestos.Add(new Repuesto { Nombre = "Mangueras radiador", Precio = 25.00m });
                repuestos.Add(new Repuesto { Nombre = "Termostato", Precio = 40.00m });
                repuestos.Add(new Repuesto { Nombre = "Válvula solenoide", Precio = 60.00m });
                repuestos.Add(new Repuesto { Nombre = "Filtro combustible", Precio = 20.00m });
                repuestos.Add(new Repuesto { Nombre = "Sensor oxígeno", Precio = 75.00m });
                repuestos.Add(new Repuesto { Nombre = "Pastillas freno traseras", Precio = 65.00m });
                repuestos.Add(new Repuesto { Nombre = "Discos de freno", Precio = 95.00m });
                repuestos.Add(new Repuesto { Nombre = "Bomba agua", Precio = 110.00m });
                repuestos.Add(new Repuesto { Nombre = "Alternador", Precio = 180.00m });
                GuardarRepuestos();
            }
            RefreshList();
        }

        private void RefreshList()
        {
            listViewRepuestos.Items.Clear();
            foreach (var r in repuestos)
            {
                var item = new ListViewItem(r.Nombre);
                item.SubItems.Add($"${r.Precio:F2}");
                item.Tag = r;
                listViewRepuestos.Items.Add(item);
            }
        }

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            using var f = new FrmRepuestoEdit();
            if (f.ShowDialog() == DialogResult.OK)
            {
                repuestos.Add(new Repuesto { Nombre = f.RepuestoNombre, Precio = f.RepuestoPrecio });
                GuardarRepuestos();
                RefreshList();
            }
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            if (listViewRepuestos.SelectedItems.Count == 0) return;
            var item = listViewRepuestos.SelectedItems[0];
            var rep = (Repuesto)item.Tag;
            using var f = new FrmRepuestoEdit(rep.Nombre, rep.Precio);
            if (f.ShowDialog() == DialogResult.OK)
            {
                rep.Nombre = f.RepuestoNombre;
                rep.Precio = f.RepuestoPrecio;
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
