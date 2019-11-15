using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace QDCeValutazioni.Views
{
    /// <summary>
    /// Logica di interazione per DescrizioneView.xaml
    /// </summary>
    public partial class DescrizioneView : UserControl
    {
        public DescrizioneView()
        {
            InitializeComponent();
        }

        private void SaveDescrizioneButton_Click(object sender, RoutedEventArgs e)
        {
            //var path = PathTextBox.Text;
            var pathCopia = "C:\\Users\\lucas\\Desktop\\samt\\anno4\\progetti\\Gestione qdc e valutazioni\\" +
                        "progettazione\\TemplateQdcTry.docx";
            var titoloKey = "<Titolo>";
            var nomeFormatoreKey = "<NomeFormatore>";
            var cognomeFormatoreKey = "<CognomeFormatore>";
            var nomePeritoKey = "<NomePerito>";
            var cognomePeritoKey = "<CognomePerito>";
            var mailFormatoreKey = "<EmailFormatore>";
            var mailPeritoKey = "<EmailPerito>";
            var dataInizioKey = "<DataInizio>";
            var dataConsegnaKey = "<DataConsegna>";
            var oraInizioKey = "<OraInizio>";
            var oraFineKey = "<OraFine>";
            var numeroOreKey = "<NumeroOre>";

            try
            {
                // copia del file 
                //File.Copy(path, pathCopia, true);
                // valori predefiniti per l'apertura del file
                object missing = Missing.Value;
                // crea l'oggetto che contiene l'istanza di Word
                Word.Application wordApp = new Word.Application();
                //  crea l'oggetto che contiene il documento
                Word.Document aDoc = null;
                // oggetto che definisce il file copiato (e da modificare)
                object filename = pathCopia;
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
                    //this.FindAndReplace(wordApp, titoloKey, TitoloTextBox.Text);
                    //this.FindAndReplace(wordApp, nomeFormatoreKey, NomeFormatoreTextBox.Text);
                    //this.FindAndReplace(wordApp, cognomeFormatoreKey, CognomeFormatoreTextBox.Text);
                    //this.FindAndReplace(wordApp, nomePeritoKey, NomePeritoTextBox.Text);
                    //this.FindAndReplace(wordApp, cognomePeritoKey, CognomePeritoTextBox.Text);
                    //this.FindAndReplace(wordApp, mailPeritoKey, EmailPeritoTextBox.Text);
                    //this.FindAndReplace(wordApp, mailFormatoreKey, EmailFormatoreTextBox.Text);
                    //this.FindAndReplace(wordApp, dataInizioKey, DataInizio.Text);
                    //this.FindAndReplace(wordApp, dataConsegnaKey, DataConsegna.Text);
                    //this.FindAndReplace(wordApp, oraInizioKey, OraInizio.Text);
                    //this.FindAndReplace(wordApp, oraFineKey, OraFine.Text);
                    //this.FindAndReplace(wordApp, numeroOreKey, NumeroOre.Text);

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
                MessageBox.Show("Error in process.", "Internal Error", MessageBoxButton.OK);
            }
        }

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
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                        ref matchDiacritics,
                ref matchAlefHamza, ref matchControl);
        }
    }
}