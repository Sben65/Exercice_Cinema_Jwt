using Cinema_Server.Interfaces;
using Cinema_Server.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            this.ticketsService = ticketsService;
        }

        // GET: api/<TicketsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return this.Ok(this.ticketsService.GetAllTicket());
        }

        // GET api/<TicketsController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return this.Ok(this.ticketsService.GetTicketById(id));
        }

        // POST api/<TicketsController>
        [HttpPost]
        public IActionResult Post(Ticket ticket)
        {
            return this.Ok(this.ticketsService.CreateTicket(ticket));
        }

        // PUT api/<TicketsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Ticket ticket)
        {
            return this.Ok(this.ticketsService.UpdateTicket(id, ticket));
        }

        // DELETE api/<TicketsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.ticketsService.DeleteTicket(id);
            return this.Ok("Le ticket a bien été supprimé");
        }
    }
}
