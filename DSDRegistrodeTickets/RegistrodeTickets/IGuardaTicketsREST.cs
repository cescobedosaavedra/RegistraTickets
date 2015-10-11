using RegistrodeTickets.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RegistrodeTickets
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGuardaTicketsREST" in both code and config file together.
    [ServiceContract]
    public interface IGuardaTicketsREST
    { 
        //RequestFormat = WebMessageFormat.Json
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ticket1", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        GuardaTicket CrearTicketREST(GuardaTicket ticketACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ticket/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        GuardaTicket ObtenerTicketREST(string codigo);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "ticket", ResponseFormat = WebMessageFormat.Json)]
        GuardaTicket ModificarTicketREST(GuardaTicket ticketAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "ticket/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarTicketREST(string codigo);

        [OperationContract]
        [WebInvoke(Method = "LIST", UriTemplate = "tickets", ResponseFormat = WebMessageFormat.Json)]
        List<GuardaTicket> ListarTicketsREST();
    }
}
