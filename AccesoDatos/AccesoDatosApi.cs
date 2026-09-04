using BaseDatos;
using BaseDatos.BDSPE;
using Entidades;

namespace AccesoDatos
{
    public class AccesoDatosApi: IAccesoDatosApi
    {
        private readonly BDDirecta bDDirecta;
        private readonly BaseDatosSPE baseDatosSPE;

        public AccesoDatosApi(BDDirectaContext context)
        {
            bDDirecta = new BDDirecta(context);
            baseDatosSPE = new BaseDatosSPE(context);
        }

        public Response AgregarExamen(RequestInsert request)
        {
            Response response = new Response();

            response = bDDirecta.AgregarExamen(request);

            return response;
        }
        public Response ActualizarExamen(RequestActualizar request)
        {
            Response response = new Response();

            response = bDDirecta.ActualizarExamen(request);

            return response;
        }
        public Response EliminarExamen(int Id)
        {
            Response response = new Response();

            response = bDDirecta.EliminarExamen(Id);

            return response;
        }
        public List<DatosBD> ConsultarExamen(RequestActualizar request)
        {
            List<DatosBD> response = new List<DatosBD>();

            response = bDDirecta.ConsultarExamen(request);

            return response;
        }

        public Response AgregarExamenSPE(RequestInsert request)
        {
            Response response = new Response();

            response = baseDatosSPE.AgregarExamen(request);

            return response;
        }
        public Response ActualizarExamenSPE(RequestActualizar request)
        {
            Response response = new Response();

            response = baseDatosSPE.ActualizarExamen(request);

            return response;
        }
        public Response EliminarExamenSPE(int Id)
        {
            Response response = new Response();

            response = baseDatosSPE.EliminarExamen(Id);

            return response;
        }
        public List<DatosBD> ConsultarExamenSPE(RequestActualizar request)
        {
            List<DatosBD> response = new List<DatosBD>();

            response = baseDatosSPE.ConsultarExamen(request);

            return response;
        }
    }
}
