using RegistrodeTickets.Dominio;
using RegistrodeTickets.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RegistrodeTickets
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GuardaTicketsREST" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GuardaTicketsREST.svc or GuardaTicketsREST.svc.cs at the Solution Explorer and start debugging.
    public class GuardaTicketsREST : IGuardaTicketsREST
    {
        private GuardaTicketRESTDAO dao = new GuardaTicketRESTDAO();

        public GuardaTicket CrearTicketREST(GuardaTicket ticketACrear)
        {
            GuardaTicket pedidoBuscar = new GuardaTicket() { CodEmpleado = ticketACrear.CodEmpleado };

            //dao.ContadorPrioridades(ticketACrear.CodEmpleado.ToString());
            if (ticketACrear.Prioridad == "Urgente")
            {
                if (dao.ContadorPrioridades(ticketACrear.CodEmpleado.ToString()) > 3)
                {
                    throw new WebFaultException<string>("Usted no puede generar más tickets prioridad Urgente", HttpStatusCode.InternalServerError);
                }
            }

            EnvioMensajes(ticketACrear.CodEmpleado.ToString());
            return dao.Crear(ticketACrear);                        
        }

        public GuardaTicket ObtenerTicketREST(string codigo)
        {
            return dao.Obtener(codigo);
        }

        public GuardaTicket ModificarTicketREST(GuardaTicket ticketAModificar)
        {
            return dao.Modificar(ticketAModificar);
        }

        public void EliminarTicketREST(string codigo)
        {
            dao.Eliminar(codigo);
        }

        public List<GuardaTicket> ListarTicketsREST()
        {
            return dao.ListarTodos();
        }

        public int ContadorPrioridades(string codigo)
        {
            return dao.ContadorPrioridades(codigo);
        }

        public void EnvioMensajes(string cod)
        {
            dao.Obtener(cod);        
            GuardaTicket mensajeaEnviar = dao.Obtener(cod);
            string codigo = mensajeaEnviar.CodEmpleado.ToString();
            string ticket = dao.GeneraTicket().ToString();
            try
            {
                string rutaCola = @".\private$\Registro";
                if (!MessageQueue.Exists(rutaCola))
                    MessageQueue.Create(rutaCola);
                MessageQueue cola = new MessageQueue(rutaCola);
                Message mensaje = new Message();
                mensaje.Label = "Se creó el ticket" + ticket;
                mensaje.Body = new GuardaTicket() { Id = mensajeaEnviar.Id, CodEmpleado = int.Parse(codigo), F_creacion = mensajeaEnviar.F_creacion, N_ticket = int.Parse(ticket), NombreEmpleado = mensajeaEnviar.NombreEmpleado, ApellidoEmpleado = mensajeaEnviar.ApellidoEmpleado, Prioridad = mensajeaEnviar.Prioridad, Estado = mensajeaEnviar.Estado, AsuntoTicket = mensajeaEnviar.AsuntoTicket, ObservacionTicket = mensajeaEnviar.ObservacionTicket };
                //mensaje.Body = new EnvioRecepcion() { FechaDeCreacion = ticketCrear.FechaDeCreacion, NumeroTicket = ticketCrear.NumeroTicket, NombreEmpleado = ticketCrear.NombreEmpleado, ApellidoEmpleado = ticketCrear.ApellidoEmpleado, Prioridad = ticketCrear.Prioridad, AsuntoTicket = ticketCrear.AsuntoTicket, ObservacionTicket = ticketCrear.ObservacionTicket };
                cola.Send(mensaje);
            }
            catch
            {
            }
        }

    }   
}
