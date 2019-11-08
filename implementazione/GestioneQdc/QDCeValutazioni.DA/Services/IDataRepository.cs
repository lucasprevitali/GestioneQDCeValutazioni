using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using QDCeValutazioni.DA.Models;

namespace QDCeValutazioni.DA.Services
{
    /// <summary>
    /// Interfaccia di base che implementa i metodi relativi alle 
    /// operazioni principali sui dati di un database.
    /// </summary>
    /// <typeparam name="T">Modello di dati di riferimento</typeparam>
    public interface IDataRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Ritorna un'entità in base all'id passato.
        /// funziona come una select.
        /// </summary>
        /// <param name="id">id passato per ricavare l'entità</param>
        /// <returns>Entità in base all'id</returns>
        T Get(int id);

        /// <summary>
        /// Ritorna tutte le entità presenti.
        /// funziona come una select all.
        /// </summary>
        /// <returns>tutte le entità</returns>
        IQueryable<T> Get();

        /// <summary>
        /// Inserisce una nuova entità.
        /// </summary>
        /// <param name="entity">Entità da inserire.</param>
        /// <returns>l'entità inserita</returns>
        T Insert(T entity);

        /// <summary>
        /// Update di un'entità.
        /// </summary>
        /// <param name="entity">Entità da modificare.</param>
        void Update(T entity);

        /// <summary>
        /// Elimina un'entità.
        /// </summary>
        /// <param name="entity">Entità da eliminare.</param>
        void Delete(T entity);
    }
}
