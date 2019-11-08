using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDCeValutazioni.DA.Models
{
    /// <summary>
    /// Classe qdc che rappresenta la tabella qdc nel database.
    /// Contiene tutti i campi che definiscono un qdc
    /// </summary>
    public class Qdc : BaseEntity
    {
        /// <summary>
        /// id identificativo del qdc.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// titolo del qdc.
        /// </summary>
        public string Titolo { get; set; }
        /// <summary>
        /// nome, cognome e mail del formatore che si occupa del progetto.
        /// </summary>
        public string NomeFormatore { get; set; }
        public string CognomeFormatore { get; set; }
        public string MailFormatore { get; set; }
        /// <summary>
        /// nome, cognome e mail del perito che si occupa del progetto.
        /// </summary>
        public string NomePerito { get; set; }
        public string CognomePerito { get; set; }
        public string MailPerito { get; set; }
        /// <summary>
        /// date di inizio e consegna del progetto.
        /// </summary>
        public DateTime? DataInizio { get; set; }
        public DateTime? DataConsegna { get; set; }
        /// <summary>
        /// orari di lavoro.
        /// </summary>
        public DateTime? OraInizio { get; set; }
        public DateTime? OraFine { get; set; }
        /// <summary>
        /// numero di ore totali a disposizione.
        /// </summary>
        public int? NumeroOre { get; set; }

        /// <summary>
        /// descrizione del progetto (si aggiunge in un altra view).
        /// </summary>
        public string Descrizione { get; set; }

        public override string ToString()
        {
            return Titolo;
        }
    }
}
