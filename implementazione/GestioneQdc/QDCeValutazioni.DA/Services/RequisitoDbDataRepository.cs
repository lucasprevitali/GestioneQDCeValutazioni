using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using QDCeValutazioni.DA.Models;

namespace QDCeValutazioni.DA.Services
{
    /// <summary>
    /// Deposito dati relativo alla classe Requisito
    /// </summary>
    public class RequisitoDbDataRepository : DbDataRepository<AppDbContext, Requisito>, IRequisitoDataRepository
    {
        /// <summary>
        /// Definizione del contesto di dati.
        /// </summary>
        /// <param name="ctx">Contesto di dati del database.</param>
        public RequisitoDbDataRepository(AppDbContext ctx) : base(ctx)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ritorna tutti requisiti ordinati per titolo.
        /// </summary>
        /// <returns>i requisiti ordinati per titolo.</returns>
        public override IQueryable<Requisito> Get()
        {
            return base.Get().OrderBy(s => s.Titolo);
        }
    }
}