﻿using Entidades;
using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraTicket
    {
        Context context;

        private ControladoraTicket()
        {
            context = new Context();
        }

        private static ControladoraTicket instancia;

        public static ControladoraTicket Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new ControladoraTicket();
                return instancia;
            }
        }

        public ReadOnlyCollection<Ticket> RecuperarTicket()
        {
            try
            {
                return context.Tickets.ToList().AsReadOnly();
            }
            catch (Exception)
            {
                throw;
            }
        }

       public string AgregarTicket(Ticket ticket)
       {
            try
            {
                var listaTickets = context.Tickets.ToList().AsReadOnly();
                var ticketEncontrado = listaTickets.FirstOrDefault(t => t.Computadora.CodigoComputadora == ticket.Computadora.CodigoComputadora); //busco el ticket por id en la lista de tickets para evitar que se repitan
                if (ticketEncontrado == null)
                {
                    context.Tickets.Add(ticket);
                    if(context.Computadoras.Any(c => c.CodigoComputadora == ticket.Computadora.CodigoComputadora))
                    {
                        context.Computadoras.Attach(ticket.Computadora);
                    }
                    if(context.Laboratorios.Any(l => l.NombreLaboratorio == ticket.Computadora.Laboratorio.NombreLaboratorio))
                    {
                        context.Laboratorios.Attach(ticket.Computadora.Laboratorio);
                    }
                    if(context.Tecnicos.Any(t => t.NombreyApellido == ticket.Tecnico.NombreyApellido))
                    {
                        context.Tecnicos.Attach(ticket.Tecnico);
                    }

                    context.SaveChanges();

                    return $"El ticket se agregó correctamente";
                }
                else
                {
                    return $"El ticket ya existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
       }

        public string ModificarTicket(Ticket ticket)
        {
            try
            {
                var listaTickets = context.Tickets.ToList().AsReadOnly();
                var ticketEncontrado = listaTickets.FirstOrDefault(t => t.Computadora.CodigoComputadora == ticket.Computadora.CodigoComputadora); //busco el ticket a modificar por id en la lista de tickets para evitar que se repitan
                if (ticketEncontrado != null)
                {
                    context.Tickets.Update(ticket);
                    if (context.Computadoras.Any(c => c.CodigoComputadora == ticket.Computadora.CodigoComputadora))
                    {
                        context.Computadoras.Attach(ticket.Computadora);
                    }
                    if (context.Laboratorios.Any(l => l.NombreLaboratorio == ticket.Computadora.Laboratorio.NombreLaboratorio))
                    {
                        context.Laboratorios.Attach(ticket.Computadora.Laboratorio);
                    }
                    if (context.Tecnicos.Any(t => t.NombreyApellido == ticket.Tecnico.NombreyApellido))
                    {
                        context.Tecnicos.Attach(ticket.Tecnico);
                    }
                    int insertados = context.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El ticket se modificó correctamente";
                    }
                    else return $"El ticket no se ha podido modificar";
                }
                else
                {
                    return $"El ticket no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarTicket(Ticket ticket)
        {
            try
            {
                var listaTickets = context.Tickets.ToList().AsReadOnly();
                var ticketEncontrado = listaTickets.FirstOrDefault(t => t.Computadora.CodigoComputadora == ticket.Computadora.CodigoComputadora);
                if (ticketEncontrado != null) //si el ticket existe, lo elimino
                {
                    context.Tickets.Remove(ticket);
                    if (context.Computadoras.Any(c => c.CodigoComputadora == ticket.Computadora.CodigoComputadora))
                    {
                        context.Computadoras.Attach(ticket.Computadora);
                    }
                    if (context.Laboratorios.Any(l => l.NombreLaboratorio == ticket.Computadora.Laboratorio.NombreLaboratorio))
                    {
                        context.Laboratorios.Attach(ticket.Computadora.Laboratorio);
                    }
                    if (context.Tecnicos.Any(t => t.NombreyApellido == ticket.Tecnico.NombreyApellido))
                    {
                        context.Tecnicos.Attach(ticket.Tecnico);
                    }
                    int insertados = context.SaveChanges();
                    if (insertados > 0)
                    {
                        return $"El ticket se eliminó correctamente";
                    }
                    else return $"El ticket no se ha podido eliminar";
                }
                else
                {
                    return $"El ticket no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
    }
}
