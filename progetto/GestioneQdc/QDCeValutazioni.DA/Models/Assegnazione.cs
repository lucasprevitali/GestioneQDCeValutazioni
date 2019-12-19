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
        public Requisito Requisito { get; set; }
        /// <summary>
        /// qdc al quale vanno assegnati i requisiti.
        /// </summary>
        public Qdc Qdc { get; set; }
        /// <summary>
        /// voto (da 0 a 3) per un requisito di un qdc.
        /// </summary>
        public int? Voto { get; set; }
        /// <summary>
        /// codice identificativo di un requisito (A01 - A30).
        /// </summary>
        public int Codice { get; set; }
        /// <summary>
        /// Motivazione per il voto.
        /// </summary>
        public string Motivazione { get; set; }
    }
}
