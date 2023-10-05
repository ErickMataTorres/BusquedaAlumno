using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusquedaAlumno.Controllers
{
    public class BusquedaController : Controller
    {
        // GET: Busqueda
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Alumnos()
        {
            return View();
        }
        public ActionResult Listas()
        {
            return View();
        }
        public ActionResult ListaGeneral()
        {
            return View();
        }
        public JsonResult ListaAlumno(string matricula,int idCongreso)
        {
            var l = Models.ClaseAlumno.Lista(matricula, idCongreso);
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaTurnos()
        {
            var l = Models.ClaseTaller.ListaTurnos();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaTalleres(string textoBuscar, int idTurno, int idCongreso)
        {
            var l = Models.ClaseTaller.ListaTalleres(textoBuscar, idTurno,idCongreso);
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        //--Impresiones--//
        public JsonResult ListaImprimir(string matricula_idCongreso)
        {
            var l = Models.ClaseAlumno.ListaImprimir(matricula_idCongreso);
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ImprimirListaTalleres(string idTaller_idCongreso)
        {
            var l = Models.ClaseTaller.ImprimirListaTalleres(idTaller_idCongreso);
            return Json(l, JsonRequestBehavior.AllowGet);
        }


    }
}