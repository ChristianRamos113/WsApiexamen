using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public interface IAccesoDatosApi
    {
        public Response AgregarExamen(RequestInsert request);
        public Response ActualizarExamen(RequestActualizar request);
        public Response EliminarExamen(int Id);
        public List<DatosBD> ConsultarExamen(RequestActualizar request);
        public Response AgregarExamenSPE(RequestInsert request);
        public Response ActualizarExamenSPE(RequestActualizar request);
        public Response EliminarExamenSPE(int Id);
        public List<DatosBD> ConsultarExamenSPE(RequestActualizar request);
    }
}
