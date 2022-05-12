using Cinema_Server.Interfaces;
using Cinema_Server.Models;
using Server.Cinema.Interfaces;

namespace Cinema_Server.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly ITicketsRepository ticketsRepository;

        public TicketsService(ITicketsRepository ticketsRepository)
        {
            this.ticketsRepository = ticketsRepository;
        }

        public List<Ticket> GetAllTicket()
        {
            List<Ticket> tickets = this.ticketsRepository.FindAll().ToList();

            if (tickets == null)
            {
                throw new NullReferenceException("la liste de ticket est vide.");
            }

            return tickets;
        }

        public Ticket GetTicketById(int id)
        {
            Ticket ticket = this.ticketsRepository.FindById(id);

            if (ticket is null)
            {
                throw new NullReferenceException("le ticket n'a pas était trouver.");
            }

            return ticket;
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            if (ticket?.Id == null)
            {
                throw new ArgumentNullException();
            }

            this.ticketsRepository.Create(ticket);

            return ticket;
        }

        public Ticket UpdateTicket(int id, Ticket ticket)
        {
            if (ticket?.Id == null)
            {
                throw new ArgumentNullException();
            }

            this.ticketsRepository.Update(id, ticket);

            return ticket;
        }

        public void DeleteTicket(int id)
        {
            this.ticketsRepository.Delete(id);
        }
    }
}
