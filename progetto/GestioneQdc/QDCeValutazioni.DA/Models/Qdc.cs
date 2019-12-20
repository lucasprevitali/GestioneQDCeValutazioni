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
        /*[Key]
        public int Id { get; set; }*/
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
        public string NomePerito1 { get; set; }
        public string CognomePerito1 { get; set; }
        public string MailPerito1 { get; set; }
        public string NomePerito2 { get; set; }
        public string CognomePerito2 { get; set; }
        public string MailPerito2 { get; set; }
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

        /// <summary>
        /// Percorsi dei file di template e di salvataggio
        /// </summary>
        public string PathTemplate { get; set; }
        public string PathSave { get; set; }

        /// <summary>
        /// Costruttore per l'inserimento di un Qdc tramite parametri
        /// </summary>
        /// <param name="titolo"></param>
        /// <param name="nomeFormatore"></param>
        /// <param name="cognomeFormatore"></param>
        /// <param name="mailFormatore"></param>
        /// <param name="nomePerito"></param>
        /// <param name="cognomePerito"></param>
        /// <param name="mailPerito"></param>
        /// <param name="dataInizio"></param>
        /// <param name="dataConsegna"></param>
        /// <param name="oraInizio"></param>
        /// <param name="oraFine"></param>
        /// <param name="numeroOre"></param>
        /// <param name="descrizione"></param>
        /// <param name="nomePerito2"></param>
        /// <param name="cognomePerito2"></param>
        /// <param name="mailPerito2"></param>
        /// <param name="pathTemplate"></param>
        /// <param name="pathSave"></param>
        public Qdc(string titolo, string nomeFormatore, string cognomeFormatore, string mailFormatore,
            string nomePerito, string cognomePerito, string mailPerito, DateTime dataInizio, DateTime dataConsegna,
            DateTime oraInizio, DateTime oraFine, int numeroOre, string descrizione, 
            string nomePerito2, string cognomePerito2, string mailPerito2, string pathTemplate, string pathSave)
        {
            Titolo = titolo;
            NomeFormatore = nomeFormatore;
            CognomeFormatore = cognomeFormatore;
            MailFormatore = mailFormatore;
            NomePerito1 = nomePerito;
            CognomePerito1 = cognomePerito;
            MailPerito1 = mailPerito;
            DataInizio = dataInizio;
            DataConsegna = dataConsegna;
            OraInizio = oraInizio;
            OraFine = oraFine;
            NumeroOre = numeroOre;
            Descrizione = descrizione;
            NomePerito2 = nomePerito2;
            CognomePerito2 = cognomePerito2;
            MailPerito2 = mailPerito2;
            PathTemplate = pathTemplate;
            PathSave = pathSave;
        }

        public Qdc(string descrizione)
        {
            Descrizione = descrizione;
        }

        /// <summary>
        /// Codtruttore vuoto.
        /// </summary>
        public Qdc()
        {

        }
    }

}
