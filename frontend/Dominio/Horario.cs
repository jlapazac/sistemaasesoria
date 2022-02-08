using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace frontend.Dominio
{
    public class Horario
    {
        public int id { get; set; }
        public string codhorario { get; set; }
        public string codciclo { get; set; }
        public string codcurso { get; set; }
        public string codseccion { get; set; }
        public DateTime finicio { get; set; }
        public DateTime ffinal { get; set; }
        public string estado { get; set; }
    }
}