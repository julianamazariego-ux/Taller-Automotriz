using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace TallerAutomotriz.Models;

public class OrdenTrabajo : INotifyPropertyChanged
{
    private EstadoOrden _estado = EstadoOrden.Pendiente;
    private string _diagnostico = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    [JsonRequired]
    public string NumeroOrden { get; set; } = string.Empty;

    public DateTime FechaIngreso { get; set; } = DateTime.Now;
    public DateTime? FechaEntrega { get; set; }

    [JsonInclude, JsonRequired]
    public string VehiculoPlaca { get; private set; } = string.Empty;

    [JsonIgnore]
    public Vehiculo? Vehiculo { get; private set; }

    [JsonInclude, JsonRequired]
    public Guid MecanicoId { get; private set; }

    [JsonIgnore]
    public Mecanico? Mecanico { get; private set; }

    public string Diagnostico
    {
        get => _diagnostico;
        set
        {
            if (_diagnostico != value)
            {
                _diagnostico = value?.Trim() ?? string.Empty;
                OnPropertyChanged();
            }
        }
    }

    public EstadoOrden Estado
    {
        get => _estado;
        set
        {
            if (_estado != value)
            {
                _estado = value;
                OnPropertyChanged();
            }
        }
    }

    [JsonInclude]
    public List<Servicio> Servicios { get; private set; } = new();

    [JsonInclude]
    public List<RepuestoItem> Repuestos { get; private set; } = new();

    public decimal TotalServicios => Servicios.Sum(s => s.CostoManoObra);
    public decimal TotalRepuestos => Repuestos.Sum(r => r.Subtotal);
    public decimal Total => TotalServicios + TotalRepuestos;

    [JsonConstructor]
    public OrdenTrabajo() { }

    public OrdenTrabajo(string numeroOrden, Vehiculo vehiculo, Mecanico mecanico, string diagnostico)
    {
        ArgumentNullException.ThrowIfNull(vehiculo);
        ArgumentNullException.ThrowIfNull(mecanico);

        NumeroOrden = numeroOrden;
        Vehiculo = vehiculo;
        VehiculoPlaca = vehiculo.Placa;
        Mecanico = mecanico;
        MecanicoId = mecanico.Id;
        Diagnostico = diagnostico;
        FechaIngreso = DateTime.Now;
        Estado = EstadoOrden.Pendiente;
    }

    public void AgregarServicio(string descripcion, decimal costoManoObra)
    {
        if (Estado == EstadoOrden.Cancelada || Estado == EstadoOrden.Entregada)
            throw new InvalidOperationException("No se pueden agregar servicios a una orden cerrada.");

        Servicios.Add(new Servicio(descripcion, costoManoObra));
        OnPropertyChanged(nameof(TotalServicios));
        OnPropertyChanged(nameof(Total));
    }

    public void AgregarRepuesto(string nombreRepuesto, int cantidad, decimal precioUnitario)
    {
        if (Estado == EstadoOrden.Cancelada || Estado == EstadoOrden.Entregada)
            throw new InvalidOperationException("No se pueden agregar repuestos a una orden cerrada.");

        Repuestos.Add(new RepuestoItem(nombreRepuesto, cantidad, precioUnitario));
        OnPropertyChanged(nameof(TotalRepuestos));
        OnPropertyChanged(nameof(Total));
    }

    public void IniciarTrabajo()
    {
        if (Estado == EstadoOrden.Pendiente)
            Estado = EstadoOrden.EnProceso;
    }

    public void FinalizarOrden()
    {
        if (Estado == EstadoOrden.EnProceso || Estado == EstadoOrden.Pendiente)
        {
            Estado = EstadoOrden.Finalizada;
            FechaEntrega = DateTime.Now;
        }
    }

    public void CancelarOrden()
    {
        if (Estado != EstadoOrden.Entregada)
            Estado = EstadoOrden.Cancelada;
    }

    protected void OnPropertyChanged([CallerMemberName] string? propiedad = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
    }
}