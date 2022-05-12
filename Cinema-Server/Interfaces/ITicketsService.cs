using Cinema_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema_Server.Interfaces
{
    public interface ITicketsService
    {
        List<Ticket> GetAllTicket();
        Ticket GetTicketById(int id);
        Ticket CreateTicket(Ticket ticket);
        Ticket UpdateTicket(int id, Ticket ticket);
        void DeleteTicket(int id);
    }
}
