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
    public class CinemasController : ControllerBase
    {
        private readonly ICinemasService cinemasService;

        public CinemasController(ICinemasService cinemasService)
        {
            this.cinemasService = cinemasService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return this.Ok(this.cinemasService.GetAllCinema());
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return this.Ok(this.cinemasService.GetCinemaById(id));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Models.Cinema cinema)
        {
            try
            {
                return this.Ok(this.cinemasService.AddCinema(cinema));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Models.Cinema cinema)
        {
            try
            {
                return this.Ok(this.cinemasService.UpdateCinema(id, cinema));
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
                this.cinemasService.DeleteCinema(id);

                return this.Ok("Le cinema à bien était supprimer");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
