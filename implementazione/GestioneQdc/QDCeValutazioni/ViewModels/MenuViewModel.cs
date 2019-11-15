using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QDCeValutazioni.Helpers;
using MVVM;

namespace QDCeValutazioni.ViewModels
{
    public class MenuViewModel : BindableBase
    {
        /// <summary>
        /// istanza dei ViewModel
        /// </summary>
        private QdcViewModel CreaQdcVM;
        private MotivazioneViewModel SelezionaQdcVM;

        /// <summary>   
        /// istanza di IDelegateCommand per la delega delle operazioni
        /// </summary>
        public IDelegateCommand QdcListCommand { get; set; }
        public IDelegateCommand MotivazioneListCommand { get; set; }

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
        /// Metodo costruttore del ViewModel.
        /// </summary>
        public MenuViewModel()
        {
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            CreaQdcVM = new QdcViewModel();
            SelezionaQdcVM = new MotivazioneViewModel();
            QdcListCommand = new DelegateCommand(OnQdcList, CanQdcList);
            MotivazioneListCommand = new DelegateCommand(OnMotivazioneList, CanMotivazioneList);
        }

        private void OnQdcList(object obj) { Messenger.Default.Send<BindableBase>(CreaQdcVM); }
        private bool CanQdcList(object arg) { return true; }
        private void OnMotivazioneList(object obj) { Messenger.Default.Send<BindableBase>(SelezionaQdcVM); }
        private bool CanMotivazioneList(object arg) { return true; }
    }
}
