using RegistrodeTickets.Dominio;
using RegistrodeTickets.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RegistrodeTickets
{
public class GuardaTickets : IGuardaTickets
    
{
        private GuardaTicketDAO guardaTicket = null;

        public object CodEmpleado { get; private set; }

        private GuardaTicketDAO GuardaTicketDAO
        {
            get
            {
                if (guardaTicket == null)
                    guardaTicket = new GuardaTicketDAO();
                return guardaTicket;
            }
        }

        public GuardaTicket InsertarTicket(string ApellidoEmpleado, string CorreoEmpleado, string CargoEmpleado, string TelefonoEmpleado, string AreaEmpleado)
        {
            throw new NotImplementedException();
        }

        public GuardaTicket InsertarTicket(string nombreEmpleado, string apellidoEmpleado, string correoEmpleado, string cargoEmpleado, string telefonoEmpleado, string areaEmpleado)
        {
            GuardaTicket empleadoACrear = new GuardaTicket()
            {
                NombreEmpleado = nombreEmpleado,
                ApellidoEmpleado = apellidoEmpleado,
                CorreoEmpleado = correoEmpleado,
                CargoEmpleado = cargoEmpleado,
                TelefonoEmpleado = telefonoEmpleado,
                AreaEmpleado = areaEmpleado,
            };
            return GuardaTicketDAO.Crear(empleadoACrear);

        }

        public void EliminarTicket(int CodEmpleado)
        {
            GuardaTicket empleadoExistente = GuardaTicketDAO.Obtener(CodEmpleado);
            GuardaTicketDAO.Eliminar(empleadoExistente);
        }

        public List<GuardaTicket> ListarTicket()
        {
            return GuardaTicketDAO.ListarTodos().ToList();
        }

        public GuardaTicket ModificarTicket(int CodEmpleado, string ApellidoEmpleado, string CorreoEmpleado, string CargoEmpleado, string TelefonoEmpleado, string AreaEmpleado)
        {
            throw new NotImplementedException();
        }

        public GuardaTicket ModificarTicket(int codEmpleado, string nombreEmpleado, string apellidoEmpleado, string correoEmpleado, string cargoEmpleado, string telefonoEmpleado, string areaEmpleado)
        {
            GuardaTicket empleadoAModificar = new GuardaTicket()
            {
                CodEmpleado = codEmpleado,
                NombreEmpleado = nombreEmpleado,
                ApellidoEmpleado = apellidoEmpleado,
                CorreoEmpleado = correoEmpleado,
                CargoEmpleado = cargoEmpleado,
                TelefonoEmpleado = telefonoEmpleado,
                AreaEmpleado = areaEmpleado,
            };
            return GuardaTicketDAO.Modificar(empleadoAModificar);

        }

        public GuardaTicket ObtenerTicket(int CodEmpleado)
        {
            //Empleado emple = new Empleado();
            //emple.ApellidoEmpleado = "Escobedo";
            return GuardaTicketDAO.Obtener(CodEmpleado);
            //return emple;
        }

        GuardaTicket IGuardaTickets.EliminarTicket(int CodEmpleado)
        {
            throw new NotImplementedException();
        }
    }
    }

