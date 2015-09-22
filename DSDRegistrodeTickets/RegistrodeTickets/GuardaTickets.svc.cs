﻿using RegistrodeTickets.Dominio;
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

        public object Id { get; private set; }

        private GuardaTicketDAO GuardaTicketDAO
        {
            get
            {
                if (guardaTicket == null)
                    guardaTicket = new GuardaTicketDAO();
                return guardaTicket;
            }
        }

        public GuardaTicket InsertarTicket(int N_Ticket, DateTime F_creacion, string Estado, int CodEmpleado, string NombreEmpleado, string ApellidoEmpleado, string CorreoEmpleado, string CargoEmpleado, string TelefonoEmpleado, string AreaEmpleado, string AsuntoTicket, string ObservacionTicket)
        {
            throw new NotImplementedException();
        }

        public GuardaTicket InsertarTicket(int n_Ticket, DateTime f_creacion, string estado, int codEmpleado, string nombreEmpleado, string apellidoEmpleado, string correoEmpleado, string cargoEmpleado, string telefonoEmpleado, string areaEmpleado, string asuntoTicket, string observacionTicket, string obs_atencion)
        {
            GuardaTicket empleadoACrear = new GuardaTicket()
            {
                N_ticket = n_Ticket,
                F_creacion = f_creacion,
                Estado = estado,
                CodEmpleado = codEmpleado,
                NombreEmpleado = nombreEmpleado,
                ApellidoEmpleado = apellidoEmpleado,
                CorreoEmpleado = correoEmpleado,
                CargoEmpleado = cargoEmpleado,
                TelefonoEmpleado = telefonoEmpleado,
                AreaEmpleado = areaEmpleado,
                AsuntoTicket = asuntoTicket,
                ObservacionTicket = observacionTicket,
                Obs_atencion = obs_atencion

            };
            return GuardaTicketDAO.Crear(empleadoACrear);

        }

        public void EliminarTicket(int Id)
        {
            GuardaTicket empleadoExistente = GuardaTicketDAO.Obtener(Id);
            GuardaTicketDAO.Eliminar(empleadoExistente);
        }

        public List<GuardaTicket> ListarTicket()
        {
            return GuardaTicketDAO.ListarTodos().ToList();
        }

        public GuardaTicket ModificarTicket(int Id, int N_Ticket, DateTime F_creacion, string Estado, int CodEmpleado, string NombreEmpleado, string ApellidoEmpleado, string CorreoEmpleado, string CargoEmpleado, string TelefonoEmpleado, string AreaEmpleado, string AsuntoTicket, string ObservacionTicket)
        {
            throw new NotImplementedException();
        }

        public GuardaTicket ModificarTicket(int id, int n_Ticket, DateTime f_creacion, string estado, int codEmpleado, string nombreEmpleado, string apellidoEmpleado, string correoEmpleado, string cargoEmpleado, string telefonoEmpleado, string areaEmpleado, string asuntoTicket, string observacionTicket, string obs_atencion)
        {
            GuardaTicket empleadoAModificar = new GuardaTicket()
            {
                Id = id,
                N_ticket = n_Ticket,
                F_creacion = f_creacion,
                Estado = estado,
                CodEmpleado = codEmpleado,
                NombreEmpleado = nombreEmpleado,
                ApellidoEmpleado = apellidoEmpleado,
                CorreoEmpleado = correoEmpleado,
                CargoEmpleado = cargoEmpleado,
                TelefonoEmpleado = telefonoEmpleado,
                AreaEmpleado = areaEmpleado,
                AsuntoTicket = asuntoTicket,
                ObservacionTicket = observacionTicket,
                Obs_atencion = obs_atencion
            };
            return GuardaTicketDAO.Modificar(empleadoAModificar);

        }

        public GuardaTicket ObtenerTicket(int Id)
        {
            //Empleado emple = new Empleado();
            //emple.ApellidoEmpleado = "Escobedo";
            return GuardaTicketDAO.Obtener(Id);
            //return emple;
        }

        GuardaTicket IGuardaTickets.EliminarTicket(int Id)
        {
            throw new NotImplementedException();
        }
    }
    }

