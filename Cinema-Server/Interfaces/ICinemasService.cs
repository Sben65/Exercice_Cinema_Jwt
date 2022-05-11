using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Interfaces
{
    public interface ICinemasService
    {
        List<Cinema_Server.Models.Cinema> GetAllCinema();
        Cinema_Server.Models.Cinema GetCinemaById(string id);
        Cinema_Server.Models.Cinema AddCinema(Cinema_Server.Models.Cinema cinema);
        Cinema_Server.Models.Cinema UpdateCinema(string id, Cinema_Server.Models.Cinema cinema);
        void DeleteCinema(string id);
    }
}
