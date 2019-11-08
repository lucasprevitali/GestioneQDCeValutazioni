using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDCeValutazioni.DA.Models
{
    public class Requisito : BaseEntity
    {
        /// <summary>
        /// id identificativo di un requisito.
        /// </summary>
        //[Key]
        //public int Id { get; set; }

        /// <summary>
        /// titolo del requisito.
        /// </summary>
        public string Titolo { get; set; }

        /// <summary>
        /// descrizione del requisito.
        /// </summary>
        public string Descrizione { get; set; }
    }
}
