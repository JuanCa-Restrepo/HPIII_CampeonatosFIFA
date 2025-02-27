using CampeonatoFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatosFIFA.Presentacion.Controllers
{
    [ApiController]
    [Route("api/Selecciones")]
    public class SeleccionCOntrolador : Controller   {

       

        private readonly ISeleccionServicio servicio;

        public SeleccionCOntrolador(ISeleccionServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("Listar")]
        public async Task<IEnumerable<Seleccion>> ObtenerTodos()
        {
            return await servicio.ObtenerTodos();
        }

    }
}
