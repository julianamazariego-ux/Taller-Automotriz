using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class frmNuevaOrden : Form
    {
        public static List<OrdenTrabajoTemporal> listaOrdenes = new List<OrdenTrabajoTemporal>();

        private ErrorProvider errorProvider = new ErrorProvider();

        public frmNuevaOrden()
        {
            InitializeComponent();
        }

        private void frmNuevaOrden_Load(object sender, EventArgs e)
        {
            cmbTipoServicio.DataSource = Enum.GetValues(typeof(TipoServicio));
            cmbTipoServicio.SelectedIndex = -1; 
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

            if (esValido)
            {
                try
                {
                    OrdenTrabajoTemporal nuevaOrden = new OrdenTrabajoTemporal
                    {
                        DUI = mtxDUI.Text,
                        Placa = txtPlaca.Text.ToUpper(),
                        Servicio = (TipoServicio)cmbTipoServicio.SelectedItem,
                        CostoEstimado = costoValidado,
                        Descripcion = txtDescripcion.Text
                    };

                    listaOrdenes.Add(nuevaOrden);

                    MessageBox.Show("Orden de trabajo registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

    public class OrdenTrabajoTemporal
    {
        public string DUI { get; set; }
        public string Placa { get; set; }
        public TipoServicio Servicio { get; set; }
        public decimal CostoEstimado { get; set; }
        public string Descripcion { get; set; }
    }
}