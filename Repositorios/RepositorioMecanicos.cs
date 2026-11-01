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
        ValidarUnicidad(entidad);

        base.Agregar(entidad);
    }

    public override void Actualizar(Mecanico entidad)
    {
        ValidarMecanico(entidad);
        ValidarUnicidad(entidad);

        base.Actualizar(entidad);
    }

    public Mecanico? ObtenerPorId(Guid id) => Obtener(m => m.Id == id);

    public bool ExisteMecanico(string nombre, EspecialidadMecanico especialidad, string telefono, Mecanico? mecanicoExcluir = null)
    {
        return Entidades.Any(m =>
            m != mecanicoExcluir &&
            m.Especialidad == especialidad &&
            m.Telefono.Equals(telefono.Trim(), StringComparison.OrdinalIgnoreCase) &&
            m.Nombre.Equals(nombre.Trim(), StringComparison.OrdinalIgnoreCase));
    }


    public bool ExisteDui(string dui, Mecanico? mecanicoExcluir = null)
    {
        if (string.IsNullOrWhiteSpace(dui))
            return false;

        return Entidades.Any(m =>
            m != mecanicoExcluir &&
            m.Dui.Equals(dui.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public List<Mecanico> Buscar(string? nombre, EspecialidadMecanico? especialidad)
    {
        string nombreBuscado = (nombre ?? string.Empty).Trim();

        return Entidades.Where(m =>
            (nombreBuscado.Length == 0 ||
                m.Nombre.Contains(nombreBuscado, StringComparison.OrdinalIgnoreCase)) &&
            (especialidad is null || m.Especialidad == especialidad)).ToList();
    }

    public List<Mecanico> ObtenerDisponibles()
    {
        return Entidades.Where(m => m.Disponible).ToList();
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

    private void ValidarUnicidad(Mecanico mecanico)
    {
        if (ExisteMecanico(mecanico.Nombre, mecanico.Especialidad, mecanico.Telefono, mecanico))
            throw new InvalidOperationException("Ya existe un mecánico con el mismo nombre, especialidad y teléfono.");

        if (ExisteDui(mecanico.Dui, mecanico))
            throw new InvalidOperationException("El DUI ingresado pertenece a otro mecánico.");
    }

    private static void ValidarMecanico(Mecanico mecanico)
    {
        ArgumentNullException.ThrowIfNull(mecanico);
        if (string.IsNullOrWhiteSpace(mecanico.Nombre))
            throw new ArgumentException("El nombre del mecánico es obligatorio.");
    }
}