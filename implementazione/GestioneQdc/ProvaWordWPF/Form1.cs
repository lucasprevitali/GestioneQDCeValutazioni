using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace ProvaWordWPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void eseguiBT_Click(object sender, EventArgs e)
        {
            try
            {
                // copia del file 
                File.Copy("C:\\Users\\lucas\\Desktop\\samt\\anno4\\progetti\\Gestione qdc e valutazioni\\prova.docx", 
                    "C:\\Users\\lucas\\Desktop\\samt\\anno4\\progetti\\Gestione qdc e valutazioni\\provatemp.docx", true);
                // valori predefiniti per l'apertura del file
                object missing = Missing.Value;
                // crea l'oggetto che contiene l'istanza di Word
                Word.Application wordApp = new Word.Application();
                //  crea l'oggetto che contiene il documento
                Word.Document aDoc = null;
                // oggetto che definisce il file copiato (e da modificare)
                object filename = "C:\\Users\\lucas\\Desktop\\samt\\anno4\\progetti\\Gestione qdc e valutazioni\\provatemp.docx";
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
                    this.FindAndReplace(wordApp, "<Date>", nomeTB.Text);
                    this.FindAndReplace(wordApp, "<Name>", valTB.Text.Trim());
                    //  salva il file
                    aDoc.Save();
                }
                else
                {
                    MessageBox.Show("File does not exist.", "No File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }      
            }
            catch (Exception)
            {
                MessageBox.Show("Error in process.", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                        ref matchDiacritics,
                ref matchAlefHamza, ref matchControl);
        }
    }
}
