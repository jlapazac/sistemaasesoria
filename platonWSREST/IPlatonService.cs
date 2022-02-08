using platonWSREST.Dominio;
using platonWSREST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace platonWSREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPlatonService" in both code and config file together.
    [ServiceContract]
    public interface IPlatonService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "horarios", ResponseFormat = WebMessageFormat.Json)]
        horario CrearHorario(horario horarioACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "horarios/{codhorario}", ResponseFormat = WebMessageFormat.Json)]
        horario ObtenerHorario(string codhorario);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "horarios", ResponseFormat = WebMessageFormat.Json)]
        horario ModificarHorario(horario horarioAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "horarios/{codhorario}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarHorario(string codhorario);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "horarios", ResponseFormat = WebMessageFormat.Json)]
        List<Horarios> ListarHorario();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ciclos", ResponseFormat = WebMessageFormat.Json)]
        List<ciclo> ListarCiclos();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "cursos", ResponseFormat = WebMessageFormat.Json)]
        List<curso> ListarCursos();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "secciones", ResponseFormat = WebMessageFormat.Json)]
        List<seccion> ListarSecciones();
    }
}
