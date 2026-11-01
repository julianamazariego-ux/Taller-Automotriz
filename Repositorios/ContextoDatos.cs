using System;
using System.Collections.Generic;
using System.IO;

namespace TallerAutomotriz.Repositorios;

public static class ContextoDatos
{
    public static RepositorioClientes Clientes { get; private set; } = null!;
    public static RepositorioMecanicos Mecanicos { get; private set; } = null!;
    public static RepositorioVehiculos Vehiculos { get; private set; } = null!;
    public static RepositorioOrdenes Ordenes { get; private set; } = null!;
    public static RepositorioRepuestos Repuestos { get; private set; } = null!;

    public static bool Inicializado { get; private set; }

    public static IReadOnlyList<string> Inicializar(string? carpetaDatos = null)
    {
        var avisos = new List<string>();
        if (Inicializado) return avisos;

        Clientes = new RepositorioClientes(carpetaDatos);
        Mecanicos = new RepositorioMecanicos(carpetaDatos);
        Vehiculos = new RepositorioVehiculos(Clientes, carpetaDatos);
        Ordenes = new RepositorioOrdenes(Vehiculos, Mecanicos, carpetaDatos);
        Repuestos = new RepositorioRepuestos(carpetaDatos);

        bool repuestosPrimeraVez = !File.Exists(Repuestos.RutaArchivo);

        LeerSeguro(Clientes, avisos);
        LeerSeguro(Mecanicos, avisos);
        LeerSeguro(Vehiculos, avisos);
        LeerSeguro(Ordenes, avisos);
        LeerSeguro(Repuestos, avisos);


        if (repuestosPrimeraVez)
        {
            try
            {
                Repuestos.CargarCatalogoInicial();
            }
            catch (IOException ex)
            {
                avisos.Add($"No se pudo guardar el catálogo inicial de repuestos: {ex.Message}");
            }
        }

        Inicializado = true;
        return avisos;
    }

    private static void LeerSeguro<T>(RepositorioBase<T> repositorio, List<string> avisos) where T : class
    {
        try
        {
            repositorio.Leer();
        }
        catch (IOException ex)
        {
            string respaldo = $"{repositorio.RutaArchivo}.danado-{DateTime.Now:yyyyMMdd-HHmmss}";
            try
            {
                if (File.Exists(repositorio.RutaArchivo))
                    File.Move(repositorio.RutaArchivo, respaldo);
            }
            catch (IOException)
            {
            }

            avisos.Add($"No se pudo leer '{Path.GetFileName(repositorio.RutaArchivo)}'. " +
                       $"Se conservó una copia como '{Path.GetFileName(respaldo)}' y se inició vacío.\n" +
                       $"Detalle: {ex.InnerException?.Message ?? ex.Message}");
        }
    }
}