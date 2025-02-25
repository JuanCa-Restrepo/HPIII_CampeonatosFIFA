using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampeonatoFIFA.Core.Repositorios;
using CampeonatosFIFA.Dominio.Entidades;
using CampeonatosFIFA.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Infraestructura.Repositorios
{
    public class SeleccionRepositorio : ISeleccionRepositorio
    {

        //
        private readonly CampeonatosFIFAContext _context;

        // Es un atributo que voy a inyectar en el constructor
        public SeleccionRepositorio(CampeonatosFIFAContext context)
        { this._context = context;
        }

        public Task<Seleccion> Agregar(Seleccion seleccion)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Seleccion>> Buscar(int Tipo, string Dato)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Seleccion> Modificar(Seleccion seleccion)
        {
            throw new NotImplementedException();
        }

        public async Task<Seleccion> Obtener(int id)
        {
            return await _context.Seleciones.FindAsync(id);
        }

        // esta parte va a ser asincronica por eso se usa el async y el await, no habria un async si no 
        // hay una intruccion de secuencia
        public async Task<IEnumerable<Seleccion>> ObtenerTodos()
        {
            return await _context.Seleciones.ToArrayAsync() ;
        }
    }
}
