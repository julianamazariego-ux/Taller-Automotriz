using System;
using System.Windows.Forms;

namespace Taller_Automotriz
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmInicio());
        }

        private void administrarClientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmClientes());
        }

        private void administrarVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmVehiculos());
        }

        // =====================================================================
        // MÉTODO MÁGICO: Cierra la ventana anterior antes de abrir la nueva.
        // Esto evita que las ventanas se vayan acumulando y desplazando hacia abajo.
        // =====================================================================
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Cierra cualquier formulario que ya esté abierto adentro del contenedor
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            // Configura el nuevo formulario
            formularioHijo.MdiParent = this;
            formularioHijo.Dock = DockStyle.Fill; // Llena todo el espacio perfectamente
            formularioHijo.Show();
        }
    }
}


