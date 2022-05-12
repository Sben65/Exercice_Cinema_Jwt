using Cinema_Server.Models;
using Server.Cinema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly CinemajwtDatabaseContext context;

        public TicketsRepository(CinemajwtDatabaseContext context)
        {
            this.context = context;
        }

        public void Create(Ticket ticket)
        {
            this.context.Tickets.Add(ticket);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> FindAll()
        {
            return this.context.Tickets.ToList();
        }

        public Ticket FindById(int id)
        {
            return this.context.Tickets.FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id, Film film)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Ticket film)
        {
            throw new NotImplementedException();
        }
    }
}
