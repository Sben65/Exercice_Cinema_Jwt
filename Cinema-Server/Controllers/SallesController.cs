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
    public class SallesController : ControllerBase
    {
        private readonly ISallesService sallesService;

        public SallesController(ISallesService sallesService)
        {
            this.sallesService = sallesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return this.Ok(this.sallesService.GetAllSalle());
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
                return this.Ok(this.sallesService.GetSalleById(id));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Salle salle)
        {
            try
            {
                return this.Ok(this.sallesService.CreateSalle(salle));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Salle salle)
        {
            try
            {
                return this.Ok(this.sallesService.UpdateSalle(id, salle));
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
                this.sallesService.DeleteSalle(id);
                return this.Ok("La salle à bien était supprimer.");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
