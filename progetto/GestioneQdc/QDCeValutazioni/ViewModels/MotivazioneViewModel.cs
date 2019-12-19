using QDCeValutazioni.DA;
using QDCeValutazioni.DA.Models;
using QDCeValutazioni.DA.Services;
using QDCeValutazioni.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace QDCeValutazioni.ViewModels
{
    public class MotivazioneViewModel : BindableBase
    {
        /// <summary>
        /// Insieme che contiene i campi di un requisito.
        /// </summary>
        public ObservableCollection<Assegnazione> Motivazioni { get; set; }

        /// <summary>
        /// Metodo costruttore del ViewModel del requisito.
        /// </summary>
        public MotivazioneViewModel()
        {
            //AssegnazioneDbDataRepository repo = new AssegnazioneDbDataRepository(new AppDbContext());
            //Motivazioni = new ObservableCollection<Assegnazione>(repo.Get());
        }
    }
}
