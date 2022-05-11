using Cinema_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Interfaces
{
    public interface ISallesService
    {
        List<Salle> GetAllSalle();
        Salle GetSalleById(string id);
        Salle CreateSalle(Salle salle);
        Salle UpdateSalle(string id, Salle salle);
        void DeleteSalle(string id);
    }
}
