using Azure.Core;
using Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.BDSPE
{
    public class BaseDatosSPE
    {

        private readonly BDDirectaContext _context;

        public BaseDatosSPE(BDDirectaContext context)
        {
            _context = context;
        }
        public Response AgregarExamen(RequestInsert request)
        {
            Response response = new Response();

            using var transaccion = _context.Database.BeginTransaction();

            try
            {
                var parametros = new[]
                {
                  new SqlParameter("@Nombre", request.Nombre),
                  new SqlParameter("@Descripcion", request.Descripcion)
                };

                var resultado = _context.Set<ResponseSPE>()
                    .FromSqlRaw("EXEC spAgregar @Nombre, @Descripcion", parametros)
                    .AsEnumerable()
                    .FirstOrDefault();
                if (resultado != null)
                {
                    response.Respuesta = resultado.CodigoRetorno == 0 ? true : false;
                    response.Descrpcion = resultado.DescripcionRetorno;
                    if (resultado.CodigoRetorno == 0)
                        transaccion.Commit();
                    else
                        transaccion.Rollback();
                }
            }
            catch (Exception ex)
            {
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
                var parametros = new[]
                {
                    new SqlParameter("@Id", request.Id),
                  new SqlParameter("@Nombre", request.Nombre),
                  new SqlParameter("@Descripcion", request.Descripcion)
                };
                var resultado = _context.Set<ResponseSPE>()
                    .FromSqlRaw("EXEC spActualizar @Id, @Nombre, @Descripcion", parametros)
                    .AsEnumerable()
                    .FirstOrDefault();
                if (resultado != null)
                {
                    response.Respuesta = resultado.CodigoRetorno == 0 ? true : false;
                    response.Descrpcion = resultado.DescripcionRetorno;

                    if (resultado.CodigoRetorno == 0)
                        transaccion.Commit();
                    else
                        transaccion.Rollback();
                }
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
                var parametros = new[]
                {
                  new SqlParameter("@Id", Id)
                };
                var resultado = _context.Set<ResponseSPE>()
                    .FromSqlRaw("EXEC spEliminar @Id", parametros)
                    .AsEnumerable()
                    .FirstOrDefault();
                if (resultado != null)
                {
                    response.Respuesta = resultado.CodigoRetorno == 0 ? true : false;
                    response.Descrpcion = resultado.DescripcionRetorno;

                    if (resultado.CodigoRetorno == 0)
                        transaccion.Commit();
                    else
                        transaccion.Rollback();
                }
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
                var lista = _context.Examenes
                    .FromSqlRaw("EXEC spConsultar ")
                    .ToList();
                if (lista != null)
                    transaccion.Commit();
                else
                    transaccion.Rollback();

                response = lista;
            }
            catch (Exception ex)
            {
            }

            return response;
        }


    }
}
