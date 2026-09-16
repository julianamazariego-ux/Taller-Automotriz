using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmNuevoVehiculo : Form
    {
        public string[] DatosCapturados;

        public FrmNuevoVehiculo()
        {
            InitializeComponent();
        }

        private void FrmNuevoVehiculo_Load(object sender, EventArgs e)
        {
            
            cmbMarca.DataSource = Enum.GetValues<MarcasVehiculos>();

           
            if (FrmNuevoCliente.ListaClientes.Count > 0)
            {

                cmbCliente.DataSource = FrmNuevoCliente.ListaClientes.Select(c => c.Nombre).ToList();
                cmbCliente.SelectedIndex = -1; 
            }
            else
            {

                cmbCliente.DataSource = new List<string> { "Primero registre un cliente..." };
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
            bool hayErrores = false; 

            
            if (string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                errorProvider1.SetError(txtPlaca, "La placa es obligatoria.");
                hayErrores = true;
            }
            else if (FrmVehiculos.listaVehiculos.Any(v => v[1].ToUpper() == txtPlaca.Text.ToUpper()))
            {
                errorProvider1.SetError(txtPlaca, "Esta placa ya se encuentra registrada.");
                hayErrores = true;
            }

            
            if (string.IsNullOrWhiteSpace(cmbMarca.Text))
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

            if (string.IsNullOrWhiteSpace(cmbCliente.Text))
            {
                errorProvider1.SetError(cmbCliente, "Seleccione un cliente.");
                hayErrores = true;
            }

            
            if (string.IsNullOrWhiteSpace(mtxAnio.Text))
            {
                errorProvider1.SetError(mtxAnio, "Ingrese el año.");
                hayErrores = true;
            }
            else if (!int.TryParse(mtxAnio.Text, out int anioVehiculo))
            {
                errorProvider1.SetError(mtxAnio,"El año debe ser un número válido.");
                hayErrores = true;
            }
            else if (anioVehiculo < 1950 || anioVehiculo > DateTime.Now.Year + 1)
            {
                errorProvider1.SetError(mtxAnio, "Ingrese un año de vehículo coherente.");
                hayErrores = true;
            }


            
            if (FrmNuevoCliente.ListaClientes.Count == 0 || cmbCliente.Text == "Primero registre un cliente...")
            {
                errorProvider1.SetError(cmbCliente, "Debe registrar un cliente en el sistema antes de guardar un vehículo.");
                hayErrores = true;
            }

            if (FrmNuevoCliente.ListaClientes.Count == 0 || cmbCliente.Text == "Primero registre un cliente...")
            {
                
                errorProvider1.SetError(cmbCliente, "Debe registrar un cliente en el sistema antes de guardar un vehículo.");


                MessageBox.Show("Debe registrar al menos un cliente en el sistema antes de poder guardar un vehículo.", "Validación de Propietario", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                hayErrores = true;
            }


            if (hayErrores)
            {
                this.DialogResult = DialogResult.None; 
                if (FrmNuevoCliente.ListaClientes.Count == 0 || cmbCliente.Text == "Primero registre un cliente...")
                {
                    errorProvider1.SetError(cmbCliente, "Debe registrar un cliente en el sistema antes de guardar un vehículo.");
                    hayErrores = true;
                }


                if (hayErrores)
                {
                    this.DialogResult = DialogResult.None; 
                    return; 
                }

              
            }

         

            DatosCapturados = new string[]
            {
    (FrmVehiculos.listaVehiculos.Count + 1).ToString(),
    txtPlaca.Text,
    cmbMarca.Text,
    txtModelo.Text,
    mtxAnio.Text,
    cmbColor.Text,
    cmbCliente.Text
            };

            
            this.DialogResult = DialogResult.OK;
            this.Close();



        }

        private void lblPlaca_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
