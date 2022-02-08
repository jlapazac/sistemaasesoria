using frontend.Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace frontend.Controllers
{
    public class HorariosController : Controller
    {
        // GET: Horarios
        public ActionResult Index()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51562/PlatonService.svc/horarios");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Horarios> horariosObtenidos = js.Deserialize<List<Horarios>>(tramaJson);

            ViewData["Message"] = "Listado de horarios";
            ViewBag.Titulo01 = "Codigo";
            ViewBag.Titulo02 = "Ciclo";
            ViewBag.Titulo03 = "Descripcion ciclo";
            ViewBag.Titulo04 = "Curso";
            ViewBag.Titulo05 = "Descripcion curso";
            ViewBag.Titulo06 = "Seccion";
            ViewBag.Titulo07 = "Descripcion seccion";
            ViewBag.Titulo08 = "Fecha hora inicio";
            ViewBag.Titulo09 = "Fecha hora final";
            ViewBag.Titulo10 = "Estado";

            return View(horariosObtenidos);
        }

        public ActionResult Details(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51562/PlatonService.svc/horarios/"+id);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Horario horarioObtenido = js.Deserialize<Horario>(tramaJson);

            if(horarioObtenido == null)
            {
                return HttpNotFound();
            }
            ViewData["Message"] = "Detalle del horario";
            ViewBag.Titulo01 = "Codigo";
            ViewBag.Titulo02 = "Ciclo";
            ViewBag.Titulo03 = "Curso";
            ViewBag.Titulo04 = "Seccion";
            ViewBag.Titulo05 = "Fecha desde";
            ViewBag.Titulo06 = "Fecha hasta";
            ViewBag.Titulo07 = "Estado";

            return View(horarioObtenido);
        }

        public ActionResult Edit(string id1)
        {
            if (id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51562/PlatonService.svc/horarios/" + id1);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Horario horarioObtenido = js.Deserialize<Horario>(tramaJson);

            if (horarioObtenido == null)
            {
                return HttpNotFound();
            }
            ViewData["Message"] = "Editar horario";
            return View(horarioObtenido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codhorario,codciclo,codcurso,codseccion,finicio,ffinal,estado")]frontend.Dominio.Horario horario)
        {
            if (ModelState.IsValid)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string postdata = js.Serialize(horario);
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51562/PlatonService.svc/horarios");
                request.Method = "PUT";
                request.ContentLength = data.Length;
                request.ContentType = "application/json";
                var requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();

                return RedirectToAction("Index");
            }
            return View(horario);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codhorario,codciclo,codcurso,codseccion,finicio,ffinal,estado")]frontend.Dominio.Horario horario)
        {
            if (ModelState.IsValid)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string postdata = js.Serialize(horario);
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51562/PlatonService.svc/horarios");
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/json";
                var requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                return RedirectToAction("Index");
            }
            return View(horario);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["Message"] = "Detalle del horario a eliminar";
            ViewBag.Titulo01 = "Codigo";
            ViewBag.Titulo02 = "Ciclo";
            ViewBag.Titulo03 = "Curso";
            ViewBag.Titulo04 = "Seccion";
            ViewBag.Titulo05 = "Fecha hora desde";
            ViewBag.Titulo06 = "Fecha hora hasta";
            ViewBag.Titulo07 = "Estado";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51562/PlatonService.svc/horarios/" + id);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Horario horarioObtenido = js.Deserialize<Horario>(tramaJson);

            if (horarioObtenido == null)
            {
                return HttpNotFound();
            }
            
            return View(horarioObtenido);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51562/PlatonService.svc/horarios/" + id);
            request.Method = "DELETE";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return RedirectToAction("Index");
        }
    }
}