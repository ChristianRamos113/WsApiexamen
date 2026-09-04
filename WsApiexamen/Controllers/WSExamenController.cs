using Entidades;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace WsApiexamen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WSExamenController : ControllerBase
    {
        private readonly INegocioApi Negocio;


        public WSExamenController(INegocioApi negocio)
        {
            Negocio = negocio;
        }

        [Route("AgregarExamen")]
        [HttpPost]
        public Response AgregarExamen(RequestInsert request)
        {
            Response response = new Response();

            response = Negocio.AgregarExamen(request);

            return response;
        }

        [Route("ActualizarExamen")]
        [HttpPost]
        public Response ActualizarExamen(RequestActualizar request)
        {
            Response response = new Response();

            response = Negocio.ActualizarExamen(request);

            return response;
        }

        [Route("EliminarExamen")]
        [HttpPost]
        public Response EliminarExamen(int Id)
        {
            Response response = new Response();

            response = Negocio.EliminarExamen(Id);

            return response;
        }

        [Route("ConsultarExamen")]
        [HttpPost]
        public List<DatosBD> ConsultarExamen(RequestActualizar request)
        {
            List<DatosBD> response = new List<DatosBD>();

            response = Negocio.ConsultarExamen(request);

            return response;
        }
    }
}
