using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBugTracker.Data;
using TheBugTracker.Models;
using TheBugTracker.Services.Interfaces;

namespace TheBugTracker.Services
{
    public class BTTicketService : IBTTicketService
    {
        //dependency Injection 
        private readonly ApplicationDbContext _context;

        public BTTicketService(ApplicationDbContext context)
        {
            _context = context;           
        }

        public async Task AddNewTicketAsync(Ticket ticket)
        {
            _context.Add(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task ArchiveTicketAsync(Ticket ticket)
        {
            ticket.Archived = true;
            _context.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public Task AssignTicketAsync(int ticketId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ticket>> GetAllTicketsByCompanyAsync(int companyId)
        {
            try
            {
                //bring projects together and asking for the list of tickets
                //Filtering companies 
                List<Ticket> tickets = await _context.Projects
                                                     .Where(p => p.CompanyId == companyId)
                                                     .SelectMany(p => p.Tickets)
                                                        .Include(t => t.Attachments)
                                                        .Include(t => t.Comments)
                                                        .Include(t => t.History)
                                                        .Include(t => t.DeveloperUser)
                                                        .Include(t => t.OwnerUser)
                                                        .Include(t => t.TicketPriority)
                                                        .Include(t => t.TicketStatus)
                                                        .Include(t => t.TicketType)
                                                        .Include(t => t.Project)
                                                    .ToListAsync();

                return tickets;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Ticket>> GetAllTicketsByPriorityAsync(int companyId, string priorityName)
        {
            //.Value helps get result of this thread 
            int priorityId = (await LookupTicketPriorityIdAsync(priorityName)).Value;

            try
            {
                List<Ticket> tickets = await _context.Projects
                                                        .Where(p => p.CompanyId == companyId)
                                                          .SelectMany(p => p.Tickets)
                                                            .Include(t => t.Attachments)
                                                            .Include(t => t.Comments)
                                                            .Include(t => t.History)
                                                            .Include(t => t.DeveloperUser)
                                                            .Include(t => t.OwnerUser)
                                                            .Include(t => t.TicketPriority)
                                                            .Include(t => t.TicketStatus)
                                                            .Include(t => t.TicketType)
                                                            .Include(t => t.Project)
                                                                .Where(t => t.TicketPriorityId == priorityId)
                                                                .ToListAsync();
                return tickets;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Ticket>> GetAllTicketsByStatusAsync(int companyId, string statusName)
        {
            //.Value helps get result of this thread 
            int statusId = (await LookupTicketStatusIdAsync(statusName)).Value;

            try
            {
                List<Ticket> tickets = await _context.Projects
                                                        .Where(p => p.CompanyId == companyId)
                                                          .SelectMany(p => p.Tickets)
                                                            .Include(t => t.Attachments)
                                                            .Include(t => t.Comments)
                                                            .Include(t => t.History)
                                                            .Include(t => t.DeveloperUser)
                                                            .Include(t => t.OwnerUser)
                                                            .Include(t => t.TicketPriority)
                                                            .Include(t => t.TicketStatus)
                                                            .Include(t => t.TicketType)
                                                            .Include(t => t.Project)
                                                                .Where(t => t.TicketStatusId == statusId)
                                                                .ToListAsync();
                return tickets;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<Ticket>> GetAllTicketsByTypeAsync(int companyId, string typeName)
        {
            //.Value helps get result of this thread 
            int typeId = (await LookupTicketTypeIdAsync(typeName)).Value;

            try
            {
                List<Ticket> tickets = await _context.Projects
                                                        .Where(p => p.CompanyId == companyId)
                                                          .SelectMany(p => p.Tickets)
                                                            .Include(t => t.Attachments)
                                                            .Include(t => t.Comments)
                                                            .Include(t => t.History)
                                                            .Include(t => t.DeveloperUser)
                                                            .Include(t => t.OwnerUser)
                                                            .Include(t => t.TicketPriority)
                                                            .Include(t => t.TicketStatus)
                                                            .Include(t => t.TicketType)
                                                            .Include(t => t.Project)
                                                                .Where(t => t.TicketTypeId == typeId)
                                                                .ToListAsync();
                return tickets;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task<List<Ticket>> GetArchivedTicketsAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetProjectTicketsByPriorityAsync(string priorityName, int companyId, int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetProjectTicketsByRoleAsync(string role, string userId, int projectId, int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetProjectTicketsByStatusAsync(string statusName, int companyId, int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetProjectTicketsByTypeAsync(string typeName, int companyId, int projectId)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);
        }

        public Task<BTUser> GetTicketDeveloperAsync(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetTicketsByRoleAsync(string role, string userId, int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetTicketsByUserIdAsync(string userId, int companyId)
        {
            throw new NotImplementedException();
        }

        //Helper methods - Lookups
        //Make sure variables and calls are correct when you reuse code ion another sections
        public async Task<int?> LookupTicketPriorityIdAsync(string priorityName)
        {
            try
            {
                //null check and priority lookup
                TicketPriority priority = await _context.TicketPriorities.FirstOrDefaultAsync(p => p.Name == priorityName);
                return priority?.Id;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<int?> LookupTicketStatusIdAsync(string statusName)
        {
            try
            {
                //null check and priority lookup
                TicketStatus status = await _context.TicketStatuses.FirstOrDefaultAsync(p => p.Name == statusName);
                return status?.Id;
            }
            catch (Exception)
            {
                // if any trouble we are throwing exception to STACK
                throw;
            }
        }

        public async Task<int?> LookupTicketTypeIdAsync(string typeName)
        {
            try
            {
                //null check and priority lookup
                TicketType type = await _context.TicketTypes.FirstOrDefaultAsync(p => p.Name == typeName);
                return type?.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            _context.Update(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
