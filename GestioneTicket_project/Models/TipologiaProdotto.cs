using System.ComponentModel.DataAnnotations;

namespace GestioneTicket_project.Models
{
    public class TipologiaProdotto
    {
        [Key]
        public int Id_tipologia_prodotto { get; set; }
        public string Descrizione { get; set; }
        public ICollection<Prodotto> Prodotti { get; set; }
    }
}
