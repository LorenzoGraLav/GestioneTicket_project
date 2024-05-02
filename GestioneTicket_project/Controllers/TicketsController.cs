using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestioneTicket_project.Data;
using GestioneTicket_project.Models;

namespace GestioneTicket_project.Controllers
{
    public class TicketsController : Controller
    {
        private readonly GestioneTicket_projectContext _context;

        public TicketsController(GestioneTicket_projectContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var gestioneTicket_projectContext = _context.Ticket.Include(t => t.Prodotto).Include(t => t.Utente);
            return View(await gestioneTicket_projectContext.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.Prodotto)
                .Include(t => t.Utente)
                .FirstOrDefaultAsync(m => m.Id_ticket == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["ProdottoId"] = new SelectList(_context.Set<Prodotto>(), "Id_prodotto", "Id_prodotto");
            ViewData["UtenteId"] = new SelectList(_context.Set<Utente>(), "Id_utente", "Cognome");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_ticket,Data_apertura,Ora_apertura,Data_chiusura,Ora_chiusura,Descrizione,Stato,UtenteId,ProdottoId,Soluzione")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdottoId"] = new SelectList(_context.Set<Prodotto>(), "Id_prodotto", "Id_prodotto", ticket.ProdottoId);
            ViewData["UtenteId"] = new SelectList(_context.Set<Utente>(), "Id_utente", "Cognome", ticket.UtenteId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["ProdottoId"] = new SelectList(_context.Set<Prodotto>(), "Id_prodotto", "Id_prodotto", ticket.ProdottoId);
            ViewData["UtenteId"] = new SelectList(_context.Set<Utente>(), "Id_utente", "Cognome", ticket.UtenteId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id_ticket,Data_apertura,Ora_apertura,Data_chiusura,Ora_chiusura,Descrizione,Stato,UtenteId,ProdottoId,Soluzione")] Ticket ticket)
        {
            if (id != ticket.Id_ticket)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id_ticket))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdottoId"] = new SelectList(_context.Set<Prodotto>(), "Id_prodotto", "Id_prodotto", ticket.ProdottoId);
            ViewData["UtenteId"] = new SelectList(_context.Set<Utente>(), "Id_utente", "Cognome", ticket.UtenteId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.Prodotto)
                .Include(t => t.Utente)
                .FirstOrDefaultAsync(m => m.Id_ticket == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket != null)
            {
                _context.Ticket.Remove(ticket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int? id)
        {
            return _context.Ticket.Any(e => e.Id_ticket == id);
        }
    }
}
