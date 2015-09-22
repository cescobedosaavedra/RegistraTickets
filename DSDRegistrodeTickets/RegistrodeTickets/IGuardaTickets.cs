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
        GuardaTicket InsertarTicket(string ApellidoEmpleado, string CorreoEmpleado, string CargoEmpleado, string TelefonoEmpleado, string AreaEmpleado);
        [OperationContract]
        GuardaTicket ObtenerTicket(int CodEmpleado);
        [OperationContract]
        GuardaTicket ModificarTicket(int CodEmpleado, string ApellidoEmpleado, string CorreoEmpleado, string CargoEmpleado, string TelefonoEmpleado, string AreaEmpleado);
        [OperationContract]
        GuardaTicket EliminarTicket(int CodEmpleado);
        [OperationContract]
        List<GuardaTicket> ListarTicket();
    }
}
