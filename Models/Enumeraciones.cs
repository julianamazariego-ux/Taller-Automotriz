namespace TallerAutomotriz.Models;

public enum MarcaVehiculo
{
    Toyota,
    Nissan,
    Honda,
    Hyundai,
    Kia,
    Mazda,
    Ford,
    Chevrolet,
    Mitsubishi,
    Otra
}

public enum EspecialidadMecanico
{
    MecanicaGeneral,
    MotorYTransmision,
    SistemaElectrico,
    FrenosYSuspension,
    AireAcondicionado,
    DiagnosticoElectronico
}

public enum EstadoOrden
{
    Pendiente,
    EnProceso,
    Finalizada,
    Entregada,
    Cancelada
}