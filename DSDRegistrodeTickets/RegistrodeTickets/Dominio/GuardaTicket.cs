using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
//Se añade el REgistrodeTicketsServices1
namespace RegistrodeTickets.Dominio
{
      [DataContract]
    public class GuardaTicket
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int N_ticket { get; set; }
        [DataMember]
        public string F_creacion { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Prioridad { get; set; }
        [DataMember]
        public int CodEmpleado { get; set; }
        [DataMember]
        public string NombreEmpleado { get; set; }
        [DataMember]
        public string ApellidoEmpleado { get; set; }
        [DataMember]
        public string CorreoEmpleado { get; set; }
        [DataMember]
        public string CargoEmpleado { get; set; }
        [DataMember]
        public string TelefonoEmpleado { get; set; }
        [DataMember]
        public string AreaEmpleado { get; set; }
        [DataMember]
        public string AsuntoTicket { get; set; }
        [DataMember]
        public string ObservacionTicket { get; set; }
        [DataMember]
        public string Obs_atencion { get; set; }

    }
  }