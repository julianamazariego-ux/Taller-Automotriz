using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using TallerAutomotriz.Models;

namespace TallerAutomotriz.Repositorios;

public class RepositorioOrdenes : RepositorioBase<OrdenTrabajo>
{
    private int _correlativo = 1;

    public RepositorioOrdenes(string? carpetaDatos = null)
        : base(Path.Combine(carpetaDatos ?? AlmacenamientoDatos.CarpetaDatos, "ordenes.json"))
    {
    }

    public override void Agregar(OrdenTrabajo entidad)
    {
        ArgumentNullException.ThrowIfNull(entidad);
        if (string.IsNullOrWhiteSpace(entidad.NumeroOrden))
        {
            entidad.NumeroOrden = GenerarSiguienteNumero();
        }
        base.Agregar(entidad);
    }

    public string GenerarSiguienteNumero()
    {
        if (Entidades.Count > 0)
        {
            _correlativo = Entidades.Count + 1;
        }
        return $"ORD-{_correlativo++:D5}";
    }

    public BindingList<OrdenTrabajo> ObtenerPorEstado(EstadoOrden estado)
    {
        var filtradas = Entidades.Where(o => o.Estado == estado).ToList();
        return new BindingList<OrdenTrabajo>(filtradas);
    }

    public BindingList<OrdenTrabajo> ObtenerPorVehiculo(string placa)
    {
        var filtradas = Entidades
            .Where(o => o.VehiculoPlaca.Equals(placa.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();
        return new BindingList<OrdenTrabajo>(filtradas);
    }
}