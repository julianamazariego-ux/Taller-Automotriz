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


    public int GenerarSiguienteFolio()
    {
        return Entidades.Select(o => o.Folio ?? 0).DefaultIfEmpty(0).Max() + 1;
    }


    public List<OrdenTrabajo> ObtenerPorFacturar()
    {
        return Entidades
            .Where(o => o.Estado == EstadoOrden.Finalizada)
            .OrderBy(o => o.FechaIngreso)
            .ToList();
    }

    public int Facturar(OrdenTrabajo orden)
    {
        ArgumentNullException.ThrowIfNull(orden);
        if (!Entidades.Contains(orden))
            throw new InvalidOperationException("La orden no pertenece al repositorio.");

        orden.Facturar(GenerarSiguienteFolio());
        Guardar();
        return orden.Folio!.Value;
    }

    public List<OrdenTrabajo> Buscar(string? texto, EstadoOrden? estado, DateTime? desde, DateTime? hasta)
    {
        string textoBuscado = (texto ?? string.Empty).Trim();

        return Entidades.Where(o =>
            (textoBuscado.Length == 0 ||
                o.NumeroOrden.Contains(textoBuscado, StringComparison.OrdinalIgnoreCase) ||
                o.VehiculoPlaca.Contains(textoBuscado, StringComparison.OrdinalIgnoreCase) ||
                (o.Vehiculo?.Cliente?.Nombre.Contains(textoBuscado, StringComparison.OrdinalIgnoreCase) ?? false)) &&
            (estado is null || o.Estado == estado) &&
            (desde is null || o.FechaIngreso.Date >= desde.Value.Date) &&
            (hasta is null || o.FechaIngreso.Date <= hasta.Value.Date))
            .OrderByDescending(o => o.FechaIngreso)
            .ToList();
    }

    public override void Eliminar(OrdenTrabajo entidad)
    {
        throw new InvalidOperationException(
            "Las órdenes de trabajo no se eliminan: permanecen en el historial. Si hace falta, cancele la orden.");
    }


    public List<OrdenTrabajo> ObtenerAbiertas()
    {
        return Entidades
            .Where(o => o.Estado == EstadoOrden.Pendiente || o.Estado == EstadoOrden.EnProceso)
            .OrderBy(o => o.FechaIngreso)
            .ToList();
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