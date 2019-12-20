using MVVM;
using QDCeValutazioni.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDCeValutazioni.ViewModels
{
    public class MainViewModel : BindableBase
    {
        /// <summary>
        /// istanza dei ViewModel
        /// </summary>
        private QdcViewModel QdcVM;
        private SelezionaViewModel SelezionaVM;
        private MenuViewModel MenuVM;

        /// <summary>   
        /// istanza di IDelegateCommand per la delega delle operazioni
        /// </summary>
        public IDelegateCommand QdcListCommand { get; set; }
        public IDelegateCommand SelezionaListCommand { get; set; }
        public IDelegateCommand MenuListCommand { get; set; }

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
        /// Costruttore che richiama RegisterCommands()
        /// </summary>
        public MainViewModel()
        {
            RegisterCommands();
        }

        /// <summary>
        /// Delega delle operazioni a DelegateCommand
        /// </summary>
        private void RegisterCommands()
        {
            MenuVM = new MenuViewModel();     
            QdcVM = new QdcViewModel();
            SelezionaVM = new SelezionaViewModel();
            QdcListCommand = new DelegateCommand(OnQdcList, CanQdcList);
            SelezionaListCommand = new DelegateCommand(OnSelezionaList, CanSelezionaList);
            MenuListCommand = new DelegateCommand(OnMenuList, CanMenuList);
            // la view di partenza è quella del menu.
            currentViewModel = MenuVM;
            RegisterMessages();
        }

        /// <summary>
        /// Gestione dei messaggi dei viewmodel
        /// </summary>
        private void RegisterMessages()
        {
            Messenger.Default.Register<BindableBase>(this, OnViewModelReceived);
        }

        /// <summary>
        /// Impostazione del viewmodel in base al messaggio
        /// </summary>
        /// <param name="viewmodel">ViewModel da impostare.</param>
        public void OnViewModelReceived(BindableBase viewmodel)
        {
            CurrentViewModel = viewmodel;
        }

        /// <summary>
        /// Attribuzione del ViewModel da mostrare
        /// </summary>
        /// <param name="obj"></param>
        private void OnQdcList(object obj)
        {
            if(CurrentViewModel == MenuVM)
                CurrentViewModel = QdcVM;
        }

        private bool CanQdcList(object arg)
        {
            return true;
        }

        private bool CanDescrizioneList(object arg)
        {
            return true;
        }

        private void OnSelezionaList(object obj)
        {
            if (CurrentViewModel == MenuVM)
                CurrentViewModel = SelezionaVM;
        }

        private bool CanSelezionaList(object arg)
        {
            return true;
        }

        private void OnMenuList(object obj)
        {
            CurrentViewModel = MenuVM;
        }

        private bool CanMenuList(object arg)
        {
            return true;
        }
    }
}
