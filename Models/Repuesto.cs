using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace TallerAutomotriz.Models;


public class Repuesto : INotifyPropertyChanged
{
    private string _nombre = string.Empty;
    private decimal _precio;
    private CategoriaRepuesto _categoria = CategoriaRepuesto.Varias;
    private int _cantidadDisponible;

    public event PropertyChangedEventHandler? PropertyChanged;

    [JsonInclude]
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Nombre
    {
        get => _nombre;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre del repuesto es obligatorio.", nameof(value));

            var limpio = value.Trim();
            if (_nombre != limpio)
            {
                _nombre = limpio;
                OnPropertyChanged();
            }
        }
    }

    public decimal Precio
    {
        get => _precio;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "El precio no puede ser negativo.");

            if (_precio != value)
            {
                _precio = value;
                OnPropertyChanged();
            }
        }
    }

    public CategoriaRepuesto Categoria
    {
        get => _categoria;
        set
        {
            if (_categoria != value)
            {
                _categoria = value;
                OnPropertyChanged();
            }
        }
    }

    public int CantidadDisponible
    {
        get => _cantidadDisponible;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "La cantidad disponible no puede ser negativa.");

            if (_cantidadDisponible != value)
            {
                _cantidadDisponible = value;
                OnPropertyChanged();
            }
        }
    }

    [JsonConstructor]
    public Repuesto() { }

    public Repuesto(string nombre, decimal precio, CategoriaRepuesto categoria, int cantidadDisponible)
    {
        Nombre = nombre;
        Precio = precio;
        Categoria = categoria;
        CantidadDisponible = cantidadDisponible;
    }

    public bool HayExistencia(int cantidad) => cantidad > 0 && CantidadDisponible >= cantidad;

    public void DescontarExistencia(int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad debe ser mayor a cero.");
        if (cantidad > CantidadDisponible)
            throw new InvalidOperationException($"Existencia insuficiente de '{Nombre}'. Disponible: {CantidadDisponible}.");

        CantidadDisponible -= cantidad;
    }

    public void Reponer(int cantidad)
    {
        if (cantidad <= 0)
            throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad debe ser mayor a cero.");

        CantidadDisponible += cantidad;
    }

    protected void OnPropertyChanged([CallerMemberName] string? propiedad = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
    }

    public override string ToString() => $"{Nombre} ({Categoria}) - ${Precio:F2}";
}