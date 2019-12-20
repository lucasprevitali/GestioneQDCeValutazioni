using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDCeValutazioni.DA.Models
{
    public class Assegnazione : BaseEntity
    {
        /// <summary>
        /// Requisito da assegnare a un qdc.
        /// </summary>
        public virtual Requisito Requisito { get; set; }
        public int RequisitoId { get; set; }
        /// <summary>
        /// qdc al quale vanno assegnati i requisiti.
        /// </summary>
        public virtual Qdc Qdc { get; set; }
        public int QdcId { get; set; }
        /// <summary>
        /// voto (da 0 a 3) per un requisito di un qdc.
        /// </summary>
        public int? Voto { get; set; }
        /// <summary>
        /// codice identificativo di un requisito (A01 - A30).
        /// </summary>
        public string Codice { get; set; }
        /// <summary>
        /// Motivazione per il voto.
        /// </summary>
        public string Motivazione { get; set; }

        /// <summary>
        /// Costruttore per l'inserimento di assegnazione tramite parametri
        /// </summary>
        /// <param name="codice"></param>
        /// <param name="qdc"></param>
        /// <param name="req"></param>
        public Assegnazione(string codice , Qdc qdc, int req)
        {
            Codice = codice;
            QdcId = qdc.Id;
            RequisitoId = req;
        }

        /// <summary>
        /// Codtruttore vuoto.
        /// </summary>
        public Assegnazione()
        {

        }
    }
}
