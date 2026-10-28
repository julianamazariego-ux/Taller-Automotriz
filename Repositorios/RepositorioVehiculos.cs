using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using TallerAutomotriz.Models;

namespace TallerAutomotriz.Repositorios;

public class RepositorioVehiculos : RepositorioBase<Vehiculo>
{
    private readonly RepositorioClientes _repositorioClientes;

    public RepositorioVehiculos(RepositorioClientes repositorioClientes, string? carpetaDatos = null)
        : base(Path.Combine(carpetaDatos ?? AlmacenamientoDatos.CarpetaDatos, "vehiculos.json"))
    {
        ArgumentNullException.ThrowIfNull(repositorioClientes);
        _repositorioClientes = repositorioClientes;
    }

    public override void Leer()
    {
        base.Leer();
        ResolverRelaciones();
    }

    public int ResolverRelaciones()
    {
        int sinCliente = 0;
        foreach (var vehiculo in Entidades)
        {
            var cliente = _repositorioClientes.ObtenerPorId(vehiculo.ClienteId);
            if (cliente is null)
                sinCliente++;
            else
                vehiculo.AsignarCliente(cliente);
        }
        return sinCliente;
    }

    public override void Agregar(Vehiculo entidad)
    {
        ValidarVehiculo(entidad);
        if (ExistePlaca(entidad.Placa))
            throw new InvalidOperationException("Ya existe un vehículo registrado con esa placa.");

        base.Agregar(entidad);
    }

    public bool ExistePlaca(string placa, Vehiculo? vehiculoExcluir = null)
    {
        return Entidades.Any(v =>
            v != vehiculoExcluir &&
            v.Placa.Equals(placa.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public Vehiculo? BuscarPorPlaca(string placa)
    {
        return Obtener(v => v.Placa.Equals(placa.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public BindingList<Vehiculo> ObtenerPorCliente(Guid clienteId)
    {
        var lista = Entidades.Where(v => v.ClienteId == clienteId).ToList();
        return new BindingList<Vehiculo>(lista);
    }

    protected override void ValidarDatos(List<Vehiculo> datos)
    {
        foreach (var vehiculo in datos)
        {
            ValidarVehiculo(vehiculo);
        }
    }

    private static void ValidarVehiculo(Vehiculo vehiculo)
    {
        ArgumentNullException.ThrowIfNull(vehiculo);
        if (string.IsNullOrWhiteSpace(vehiculo.Placa))
            throw new ArgumentException("La placa del vehículo es obligatoria.");
    }
}