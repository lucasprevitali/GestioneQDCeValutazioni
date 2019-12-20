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
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;

namespace QDCeValutazioni.ViewModels
{
    public class RequisitoViewModel : BindableBase
    {
        /// <summary>
        /// Insieme che contiene i campi di un requisito.
        /// </summary>
        public ObservableCollection<Requisito> Requisiti { get; set; }
        public ObservableCollection<Requisito> CheckRequisiti { get; set; }

        /// <summary>
        /// Insieme che contiene i campi di un Qdc.
        /// </summary>
        public ObservableCollection<Qdc> Qdcs { get; set; }

        /// <summary>
        /// Insieme che contiene i campi delle Assegnazioni.
        /// </summary>
        public ObservableCollection<Assegnazione> Assegnazioni { get; set; }
        RequisitoDbDataRepository repo;

        /// <summary>   
        /// istanza di IDelegateCommand per la delega delle operazioni
        /// </summary>
        public IDelegateCommand ContinuaCommand { get; set; }
        public IDelegateCommand CercaA14 { get; set; }
        public IDelegateCommand CercaA15 { get; set; }
        public IDelegateCommand CercaA16 { get; set; }
        public IDelegateCommand CercaA17 { get; set; }
        public IDelegateCommand CercaA18 { get; set; }
        public IDelegateCommand CercaA19 { get; set; }
        public IDelegateCommand CercaA20 { get; set; }

        /// <summary>
        /// Variabili relative ai TextBox contenenti gli Id 
        /// dei requisiti da cercare (Binding).
        /// </summary>
        public string Cod14 { get; set; }
        public string Cod15 { get; set; }
        public string Cod16 { get; set; }
        public string Cod17 { get; set; }
        public string Cod18 { get; set; }
        public string Cod19 { get; set; }
        public string Cod20 { get; set; }

        /// <summary>
        /// Variabili alle quali assegnare l'Id e 
        /// il titolo dei Requisiti trovati.
        /// </summary>
        public int Id14 { get; set; }
        public int Id15 { get; set; }
        public int Id16 { get; set; }
        public int Id17 { get; set; }
        public int Id18 { get; set; }
        public int Id19 { get; set; }
        public int Id20 { get; set; }
        public string Titolo14 { get; set; }
        public string Titolo15 { get; set; }
        public string Titolo16 { get; set; }
        public string Titolo17 { get; set; }
        public string Titolo18 { get; set; }
        public string Titolo19 { get; set; }
        public string Titolo20 { get; set; }


        /// <summary>
        /// Array contenente i codici dei requisiti standard
        /// </summary>
        string[] codici = { "a1", "a2", "a3", "a4", "a5", "a6", "a7", "a8",
            "a9", "a10", "a11", "a12", "a13", "b1", "b2", "b3", "b4", "b5", "b6",
            "b7", "b8", "b9", "b10", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "c10"};
        bool generale = false;
        bool standard = false;
        int[] controllo = { 0, 0, 0, 0, 0, 0, 0 };

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
            
            repo = new RequisitoDbDataRepository(new AppDbContext());
            CercaA14 = new DelegateCommand(OnA14, CanA14);
            CercaA15 = new DelegateCommand(OnA15, CanA15);
            CercaA16 = new DelegateCommand(OnA16, CanA16);
            CercaA17 = new DelegateCommand(OnA17, CanA17);
            CercaA18 = new DelegateCommand(OnA18, CanA18);
            CercaA19 = new DelegateCommand(OnA19, CanA19);
            CercaA20 = new DelegateCommand(OnA20, CanA20);
        }

        private bool CanA14(object arg)
        {
            return true;
        }

        /// <summary>
        /// Metodo per cercare il requisito a14 sulla base di
        /// ciò che ha inserito l'utente.
        /// </summary>
        /// <param name="obj"></param>
        private void OnA14(object obj)
        {
            generale = false;
            CheckRequisiti = new ObservableCollection<Requisito>(repo.Get());

            // controllo che il requisito scelto non sia uno di quelli standard.
            for (int i = 0; i < 33; i++)
            {
                if(Cod14 == codici[i])
                {
                    MessageBox.Show("Inserisci un valore valido");
                    break;
                }
                else
                {
                    standard = true;
                }
            }
            if (standard)
            {
                // confronto ogni requisito esistente con l'Id inserito dall'utente.
                for(int i = 0; i < CheckRequisiti.Count; i++)
                {
                    if(Cod14 == CheckRequisiti[i].CodiceReq)
                    {
                        try
                        {
                            // ricavo l'Id e il Titolo del requisito.
                            Requisiti = new ObservableCollection<Requisito>(repo.Get().Where(r => r.CodiceReq == Cod14));
                            Requisito r14 = Requisiti[0];
                            Id14 = r14.Id;
                            Titolo14 = r14.Titolo;
                            controllo[0] = 1;
                            generale = true;
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            MessageBox.Show("Inserisci un valore valido");
                        }
                    }
                }

                if (!generale)
                {
                    MessageBox.Show("Inserisci un valore valido");
                }
            }
           
        }

