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
        // REQUISITO: Lista genérica para guardar las órdenes temporalmente
        public static List<OrdenTrabajoTemporal> listaOrdenes = new List<OrdenTrabajoTemporal>();

        // REQUISITO: ErrorProvider para mostrar los íconos de error
        private ErrorProvider errorProvider = new ErrorProvider();

        public frmNuevaOrden()
        {
            InitializeComponent();
        }

        private void frmNuevaOrden_Load(object sender, EventArgs e)
        {
            // Llenar el ComboBox con los valores de la enumeración al cargar la ventana
            cmbTipoServicio.DataSource = Enum.GetValues(typeof(TipoServicio));
            cmbTipoServicio.SelectedIndex = -1; // Dejarlo vacío por defecto
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Limpiar errores previos antes de volver a evaluar
            errorProvider.Clear();
            bool esValido = true;
            decimal costoValidado = 0;

            // 1. Validación del DUI (MaskedTextBox)
            if (!mtxDUI.MaskFull)
            {
                errorProvider.SetError(mtxDUI, "Ingrese el DUI completo del cliente.");
                esValido = false;
            }

            // 2. Validación de la Placa
            if (string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                errorProvider.SetError(txtPlaca, "La placa del vehículo es obligatoria.");
                esValido = false;
            }

            // 3. Validación del ComboBox de Servicio
            if (cmbTipoServicio.SelectedIndex == -1)
            {
                errorProvider.SetError(cmbTipoServicio, "Seleccione un tipo de servicio.");
                esValido = false;
            }

            // 4. REQUISITO: Validación numérica con TryParse para el Costo Estimado
            if (!decimal.TryParse(txtCostoEstimado.Text, out costoValidado) || costoValidado < 0)
            {
                errorProvider.SetError(txtCostoEstimado, "Ingrese un costo estimado válido (solo números, ej: 45.50).");
                esValido = false;
            }

            // 5. Validación de la Descripción
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errorProvider.SetError(txtDescripcion, "Ingrese una descripción del problema.");
                esValido = false;
            }

            // Si todos los datos están llenos correctamente, procedemos a guardar
            if (esValido)
            {
                try
                {
                    // Crear el objeto con los datos capturados
                    OrdenTrabajoTemporal nuevaOrden = new OrdenTrabajoTemporal
                    {
                        DUI = mtxDUI.Text,
                        Placa = txtPlaca.Text.ToUpper(),
                        Servicio = (TipoServicio)cmbTipoServicio.SelectedItem,
                        CostoEstimado = costoValidado,
                        Descripcion = txtDescripcion.Text
                    };

                    // Agregarlo a la lista temporal
                    listaOrdenes.Add(nuevaOrden);

                    MessageBox.Show("Orden de trabajo registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiamos los campos para permitir el ingreso de una nueva orden
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

    // --- CLASES Y ENUMERACIONES SE MANTIENEN AL FINAL PARA EVITAR ERRORES DEL DISEÑADOR ---

    // REQUISITO: Enumeración para los tipos de servicio
    public enum TipoServicio
    {
        Diagnostico,
        MantenimientoBasico,
        ReparacionMecanica,
        SistemaElectrico,
        Otro
    }

    // Clase temporal para estructurar los datos de la orden
    public class OrdenTrabajoTemporal
    {
        public string DUI { get; set; }
        public string Placa { get; set; }
        public TipoServicio Servicio { get; set; }
        public decimal CostoEstimado { get; set; }
        public string Descripcion { get; set; }
    }
}