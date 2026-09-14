namespace Taller_Automotriz
{
    public class Repuesto
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public CategoriaRepuesto Categoria { get; set; }
        public int CantidadDisponible { get; set; }
    }
}