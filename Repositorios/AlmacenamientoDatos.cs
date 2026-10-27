
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;

namespace TallerAutomotriz.Repositorios;

public static class AlmacenamientoDatos
{
    public static string CarpetaDatos =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "TallerAutomotrizApp", "Datos");
}