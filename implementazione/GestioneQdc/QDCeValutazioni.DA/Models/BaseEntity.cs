using System;
using System.Collections.Generic;
using System.Text;

namespace QDCeValutazioni.DA.Models
{
    /// <summary>
    /// BaseEntity è la classe che implementano
    /// tutte le altre classi.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Numero identificativo che serve a tutte le classi
        /// </summary>
        public int Id { get; set; }
    }
}