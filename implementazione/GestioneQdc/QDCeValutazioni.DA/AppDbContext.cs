using QDCeValutazioni.DA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace QDCeValutazioni.DA
{
    /// <summary>
    /// Classe che imposta le entità del database e il percorso
    /// di salvataggio del db.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Raccolta di Qdc.
        /// </summary>
        public DbSet<Qdc> Qdcs { get; set; }

        /// <summary>
        /// Raccolta di Requisiti.
        /// </summary>
        public DbSet<Requisito> Requisiti { get; set; }

        /// <summary>
        /// Raccolta di Assegnazioni.
        /// </summary>
        public DbSet<Assegnazione> Assegnazioni { get; set; }

        /// <summary>
        /// Metodo costruttore vuoto (ereditato).
        /// Ev. potrei mettere come parametro il nome (es: DefaultConnection)
        /// </summary>
        public AppDbContext() : base()
        {
        
        }

        /// <summary>
        /// preparazione database (costruttore alternativo).
        /// </summary>
        /// <param name="options">Configurazioni del database.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Percorso di salvataggio del database e dei dati.
        /// </summary>
        /// <param name="optionsBuilder">Opzioni del contesto di dati presenti nel sistema.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\lucas\\source\\repos\\GestioneQdc" +
                    "\\QDCeValutazioni.DA\\QdcDb.sqlite");
            }
        }
    }
}
