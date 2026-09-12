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

        public static List<ClienteTemporal> listaClientes = new List<ClienteTemporal>();

        // REQUISITO: ErrorProvider para mostrar los íconos de error
        private ErrorProvider errorProvider = new ErrorProvider();


        public frmNuevaOrden()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Limpiar errores previos antes de volver a evaluar
            errorProvider.Clear();
            bool esValido = true;

            // 1. Validación del Nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "El nombre es obligatorio.");
                esValido = false;
            }

            // 2. Validación del Teléfono (MaskedTextBox)
            if (!mtxTelefono.MaskFull)
            {
                errorProvider.SetError(mtxTelefono, "Debe ingresar el número de teléfono completo.");
                esValido = false;
            }

            // 3. Validación del Correo Electrónico
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                errorProvider.SetError(txtCorreo, "El correo electrónico es obligatorio.");
                esValido = false;
            }

            // 4. Validación del Documento de Identidad (MaskedTextBox)
            if (!mtxDUI.MaskFull)
            {
                errorProvider.SetError(mtxDUI, "Debe ingresar el documento de identidad completo.");
                esValido = false;
            }

            // Si todos los datos están llenos correctamente, procedemos a guardar y avanzar
            if (esValido)
            {
                try
                {
                    // Crear el objeto con los datos capturados
                    ClienteTemporal nuevoCliente = new ClienteTemporal
                    {
                        Nombre = txtNombre.Text,
                        Telefono = mtxTelefono.Text,
                        Correo = txtCorreo.Text,
                        DUI = mtxDUI.Text
                    };

                    // Agregarlo a la lista temporal
                    listaClientes.Add(nuevoCliente);

                    // Abrir la ventana 2 que ya tenías programada
                    FrmNuevaOrden2 ventana2 = new FrmNuevaOrden2();
                    ventana2.ShowDialog();

                    // Limpiamos los campos por si cierran la ventana 2 y quieren registrar otro cliente
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
        

        private void frmNuevaOrden_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            mtxTelefono.Clear();
            txtCorreo.Clear();
            mtxDUI.Clear();
        }

        public class ClienteTemporal
        {
            public string Nombre { get; set; }
            public string Telefono { get; set; }
            public string Correo { get; set; }
            public string DUI { get; set; }
        }
    }
}
