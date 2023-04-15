using CanidateApp.Shared;
using System.Threading.Tasks;

namespace CanidateApp.Server.Interface
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>?> GetTicketsBySite(Guid siteId);
        Task<IEnumerable<Ticket>?> GetTickets();
        Task<bool> saveTicket(Ticket ticket);
        Task<bool> UpdateTicket(Ticket ticket);
        Task<IEnumerable<TicketAsignment>?> GetTicketAsignmentsByContractor(string name);
        Task<bool> SaveTicketAsignments(TicketAsignment ticketAsignment);
        Task<bool> UpdateTicketAsignments(TicketAsignment ticketAsignment);
    }
}
