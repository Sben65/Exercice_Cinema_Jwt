using Cinema_Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Cinema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmsService filmsService;
        private readonly ISeancesService seancesService;

        public FilmsController(IFilmsService filmsService, ISeancesService seancesService)
        {
            this.filmsService = filmsService;
            this.seancesService = seancesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return this.Ok(this.filmsService.GetAllFilm());
        }

        //[HttpGet("cinema/{cinemaId}")]
        //public IActionResult GetAllByCinema(string cinemaId)
        //{
        //    try
        //    {
        //        List<Seance> seances = this.seancesService.GetAllSeance().Where(c => c.Id == cinemaId).ToList();
        //        List<Film> films = new();
        //        foreach (var item in seances)
        //        {
        //            films.Add(item.Film);
        //        }

        //        var test = films.GroupBy(c => c.Id).Select(c => c.FirstOrDefault()).ToList();

        //        return this.Ok(test);
        //    }
        //    catch (NullReferenceException e)
        //    {
        //        return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
        //    }
        //}

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return this.Ok(this.filmsService.GetFilmById(id));
        }

        [HttpPost]
        public IActionResult Post(Film film)
        {
            return this.Ok(this.filmsService.CreateFilm(film));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Film film)
        {
            return this.Ok(this.filmsService.UpdateFilm(id, film));
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    try
        //    {
        //        this.filmsService.DeleteFilm(id);
        //        return this.Ok("Le film à bien était supprimé.");
        //    }
        //    catch (Exception e)
        //    {
        //        return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
        //    }
        //}
    }
}
