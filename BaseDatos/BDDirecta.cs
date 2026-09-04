using Azure.Core;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace BaseDatos
{
    public class BDDirecta
    {

        private readonly BDDirectaContext _context;

        public BDDirecta(BDDirectaContext context)
        {
            _context = context;
        }
        public Response AgregarExamen(RequestInsert request)
        {
            Response response = new Response();

            using var transaccion = _context.Database.BeginTransaction();
            try
            {
                var examen = new DatosBD
                {
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion
                };
                _context.Examenes.Add(examen);
                _context.SaveChanges();

                transaccion.Commit();

                response.Respuesta = true;
                response.Descrpcion = "Registro insertado satisfactoriamente";
            }
            catch (Exception ex) {
                transaccion.Rollback();
                response.Respuesta = false;
                response.Descrpcion = ex.Message;
            }
            return response;
        }
        public Response ActualizarExamen(RequestActualizar request)
        {
            Response response = new Response();

            using var transaccion = _context.Database.BeginTransaction();
            try
            {
                var examen = _context.Examenes.FirstOrDefault(e => e.IdExamen == request.Id);

                if (examen == null)
                {
                    transaccion.Rollback();
                    response.Respuesta = false;
                    response.Descrpcion = "Registro no localizado";
                    return response;
                }
                examen.Nombre = request.Nombre;
                examen.Descripcion = request.Descripcion;

                _context.SaveChanges();

                transaccion.Commit();

                response.Respuesta = true;
                response.Descrpcion = "Registro Actualizado satisfactoriamente";
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                response.Respuesta = false;
                response.Descrpcion = ex.Message;
            }
            return response;
        }
        public Response EliminarExamen(int Id)
        {
            Response response = new Response();

            using var transaccion = _context.Database.BeginTransaction();
            try
            {
                var examen = _context.Examenes.FirstOrDefault(e => e.IdExamen == Id);
                if (examen == null)
                {
                    transaccion.Rollback();
                    response.Respuesta = false;
                    response.Descrpcion = "Registro no localizado";
                    return response;
                }

                _context.Examenes.Remove(examen);
                _context.SaveChanges();
                transaccion.Commit();

                response.Respuesta = true;
                response.Descrpcion = "Registro eliminado satisfactoriamente";
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                response.Respuesta = false;
                response.Descrpcion = ex.Message;
            }
            return response;
        }
        public List<DatosBD> ConsultarExamen(RequestActualizar request)
        {
            List<DatosBD> response = new List<DatosBD>();

            using var transaccion = _context.Database.BeginTransaction();
            try
            {
                var List = _context.Examenes.ToList();
                response = List;
            }
            catch (Exception ex)
            {
            }
            return response;
        }
    }
}
    
