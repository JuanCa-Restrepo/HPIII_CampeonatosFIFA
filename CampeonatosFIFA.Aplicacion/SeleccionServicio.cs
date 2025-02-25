using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampeonatoFIFA.Core.Repositorios;
using CampeonatoFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.Aplicacion
{
    internal class SeleccionServicio : ISeleccionServicio

    {
        public readonly ISeleccionRepositorio repositorio;
        public SeleccionServicio(ISeleccionRepositorio repositorio)
        {
            this.repositorio = repositorio;
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
            return await repositorio.Obtener(id);
        }

        public async Task<IEnumerable<Seleccion>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
    }
}
