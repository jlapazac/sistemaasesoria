using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace frontend.Dominio
{
    public class Horarios
    {
        public int id { get; set; }
        public string codhorario { get; set; }
        public string codciclo { get; set; }
        public string desciclo { get; set; }
        public string codcurso { get; set; }
        public string descurso { get; set; }
        public string codseccion { get; set; }
        public string desseccion { get; set; }
        public DateTime finicio { get; set; }
        public DateTime ffinal { get; set; }
        public string estado { get; set; }
    }
}