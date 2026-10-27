using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TallerAutomotriz.Repositorios;

public abstract class RepositorioBase<T> : IRepositorio<T> where T : class
{
    protected BindingList<T> Entidades { get; } = new();
    public string RutaArchivo { get; }

    private readonly JsonSerializerOptions _opciones = new()
    {
        WriteIndented = true
    };

    protected RepositorioBase(string rutaArchivo)
    {
        RutaArchivo = rutaArchivo;
    }

    public virtual void Agregar(T entidad)
    {
        ArgumentNullException.ThrowIfNull(entidad);
        Entidades.Add(entidad);
        Guardar();
    }

    public virtual void Actualizar(T entidad)
    {
        ArgumentNullException.ThrowIfNull(entidad);
        Guardar();
    }

    public virtual void Eliminar(T entidad)
    {
        ArgumentNullException.ThrowIfNull(entidad);
        if (Entidades.Remove(entidad))
        {
            Guardar();
        }
    }

    public BindingList<T> ObtenerTodos() => Entidades;

    public void Guardar() => GuardarLista(Entidades.ToList());

    public void Leer()
    {
        try
        {
            if (!File.Exists(RutaArchivo))
            {
                Entidades.Clear();
                return;
            }

            string json = File.ReadAllText(RutaArchivo);
            if (string.IsNullOrWhiteSpace(json))
            {
                Entidades.Clear();
                return;
            }

            var datos = JsonSerializer.Deserialize<List<T>>(json, _opciones) ?? new List<T>();
            ValidarDatos(datos);

            Entidades.Clear();
            foreach (var item in datos)
            {
                Entidades.Add(item);
            }
        }
        catch (Exception ex)
        {
            throw new IOException($"Error al leer el archivo JSON en '{RutaArchivo}': {ex.Message}", ex);
        }
    }

    protected virtual void ValidarDatos(List<T> datos)
    {
    }

    private void GuardarLista(List<T> datos)
    {
        string? directorio = Path.GetDirectoryName(RutaArchivo);
        if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
        {
            Directory.CreateDirectory(directorio);
        }

        string archivoTemporal = $"{RutaArchivo}.tmp";

        try
        {
            string json = JsonSerializer.Serialize(datos, _opciones);
            File.WriteAllText(archivoTemporal, json);

            if (File.Exists(RutaArchivo))
            {
                File.Replace(archivoTemporal, RutaArchivo, null);
            }
            else
            {
                File.Move(archivoTemporal, RutaArchivo);
            }
        }
        catch (Exception ex)
        {
            if (File.Exists(archivoTemporal))
            {
                File.Delete(archivoTemporal);
            }
            throw new IOException($"Error al guardar el archivo JSON en '{RutaArchivo}': {ex.Message}", ex);
        }
    }
}