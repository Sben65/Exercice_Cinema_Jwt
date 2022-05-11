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
    public class SeancesController : ControllerBase
    {
        //private readonly ISeancesService seanceService;
        //private readonly IFilmsService filmsService;

        //public SeancesController(ISeancesService seanceService)
        //{
        //    this.seanceService = seanceService;
        //}

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    try
        //    {
        //        return this.Ok(this.seanceService.GetAllSeance());
        //    }
        //    catch (NullReferenceException e)
        //    {
        //        return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
        //    }
        //}

        //[HttpGet("{cinemaId}/{filmId}")]
        //public IActionResult GetAllByFilm(string cinemaId, string filmId)
        //{
        //    try
        //    {
        //        // on obtient toute les séances du cinema
        //        List<Seance> seances = this.seanceService.GetAllSeance().Where(c => c.CinemaId == cinemaId && c.FilmId == filmId).ToList();

        //        return this.Ok(seances);
        //    }
        //    catch (NullReferenceException e)
        //    {
        //        return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
        //    }
        //}

        //[HttpGet("{id}")]
        //public IActionResult Get(string id)
        //{
        //    try
        //    {
        //        return this.Ok(this.seanceService.GetSeanceById(id));
        //    }
        //    catch (NullReferenceException e)
        //    {
        //        return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
        //    }
        //}

        //[HttpPost]
        //public IActionResult Post(Seance seance)
        //{
        //    try
        //    {
        //        return this.Ok(this.seanceService.AddSeance(seance));
        //    }
        //    catch (Exception e)
        //    {
        //        return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
        //    }
        //}

        //[HttpPut("{id}")]
        //public IActionResult Put(string id, Seance seance)
        //{
        //    try
        //    {
        //        return this.Ok(this.seanceService.UpdateSeance(id, seance));
        //    }
        //    catch (Exception e)
        //    {
        //        return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    try
        //    {
        //        this.seanceService.DeleSeance(id);

        //        return this.Ok("La seance à bien était supprimer");
        //    }
        //    catch (Exception e)
        //    {
        //        return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
        //    }
        //}
    }
}
