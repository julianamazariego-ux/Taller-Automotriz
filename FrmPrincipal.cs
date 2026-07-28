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

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmInicio());
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Muestra un cuadro de diálogo con botones "Sí" y "No"
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro que desea salir del sistema?", // El mensaje principal
                "Confirmar Salida",                          // El título de la ventanita
                MessageBoxButtons.YesNo,                     // Qué botones mostrar
                MessageBoxIcon.Question                      // El ícono de interrogación
            );

            // Si el usuario hace clic en "Sí"
            if (respuesta == DialogResult.Yes)
            {
                Application.Exit(); // Cierra todo el programa por completo
            }
            // Si hace clic en "No", el "if" se ignora y el programa sigue funcionando normalmente
        }

        private void nuevaOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmNuevaOrden modalNuevaOrden = new frmNuevaOrden();


            modalNuevaOrden.ShowDialog();
        }

        private void mecanicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmMecanicos());
        }

        private void verRepuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmRepuestos());
        }
    }
}


