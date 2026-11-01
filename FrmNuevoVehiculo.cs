using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TallerAutomotriz.Models;
using TallerAutomotriz.Repositorios;

namespace TallerAutomotriz
{
    public partial class FrmNuevoVehiculo : Form
    {
        public Vehiculo? VehiculoCreado { get; private set; }

        public FrmNuevoVehiculo()
        {
            InitializeComponent();
        }

        private void FrmNuevoVehiculo_Load(object sender, EventArgs e)
        {
            cmbMarca.DataSource = Enum.GetValues<MarcaVehiculo>();

            var clientes = ContextoDatos.Clientes.ObtenerTodos().ToList();

            if (clientes.Count > 0)
            {
                cmbCliente.DisplayMember = nameof(Cliente.Nombre);
                cmbCliente.DataSource = clientes;
                cmbCliente.SelectedIndex = -1;
            }
            else
            {
                cmbCliente.DataSource = null;
                cmbCliente.Items.Clear();
                cmbCliente.Items.Add("Primero registre un cliente...");
                cmbCliente.SelectedIndex = 0;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (ContextoDatos.Clientes.ObtenerTodos().Count == 0)
            {
                errorProvider1.SetError(cmbCliente, "Debe registrar un cliente en el sistema antes de guardar un vehículo.");
                MessageBox.Show("Debe registrar al menos un cliente en el sistema antes de poder guardar un vehículo.", "Validación de Propietario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            bool hayErrores = false;

            if (string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                errorProvider1.SetError(txtPlaca, "La placa es obligatoria.");
                hayErrores = true;
            }
            else if (ContextoDatos.Vehiculos.ExistePlaca(txtPlaca.Text))
            {
                errorProvider1.SetError(txtPlaca, "Esta placa ya se encuentra registrada.");
                hayErrores = true;
            }

            MarcaVehiculo marcaSeleccionada = default;
            if (string.IsNullOrWhiteSpace(cmbMarca.Text) || !Enum.TryParse(cmbMarca.Text, out marcaSeleccionada))
            {
                errorProvider1.SetError(cmbMarca, "Ingrese la marca.");
                hayErrores = true;
            }

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                errorProvider1.SetError(txtModelo, "Ingrese el modelo.");
                hayErrores = true;
            }

            if (string.IsNullOrWhiteSpace(cmbColor.Text))
            {
                errorProvider1.SetError(cmbColor, "Ingrese el color.");
                hayErrores = true;
            }

            var clienteSeleccionado = cmbCliente.SelectedItem as Cliente;
            if (clienteSeleccionado == null)
            {
                errorProvider1.SetError(cmbCliente, "Seleccione un cliente.");
                hayErrores = true;
            }

            int anioVehiculo = 0;
            if (string.IsNullOrWhiteSpace(mtxAnio.Text))
            {
                errorProvider1.SetError(mtxAnio, "Ingrese el año.");
                hayErrores = true;
            }
            else if (!int.TryParse(mtxAnio.Text, out anioVehiculo))
            {
                errorProvider1.SetError(mtxAnio, "El año debe ser un número válido.");
                hayErrores = true;
            }
            else if (anioVehiculo < 1950 || anioVehiculo > DateTime.Now.Year + 1)
            {
                errorProvider1.SetError(mtxAnio, "Ingrese un año de vehículo coherente.");
                hayErrores = true;
            }

            if (hayErrores || clienteSeleccionado == null)
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            try
            {
                var vehiculo = new Vehiculo(txtPlaca.Text, marcaSeleccionada, txtModelo.Text,
                                            anioVehiculo, cmbColor.Text, clienteSeleccionado);

                ContextoDatos.Vehiculos.Agregar(vehiculo);
                VehiculoCreado = vehiculo;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }

        private void lblPlaca_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmNuevoVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}