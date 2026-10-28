using System;
using System.Text.Json.Serialization;

namespace TallerAutomotriz.Models;

public class RepuestoItem
{
    [JsonRequired]
    public string NombreRepuesto { get; set; } = string.Empty;

    [JsonRequired]
    public int Cantidad { get; set; } = 1;

    [JsonRequired]
    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal => Cantidad * PrecioUnitario;

    [JsonConstructor]
    public RepuestoItem() { }

    public RepuestoItem(string nombreRepuesto, int cantidad, decimal precioUnitario)
    {
        if (string.IsNullOrWhiteSpace(nombreRepuesto))
            throw new ArgumentException("El nombre del repuesto es obligatorio.", nameof(nombreRepuesto));
        if (cantidad <= 0)
            throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad debe ser mayor a cero.");
        if (precioUnitario < 0)
            throw new ArgumentOutOfRangeException(nameof(precioUnitario), "El precio no puede ser negativo.");

        NombreRepuesto = nombreRepuesto.Trim();
        Cantidad = cantidad;
        PrecioUnitario = precioUnitario;
    }
}