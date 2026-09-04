using Azure.Core;
using BaseDatos;
using BaseDatos.BDSPE;
using Configuracion;
using Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ClsExamen
    {
        private readonly ServicesConfiguracion servicesConfiguracion;
        private readonly IAccesoDatosApi _accesoDatosApi;
        private string URLAPI = Environment.GetEnvironmentVariable("WsApiExamen");

        public ClsExamen(IAccesoDatosApi accesoDatosApi, ServicesConfiguracion configuracion)
        {
            servicesConfiguracion = configuracion;
            _accesoDatosApi = accesoDatosApi;
        }
        public Response AgregarExamen(RequestInsert request,bool BanderaSPE)
        {
            Response response = new Response();
            //Valida la bandera de API para el guardado por SPE o por API
            if (BanderaSPE)
            {
                using var client = new HttpClient
                {
                    BaseAddress = new Uri(URLAPI)
                };
                //Consume el Servicio APi y comunica a base de datos sin SP
                var responses = client.PostAsJsonAsync(URLAPI + "WSExamen/AgregarExamen", request).Result;

                if (!responses.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        Respuesta = false,
                        Descrpcion = "Error al consumir la API."
                    };
                }
            }
            else
            {
                //Se accede a AccesoDatos y despues se ejecutan los SP 
                response = _accesoDatosApi.AgregarExamenSPE(request);
            }


            return response;
        }
        public Response ActualizarExamen(RequestActualizar request, bool BanderaSPE)
        {
            Response response = new Response();

            if (BanderaSPE)
            {
                using var client = new HttpClient
                {
                    BaseAddress = new Uri(URLAPI)
                };
                var responses = client.PostAsJsonAsync("/WSExamen/ActualizarExamen", request).Result;

                if (!responses.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        Respuesta = false,
                        Descrpcion = "Error al consumir la API."
                    };
                }
            }
            else
                response = _accesoDatosApi.ActualizarExamenSPE(request);

            return response;
        }
        public Response EliminarExamen(int Id, bool BanderaSPE)
        {
            Response response = new Response();

            if (BanderaSPE)
            {
                using var client = new HttpClient
                {
                    BaseAddress = new Uri(URLAPI)
                };
                var responses = client.PostAsync($"WSExamen/EliminarExamen?Id={Id}",null).Result;

                if (!responses.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        Respuesta = false,
                        Descrpcion = "Error al consumir la API."
                    };
                }
            }
            else
                response = _accesoDatosApi.EliminarExamenSPE(Id);

            return response;
        }
        public List<DatosBD> ConsultarExamen(RequestActualizar request, bool BanderaSPE)
        {
            List<DatosBD> response = new List<DatosBD>();

            if (BanderaSPE)
            {
                using var client = new HttpClient
                {
                    BaseAddress = new Uri(URLAPI)
                };
                var responses = client.PostAsJsonAsync(URLAPI+"/WSExamen/ConsultarExamen", request).Result;
                if (!responses.IsSuccessStatusCode)
                {
                    return response;
                }
            }
            else
                response = _accesoDatosApi.ConsultarExamenSPE(request);

            return response;
        }
    }
}
