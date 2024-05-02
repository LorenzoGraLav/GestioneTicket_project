using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace GestioneTicket_project.Models
{
    public class Prodotto
    {
        [Key]
        public int Id_prodotto { get; set; }
        public string Descrizione { get; set; }
        public int Id_tipo_prodotto { get; set; }
        public TipologiaProdotto TipologiaProdotto { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();


    }
}
