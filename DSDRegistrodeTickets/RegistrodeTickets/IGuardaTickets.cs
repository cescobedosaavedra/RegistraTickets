using RegistrodeTickets.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RegistrodeTickets
{
 [ServiceContract]
    public interface IGuardaTickets
    {
        [OperationContract]
        GuardaTicket InsertarTicket(int N_Ticket, DateTime F_creacion, string Estado, string Prioridad, int CodEmpleado, string NombreEmpleado, string ApellidoEmpleado, string CorreoEmpleado, string CargoEmpleado, string TelefonoEmpleado, string AreaEmpleado, string AsuntoTicket, string ObservacionTicket);
        [OperationContract]
        GuardaTicket ObtenerTicket(int Id);
        [OperationContract]
        GuardaTicket ModificarTicket(int Id, int N_Ticket, DateTime F_creacion, string Estado, string Prioridad, int CodEmpleado, string NombreEmpleado, string ApellidoEmpleado, string CorreoEmpleado, string CargoEmpleado, string TelefonoEmpleado, string AreaEmpleado, string AsuntoTicket, string ObservacionTicket);
        [OperationContract]
        GuardaTicket EliminarTicket(int Id);
        [OperationContract]
        List<GuardaTicket> ListarTicket();
    }
}
