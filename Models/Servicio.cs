using System;
using System.Text.Json.Serialization;

namespace TallerAutomotriz.Models;

public class Servicio
{
    [JsonRequired]
    public string Descripcion { get; set; } = string.Empty;

    [JsonRequired]
    public decimal CostoManoObra { get; set; }

    [JsonConstructor]
    public Servicio() { }

    public Servicio(string descripcion, decimal costoManoObra)
    {
        if (string.IsNullOrWhiteSpace(descripcion))
            throw new ArgumentException("La descripción del servicio es obligatoria.", nameof(descripcion));
        if (costoManoObra < 0)
            throw new ArgumentOutOfRangeException(nameof(costoManoObra), "El costo no puede ser negativo.");

        Descripcion = descripcion.Trim();
        CostoManoObra = costoManoObra;
    }
}