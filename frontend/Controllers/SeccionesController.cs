using frontend.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace frontend.Controllers
{
    public class SeccionesController : Controller
    {
        // GET: Secciones
        public ActionResult Index()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51562/PlatonService.svc/secciones");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Secciones> seccionesObtenidos = js.Deserialize<List<Secciones>>(tramaJson);

            ViewData["Message"] = "Listado de Secciones";
            ViewBag.Titulo01 = "Seccion";
            ViewBag.Titulo02 = "Descripcion seccion";
            ViewBag.Titulo03 = "Campus";
            ViewBag.Titulo04 = "Estado";

            return View(seccionesObtenidos);
        }
    }
}