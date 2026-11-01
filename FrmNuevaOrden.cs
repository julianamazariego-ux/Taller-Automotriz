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
    public partial class frmNuevaOrden : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();

        private readonly ComboBox cmbMecanico = new ComboBox();

        public frmNuevaOrden()
        {
            InitializeComponent();
            CrearControlMecanico();
        }

        private void CrearControlMecanico()
        {
            var lblMecanico = new Label
            {
                AutoSize = true,
                Font = label3.Font,
                ForeColor = label3.ForeColor,
                Location = new Point(63, 476),
                Text = "Mecánico:"
            };

            cmbMecanico.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMecanico.FormattingEnabled = true;
            cmbMecanico.Location = new Point(172, 472);
            cmbMecanico.Size = new Size(400, 28);
            cmbMecanico.TabIndex = 25;
            cmbMecanico.Format += cmbMecanico_Format;

            Controls.Add(lblMecanico);
            Controls.Add(cmbMecanico);

            lblMecanico.BringToFront();
            cmbMecanico.BringToFront();
        }

        private void cmbMecanico_Format(object? sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Mecanico mecanico)
            {
                e.Value = $"{mecanico.Nombre} ({mecanico.Especialidad})";
            }
        }

        private void frmNuevaOrden_Load(object sender, EventArgs e)
        {
            cmbTipoServicio.DataSource = Enum.GetValues(typeof(TipoServicio));
            cmbTipoServicio.SelectedIndex = -1;

            cmbMecanico.DataSource = ContextoDatos.Mecanicos.ObtenerDisponibles();
            cmbMecanico.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool esValido = true;
            decimal costoValidado = 0;

            if (!mtxDUI.MaskFull)
            {
                errorProvider.SetError(mtxDUI, "Ingrese el DUI completo del cliente.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                errorProvider.SetError(txtPlaca, "La placa del vehículo es obligatoria.");
                esValido = false;
            }

            if (cmbTipoServicio.SelectedIndex == -1)
            {
                errorProvider.SetError(cmbTipoServicio, "Seleccione un tipo de servicio.");
                esValido = false;
            }

            if (!decimal.TryParse(txtCostoEstimado.Text, out costoValidado) || costoValidado < 0)
            {
                errorProvider.SetError(txtCostoEstimado, "Ingrese un costo estimado válido (solo números, ej: 45.50).");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errorProvider.SetError(txtDescripcion, "Ingrese una descripción del problema.");
                esValido = false;
            }

            var mecanicoSeleccionado = cmbMecanico.SelectedItem as Mecanico;
            if (mecanicoSeleccionado == null)
            {
                errorProvider.SetError(cmbMecanico, cmbMecanico.Items.Count == 0
                    ? "No hay mecánicos activos. Registre o active uno en la pantalla de Mecánicos."
                    : "Seleccione el mecánico que atenderá la orden.");
                esValido = false;
            }

            Cliente? cliente = null;
            Vehiculo? vehiculo = null;

            if (esValido)
            {
                cliente = ContextoDatos.Clientes.Obtener(c => c.Dui == mtxDUI.Text);
                if (cliente == null)
                {
                    errorProvider.SetError(mtxDUI, "No existe un cliente registrado con ese DUI.");
                    esValido = false;
                }

                vehiculo = ContextoDatos.Vehiculos.BuscarPorPlaca(txtPlaca.Text);
                if (vehiculo == null)
                {
                    errorProvider.SetError(txtPlaca, "No existe un vehículo registrado con esa placa.");
                    esValido = false;
                }
                else if (cliente != null && vehiculo.ClienteId != cliente.Id)
                {
                    errorProvider.SetError(txtPlaca, "Ese vehículo no pertenece al cliente con ese DUI.");
                    esValido = false;
                }
            }

            if (!esValido || cliente == null || vehiculo == null || mecanicoSeleccionado == null)
                return;

            try
            {
                var orden = new OrdenTrabajo(string.Empty, vehiculo, mecanicoSeleccionado, txtDescripcion.Text);
                orden.AgregarServicio(((TipoServicio)cmbTipoServicio.SelectedItem!).ToString(), costoValidado);

                ContextoDatos.Ordenes.Agregar(orden);

                MessageBox.Show($"Orden de trabajo {orden.NumeroOrden} registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            mtxDUI.Clear();
            txtPlaca.Clear();
            cmbTipoServicio.SelectedIndex = -1;
            cmbMecanico.SelectedIndex = -1;
            txtCostoEstimado.Clear();
            txtDescripcion.Clear();
            mtxDUI.Focus();
        }
    }

    public enum TipoServicio
    {
        Diagnostico,
        MantenimientoBasico,
        ReparacionMecanica,
        SistemaElectrico,
        Otro
    }
}