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
    public class CiclosController : Controller
    {
        // GET: Ciclos
        public ActionResult Index()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51562/PlatonService.svc/ciclos");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Ciclos> ciclosObtenidos = js.Deserialize<List<Ciclos>>(tramaJson);

            ViewData["Message"] = "Listado de Cursos";
            ViewBag.Titulo01 = "Ciclo";
            ViewBag.Titulo02 = "Descripcion ciclo";
            ViewBag.Titulo03 = "Desde";
            ViewBag.Titulo04 = "Hasta";
            ViewBag.Titulo05 = "Estado";

            return View(ciclosObtenidos);
        }
    }
}