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
    public class AssegnazioneViewModel : BindableBase
    {
        /// <summary>
        /// Insieme che contiene i campi di un requisito.
        /// </summary>
        public ObservableCollection<Assegnazione> Assegnazioni { get; set; }

        /// <summary>
        /// Metodo costruttore del ViewModel del requisito.
        /// </summary>
        public AssegnazioneViewModel()
        {

        }
    }
}
