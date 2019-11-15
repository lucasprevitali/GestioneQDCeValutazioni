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
using QDCeValutazioni.Views;
using Word = Microsoft.Office.Interop.Word;

namespace QDCeValutazioni.ViewModels
{
    public class QdcViewModel : BindableBase
    {
        /// <summary>
        /// Insieme che contiene i campi di un Qdc.
        /// </summary>
        public ObservableCollection<Qdc> Qdcs { get; set; }

        private DescrizioneViewModel DescrizioneVM;

        public IDelegateCommand DescrizioneCommand { get; set; }
        public IDelegateCommand SaveInfo { get; set; }

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
        public QdcViewModel()
        {
            RegisterCommands();

            AppDbContext ctx = new AppDbContext();
            QdcDbDataRepository repo = new QdcDbDataRepository(ctx);
            Qdcs = new ObservableCollection<Qdc>(repo.Get());
        }

        private void RegisterCommands()
        {
            DescrizioneVM = new DescrizioneViewModel();
            DescrizioneCommand = new DelegateCommand(OnDescrizioneList, CanDescrizioneList);
            SaveInfo = new DelegateCommand(OnSaveInfo, CanSaveInfo);
        }

        private bool CanSaveInfo(object arg)
        {
            return true;
        }

        private void OnSaveInfo(object obj)
        {
            //Qdcs.Insert(2, null);
        }

        private void OnDescrizioneList(object obj)
        {
            Messenger.Default.Send<BindableBase>(DescrizioneVM);
        }
        private bool CanDescrizioneList(object arg)
        {
            return true;
        }
    }
}
