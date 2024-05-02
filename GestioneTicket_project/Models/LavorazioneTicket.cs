﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
namespace GestioneTicket_project.Models
{
    public class LavorazioneTicket
    {
        [Key]
        [Column("id_ticket_lavorazione")]
        public int LavorazioneTicketId { get; set; }
        [ForeignKey("id_utente")]
        [Column("id_utente")]
        public int UtenteId { get; set; }
        [ForeignKey("id_ticket")]
        [Column("id_ticket")]
        public int TicketId { get; set; }
        [Column("data_presa_incarico")]
        public DateTime Data_presa_incarico { get; set; }
        [Column("ora_presa_incarico")]
        public string Ora_presa_incarico { get; set; }
        [Column("motivazione")]
        public string motivazione { get; set; }

        public Utente? Utente { get; set; }

        public Ticket? Ticket { get; set; }


    }
}
