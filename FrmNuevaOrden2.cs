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
            
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void FrmNuevaOrden2_Load(object sender, EventArgs e)
        {
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