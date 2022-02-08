using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace frontend.Dominio
{
    public class Curso
    {
        public int id { get; set; }
        public string codcurso { get; set; }
        public string descurso { get; set; }
        public int nivel { get; set; }
        public int malla { get; set; }
        public string estado { get; set; }
    }
}