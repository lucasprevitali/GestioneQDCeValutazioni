using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using QDCeValutazioni.DA.Models;

namespace QDCeValutazioni.DA.Services
{
    /// <summary>
    /// Deposito dati relativo alla classe Assegnazione
    /// </summary>
    public class AssegnazioneDbDataRepository : DbDataRepository<AppDbContext, Assegnazione>, IAssegnazioneDataRepository
    {
        /// <summary>
        /// Definizione del contesto di dati.
        /// </summary>
        /// <param name="ctx">Contesto di dati del database.</param>
        public AssegnazioneDbDataRepository(AppDbContext ctx) : base(ctx)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Ritorna tutte le asseganzioni ordinate per id.
        /// </summary>
        /// <returns>Le assegnazioni ordinate per id.</returns>
        public override IQueryable<Assegnazione> Get()
        {
            return base.Get().OrderBy(s => s.Id);
        }
    }
}