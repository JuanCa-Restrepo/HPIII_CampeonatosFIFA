using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatoFIFA.Core.Servicios
{
    public interface ISeleccionServicio
    {
        //TAREA QUE ME DEVUEKVA LA lista los paises, esto se maneajra con asincronicidad
        Task<IEnumerable<Seleccion>> ObtenerTodos();

        // TAREA QUE ME DEVUELVE UN OBJETO SELECCON
        Task<Seleccion> Obtener(int id);// read

        //TAREA QUE AGREGE UN OBJETO SELECCION
        Task<Seleccion> Agregar(Seleccion seleccion);// create

        // TAREA QUE ACTUALIZA UN OBJETO SELECCION
        Task<Seleccion> Modificar(Seleccion seleccion);// update

        // TAREA QUE ELIMINA UN OBJETO SELECCION
        Task<bool> Eliminar(int id); // delete

        // TAREA QUE ME PERMITE BUSCAR UNA SELECCION POR NOMBRE
        Task<IEnumerable<Seleccion>> Buscar(int Tipo, string Dato);
        /
    }
}
