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
        /// istanza di IDelegateCommand per la delega delle operazioni
        /// </summary>
        public IDelegateCommand QdcListCommand { get; set; }
        public IDelegateCommand SelezionaListCommand { get; set; }

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
            QdcListCommand = new DelegateCommand(OnQdcList, CanQdcList);
            SelezionaListCommand = new DelegateCommand(OnSelezionaList, CanSelezionaList);
        }

        private void RegisterCommands()
        {
            
        }

        /// <summary>
        /// Metodo per spostarsi in QdcView.
        /// </summary>
        /// <param name="obj"></param>
        private void OnQdcList(object obj)
        {
            Messenger.Default.Send<BindableBase>(new QdcViewModel());
        }

        private bool CanQdcList(object arg)
        {
            return true;
        }

        /// <summary>
        /// Metodo per spostarsi in SelezionaView.
        /// </summary>
        /// <param name="obj"></param>
        private void OnSelezionaList(object obj)
        {
            Messenger.Default.Send<BindableBase>(new SelezionaViewModel());
        }

        private bool CanSelezionaList(object arg)
        {
            return true;
        }
    }
}
