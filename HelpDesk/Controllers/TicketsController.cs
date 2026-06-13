using HelpDesk.Database;
using HelpDesk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HelpDesk.Controllers
{
    public class TicketsController : Controller
    {

        private readonly DbConnection _context;

        public TicketsController(DbConnection context)
        {

            _context = context;
            
        }
        public async Task<IActionResult> Index()
        {

            var listaTickets = await _context.Tickets.ToListAsync();

            return View(listaTickets);
        }

     
    }
}
