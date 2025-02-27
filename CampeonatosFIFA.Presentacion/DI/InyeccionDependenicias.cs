using CampeonatosFIFA.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Presentacion.DI
{
    public static class InyeccionDependenicias
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection services,IConfiguration configuration)
        {
            //agregar la instancia del DbContext

            services.AddDbContext<CampeonatosFIFAContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CampeonatosFIFAContext"));
            });
            return services;
        }
}
