using System;
using System.Text.Json.Serialization;

namespace TallerAutomotriz.Models;

public class Cliente : Persona
{
    private string _correo = string.Empty;

    public string Correo
    {
        get => _correo;
        set
        {
            if (_correo != value)
            {
                _correo = value?.Trim() ?? string.Empty;
                OnPropertyChanged();
            }
        }
    }

    public DateTime FechaRegistro { get; set; } = DateTime.Today;

    [JsonConstructor]
    public Cliente() { }

    public Cliente(string nombre, string dui, string telefono, string direccion, string correo)
        : base(nombre, dui, telefono, direccion)
    {
        Correo = correo;
        FechaRegistro = DateTime.Today;
    }
}
