using AccesoDatos;
using Entidades;

namespace Negocio
{
    public class NegocioApi : INegocioApi
    {
        private readonly IAccesoDatosApi AccesoDatos;


        public NegocioApi(IAccesoDatosApi accesoDatos)
        {
            AccesoDatos = accesoDatos;
        }
        public Response AgregarExamen(RequestInsert request)
        {
            Response response = new Response();

            response = AccesoDatos.AgregarExamen(request);

            return response;
        }
        public Response ActualizarExamen(RequestActualizar request)
        {
            Response response = new Response();

            response = AccesoDatos.ActualizarExamen(request);

            return response;
        }
        public Response EliminarExamen(int Id)
        {
            Response response = new Response();

            response = AccesoDatos.EliminarExamen(Id);

            return response;
        }
        public List<DatosBD> ConsultarExamen(RequestActualizar request)
        {
            List<DatosBD> response = new List<DatosBD>();

            response = AccesoDatos.ConsultarExamen(request);

            return response;
        }
    }
}
