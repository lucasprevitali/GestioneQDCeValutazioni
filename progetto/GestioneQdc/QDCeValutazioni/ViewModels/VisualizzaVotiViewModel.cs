using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using MVVM;
using Word = Microsoft.Office.Interop.Word;

namespace QDCeValutazioni.ViewModels
{
    public class VisualizzaVotiViewModel : BindableBase
    {
        /// <summary>   
        /// istanza di IDelegateCommand per la delega delle operazioni
        /// </summary>
        public IDelegateCommand VisualizzaVoti { get; set; }
        public IDelegateCommand MenuCommand { get; set; }
        public IDelegateCommand SaveVoti { get; set; }

        /// <summary>
        /// Variabili relative ai TextBox contenenti i percorsi dei file (Binding).
        /// </summary>
        public string PathVotiTemplate { get; set; }
        public string PathVotiSave { get; set; }

        /// <summary>
        /// Variabile di controllo.
        /// </summary>
        private bool check = false;

        public VisualizzaVotiViewModel()
        {
            MenuCommand = new DelegateCommand(OnMenuClick, CanMenuClick);
            VisualizzaVoti = new DelegateCommand(OnVisualizzaClick, CanVisualizzaClick);
            SaveVoti = new DelegateCommand(OnSaveVoti, CanSaveVoti);
        }

        /// <summary>
        /// Metodo per copiare il file di template dei voti.
        /// </summary>
        /// <param name="obj"></param>
        private void OnSaveVoti(object obj)
        {
            // controllo che i due percorsi non siano uguali.
            if (PathVotiTemplate == PathVotiSave)
            {
                System.Windows.MessageBox.Show("Inserisci un percorso differente per il salvataggio", "Internal Error", System.Windows.MessageBoxButton.OK);
            }
            else
            {
                // controllo che il percorso di salvataggio non esiste già.
                if (File.Exists((string)PathVotiSave))
                {
                    System.Windows.MessageBox.Show("Il percorso del file di salvataggio esiste già", "Internal Error", System.Windows.MessageBoxButton.OK);
                }
                else
                {
                    try
                    {
                        // copia del file 
                        File.Copy(PathVotiTemplate, PathVotiSave, true);
                        // valori predefiniti per l'apertura del file
                        object missing = Missing.Value;
                        // crea l'oggetto che contiene l'istanza di Word
                        Word.Application wordApp = new Word.Application();
                        //  crea l'oggetto che contiene il documento
                        Word.Document aDoc = null;
                        // oggetto che definisce il file copiato (e da modificare)
                        object filename = PathVotiSave;
                        // Se il file esiste
                        if (!File.Exists((string)filename))
                        {
                            System.Windows.MessageBox.Show("File does not exist.", "No File", System.Windows.MessageBoxButton.OK);
                        }
                        else
                        {
                            check = true;
                        }
                    }
                    catch (Exception)
                    {
                        System.Windows.MessageBox.Show("Errore, il percorso inserito non è valido", "Internal Error", System.Windows.MessageBoxButton.OK);
                    }
                }
            }
        }

        private bool CanSaveVoti(object arg)
        {
            return true;
        }

        /// <summary>
        /// Metodo per visualizzare il file dei voti appena creato.
        /// </summary>
        /// <param name="obj"></param>
        private void OnVisualizzaClick(object obj)
        {
            // se il file è stato creato correttamente.
            if (check)
            {
                try
                {
                    // apertura del file.
                    Application application = new Application();
                    application.Visible = true;
                    Document file = application.Documents.Open(PathVotiSave);
                    //application.Quit();
                }
                catch (System.Runtime.InteropServices.COMException e)
                {
                    System.Windows.MessageBox.Show("Errore con l'apertura del file");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Inserisci dei percorsi adeguati", "Internal Error", System.Windows.MessageBoxButton.OK);
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
