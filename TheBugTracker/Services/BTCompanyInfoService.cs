using Microsoft.AspNetCore.Identity;
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
    public class BTCompanyInfoService : IBTCompanyInfoService
    {
        //dependency Injection 
        private readonly ApplicationDbContext _context;
        

        public BTCompanyInfoService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<BTUser>> GetAllMembersAsync(int companyId)
        {
            //instance of a list of a BTUser, list of users constructor.
            //calling new detects type that is needed to be used
            List<BTUser> result = new();

            result = await _context.Users.Where(u => u.CompanyId == companyId).ToListAsync();
            return result;
        }

        public async Task<List<Project>> GetAllProjectsAsync(int companyId)
        {
            List<Project> result = new();

            //Eagar loading data / info hadt to be "Included" so that it is included in the data that is returned, will be null otherwise 
            result = await _context.Projects.Where(p => p.CompanyId == companyId)
                                            .Include(p => p.Members)
                                            .Include(p => p.Tickets) //can use then inlcude to add items from "Tickets"
                                                .ThenInclude(t => t.Comments)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.Attachments)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.History) //Satisfying virtual properties 
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.DeveloperUser)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.OwnerUser)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.TicketStatus)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.TicketPriority)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.TicketType)
                                            .Include(p => p.ProjectPriority)
                                            .ToListAsync();

            return result;

        }

        public async Task<List<Ticket>> GetAllTicketsAsync(int companyId)
        {
            List<Ticket> result = new();
            List<Project> projects = new();

            // calling method above
            projects = await GetAllProjectsAsync(companyId);

            result = projects.SelectMany(p => p.Tickets).ToList();

            return result;
        }

        public async Task<Company> GetCompanyInfoByIdAsync(int? companyId) // will accept null in some cases
        {
            Company result = new();

            if (companyId != null)
            {
                result = await _context.Companies
                    .Include(c => c.Members)
                    .Include(c=> c.Projects)
                    .Include(c=> c.Invites)
                    .FirstOrDefaultAsync(c => c.Id == companyId);
            }
            return result;
        }
    }
}
