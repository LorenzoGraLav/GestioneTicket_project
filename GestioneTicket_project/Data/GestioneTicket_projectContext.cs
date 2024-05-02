using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestioneTicket_project.Models;

namespace GestioneTicket_project.Data
{
    public class GestioneTicket_projectContext : DbContext
    {
        public GestioneTicket_projectContext (DbContextOptions<GestioneTicket_projectContext> options)
            : base(options)
        {
        }

      
        public DbSet<GestioneTicket_project.Models.Utente> Utente { get; set; } = default!;
        public DbSet<GestioneTicket_project.Models.Prodotto> Prodotto { get; set; } = default!;
        public DbSet<GestioneTicket_project.Models.Ticket> Ticket { get; set; } = default!;
        public DbSet<GestioneTicket_project.Models.LavorazioneTicket> LavorazioneTicket { get; set; } = default!;
        public DbSet<GestioneTicket_project.Models.TipologiaProdotto> TipologiaProdotto { get; set; } = default!;

    }
}
