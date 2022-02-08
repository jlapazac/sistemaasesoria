using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace frontend.Dominio
{
    public class Ciclos
    {
        public int id { get; set; }
        public string codciclo { get; set; }
        public string desciclo { get; set; }
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public string estado { get; set; }
    }
}