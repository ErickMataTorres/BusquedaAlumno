using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusquedaAlumno.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }
        public JsonResult ListaRegistroProfesor(int idCongreso, string numeroEmpleado_nombre)
        {
            var a = Models.ClaseProfesor.ListaRegistroProfesor(idCongreso,numeroEmpleado_nombre);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaCargarModificarProfesorConstancia(string numeroEmpleado_idCongreso)
        {
            var a = Models.ClaseProfesor.ListaCargarModificarProfesorConstancia(numeroEmpleado_idCongreso);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string GuardarProfesorConstancia(Models.ClaseProfesor cp)
        {
            string r = cp.Guardar();
            return r;
        }
        public string ModificarProfesorConstancia(Models.ClaseProfesor cp)
        {
            string r = cp.Modificar();
            return r;
        }
        public string BorrarProfesorConstancia(Models.ClaseProfesor cp)
        {
            string r = cp.Borrar();
            return r;
        }
        [HttpPost]
        public string GuardarRegistroLista(int idCongreso,string[] listaNombres)
        {
            Models.ClaseProfesor c = new Models.ClaseProfesor();
            string r = c.GuardarLista(idCongreso,listaNombres);
            return r;
        }
    }
}