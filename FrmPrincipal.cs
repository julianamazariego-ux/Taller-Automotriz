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

        }

        private void administrarClientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmClientes formulario = new FrmClientes();

            formulario.MdiParent = this;

            formulario.Show();
        }

        private void administrarVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVehiculos formulario = new FrmVehiculos();

            formulario.MdiParent = this;

            formulario.Show();
        }
    }
}
