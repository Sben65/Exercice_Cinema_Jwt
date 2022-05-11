using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Interfaces
{
    public interface ICinemasRepository
    {
        List<Cinema_Server.Models.Cinema> FindAll();
        Cinema_Server.Models.Cinema FindById(string id);
        void Create(Cinema_Server.Models.Cinema cinema);
        void Update(string id, Cinema_Server.Models.Cinema cinema);
        void Delete(string id);
    }
}
