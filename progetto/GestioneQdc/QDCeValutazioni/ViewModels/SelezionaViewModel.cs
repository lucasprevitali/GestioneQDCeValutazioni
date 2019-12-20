using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;
using QDCeValutazioni.DA;
using QDCeValutazioni.DA.Models;
using QDCeValutazioni.DA.Services;

namespace QDCeValutazioni.ViewModels
{
    public class SelezionaViewModel : BindableBase
    {
        /// <summary>
        /// Insieme che contiene i campi di un Qdc.
        /// </summary>
        public ObservableCollection<Qdc> Qdcs { get; set; }
        QdcDbDataRepository repoQdc;

        /// <summary>   
        /// istanza di IDelegateCommand per la delega delle operazioni
        /// </summary>
        public IDelegateCommand SelezionaCommand { get; set; }

        public SelezionaViewModel()
        {
            SelezionaCommand = new DelegateCommand(OnSeleziona, CanSeleziona);
            repoQdc = new QdcDbDataRepository(new AppDbContext());
            Qdcs = new ObservableCollection<Qdc>(repoQdc.Get());
        }
  
        private void OnSeleziona(object obj)
        {
            Messenger.Default.Send<BindableBase>(new MotivazioneViewModel());
        }

        private bool CanSeleziona(object arg)
        {
            return true;
        }
    }
}
