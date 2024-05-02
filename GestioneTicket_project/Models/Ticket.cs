using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum Status
{
    APERTO, LAVORAZIONE, CHIUSO
}
namespace GestioneTicket_project.Models
{
    public class Ticket
    {
        [Key]
        public int? Id_ticket { get; set; }
        [Column("data_apertura")]
        [Display(Name = "Data Apertura")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Data_apertura { get; set; }
        [Column("ora_apertura")]
        [Display(Name = "Ora Apertura")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public string? Ora_apertura { get; set; }
        [Column("data_chiusura")]
        [Display(Name = "Data Chiusura")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Data_chiusura { get; set; }
        [Column("ora_chiusura")]
        [Display(Name = "Ora Chiusura")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public string? Ora_chiusura { get; set; }
        [Column("descrizione")]
        public string? Descrizione { get; set; }
        [Column("status")]
        public Status? Stato { get; set; }
        [ForeignKey("utente_id")]
        [Column("utente_id")]
        public int? UtenteId { get; set; }
        [ForeignKey("prodotto_id")]
        [Column("prodotto_id")]
        public int? ProdottoId { get; set; }
        public ICollection<LavorazioneTicket>? Lavorazioni_ticket { get; set; }

        [Column("soluzione")]
        public string? Soluzione { get; set; }


        public Utente? Utente { get; set; }
        public Prodotto? Prodotto { get; set; }
        //proprieta booleana per dare la possibilita di aprire o di chiudere un ticket con un pulsante
        //public bool open { get; set; }

    }
}
