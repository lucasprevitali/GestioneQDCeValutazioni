using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;
using QDCeValutazioni.DA;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using Microsoft.Office.Interop.Word;
using QDCeValutazioni.DA.Models;
using System.Collections.ObjectModel;
using QDCeValutazioni.DA.Services;

namespace QDCeValutazioni.ViewModels
{
    public class VisualizzaViewModel : BindableBase
    {
        /// <summary>
        /// Insieme che contiene i campi di un Qdc.
        /// </summary>
        public ObservableCollection<Qdc> Qdcs { get; set; }
        QdcDbDataRepository repoQdc;

        /// <summary>   
        /// istanza di IDelegateCommand per la delega delle operazioni
        /// </summary>
        public IDelegateCommand VisualizzaQdc { get; set; }
        public IDelegateCommand MenuCommand { get; set; }

        public VisualizzaViewModel()
        {
            AppDbContext ctx = new AppDbContext();
            repoQdc = new QdcDbDataRepository(ctx);
            MenuCommand = new DelegateCommand(OnMenuClick, CanMenuClick);
            VisualizzaQdc = new DelegateCommand(OnVisualizzaClick, CanVisualizzaClick);
        }

        /// <summary>
        /// Metodo per visualizzare il file Qdc appena creato.
        /// </summary>
        /// <param name="obj"></param>
        private void OnVisualizzaClick(object obj)
        {
            // ricavo l'ultimo Qdc creato.
            int ind = repoQdc.Get().Where(q1 => q1.Id == q1.Id).Max(q1 => q1.Id);
            Qdcs = new ObservableCollection<Qdc>(repoQdc.Get().Where(q1 => q1.Id == ind));
            Qdc q = Qdcs[0];
            try
            {
                // apro il file.
                Application application = new Application();
                application.Visible = true;
                Document file = application.Documents.Open(q.PathSave);
                //application.Quit();
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                System.Windows.MessageBox.Show("Errore con l'apertura del file");
            }
        }

        private bool CanVisualizzaClick(object arg)
        {
            return true;
        }

        /// <summary>
        /// Metodo per Tornare al Menu Principale.
        /// </summary>
        /// <param name="obj"></param>
        private void OnMenuClick(object obj)
        {
            Messenger.Default.Send<BindableBase>(new MenuViewModel());
        }

        private bool CanMenuClick(object arg)
        {
            return true;
        }
    }
}
