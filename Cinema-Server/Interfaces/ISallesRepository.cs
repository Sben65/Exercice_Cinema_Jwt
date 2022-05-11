using Server.Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Interfaces
{
    public interface ISallesRepository
    {
        List<Salle> FindAll();
        Salle FindById(string id);
        void Create(Salle salle);
        void Update(string id, Salle salle);
        void Delete(string id);
    }
}
