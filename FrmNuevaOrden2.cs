using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{

    public partial class FrmNuevaOrden2 : Form
    {
        // REQUISITO: Segunda lista genérica para el registro temporal
        public static List<VehiculoTemporal> listaVehiculos = new List<VehiculoTemporal>();

        private ErrorProvider errorProvider = new ErrorProvider();


        public FrmNuevaOrden2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (frmNuevaOrden.listaClientes.Count > listaVehiculos.Count)
            {
                frmNuevaOrden.listaClientes.RemoveAt(frmNuevaOrden.listaClientes.Count - 1);
            }

            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            bool esValido = true;
            int anioValidado = 0;
            int kilometrajeValidado = 0;

            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                errorProvider.SetError(txtMarca, "La marca es obligatoria.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                errorProvider.SetError(txtModelo, "El modelo es obligatorio.");
                esValido = false;
            }

            if (!int.TryParse(txtAño.Text, out anioValidado) || anioValidado < 1950 || anioValidado > DateTime.Now.Year + 1)
            {
                errorProvider.SetError(txtAño, "Ingrese un año válido (ej. 2015).");
                esValido = false;
            }

            if (!int.TryParse(txtKilometraje.Text, out kilometrajeValidado) || kilometrajeValidado < 0)
            {
                errorProvider.SetError(txtKilometraje, "Ingrese un kilometraje numérico válido.");
                esValido = false;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                errorProvider.SetError(cmbEstado, "Seleccione el estado del vehículo.");
                esValido = false;
            }

            if (esValido)
            {
                try
                {
                    VehiculoTemporal nuevoVehiculo = new VehiculoTemporal
                    {
                        Marca = txtMarca.Text,
                        Modelo = txtModelo.Text,
                        Año = anioValidado,
                        Kilometraje = kilometrajeValidado,
                        Estado = (EstadoVehiculo)cmbEstado.SelectedItem
                    };

                    listaVehiculos.Add(nuevoVehiculo);

                    MessageBox.Show("Orden completa registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void FrmNuevaOrden2_Load(object sender, EventArgs e)
        {

            // Llenar el ComboBox usando la enumeración al cargar la ventana
            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoVehiculo));
            cmbEstado.SelectedIndex = -1; // Dejarlo en blanco por defecto

        }

        public enum EstadoVehiculo
        {
            Excelente,
            Bueno,
            Regular,
            RequiereReparacion,
            Inoperable
        }

        public class VehiculoTemporal
        {
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public int Año { get; set; }
            public int Kilometraje { get; set; }
            public EstadoVehiculo Estado { get; set; }
        }
    }
}
