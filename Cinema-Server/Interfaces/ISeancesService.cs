using Cinema_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Interfaces
{
    public interface ISeancesService
    {
        List<Seance> GetAllSeance();
        Seance GetSeanceById(string id);
        Seance AddSeance(Seance seance);
        Seance UpdateSeance(string id, Seance seance);
        void DeleSeance(string id);
    }
}
