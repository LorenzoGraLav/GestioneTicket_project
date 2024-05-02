using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net.Sockets;

namespace GestioneTicket_project.Models
{
    public enum Ruolo
    {
        Utente, Tecnico, Amministratore
    }
    public class Utente
    {
        [Key]
        public int Id_utente { get; set; }
        [Required(ErrorMessage = "Il campo Nome è obbligatorio.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Il campo Cognome è obbligatorio.")]
        public string Cognome { get; set; }
        [Required(ErrorMessage = "Il campo Email è obbligatorio.")]
        [EmailAddress(ErrorMessage = "Il campo Email non è un indirizzo email valido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Il campo Password è obbligatorio.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La password deve contenere almeno 6 caratteri.")]
        public string Password { get; set; }
        //Inserisco Icollection qui in quanto puo avere n utenti
        public ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();
        [Required(ErrorMessage = "Il campo Ruolo è obbligatorio.")]
        public Ruolo Ruolo { get; set; }
        public ICollection<LavorazioneTicket>? Lavorazioni_ticket { get; set; }


    }
}
