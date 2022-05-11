using Server.Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Interfaces
{
    public interface ICinemasRepository
    {
        List<Models.Cinema> FindAll();
        Models.Cinema FindById(string id);
        void Create(Models.Cinema cinema);
        void Update(string id, Models.Cinema cinema);
        void Delete(string id);
    }
}
