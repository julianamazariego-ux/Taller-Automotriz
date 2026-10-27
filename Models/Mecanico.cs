using System;
using System.Text.Json.Serialization;

namespace TallerAutomotriz.Models;

public class Mecanico : Persona
{
    private EspecialidadMecanico _especialidad = EspecialidadMecanico.MecanicaGeneral;
    private decimal _tarifaHora = 15.00m;
    private bool _disponible = true;

    public EspecialidadMecanico Especialidad
    {
        get => _especialidad;
        set
        {
            if (_especialidad != value)
            {
                _especialidad = value;
                OnPropertyChanged();
            }
        }
    }

    public decimal TarifaHora
    {
        get => _tarifaHora;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "La tarifa por hora no puede ser negativa.");

            if (_tarifaHora != value)
            {
                _tarifaHora = value;
                OnPropertyChanged();
            }
        }
    }

    public bool Disponible
    {
        get => _disponible;
        set
        {
            if (_disponible != value)
            {
                _disponible = value;
                OnPropertyChanged();
            }
        }
    }

    [JsonConstructor]
    public Mecanico() { }

    public Mecanico(string nombre, string dui, string telefono, string direccion, EspecialidadMecanico especialidad, decimal tarifaHora)
        : base(nombre, dui, telefono, direccion)
    {
        Especialidad = especialidad;
        TarifaHora = tarifaHora;
        Disponible = true;
    }
}