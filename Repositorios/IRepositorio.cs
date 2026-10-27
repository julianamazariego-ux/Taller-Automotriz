using System;
using System.Collections.Generic;

using System.Text;
using System.ComponentModel;

namespace TallerAutomotriz.Repositorios;

public interface IRepositorio<T> where T : class
{
    void Agregar(T entidad);
    void Actualizar(T entidad);
    void Eliminar(T entidad);
    BindingList<T> ObtenerTodos();
    void Guardar();
    void Leer();
}