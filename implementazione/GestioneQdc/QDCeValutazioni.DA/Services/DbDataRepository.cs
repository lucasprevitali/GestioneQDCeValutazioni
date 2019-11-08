using Microsoft.EntityFrameworkCore;
using QDCeValutazioni.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QDCeValutazioni.DA.Services
{
    /// <summary>
    /// Deposito di dati che implementa i metodi principale relativi al database.
    /// </summary>
    /// <typeparam name="C">Contesto di dati di riferimento</typeparam>
    /// <typeparam name="T">Modello di dati di riferimento</typeparam>
    public abstract class DbDataRepository<C, T> : IDataRepository<T> where T : BaseEntity
                                                                      where C : DbContext, new()
    {
        /// <summary>
        /// rappresenta i dati del database
        /// </summary>
        protected C context;

        /// <summary>
        /// definizione del contesto di dati del database.
        /// </summary>
        /// <param name="ctx">Contesto di dati del database.</param>
        protected DbDataRepository(C ctx)
        {
            context = ctx;
        }

        /// <summary>
        /// Ritorna un'entità in base all'id passato.
        /// funziona come una select.
        /// </summary>
        /// <param name="id">id passato per ricavare l'entità</param>
        /// <returns>Entità in base all'id</returns>
        public T Get(int id)
        {
            return Get().SingleOrDefault(be => be.Id == id);
        }

        /// <summary>
        /// Ritorna tutte le entità presenti.
        /// funziona come una select all.
        /// </summary>
        /// <returns>tutte le entità</returns>
        public virtual IQueryable<T> Get()
        {
            return context.Set<T>();
        }

        /// <summary>
        /// Inserisce una nuova entità.
        /// </summary>
        /// <param name="entity">Entità da inserire.</param>
        /// <returns>l'entità inserita</returns>
        public virtual T Insert(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Update di un'entità.
        /// </summary>
        /// <param name="entity">Entità da modificare.</param>
        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        /// <summary>
        /// Elimina un'entità.
        /// </summary>
        /// <param name="entity">Entità da eliminare.</param>
        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }
    }
}
