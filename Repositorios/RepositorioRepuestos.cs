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

    public bool CargarCatalogoInicial()
    {
        if (Entidades.Count > 0)
            return false;

        var catalogo = new[]
        {
            new Repuesto("Filtro de aceite", 45.00m, CategoriaRepuesto.Filtros, 15),
            new Repuesto("Pastillas de freno", 80.00m, CategoriaRepuesto.Pastillas, 8),
            new Repuesto("Aceite Premium 5W-30", 35.00m, CategoriaRepuesto.Varias, 20),
            new Repuesto("Batería 60 Amper", 120.00m, CategoriaRepuesto.Electrico, 5),
            new Repuesto("Bujías NGK", 15.00m, CategoriaRepuesto.Bujias, 40),
            new Repuesto("Correa de distribución", 85.00m, CategoriaRepuesto.Varias, 4),
            new Repuesto("Mangueras radiador", 25.00m, CategoriaRepuesto.Mangueras, 12),
            new Repuesto("Termostato", 40.00m, CategoriaRepuesto.Sensores, 6),
            new Repuesto("Válvula solenoide", 60.00m, CategoriaRepuesto.Sensores, 7),
            new Repuesto("Filtro combustible", 20.00m, CategoriaRepuesto.Filtros, 10),
            new Repuesto("Sensor oxígeno", 75.00m, CategoriaRepuesto.Sensores, 3),
            new Repuesto("Pastillas freno traseras", 65.00m, CategoriaRepuesto.Pastillas, 9),
            new Repuesto("Discos de freno", 95.00m, CategoriaRepuesto.Pastillas, 6),
            new Repuesto("Bomba agua", 110.00m, CategoriaRepuesto.Varias, 2),
            new Repuesto("Alternador", 180.00m, CategoriaRepuesto.Electrico, 2)
        };

        foreach (var repuesto in catalogo)
        {
            Entidades.Add(repuesto);
        }

        Guardar();
        return true;
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