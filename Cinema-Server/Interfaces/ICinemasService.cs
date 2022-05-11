using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Interfaces
{
    public interface ICinemasService
    {
        List<Models.Cinema> GetAllCinema();
        Models.Cinema GetCinemaById(string id);
        Models.Cinema AddCinema(Models.Cinema cinema);
        Models.Cinema UpdateCinema(string id, Models.Cinema cinema);
        void DeleteCinema(string id);
    }
}
