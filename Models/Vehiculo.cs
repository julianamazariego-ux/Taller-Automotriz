using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace TallerAutomotriz.Models;

public class Vehiculo : INotifyPropertyChanged
{
    private string _placa = string.Empty;
    private MarcaVehiculo _marca = MarcaVehiculo.Toyota;
    private string _modelo = string.Empty;
    private int _anio = DateTime.Today.Year;
    private string _color = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    [JsonRequired]
    public string Placa
    {
        get => _placa;
        set
        {
            if (_placa != value)
            {
                _placa = value?.Trim().ToUpperInvariant() ?? string.Empty;
                OnPropertyChanged();
            }
        }
    }

    public MarcaVehiculo Marca
    {
        get => _marca;
        set
        {
            if (_marca != value)
            {
                _marca = value;
                OnPropertyChanged();
            }
        }
    }

    [JsonRequired]
    public string Modelo
    {
        get => _modelo;
        set
        {
            if (_modelo != value)
            {
                _modelo = value?.Trim() ?? string.Empty;
                OnPropertyChanged();
            }
        }
    }

    public int Anio
    {
        get => _anio;
        set
        {
            if (_anio != value)
            {
                _anio = value;
                OnPropertyChanged();
            }
        }
    }

    public string Color
    {
        get => _color;
        set
        {
            if (_color != value)
            {
                _color = value?.Trim() ?? string.Empty;
                OnPropertyChanged();
            }
        }
    }

    [JsonInclude, JsonRequired]
    public Guid ClienteId { get; private set; }

    [JsonIgnore]
    public Cliente? Cliente { get; private set; }

    [JsonConstructor]
    public Vehiculo() { }

    public Vehiculo(string placa, MarcaVehiculo marca, string modelo, int anio, string color, Cliente cliente)
    {
        ArgumentNullException.ThrowIfNull(cliente);
        Placa = placa;
        Marca = marca;
        Modelo = modelo;
        Anio = anio;
        Color = color;
        AsignarCliente(cliente);
    }

    public void AsignarCliente(Cliente cliente)
    {
        ArgumentNullException.ThrowIfNull(cliente);
        Cliente = cliente;
        ClienteId = cliente.Id;
    }

    protected void OnPropertyChanged([CallerMemberName] string? propiedad = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
    }

    public override string ToString() => $"{Placa} - {Marca} {Modelo} ({Anio})";
}