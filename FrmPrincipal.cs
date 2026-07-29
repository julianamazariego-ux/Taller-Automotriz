using System;
using System.Windows.Forms;
using Taller_Automotriz;
namespace Taller_Automotriz
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
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


        private void AbrirFormularioHijo(Form formularioHijo)
        {

            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }


            formularioHijo.MdiParent = this;
            formularioHijo.Dock = DockStyle.Fill;
            formularioHijo.Show();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmInicio());
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro que desea salir del sistema?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );


            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }

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

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmServicios formulario = new FrmServicios();
            formulario.MdiParent = this;
            formulario.WindowState = FormWindowState.Maximized;
            formulario.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void repuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ordenesAbiertasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmNuevaOrden modalNuevaOrden = new frmNuevaOrden();
            FrmOrdenes modalOrdenes = new FrmOrdenes();

            //modalNuevaOrden.ShowDialog();
            modalOrdenes.ShowDialog();  
        }
    }
}


