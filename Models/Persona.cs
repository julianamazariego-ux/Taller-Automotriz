using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace TallerAutomotriz.Models;

public abstract class Persona : INotifyPropertyChanged
{
    private string _nombre = string.Empty;
    private string _dui = string.Empty;
    private string _telefono = string.Empty;
    private string _direccion = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    [JsonInclude, JsonRequired]
    public Guid Id { get; protected set; } = Guid.NewGuid();

    [JsonRequired]
    public string Nombre
    {
        get => _nombre;
        set
        {
            if (_nombre != value)
            {
                _nombre = value?.Trim() ?? string.Empty;
                OnPropertyChanged();
            }
        }
    }

    [JsonRequired]
    public string Dui
    {
        get => _dui;
        set
        {
            if (_dui != value)
            {
                _dui = value?.Trim() ?? string.Empty;
                OnPropertyChanged();
            }
        }
    }

    public string Telefono
    {
        get => _telefono;
        set
        {
            if (_telefono != value)
            {
                _telefono = value?.Trim() ?? string.Empty;
                OnPropertyChanged();
            }
        }
    }

    public string Direccion
    {
        get => _direccion;
        set
        {
            if (_direccion != value)
            {
                _direccion = value?.Trim() ?? string.Empty;
                OnPropertyChanged();
            }
        }
    }

    protected Persona() { }

    protected Persona(string nombre, string dui, string telefono, string direccion)
    {
        Id = Guid.NewGuid();
        Nombre = nombre;
        Dui = dui;
        Telefono = telefono;
        Direccion = direccion;
    }

    protected void OnPropertyChanged([CallerMemberName] string? propiedad = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
    }

    public override string ToString() => $"{Nombre} ({Dui})";
}