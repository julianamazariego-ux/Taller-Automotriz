using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using TallerAutomotriz.Models;

namespace TallerAutomotriz.Repositorios;

public class RepositorioOrdenes : RepositorioBase<OrdenTrabajo>
{
    private readonly RepositorioVehiculos _repositorioVehiculos;
    private readonly RepositorioMecanicos _repositorioMecanicos;
    

    public RepositorioOrdenes(RepositorioVehiculos repositorioVehiculos,
                              RepositorioMecanicos repositorioMecanicos,
                              string? carpetaDatos = null)
        : base(Path.Combine(carpetaDatos ?? AlmacenamientoDatos.CarpetaDatos, "ordenes.json"))
    {
        ArgumentNullException.ThrowIfNull(repositorioVehiculos);
        ArgumentNullException.ThrowIfNull(repositorioMecanicos);
        _repositorioVehiculos = repositorioVehiculos;
        _repositorioMecanicos = repositorioMecanicos;
    }

    public override void Leer()
    {
        base.Leer();
        ResolverRelaciones();
    }


    public int ResolverRelaciones()
    {
        int incompletas = 0;
        foreach (var orden in Entidades)
        {
            var vehiculo = _repositorioVehiculos.BuscarPorPlaca(orden.VehiculoPlaca);
            var mecanico = _repositorioMecanicos.ObtenerPorId(orden.MecanicoId);

            if (vehiculo is not null) orden.AsignarVehiculo(vehiculo);
            if (mecanico is not null) orden.AsignarMecanico(mecanico);
            if (vehiculo is null || mecanico is null) incompletas++;
        }
        return incompletas;
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

    public OrdenTrabajo? ObtenerPorNumero(string numeroOrden)
    {
        return Obtener(o => o.NumeroOrden.Equals(numeroOrden.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public string GenerarSiguienteNumero()
    {
        int maximo = Entidades
            .Select(o => o.NumeroOrden)
            .Where(n => n.StartsWith("ORD-", StringComparison.OrdinalIgnoreCase)
                        && int.TryParse(n.AsSpan(4), out _))
            .Select(n => int.Parse(n.AsSpan(4)))
            .DefaultIfEmpty(0)
            .Max();

        return $"ORD-{maximo + 1:D5}";
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