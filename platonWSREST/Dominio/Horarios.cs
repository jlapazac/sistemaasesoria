using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace platonWSREST.Dominio
{
    [DataContract]
    public class Horarios
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string codhorario { get; set; }
        [DataMember]
        public string codciclo { get; set; }
        [DataMember]
        public string desciclo { get; set; }
        [DataMember]
        public string codcurso { get; set; }
        [DataMember]
        public string descurso { get; set; }
        [DataMember]
        public string codseccion { get; set; }
        [DataMember]
        public string desseccion { get; set; }
        [DataMember]
        public DateTime finicio { get; set; }
        [DataMember]
        public DateTime ffinal { get; set; }
        [DataMember]
        public string estado { get; set; }
    }
}