using CanidateApp.Server.Interface;
using CanidateApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CanidateApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet("{siteId}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsBySite(Guid siteId)
        {
            var tickets = await _ticketRepository.GetTicketsBySite(siteId);
            if (tickets == null)
            {
                return NotFound();
            }
            return Ok(tickets);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            var tickets = await _ticketRepository.GetTickets();
            if (tickets == null)
            {
                return NotFound();
            }
            return Ok(tickets);
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            var result = await _ticketRepository.saveTicket(ticket);
            if (!result)
            {
                return BadRequest();
            }
            return CreatedAtAction("Save Ticket", new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(Ticket ticket)
        {          
            var result = await _ticketRepository.UpdateTicket(ticket);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("ticketasignments/{contractorId}")]
        public async Task<ActionResult<IEnumerable<TicketAsignment>>> GetTicketAsignmentsByContractor(string contractorname)
        {
            var ticketAsignments = await _ticketRepository.GetTicketAsignmentsByContractor(contractorname);
            if (ticketAsignments == null)
            {
                return NotFound();
            }
            return Ok(ticketAsignments);
        }

        [HttpPost("ticketasignments")]
        public async Task<ActionResult<TicketAsignment>> PostTicketAsignment(TicketAsignment ticketAsignment)
        {
            var result = await _ticketRepository.SaveTicketAsignments(ticketAsignment);
            if (!result)
            {
                return BadRequest();
            }
            return CreatedAtAction("Save Ticket Asignments", new { id = ticketAsignment.Id }, ticketAsignment);
        }

        [HttpPut("ticketasignments/{id}")]
        public async Task<IActionResult> PutTicketAsignment(TicketAsignment ticketAsignment)
        {           
            var result = await _ticketRepository.UpdateTicketAsignments(ticketAsignment);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
