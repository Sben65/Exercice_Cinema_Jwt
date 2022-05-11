using Cinema_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Interfaces
{
    public interface ISeancesRepository
    {
        List<Seance> FindAll();
        Seance FindById(string id);
        void Create(Seance seance);
        void Update(string id, Seance seance);
        void Delete(string id);
    }
}