        // tutti gli altri metodi funzionano allo stesso modo.

        private bool CanA15(object arg)
        {
            return true;
        }

        private void OnA15(object obj)
        {
            generale = false;
            CheckRequisiti = new ObservableCollection<Requisito>(repo.Get());

            // controllo che il requisito scelto non sia uno di quelli standard.
            for (int i = 0; i < 33; i++)
            {
                if (Cod15 == codici[i])
                {
                    MessageBox.Show("Inserisci un valore valido");
                    break;
                }
                else
                {
                    standard = true;
                }
            }
            if (standard)
            {
                // confronto ogni requisito esistente con l'Id inserito dall'utente.
                for (int i = 0; i < CheckRequisiti.Count; i++)
                {
                    if (Cod15 == CheckRequisiti[i].CodiceReq)
                    {
                        try
                        {
                            // ricavo l'Id e il Titolo del requisito.
                            Requisiti = new ObservableCollection<Requisito>(repo.Get().Where(r => r.CodiceReq == Cod15));
                            Requisito r15 = Requisiti[0];
                            Id15 = r15.Id;
                            Titolo15 = r15.Titolo;
                            controllo[0] = 1;
                            generale = true;
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            MessageBox.Show("Inserisci un valore valido");
                        }
                    }
                }

                if (!generale)
                {
                    MessageBox.Show("Inserisci un valore valido");
                }
            }
        }

        private bool CanA16(object arg)
        {
            return true;
        }

        private void OnA16(object obj)
        {
            generale = false;
            CheckRequisiti = new ObservableCollection<Requisito>(repo.Get());

            // controllo che il requisito scelto non sia uno di quelli standard.
            for (int i = 0; i < 33; i++)
            {
                if (Cod16 == codici[i])
                {
                    MessageBox.Show("Inserisci un valore valido");
                    break;
                }
                else
                {
                    standard = true;
                }
            }
            if (standard)
            {
                // confronto ogni requisito esistente con l'Id inserito dall'utente.
                for (int i = 0; i < CheckRequisiti.Count; i++)
                {
                    if (Cod16 == CheckRequisiti[i].CodiceReq)
                    {
                        try
                        {
                            // ricavo l'Id e il Titolo del requisito.
                            Requisiti = new ObservableCollection<Requisito>(repo.Get().Where(r => r.CodiceReq == Cod16));
                            Requisito r16 = Requisiti[0];
                            Id16 = r16.Id;
                            Titolo16 = r16.Titolo;
                            controllo[0] = 1;
                            generale = true;
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            MessageBox.Show("Inserisci un valore valido");
                        }
                    }
                }

                if (!generale)
                {
                    MessageBox.Show("Inserisci un valore valido");
                }
            }
        }

        private bool CanA17(object arg)
        {
            return true;
        }

        private void OnA17(object obj)
        {
            generale = false;
            CheckRequisiti = new ObservableCollection<Requisito>(repo.Get());

            // controllo che il requisito scelto non sia uno di quelli standard.
            for (int i = 0; i < 33; i++)
            {
                if (Cod17 == codici[i])
                {
                    MessageBox.Show("Inserisci un valore valido");
                    break;
                }
                else
                {
                    standard = true;
                }
            }
            if (standard)
            {
                // confronto ogni requisito esistente con l'Id inserito dall'utente.
                for (int i = 0; i < CheckRequisiti.Count; i++)
                {
                    if (Cod17 == CheckRequisiti[i].CodiceReq)
                    {
                        try
                        {
                            // ricavo l'Id e il Titolo del requisito.
                            Requisiti = new ObservableCollection<Requisito>(repo.Get().Where(r => r.CodiceReq == Cod17));
                            Requisito r17 = Requisiti[0];
                            Id17 = r17.Id;
                            Titolo17 = r17.Titolo;
                            controllo[0] = 1;
                            generale = true;
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            MessageBox.Show("Inserisci un valore valido");
                        }
                    }
                }

                if (!generale)
                {
                    MessageBox.Show("Inserisci un valore valido");
                }
            }
        }

        private bool CanA18(object arg)
        {
            return true;
        }

