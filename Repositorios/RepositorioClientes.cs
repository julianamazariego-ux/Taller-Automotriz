using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using TallerAutomotriz.Models;

namespace TallerAutomotriz.Repositorios;

public class RepositorioClientes : RepositorioBase<Cliente>
{
    public RepositorioClientes(string? carpetaDatos = null)
        : base(Path.Combine(carpetaDatos ?? AlmacenamientoDatos.CarpetaDatos, "clientes.json"))
    {
    }

    public override void Agregar(Cliente entidad)
    {
        ValidarCliente(entidad);
        if (ExisteDui(entidad.Dui))
            throw new InvalidOperationException("Ya existe un cliente registrado con ese DUI.");

        base.Agregar(entidad);
    }

    public override void Actualizar(Cliente entidad)
    {
        ValidarCliente(entidad);
        if (ExisteDui(entidad.Dui, entidad))
            throw new InvalidOperationException("El DUI ingresado pertenece a otro cliente.");

        base.Actualizar(entidad);
    }

    public Cliente? ObtenerPorId(Guid id) => Obtener(c => c.Id == id);
    public bool ExisteDui(string dui, Cliente? clienteExcluir = null)
    {
        return Entidades.Any(c =>
            c != clienteExcluir &&
            c.Dui.Equals(dui.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public BindingList<Cliente> BuscarPorTexto(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return Entidades;

        var filtro = texto.Trim();
        var resultado = Entidades.Where(c =>
            c.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
            c.Dui.Contains(filtro, StringComparison.OrdinalIgnoreCase)).ToList();

        return new BindingList<Cliente>(resultado);
    }

    protected override void ValidarDatos(List<Cliente> datos)
    {
        foreach (var cliente in datos)
        {
            ValidarCliente(cliente);
        }
    }

    private static void ValidarCliente(Cliente cliente)
    {
        ArgumentNullException.ThrowIfNull(cliente);
        if (string.IsNullOrWhiteSpace(cliente.Nombre))
            throw new ArgumentException("El nombre del cliente es obligatorio.");
        if (string.IsNullOrWhiteSpace(cliente.Dui))
            throw new ArgumentException("El DUI del cliente es obligatorio.");
    }
}