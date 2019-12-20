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
        public class DescrizioneViewModel : BindableBase
        {
        /// <summary>
        /// Insieme che contiene i campi di un Qdc.
        /// </summary>
        public ObservableCollection<Qdc> Descrizioni { get; set; }

        //private RequisitoViewModel RequistoVM;

        public IDelegateCommand RequisitoCommand { get; set; }
        //public IDelegateCommand SaveDescrizione { get; set; }

        public string Descrizione { get; set; }
        //public int id { get; set; }

        /// <summary>
        /// ViewModel da mostrare
        /// </summary>
        private BindableBase currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { SetProperty(ref currentViewModel, value); }
        }

        /// <summary>
        /// Metodo costruttore del ViewModel del Qdc.
        /// </summary>
        public DescrizioneViewModel()
        {
            //RegisterCommands();
            //QdcDbDataRepository repo = new QdcDbDataRepository(new AppDbContext());
            //Descrizioni = new ObservableCollection<Qdc>(repo.Get());
        }
    }
}
