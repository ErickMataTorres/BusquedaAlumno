 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace BusquedaAlumno.Controllers
{
    public class CongresoController : Controller
    {
        // GET: Congreso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TipoImagenConstancia()
        {
            return View();
        }


        public ActionResult ImagenConstancia()
        {
            return View();
        }
        public ActionResult ConstanciaTipo()
        {
            return View();
        }
        public ActionResult RegistroTipoConstancia()
        {
            return View();
        }
        
        public JsonResult TablaImagenConstancias(int idTipoImagen)
        {
            var a = Models.ClaseImagenConstancia.TablaImagenConstancias(idTipoImagen);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ConsultarImagenConstancia(int idCongreso)
        {
            var a = Models.ClaseImagenConstancia.ConsultarImagenConstancia(idCongreso);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string GuardarImagenConstancia(Models.ClaseImagenConstancia c)
        {
            string respuesta = string.Empty;
            foreach (var imagen in c.Files)
            {
                string nombreImagen = Path.GetFileNameWithoutExtension(imagen.FileName);
                string extensionImagen = Path.GetExtension(imagen.FileName);
                string nombreImagenExtension = Path.GetFileName(imagen.FileName);

                string path = Path.Combine(Server.MapPath("~/ConstanciasImagenes/"), nombreImagenExtension);

                string imagenUrl = "/ConstanciasImagenes/" + nombreImagenExtension;

                c.ImagenUrl = imagenUrl;

                if (!System.IO.File.Exists(path))
                {
                    imagen.SaveAs(path);
                }

                respuesta = c.Guardar();


            }
            return respuesta;
        }
        [HttpPost]
        public string BorrarImagenConstancia(int id)
        {
            Models.ClaseImagenConstancia c = new Models.ClaseImagenConstancia();
            string r = c.Borrar(id);
            return r;
        }
        [HttpPost]
        public string GuardarTipoConstancia(Models.ClaseTipoConstancia c)
        {
            string r = c.Guardar();
            return r;
        }
        [HttpPost]
        public string BorrarTipoConstancia(int id)
        {
            Models.ClaseTipoConstancia c = new Models.ClaseTipoConstancia();
            string r = c.Borrar(id);
            return r;
        }


        public JsonResult ConsultarTipoConstancia(int parametro)
        {
            var a = Models.ClaseTipoConstancia.ConsultarTipoConstancia(parametro);
            return Json(a, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ListaCongresos()
        {
            var a = Models.ClaseCongreso.LlenarComboBox();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ImprimirListaCongresos(int idCongreso)
        {
            var l = Models.ClaseCongreso.ImprimirListaCongresos(idCongreso);
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaGeneral(string textoBuscar,int opcion)
        {
            var l = Models.ClaseCongreso.ListaCongresos(textoBuscar, opcion);
            return Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}