using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public interface INegocioApi
    {
        public Response AgregarExamen(RequestInsert request);
        public Response ActualizarExamen(RequestActualizar request);
        public Response EliminarExamen(int Id);
        public List<DatosBD> ConsultarExamen(RequestActualizar request);
    }
}
