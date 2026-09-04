using AccesoDatos;
using Azure.Core;
using BaseDatos;
using Configuracion;
using Entidades;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    public class ExamenController : Controller
    {
        private readonly ClsExamen _clsExamen;

        public ExamenController(ClsExamen clsExamen)
        {
            _clsExamen = clsExamen;
        }
        public IActionResult Index()
        {
            var request = new RequestActualizar
            {
                Nombre = "",
                Descripcion = ""
            };

            var response = _clsExamen.ConsultarExamen(request, false);
            return View(response);
        }
        [HttpPost]
        public IActionResult Agregar(Entidades.RequestInsert request, bool usarAPI)
        {
            //Se genera validaciones por metodo dependiendo lo que ocupen
            #region Validacion
            if (string.IsNullOrEmpty(request.Nombre))
            {
                ModelState.AddModelError("Nombre", "El nombre es obligatorio.");
            }
            if (string.IsNullOrEmpty(request.Descripcion))
            {
                ModelState.AddModelError("Nombre", "La Descripcion es obligatoria.");
            }
            #endregion

            // se manda a llamar la DLL
            var resultado = _clsExamen.AgregarExamen(request, usarAPI);
            var requestConsultar = new RequestActualizar
            {
                Nombre = "",
                Descripcion = ""
            };

            var response = _clsExamen.ConsultarExamen(requestConsultar, false);
            ViewBag.Mensaje = resultado.Descrpcion;
            return View("Index", response);
        }

        public IActionResult Actualizar(RequestActualizar request, bool usarAPI)
        {
            #region Validacion
            if (request.Id == 0)
            {
                ModelState.AddModelError("Nombre", "El Id es obligatorio.");
            }
            if (string.IsNullOrEmpty(request.Nombre))
            {
                ModelState.AddModelError("Nombre", "El nombre es obligatorio.");
            }
            if (string.IsNullOrEmpty(request.Descripcion))
            {
                ModelState.AddModelError("Nombre", "La descripcion es obligatoria.");
            }
            #endregion

            var resultado = _clsExamen.ActualizarExamen(request, usarAPI);
            var requestConsultar = new RequestActualizar
            {
                Nombre = "",
                Descripcion = ""
            };
            var response = _clsExamen.ConsultarExamen(requestConsultar, false);
            ViewBag.Mensaje = resultado.Descrpcion;
            return View("Index", response);
        }

        public IActionResult Eliminar(int Id, bool usarAPI)
        {
            #region Validacion
            if (Id == 0)
            {
                ModelState.AddModelError("Nombre", "El Id es obligatorio.");
            }
            #endregion

            var resultado = _clsExamen.EliminarExamen(Id, usarAPI);
            var requestConsultar = new RequestActualizar
            {
                Nombre = "",
                Descripcion = ""
            };
            var response = _clsExamen.ConsultarExamen(requestConsultar, false);
            ViewBag.Mensaje = resultado.Descrpcion;
            return View("Index", response);
        }
    }
}
