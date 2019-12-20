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
using System.Windows;

namespace QDCeValutazioni.ViewModels
{
    public class MotivazioneViewModel : BindableBase
    {
        /// <summary>
        /// Insieme che contiene i campi di un requisito.
        /// </summary>
        public ObservableCollection<Assegnazione> Motivazioni { get; set; }
        AssegnazioneDbDataRepository repoAss;
        Assegnazione Ass;

        /// <summary>   
        /// istanza di IDelegateCommand per la delega delle operazioni
        /// </summary>
        public IDelegateCommand SaveVoto { get; set; }

        /// <summary>
        /// Insieme che contiene i campi di un Qdc.
        /// </summary>
        public ObservableCollection<Qdc> Qdcs { get; set; }
        QdcDbDataRepository repoQdc;

        /// <summary>
        /// Metodo costruttore del ViewModel del requisito.
        /// </summary>
        public MotivazioneViewModel()
        {
            SaveVoto = new DelegateCommand(OnSaveClick, CanSaveClick);

            AppDbContext ctx = new AppDbContext();
            repoQdc = new QdcDbDataRepository(ctx);
            repoAss = new AssegnazioneDbDataRepository(ctx);
            try
            {
                int ind = repoQdc.Get().Where(q1 => q1.Id == q1.Id).Max(q1 => q1.Id);
                Motivazioni = new ObservableCollection<Assegnazione>(repoAss.Get().Where(a1 => a1.QdcId == ind));
                Ass = Motivazioni[0];
            }
            catch(Exception e)
            {
                if(e is ArgumentOutOfRangeException || e is InvalidOperationException)
                    MessageBox.Show("Non esistono requisiti assegnati a questo Qdc");
            }
        }

        /// <summary>
        /// Metodo per spostarsi in VisualizzVotiView.
        /// </summary>
        /// <param name="obj"></param>
        private void OnSaveClick(object obj)
        {
            Messenger.Default.Send<BindableBase>(new VisualizzaVotiViewModel());
        }

        private bool CanSaveClick(object arg)
        {
            return true;
        }
    }
}
