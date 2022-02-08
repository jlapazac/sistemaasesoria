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
    public class CursosController : Controller
    {
        // GET: Cursos
        public ActionResult Index()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51562/PlatonService.svc/cursos");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Curso> cursosObtenidos = js.Deserialize<List<Curso>>(tramaJson);

            ViewData["Message"] = "Listado de Cursos";
            ViewBag.Titulo01 = "Curso";
            ViewBag.Titulo02 = "Descripcion curso";
            ViewBag.Titulo03 = "Nivel";
            ViewBag.Titulo04 = "Malla";
            ViewBag.Titulo05 = "Estado";

            return View(cursosObtenidos);
        }
    }
}