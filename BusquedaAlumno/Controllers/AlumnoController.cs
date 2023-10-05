using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusquedaAlumno.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Modificar()
        {
            return View();
        }
        public ActionResult Constancia()
        {
            return View();
        }
        public ActionResult EntregaKit()
        {
            return View();
        }

        

        public JsonResult ImprimirConstanciaAlumno(string matricula_idCongreso, int idTipoImagen)
        {
            Models.ClaseAlumno ca = new Models.ClaseAlumno();
            var a = ca.ImprimirConstanciaAlumno(matricula_idCongreso, idTipoImagen);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaAlumnoConstancia(int idCongreso,string matricula_nombre)
        {
            var a= Models.ClaseAlumno.ListaAlumnoConstancia(idCongreso,matricula_nombre);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CargarModificarAlumno(string matricula_idCongreso)
        {
            var a = Models.ClaseAlumno.CargarModificarAlumno(matricula_idCongreso);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaModificarAlumno(int opcion,string textoBuscar, int idCongreso)
        {
            var a = Models.ClaseAlumno.ListaModificarAlumno(opcion,textoBuscar, idCongreso);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string ModificarDatosAlumno(Models.ClaseAlumno c)
        {
            string r = c.ModificarDatosAlumno();
            return r;
        }
        public string BorrarAlumno(Models.ClaseAlumno c)
        {
            string r = c.BorrarAlumno();
            return r;
        }
    }
}