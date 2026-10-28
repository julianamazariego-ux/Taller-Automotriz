using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using TallerAutomotriz.Models;

namespace TallerAutomotriz.Repositorios;

public class RepositorioRepuestos : RepositorioBase<Repuesto>
{
    public RepositorioRepuestos(string? carpetaDatos = null)
        : base(Path.Combine(carpetaDatos ?? AlmacenamientoDatos.CarpetaDatos, "repuestos.json"))
    {
    }

    public override void Agregar(Repuesto entidad)
    {
        ValidarRepuesto(entidad);
        if (ExisteNombre(entidad.Nombre))
            throw new InvalidOperationException("Ya existe un repuesto con ese nombre.");

        base.Agregar(entidad);
    }

    public override void Actualizar(Repuesto entidad)
    {
        ValidarRepuesto(entidad);
        if (ExisteNombre(entidad.Nombre, entidad))
            throw new InvalidOperationException("El nombre ingresado pertenece a otro repuesto.");

        base.Actualizar(entidad);
    }

    public Repuesto? ObtenerPorId(Guid id) => Obtener(r => r.Id == id);

    public Repuesto? BuscarPorNombre(string nombre)
    {
        return Obtener(r => r.Nombre.Equals(nombre.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public bool ExisteNombre(string nombre, Repuesto? repuestoExcluir = null)
    {
        return Entidades.Any(r =>
            r != repuestoExcluir &&
            r.Nombre.Equals(nombre.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public BindingList<Repuesto> ObtenerPorCategoria(CategoriaRepuesto categoria)
    {
        var lista = Entidades.Where(r => r.Categoria == categoria).ToList();
        return new BindingList<Repuesto>(lista);
    }

    public BindingList<Repuesto> ObtenerConExistenciaBaja(int minimo = 5)
    {
        var lista = Entidades
            .Where(r => r.CantidadDisponible <= minimo)
            .OrderBy(r => r.CantidadDisponible)
            .ToList();
        return new BindingList<Repuesto>(lista);
    }

   
    public void DescontarExistencia(Guid id, int cantidad)
    {
        var repuesto = ObtenerPorId(id)
            ?? throw new InvalidOperationException("El repuesto indicado no existe.");

        repuesto.DescontarExistencia(cantidad);
        Guardar();
    }

    protected override void ValidarDatos(List<Repuesto> datos)
    {
        foreach (var repuesto in datos)
        {
            ValidarRepuesto(repuesto);
        }
    }

    private static void ValidarRepuesto(Repuesto repuesto)
    {
        ArgumentNullException.ThrowIfNull(repuesto);
        if (string.IsNullOrWhiteSpace(repuesto.Nombre))
            throw new ArgumentException("El nombre del repuesto es obligatorio.");
    }
}