        private void OnA18(object obj)
        {
            generale = false;
            CheckRequisiti = new ObservableCollection<Requisito>(repo.Get());

            // controllo che il requisito scelto non sia uno di quelli standard.
            for (int i = 0; i < 33; i++)
            {
                if (Cod18 == codici[i])
                {
                    MessageBox.Show("Inserisci un valore valido");
                    break;
                }
                else
                {
                    standard = true;
                }
            }
            if (standard)
            {
                // confronto ogni requisito esistente con l'Id inserito dall'utente.
                for (int i = 0; i < CheckRequisiti.Count; i++)
                {
                    if (Cod18 == CheckRequisiti[i].CodiceReq)
                    {
                        try
                        {
                            // ricavo l'Id e il Titolo del requisito.
                            Requisiti = new ObservableCollection<Requisito>(repo.Get().Where(r => r.CodiceReq == Cod18));
                            Requisito r18 = Requisiti[0];
                            Id18 = r18.Id;
                            Titolo18 = r18.Titolo;
                            controllo[0] = 1;
                            generale = true;
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            MessageBox.Show("Inserisci un valore valido");
                        }
                    }
                }

                if (!generale)
                {
                    MessageBox.Show("Inserisci un valore valido");
                }
            }
        }

        private bool CanA19(object arg)
        {
            return true;
        }

        private void OnA19(object obj)
        {
            generale = false;
            CheckRequisiti = new ObservableCollection<Requisito>(repo.Get());

            // controllo che il requisito scelto non sia uno di quelli standard.
            for (int i = 0; i < 33; i++)
            {
                if (Cod19 == codici[i])
                {
                    MessageBox.Show("Inserisci un valore valido");
                    break;
                }
                else
                {
                    standard = true;
                }
            }
            if (standard)
            {
                // confronto ogni requisito esistente con l'Id inserito dall'utente.
                for (int i = 0; i < CheckRequisiti.Count; i++)
                {
                    if (Cod19 == CheckRequisiti[i].CodiceReq)
                    {
                        try
                        {
                            // ricavo l'Id e il Titolo del requisito.
                            Requisiti = new ObservableCollection<Requisito>(repo.Get().Where(r => r.CodiceReq == Cod19));
                            Requisito r19 = Requisiti[0];
                            Id19 = r19.Id;
                            Titolo19 = r19.Titolo;
                            controllo[0] = 1;
                            generale = true;
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            MessageBox.Show("Inserisci un valore valido");
                        }
                    }
                }

                if (!generale)
                {
                    MessageBox.Show("Inserisci un valore valido");
                }
            }
        }

        private bool CanA20(object arg)
        {
            return true;
        }

        private void OnA20(object obj)
        {
            generale = false;
            CheckRequisiti = new ObservableCollection<Requisito>(repo.Get());

            // controllo che il requisito scelto non sia uno di quelli standard.
            for (int i = 0; i < 33; i++)
            {
                if (Cod20 == codici[i])
                {
                    MessageBox.Show("Inserisci un valore valido");
                    break;
                }
                else
                {
                    standard = true;
                }
            }
            if (standard)
            {
                // confronto ogni requisito esistente con l'Id inserito dall'utente.
                for (int i = 0; i < CheckRequisiti.Count; i++)
                {
                    if (Cod20 == CheckRequisiti[i].CodiceReq)
                    {
                        try
                        {
                            // ricavo l'Id e il Titolo del requisito.
                            Requisiti = new ObservableCollection<Requisito>(repo.Get().Where(r => r.CodiceReq == Cod20));
                            Requisito r20 = Requisiti[0];
                            Id20 = r20.Id;
                            Titolo20 = r20.Titolo;
                            controllo[0] = 1;
                            generale = true;
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            MessageBox.Show("Inserisci un valore valido");
                        }
                    }
                }

                if (!generale)
                {
                    MessageBox.Show("Inserisci un valore valido");
                }
            }
        }

        private void RegisterCommands()
        {
            //VisualizzaVM = new VisualizzaViewModel();
            ContinuaCommand = new DelegateCommand(OnVisualizzaClick, CanVisualizzaClick);
        }

