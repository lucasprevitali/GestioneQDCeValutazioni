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
    public class RequisitoViewModel : BindableBase
    {
        /// <summary>
        /// Insieme che contiene i campi di un requisito.
        /// </summary>
        public ObservableCollection<Requisito> Requisiti { get; set; }

        private MotivazioneViewModel MotivazioneVM;

        public IDelegateCommand MotivazioneCommand { get; set; }

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
        /// Metodo costruttore del ViewModel del requisito.
        /// </summary>
        public RequisitoViewModel()
        {
            RegisterCommands();
            //RequisitoDbDataRepository repo = new RequisitoDbDataRepository(new AppDbContext());
            //Requisiti = new ObservableCollection<Requisito>(repo.Get());
        }

        private void RegisterCommands()
        {
            MotivazioneVM = new MotivazioneViewModel();
            MotivazioneCommand = new DelegateCommand(OnMotivazioneList, CanMotivazioneList);
        }

        private void OnMotivazioneList(object obj) { Messenger.Default.Send<BindableBase>(MotivazioneVM); }
        private bool CanMotivazioneList(object arg) { return true; }
    }
}
