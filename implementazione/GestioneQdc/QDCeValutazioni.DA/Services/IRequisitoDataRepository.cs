using System;
using System.Collections.Generic;
using System.Text;
using QDCeValutazioni.DA.Models;

namespace QDCeValutazioni.DA.Services
{
    /// <summary>
    /// Interfaccia che implementa i metodi principali relativi al database
    /// (presenti in IDataRepository), relativi al modello corrente, cioè Requisito.
    /// </summary>
    public interface IRequisitoDataRepository : IDataRepository<Requisito>
    {
    }
}