        /// <summary>
        /// Metodo per salvare i dati sul database e sul file Word.
        /// </summary>
        /// <param name="obj"></param>
        private void OnVisualizzaClick(object obj) {
            // controllo che siano stati scelti tutti i requisiti.
            if(controllo[0] == 1 && controllo[1] == 1 &&
                controllo[2] == 1 && controllo[3] == 1 &&
                controllo[4] == 1 && controllo[5] == 1 && controllo[6] == 1)
            {
                AppDbContext ctx = new AppDbContext();
                AssegnazioneDbDataRepository repoAss = new AssegnazioneDbDataRepository(ctx);

                // ricavo l'ultimo Qdc creato (quello al quale assegnare i Qdc).
                QdcDbDataRepository repoQdc = new QdcDbDataRepository(ctx);
                int ind = repoQdc.Get().Where(q1 => q1.Id == q1.Id).Max(q1 => q1.Id);
                Qdcs = new ObservableCollection<Qdc>(repoQdc.Get().Where(q1 => q1.Id == ind));
                Qdc q = Qdcs[0];

                // inserisco tutti i requisiti standard.
                for (int i = 0; i < codici.Length; i++)
                {
                    repoAss.Insert(new Assegnazione(codici[i], q, i + 1));
                }

                // inserisco i requisiti scelti dall'utente.
                repoAss.Insert(new Assegnazione(Cod14, q, Id14));
                repoAss.Insert(new Assegnazione(Cod15, q, Id15));
                repoAss.Insert(new Assegnazione(Cod16, q, Id16));
                repoAss.Insert(new Assegnazione(Cod17, q, Id17));
                repoAss.Insert(new Assegnazione(Cod18, q, Id18));
                repoAss.Insert(new Assegnazione(Cod19, q, Id19));
                repoAss.Insert(new Assegnazione(Cod20, q, Id20));

                // metodo per il salvataggio su Word.
                SaveInFile(q);

                // mi sposto in VisualizzaView.
                Messenger.Default.Send<BindableBase>(new VisualizzaViewModel());
            }
            else
            {
                MessageBox.Show("Inserisci tutti i requisiti");
            }
            
        }

        private bool CanVisualizzaClick(object arg) { return true; }

        /// <summary>
        /// Metodo per salvare i dati sul file Word.
        /// </summary>
        /// <param name="q">Qdc contenente il percorso del file</param>
        private void SaveInFile(Qdc q)
        {
            // percorsi dei file.
            var pathTemplate = q.PathTemplate;
            var pathSave = q.PathSave;

            // pattern da modificare.
            var a14Key = "<a14>";
            var a15Key = "<a15>";
            var a16Key = "<a16>";
            var a17Key = "<a17>";
            var a18Key = "<a18>";
            var a19Key = "<a19>";
            var a20Key = "<a20>";
            var req14Key = "<Req14>";
            var req15Key = "<Req15>";
            var req16Key = "<Req16>";
            var req17Key = "<Req17>";
            var req18Key = "<Req18>";
            var req19Key = "<Req19>";
            var req20Key = "<Req20>";

            try
            {
                object missing = Missing.Value;
                // crea l'oggetto che contiene l'istanza di Word
                Word.Application wordApp = new Word.Application();
                //  crea l'oggetto che contiene il documento
                Word.Document aDoc = null;
                // oggetto che definisce il file copiato (e da modificare)
                object filename = pathSave;
                // Se il file esiste
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    wordApp.Visible = false;
                    // apertura del file copiato
                    aDoc = wordApp.Documents.Open(ref filename, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);
                    aDoc.Activate();
                    // richiama la funzione FindAndReplace passandogli due parametri,
                    // il testo da sostituire e con cosa sostituirlo
                    this.FindAndReplace(wordApp, a14Key, Cod14);
                    this.FindAndReplace(wordApp, a15Key, Cod15);
                    this.FindAndReplace(wordApp, a16Key, Cod16);
                    this.FindAndReplace(wordApp, a17Key, Cod17);
                    this.FindAndReplace(wordApp, a18Key, Cod18);
                    this.FindAndReplace(wordApp, a19Key, Cod19);
                    this.FindAndReplace(wordApp, a20Key, Cod20);
                    this.FindAndReplace(wordApp, req14Key, Titolo14);
                    this.FindAndReplace(wordApp, req15Key, Titolo15);
                    this.FindAndReplace(wordApp, req16Key, Titolo16);
                    this.FindAndReplace(wordApp, req17Key, Titolo17);
                    this.FindAndReplace(wordApp, req18Key, Titolo18);
                    this.FindAndReplace(wordApp, req19Key, Titolo19);
                    this.FindAndReplace(wordApp, req20Key, Titolo20);

                    //  salva il file
                    aDoc.Save();
                    ////////////////// IMPORTANTE, CHIUDERE IL PROCESSO ///////////////////////////////////////////////
                    wordApp.Quit();
                }
                else
                {
                    MessageBox.Show("File does not exist.", "No File", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Errore, inserisci un percorso valido dei file", "Internal Error", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Metodo per la sostituzione del testo con ciò che ha inserito l'utente.
        /// </summary>
        /// <param name="wordApp">Istanza dell'oggetto Word</param>
        /// <param name="findText">Testo da sostituire</param>
        /// <param name="replaceText">Con cosa sostituirlo</param>
        private void FindAndReplace(Word.Application wordApp, object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            //replaceText = false;

            // sostituizone del testo.
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                        ref matchDiacritics,
                ref matchAlefHamza, ref matchControl);
        }
    }
}
