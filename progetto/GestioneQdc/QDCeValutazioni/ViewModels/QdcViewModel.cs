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
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;

namespace QDCeValutazioni.ViewModels
{
    public class QdcViewModel : BindableBase
    {
        /// <summary>
        /// Insieme che contiene i campi di un Qdc.
        /// </summary>
        public ObservableCollection<Qdc> Qdcs { get; set; }

        /// <summary>   
        /// istanza di IDelegateCommand per la delega delle operazioni
        /// </summary>
        public IDelegateCommand DescrizioneCommand { get; set; }
        public IDelegateCommand SaveInfo { get; set; }
        public IDelegateCommand RequisitoCommand { get; set; }
        public IDelegateCommand SaveDescrizione { get; set; }

        /// <summary>
        /// Variabili relative ai TextBox contenenti le 
        /// informazioni generiche da inserire (Binding).
        /// </summary>
        public string Titolo { get; set; }
        public string NomeFormatore { get; set; }
        public string CognomeFormatore { get; set; }
        public string MailFormatore { get; set; }
        public string NomePerito { get; set; }
        public string CognomePerito { get; set; }
        public string MailPerito { get; set; }
        public string NomePerito2 { get; set; } 
        public string CognomePerito2 { get; set; }
        public string MailPerito2 { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataConsegna { get; set; }
        public DateTime OraInizio { get; set; }
        public DateTime OraFine { get; set; }
        public int NumeroOre { get; set; }
        public string Descrizione { get; set; }
        public string PathTemplate { get; set; }
        public string PathSave { get; set; }

        /// <summary>
        /// Metodo costruttore del ViewModel del Qdc.
        /// </summary>
        public QdcViewModel()
        {
            //DescrizioneVM = new DescrizioneViewModel();
            DescrizioneCommand = new DelegateCommand(OnDescrizioneList, CanDescrizioneList);
            SaveInfo = new DelegateCommand(OnSaveInfo, CanSaveInfo);

            //RequistoVM = new RequisitoViewModel();
            RequisitoCommand = new DelegateCommand(OnRequisitoList, CanRequisitoList);
            SaveDescrizione = new DelegateCommand(OnSaveDescrizione, CanSaveDescrizione);
        }

        private void RegisterCommands()
        {
            
        }

        private bool CanSaveInfo(object arg)
        {
            return true;
        }

        /// <summary>
        /// Metodo per salvare i dati sul database e sul file Word.
        /// </summary>
        /// <param name="obj"></param>
        private void OnSaveInfo(object obj)
        {
            AppDbContext ctx = new AppDbContext();
            QdcDbDataRepository repoQdc = new QdcDbDataRepository(ctx);

            // controllo che il percorso dei due file sia differente.
            if(PathTemplate == PathSave)
            {
                MessageBox.Show("Inserisci un percorso differente per il salvataggio", "Internal Error", MessageBoxButton.OK);
            }
            else
            {
                // controllo che il percorso di salvataggio non esista già.
                if (File.Exists((string)PathSave))
                {
                    MessageBox.Show("Il percorso del file di salvataggio esiste già", "Internal Error", MessageBoxButton.OK);
                }
                else
                {
                    try
                    {
                        // copia del file 
                        File.Copy(PathTemplate, PathSave, true);
                        // valori predefiniti per l'apertura del file
                        object missing = Missing.Value;
                        // crea l'oggetto che contiene l'istanza di Word
                        Word.Application wordApp = new Word.Application();
                        //  crea l'oggetto che contiene il documento
                        Word.Document aDoc = null;
                        // oggetto che definisce il file copiato (e da modificare)
                        object filename = PathSave;
                        // Se il file esiste
                        if (!File.Exists((string)filename))
                        {
                            MessageBox.Show("File does not exist.", "No File", MessageBoxButton.OK);
                        }
                        else
                        {
                            // controllo che l'utente abbia inserito tutti i dati.
                            if (!string.IsNullOrEmpty(Titolo) && !string.IsNullOrEmpty(NomeFormatore) &&
                                !string.IsNullOrEmpty(CognomeFormatore) && !string.IsNullOrEmpty(MailFormatore) &&
                                !string.IsNullOrEmpty(NomePerito) && !string.IsNullOrEmpty(CognomePerito) &&
                                !string.IsNullOrEmpty(MailPerito) && !string.IsNullOrEmpty(DataInizio.ToString()) &&
                                !string.IsNullOrEmpty(DataConsegna.ToString()) && !string.IsNullOrEmpty(OraInizio.ToString()) &&
                                !string.IsNullOrEmpty(OraFine.ToString()) && !string.IsNullOrEmpty(NumeroOre.ToString()) &&
                                !string.IsNullOrEmpty(PathTemplate) && !string.IsNullOrEmpty(PathSave))
                            {
                                if (DataConsegna == DateTime.MinValue)
                                {
                                    DataConsegna = DateTime.Today;
                                }
                                if (DataInizio == DateTime.MinValue)
                                {
                                    DataInizio = DateTime.Today;
                                }
                                if (OraInizio == DateTime.MinValue)
                                {
                                    OraInizio = DateTime.Today;
                                }
                                if (OraFine == DateTime.MinValue)
                                {
                                    OraFine = DateTime.Today;
                                }

                                // inserimento dei dati sul database.
                                repoQdc.Insert(new Qdc(Titolo, NomeFormatore, CognomeFormatore,
                                    MailFormatore, NomePerito, CognomePerito, MailPerito,
                                    DataInizio, DataConsegna, OraInizio, OraFine, NumeroOre, Descrizione,
                                    NomePerito2, CognomePerito2, MailPerito2, PathTemplate, PathSave));
                                //repoQdc.Insert(new Qdc(Descrizione));   

                                // mi sposto in DescrizioneView.
                                OnDescrizioneList(obj);
                            }
                            else
                            {
                                MessageBox.Show("Inserisci tutte le informazioni");
                            }

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Errore, il percorso inserito non è valido", "Internal Error", MessageBoxButton.OK);
                    }
                }
            }

        }

        /// <summary>
        /// Metodo per spostarmi in DescrizioneView.
        /// </summary>
        /// <param name="obj"></param>
        private void OnDescrizioneList(object obj)
        {
            //c = 1;
            //OnSaveInfo(obj);
            Messenger.Default.Send<BindableBase>(new DescrizioneViewModel());
        }
        private bool CanDescrizioneList(object arg)
        {
            return true;
        }

        private bool CanSaveDescrizione(object arg)
        {
            return true;
        }

        /// <summary>
        /// Metodo per salvare la descrizione.
        /// </summary>
        /// <param name="obj"></param>
        private void OnSaveDescrizione(object obj)
        {
            AppDbContext ctx = new AppDbContext();
            QdcDbDataRepository repoQdc = new QdcDbDataRepository(ctx);

            // ricavo l'ultimo Qdc inserito.
            int i = repoQdc.Get().Where(q1 => q1.Id == q1.Id).Max(q1 => q1.Id);
            Qdcs = new ObservableCollection<Qdc>(repoQdc.Get().Where(q1 => q1.Id == i));
            Qdc q = Qdcs[0];

            if (!string.IsNullOrEmpty(Descrizione))
            {
                // eseguo l'update della descrizione.
                q.Descrizione = Descrizione;
                repoQdc.Update(q);

                SaveInFile(q);

                OnRequisitoList(obj);
            }
            else
            {
                MessageBox.Show("Inserisci una descrizione");
            }  
   
        }

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
            var titoloKey = "<Titolo>";
            var nomeFormatoreKey = "<NomeFormatore>";
            var cognomeFormatoreKey = "<CognomeFormatore>";
            var nomePeritoKey = "<NomePerito>";
            var cognomePeritoKey = "<CognomePerito>";
            var nomePerito2Key = "<NomePerito2>";
            var cognomePerito2Key = "<CognomePerito2>";
            var mailFormatoreKey = "<EmailFormatore>";
            var mailPeritoKey = "<EmailPerito>";
            var dataInizioKey = "<DataInizio>";
            var dataConsegnaKey = "<DataConsegna>";
            var oraInizioKey = "<OraInizio>";
            var oraFineKey = "<OraFine>";
            var numeroOreKey = "<NumeroOre>";
            var descrizioneKey = "<Descrizione>";

            DateTime OraInizioAdj = DateTime.Parse(q.OraInizio.ToString());
            OraInizioAdj.ToString("HH:mm");
            DateTime OraFineAdj = DateTime.Parse(q.OraFine.ToString());
            OraFineAdj.ToString("HH:mm");

            try
            {
                // copia del file 
                //File.Copy(pathTemplate, pathSave, true);
                // valori predefiniti per l'apertura del file
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
                    //  apertura del file copiato
                    aDoc = wordApp.Documents.Open(ref filename, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);
                    aDoc.Activate();
                    // richiama la funzione FindAndReplace passandogli due parametri,
                    // il testo da sostituire e con cosa sostituirlo
                    this.FindAndReplace(wordApp, titoloKey, q.Titolo);
                    this.FindAndReplace(wordApp, nomeFormatoreKey, q.NomeFormatore);
                    this.FindAndReplace(wordApp, cognomeFormatoreKey, q.CognomeFormatore);
                    this.FindAndReplace(wordApp, nomePeritoKey, q.NomePerito1);
                    this.FindAndReplace(wordApp, cognomePeritoKey, q.CognomePerito1);
                    this.FindAndReplace(wordApp, nomePerito2Key, q.NomePerito2);
                    this.FindAndReplace(wordApp, cognomePerito2Key, q.CognomePerito2);
                    this.FindAndReplace(wordApp, mailPeritoKey, q.MailPerito1);
                    this.FindAndReplace(wordApp, mailFormatoreKey, q.MailFormatore);
                    this.FindAndReplace(wordApp, dataInizioKey, q.DataInizio);
                    this.FindAndReplace(wordApp, dataConsegnaKey, q.DataConsegna);
                    this.FindAndReplace(wordApp, oraInizioKey, OraInizioAdj);
                    this.FindAndReplace(wordApp, oraFineKey, OraFineAdj);
                    this.FindAndReplace(wordApp, numeroOreKey, q.NumeroOre);
                    this.FindAndReplace(wordApp, descrizioneKey, q.Descrizione);

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

        private void OnRequisitoList(object obj) { Messenger.Default.Send<BindableBase>(new RequisitoViewModel()); }
        private bool CanRequisitoList(object arg) { return true; }
    }
}


// C:\Users\lucas\Desktop\samt\anno4\progetti\Gestione qdc e valutazioni\progettazione\TemplateQdc.docx
