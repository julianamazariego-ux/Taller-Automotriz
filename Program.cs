using TallerAutomotriz.Repositorios;

namespace TallerAutomotriz
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var avisos = ContextoDatos.Inicializar();
            if (avisos.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine + Environment.NewLine, avisos),
                    "Aviso al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.Run(new FrmPrincipal());
        }
    }
}