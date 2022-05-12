using Cinema_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Interfaces
{
    public interface ITicketsRepository
    {
        IEnumerable<Ticket> FindAll();
        Ticket FindById(int id);
        void Create(Ticket film);
        void Update(int id, Ticket film);
        void Delete(int id);
    }
}
