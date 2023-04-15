using CanidateApp.Server.DataHandler;
using CanidateApp.Server.Interface;
using CanidateApp.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TicketDbContext :  DbContext, ITicketRepository
{
    private readonly DataContext _dataContext;

    public TicketDbContext(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Ticket>?> GetTicketsBySite(Guid siteId)
    {
        return await _dataContext.Tickets.Where(t => t.SiteId == siteId).ToListAsync();
    }

    public async Task<IEnumerable<Ticket>?> GetTickets()
    {
        return await _dataContext.Tickets.Where(x => x.DateCompleted == null).ToListAsync();
    }

    public async Task<bool> saveTicket(Ticket ticket)
    {
        await _dataContext.Tickets.AddAsync(ticket);
        return await SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateTicket(Ticket ticket)
    {
        _dataContext.Tickets.Update(ticket);
        return await SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<TicketAsignment>?> GetTicketAsignmentsByContractor(string contractor)
    {
        return await _dataContext.TicketAsignments.Where(t => t.Contractor == contractor).ToListAsync();
    }

    public async Task<bool> SaveTicketAsignments(TicketAsignment ticketAsignment)
    {
        await _dataContext.TicketAsignments.AddAsync(ticketAsignment);
        return await SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateTicketAsignments(TicketAsignment ticketAsignment)
    {
        _dataContext.TicketAsignments.Update(ticketAsignment);
        return await SaveChangesAsync() > 0;
    }  
}
