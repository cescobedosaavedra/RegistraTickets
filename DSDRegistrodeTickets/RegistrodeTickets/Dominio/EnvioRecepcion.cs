using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RegistrodeTickets.Dominio
{
    [DataContract]
    public class EnvioRecepcion
    {
        [DataMember]
        public int NumeroTicket { get; set; }
        [DataMember]
        public string FechaDeCreacion { get; set; }
        [DataMember]
        public string Prioridad { get; set; }
        [DataMember]
        public string NombreEmpleado { get; set; }
        [DataMember]
        public string ApellidoEmpleado { get; set; }
        [DataMember]
        public string AsuntoTicket { get; set; }
        [DataMember]
        public string ObservacionTicket { get; set; }
        [DataMember]
        public string Obs_atencion { get; set; }
    }
}