using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Cinema.Interfaces;
using Server.Cinema.Models;
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
            try
            {
                return this.Ok(this.filmsService.GetAllFilm());
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
        
        [HttpGet("cinema/{cinemaId}")]
        public IActionResult GetAllByCinema(string cinemaId)
        {
            try
            {
                List<Seance> seances = this.seancesService.GetAllSeance().Where(c => c.CinemaId == cinemaId).ToList();
                List<Film> films = new();
                foreach (var item in seances)
                {
                    films.Add(item.Film);
                }

                var test = films.GroupBy(c => c.Id).Select(c => c.FirstOrDefault()).ToList();

                return this.Ok(test);
            }
            catch (NullReferenceException e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                return this.Ok(this.filmsService.GetFilmById(id));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Film film)
        {
            try
            {
                return this.Ok(this.filmsService.CreateFilm(film));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Film film)
        {
            try
            {
                return this.Ok(this.filmsService.UpdateFilm(id, film));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                this.filmsService.DeleteFilm(id);
                return this.Ok("Le film à bien était supprimé.");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
