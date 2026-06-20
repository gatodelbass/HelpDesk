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

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Ticket ticket) {

            if (ModelState.IsValid ) {
                _context.Add(ticket);
                await _context.SaveChangesAsync();

            return RedirectToAction("Index");
            }

            return View(ticket);

        
        }


        public async Task<IActionResult> Edit(int? id) {

            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null) { return NotFound(); }

            return View(ticket);    
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ticket ticket)
        {

            if (id != ticket.Id) {
                return NotFound();

            }           

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Tickets.Any(e => e.Id == ticket.Id)) return NotFound();
                    else throw;

                }
            }

            return View(ticket);


        }

    }
}
