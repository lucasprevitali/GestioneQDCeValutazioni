using QDCeValutazioni.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDCeValutazioni.DA.Services
{
    /// <summary>
    /// Deposito dati relativo alla classe Qdc
    /// </summary>
    public class QdcDbDataRepository : DbDataRepository<AppDbContext, Qdc>, IQdcDataRepository
    {
        /// <summary>
        /// Definizione del contesto di dati.
        /// </summary>
        /// <param name="ctx">Contesto di dati del database.</param>
        public QdcDbDataRepository(AppDbContext ctx) : base(ctx)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Ritorna tutte le asseganzioni ordinate per Id.
        /// </summary>
        /// <returns>Le assegnazioni ordinate per Id.</returns>
        public override IQueryable<Qdc> Get()
        {
            return base.Get().OrderBy(s => s.Id);
        }

        /// <summary>
        /// Esegue un update della tabella Qdc sulla base di un entità Qdc
        /// </summary>
        /// <param name="entity">Le modifiche da eseguire</param>
        public override void Update(Qdc entity)
        {
            base.Update(entity);
        }
    }
}
