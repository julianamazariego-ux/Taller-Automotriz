using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using TallerAutomotriz.Models;

namespace TallerAutomotriz.Repositorios;

public class RepositorioMecanicos : RepositorioBase<Mecanico>
{
    public RepositorioMecanicos(string? carpetaDatos = null)
        : base(Path.Combine(carpetaDatos ?? AlmacenamientoDatos.CarpetaDatos, "mecanicos.json"))
    {
    }

    public override void Agregar(Mecanico entidad)
    {
        ValidarMecanico(entidad);
        if (ExisteDui(entidad.Dui))
            throw new InvalidOperationException("Ya existe un mecánico con ese DUI.");

        base.Agregar(entidad);
    }

    public Mecanico? ObtenerPorId(Guid id) => Obtener(m => m.Id == id);

    public override void Actualizar(Mecanico entidad)
    {
        ValidarMecanico(entidad);
        if (ExisteDui(entidad.Dui, entidad))
            throw new InvalidOperationException("El DUI ingresado pertenece a otro mecánico.");

        base.Actualizar(entidad);
    }

    public bool ExisteDui(string dui, Mecanico? mecanicoExcluir = null)
    {
        return Entidades.Any(m =>
            m != mecanicoExcluir &&
            m.Dui.Equals(dui.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public BindingList<Mecanico> ObtenerDisponiblesPorEspecialidad(EspecialidadMecanico especialidad)
    {
        var disponibles = Entidades
            .Where(m => m.Disponible && m.Especialidad == especialidad)
            .ToList();

        return new BindingList<Mecanico>(disponibles);
    }

    protected override void ValidarDatos(List<Mecanico> datos)
    {
        foreach (var mecanico in datos)
        {
            ValidarMecanico(mecanico);
        }
    }

    private static void ValidarMecanico(Mecanico mecanico)
    {
        ArgumentNullException.ThrowIfNull(mecanico);
        if (string.IsNullOrWhiteSpace(mecanico.Nombre))
            throw new ArgumentException("El nombre del mecánico es obligatorio.");
    }
}
