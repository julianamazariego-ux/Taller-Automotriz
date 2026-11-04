using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TallerAutomotriz.Models;

namespace TallerAutomotriz
{
    public class FrmSeleccionarMecanico : Form
    {
        private readonly ComboBox cmbMecanicos = new ComboBox();

        public Mecanico? MecanicoSeleccionado { get; private set; }

        public FrmSeleccionarMecanico(IEnumerable<Mecanico> mecanicos)
        {
            Text = "Asignar mecánico";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(390, 135);

            var lblTitulo = new Label
            {
                AutoSize = true,
                Location = new Point(15, 15),
                Text = "¿Qué mecánico atenderá la orden?"
            };

            var lista = mecanicos.ToList();

            cmbMecanicos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMecanicos.FormattingEnabled = true;
            cmbMecanicos.Location = new Point(15, 45);
            cmbMecanicos.Size = new Size(360, 28);
            cmbMecanicos.Format += cmbMecanicos_Format;
            cmbMecanicos.DataSource = lista;
            cmbMecanicos.SelectedIndex = lista.Count == 1 ? 0 : -1;

            var btnAceptar = new Button
            {
                Text = "Aceptar",
                Location = new Point(190, 90),
                Size = new Size(90, 30)
            };
            btnAceptar.Click += btnAceptar_Click;

            var btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(285, 90),
                Size = new Size(90, 30),
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(lblTitulo);
            Controls.Add(cmbMecanicos);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);

            AcceptButton = btnAceptar;
            CancelButton = btnCancelar;
        }

        private void cmbMecanicos_Format(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Mecanico mecanico)
            {
                e.Value = $"{mecanico.Nombre} ({mecanico.Especialidad})";
            }
        }

        private void btnAceptar_Click(object? sender, EventArgs e)
        {
            if (cmbMecanicos.SelectedItem is not Mecanico mecanico)
            {
                MessageBox.Show("Seleccione un mecánico.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MecanicoSeleccionado = mecanico;
            DialogResult = DialogResult.OK;
        }
    }
}