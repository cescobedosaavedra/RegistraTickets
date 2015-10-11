using RegistrodeTickets.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Messaging;
using System.Web;

namespace RegistrodeTickets.Persistencia
{
    public class GuardaTicketRESTDAO
    {
        public GuardaTicket Crear(GuardaTicket ticketACrear)
        {
            GuardaTicket ticketCreado = null;
            string _fecha = ticketACrear.F_creacion.ToString();
            string sql = "INSERT INTO t_tickets VALUES (@nTicket, @fCreacion, @estado, @prioridad, @codEmpleado, @nombreEmpleado, @apellidoEmpleado, @correo, @cargoEmpleado, @telefonoEmpleado, @area, @asunto, @observacion, @obsAtencion)";
            string ticket = GeneraTicket().ToString();
            string codigo = ticketACrear.CodEmpleado.ToString();
            string fecha = ticketACrear.F_creacion.ToString();

            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@nTicket", ticket));
                    com.Parameters.Add(new SqlParameter("@fCreacion", Convert.ToDateTime(ticketACrear.F_creacion)));
                    com.Parameters.Add(new SqlParameter("@estado", ticketACrear.Estado));
                    com.Parameters.Add(new SqlParameter("@prioridad", ticketACrear.Prioridad));
                    com.Parameters.Add(new SqlParameter("@codEmpleado", codigo));
                    com.Parameters.Add(new SqlParameter("@nombreEmpleado", ticketACrear.NombreEmpleado));
                    com.Parameters.Add(new SqlParameter("@apellidoEmpleado", ticketACrear.ApellidoEmpleado));
                    com.Parameters.Add(new SqlParameter("@correo", ticketACrear.CorreoEmpleado));
                    com.Parameters.Add(new SqlParameter("@cargoEmpleado", ticketACrear.CargoEmpleado));
                    com.Parameters.Add(new SqlParameter("@telefonoEmpleado", ticketACrear.TelefonoEmpleado));
                    com.Parameters.Add(new SqlParameter("@area", ticketACrear.AreaEmpleado));
                    com.Parameters.Add(new SqlParameter("@asunto", ticketACrear.AsuntoTicket));
                    com.Parameters.Add(new SqlParameter("@observacion", ticketACrear.ObservacionTicket));
                    com.Parameters.Add(new SqlParameter("@obsatencion", ticketACrear.Obs_atencion));
                    com.ExecuteNonQuery();                    
                }
            }
            //try
            //{
            //    string rutaCola = @".\private$\Registro";
            //    if (!MessageQueue.Exists(rutaCola))
            //        MessageQueue.Create(rutaCola);
            //    MessageQueue cola = new MessageQueue(rutaCola);
            //    Message mensaje = new Message();
            //    mensaje.Label = "ItemCompra";
            //    mensaje.Body = new GuardaTicket() { Id = ticketACrear.Id, CodEmpleado = int.Parse(codigo), F_creacion = ticketACrear.F_creacion, N_ticket = int.Parse(ticket), NombreEmpleado = ticketACrear.NombreEmpleado, ApellidoEmpleado = ticketACrear.ApellidoEmpleado, Prioridad = ticketACrear.Prioridad, Estado = ticketACrear.Estado, AsuntoTicket = ticketACrear.AsuntoTicket, ObservacionTicket = ticketACrear.ObservacionTicket };
            //    //mensaje.Body = new EnvioRecepcion() { FechaDeCreacion = ticketCrear.FechaDeCreacion, NumeroTicket = ticketCrear.NumeroTicket, NombreEmpleado = ticketCrear.NombreEmpleado, ApellidoEmpleado = ticketCrear.ApellidoEmpleado, Prioridad = ticketCrear.Prioridad, AsuntoTicket = ticketCrear.AsuntoTicket, ObservacionTicket = ticketCrear.ObservacionTicket };
            //    cola.Send(mensaje);
            //}
            //catch
            //{
            //}
            ticketCreado = Obtener(ticketACrear.CodEmpleado.ToString());
            return ticketCreado;

        }
        public GuardaTicket Obtener(string codigo)
        {
            GuardaTicket ticketEncontrado = null;
            string sql = "SELECT * FROM t_tickets WHERE Id=@cod";
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    //string id = ticketEncontrado.Id.ToString();
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            ticketEncontrado = new GuardaTicket()
                            {
                                Id = (int)resultado["Id"],
                                N_ticket = (int)resultado["N_ticket"],
                                F_creacion = ((DateTime)resultado["F_creacion"]).ToString(),
                                Estado = (string)resultado["Estado"],
                                Prioridad = (string)resultado["Prioridad"],
                                CodEmpleado = (int)resultado["CodEmpleado"],
                                NombreEmpleado = (string)resultado["NombreEmpleado"],
                                ApellidoEmpleado = (string)resultado["ApellidoEmpleado"],
                                CorreoEmpleado = (string)resultado["CorreoEmpleado"],
                                CargoEmpleado = (string)resultado["CargoEmpleado"],
                                TelefonoEmpleado = (string)resultado["TelefonoEmpleado"],
                                AreaEmpleado = (string)resultado["AreaEmpleado"],
                                AsuntoTicket = (string)resultado["AsuntoTicket"],
                                ObservacionTicket = (string)resultado["ObservacionTicket"]
                            };
                        }
                    }
                }
            }
            return ticketEncontrado;
        }
        public GuardaTicket Modificar(GuardaTicket ticketAModificar)
        {
            GuardaTicket ticketModificado = null;
            string sql = "UPDATE t_tickets SET " +
                //"N_ticket=@nTicket, F_creacion=@fCreacion,"+
                "Estado=@estado," +
                //"Prioridad=@prioridad, CodEmpleado=@codEmpleado,"+
                //"NombreEmpleado=@nombreEmpleado, ApellidoEmpleado=@apellidoEmpleado,"+
                //"CorreoEmpleado=@correo, CargoEmpleado=@cargoEmpleado, TelefonoEmpleado=@telefonoEmpleado," +
                //"AreaEmpleado=@area, AsuntoTicket=@asunto, ObservacionTicket=@observacion,"+
                "Obs_atencion=@obsatencion WHERE Id=@id";
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    string codigo = ticketAModificar.CodEmpleado.ToString();
                    string id = ticketAModificar.Id.ToString();
                    //string ticket = ticketAModificar.N_ticket.ToString();
                    //string fecha = ticketAModificar.F_creacion.ToString();

                    //com.Parameters.Add(new SqlParameter("@id", id));
                    //com.Parameters.Add(new SqlParameter("@nTicket", ticket));
                    //com.Parameters.Add(new SqlParameter("@fCreacion", Convert.ToDateTime(ticketAModificar.F_creacion)));
                    com.Parameters.Add(new SqlParameter("@estado", ticketAModificar.Estado));
                    //com.Parameters.Add(new SqlParameter("@prioridad", ticketAModificar.Prioridad));
                    //com.Parameters.Add(new SqlParameter("@codEmpleado", codigo));
                    //com.Parameters.Add(new SqlParameter("@nombreEmpleado", ticketAModificar.NombreEmpleado));
                    //com.Parameters.Add(new SqlParameter("@apellidoEmpleado", ticketAModificar.ApellidoEmpleado));
                    //com.Parameters.Add(new SqlParameter("@correo", ticketAModificar.CorreoEmpleado));
                    //com.Parameters.Add(new SqlParameter("@cargoEmpleado", ticketAModificar.CargoEmpleado));
                    //com.Parameters.Add(new SqlParameter("@telefonoEmpleado", ticketAModificar.TelefonoEmpleado));
                    //com.Parameters.Add(new SqlParameter("@area", ticketAModificar.AreaEmpleado));
                    //com.Parameters.Add(new SqlParameter("@asunto", ticketAModificar.AsuntoTicket));
                    //com.Parameters.Add(new SqlParameter("@observacion", ticketAModificar.ObservacionTicket));
                    com.Parameters.Add(new SqlParameter("@obsatencion", ticketAModificar.Obs_atencion));
                    com.ExecuteNonQuery();
                }
            }
            ticketModificado = Obtener(ticketAModificar.Id.ToString());
            return ticketModificado;
        }

        public void Eliminar(string codigo)
        {
            string sql = "DELETE FROM t_tickets WHERE Id=@id";
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@id", codigo));
                    com.ExecuteNonQuery();
                }
            }
        }
        public List<GuardaTicket> ListarTodos()
        {
            List<GuardaTicket> tickets = new List<GuardaTicket>();
            string sql = "SELECT * FROM t_tickets";
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.HasRows)
                        {
                            while (resultado.Read())
                            {
                                GuardaTicket campo = new GuardaTicket()
                                {
                                    Id = resultado.IsDBNull(resultado.GetOrdinal("Id")) ? 0 : (int)resultado["Id"],
                                    N_ticket = resultado.IsDBNull(resultado.GetOrdinal("N_ticket")) ? 0 : (int)resultado["N_ticket"],
                                    F_creacion = resultado.IsDBNull(resultado.GetOrdinal("F_creacion")) ? "" : ((DateTime)resultado["F_creacion"]).ToString(),
                                    Estado = resultado.IsDBNull(resultado.GetOrdinal("Estado")) ? "" : (string)resultado["Estado"],
                                    Prioridad = resultado.IsDBNull(resultado.GetOrdinal("Prioridad")) ? "" : (string)resultado["Prioridad"],
                                    CodEmpleado = resultado.IsDBNull(resultado.GetOrdinal("CodEmpleado")) ? 0 : (int)resultado["CodEmpleado"],
                                    NombreEmpleado = resultado.IsDBNull(resultado.GetOrdinal("NombreEmpleado")) ? "" : (string)resultado["NombreEmpleado"],
                                    ApellidoEmpleado = resultado.IsDBNull(resultado.GetOrdinal("ApellidoEmpleado")) ? "" : (string)resultado["ApellidoEmpleado"],
                                    CorreoEmpleado = resultado.IsDBNull(resultado.GetOrdinal("CorreoEmpleado")) ? "" : (string)resultado["CorreoEmpleado"],
                                    CargoEmpleado = resultado.IsDBNull(resultado.GetOrdinal("CargoEmpleado")) ? "" : (string)resultado["CargoEmpleado"],
                                    TelefonoEmpleado = resultado.IsDBNull(resultado.GetOrdinal("TelefonoEmpleado")) ? "" : (string)resultado["TelefonoEmpleado"],
                                    AreaEmpleado = resultado.IsDBNull(resultado.GetOrdinal("AreaEmpleado")) ? "" : (string)resultado["AreaEmpleado"],
                                    AsuntoTicket = resultado.IsDBNull(resultado.GetOrdinal("AsuntoTicket")) ? "" : (string)resultado["AsuntoTicket"],
                                    ObservacionTicket = resultado.IsDBNull(resultado.GetOrdinal("ObservacionTicket")) ? "" : (string)resultado["ObservacionTicket"],
                                    Obs_atencion = resultado.IsDBNull(resultado.GetOrdinal("Obs_atencion")) ? "" : (string)resultado["Obs_atencion"]
                                };

                                tickets.Add(campo);
                            }
                        }
                    }
                }
            }
            return tickets;
        }
        public int ContadorPrioridades(string codigo)
        {
            SqlConnection mySqlCon = new SqlConnection(Conexion.Cadena);
            SqlCommand mySqlCmd = mySqlCon.CreateCommand();
            mySqlCmd.CommandText = "SELECT COUNT(prioridad) FROM t_tickets WHERE codEmpleado='" + codigo + "' and prioridad='Urgente'";
            mySqlCon.Open();
            int returnvalue = (int)mySqlCmd.ExecuteScalar();
            return returnvalue;
        }
        public int GeneraTicket()
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                
                int cant = 0;// = numeroTicket.N_ticket;
                con.Open();
                using (SqlCommand com = new SqlCommand("GenerarCodigo", con))
                {
                    string query = " select max(n_ticket) from t_tickets";

                    SqlCommand cmd = new SqlCommand(query, con);
                    //cmd.Parameters.AddWithValue("@id", codigo);
                    //   cmd.Parameters.AddWithValue("@Id_empresa", valor);
                    //   cmd.Parameters.AddWithValue("@ID_bodega", valor);

                    cant = (int)cmd.ExecuteScalar();
                    cant = cant + 1;
                }
                return cant;
            }

        }


        

    }
}
