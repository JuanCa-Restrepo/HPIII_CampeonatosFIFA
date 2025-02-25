using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatoFIFA.Core.Repositorios
{
    public interface ICampeonatoRepositorio
    {
        //TAREA QUE ME DEVUEKVA LA lista los registros, esto se maneajra con asincronicidad
        Task<IEnumerable<Campeonato>> ObtenerTodos();

        // TAREA QUE ME DEVUELVE UN OBJETO SELECCON
        Task<Campeonato> Obtener(int id);// read

        //TAREA QUE AGREGE UN OBJETO Campeonato
        Task<Campeonato> Agregar(Campeonato Campeonato);// create

        // TAREA QUE ACTUALIZA UN OBJETO Campeonato
        Task<Campeonato> Modificar(Campeonato Campeonato);// update

        // TAREA QUE ELIMINA UN OBJETO Campeonato
        Task<bool> Eliminar(int id); // delete

        // TAREA QUE ME PERMITE BUSCAR UNA Campeonato POR NOMBRE
        Task<IEnumerable<Campeonato>> Buscar(int Tipo, string Dato);
        //


    }
}
