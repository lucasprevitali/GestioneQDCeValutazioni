using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
            var titolo = "<Titolo>";
            var nomeFormatoreloc = "<NomeFormatore>";
            var pathCriteri = "C:\\Users\\lucas\\Desktop\\samt\\anno4\\progetti\\" +
                        "Gestione qdc e valutazioni\\A2. Criteri di valutazione LPI (estesi).docx";
            var pathTemplate = "C:\\Users\\lucas\\Desktop\\samt\\anno4\\progetti\\Gestione qdc e valutazioni\\" +
                        "progettazione\\TemplateQdc.docx";
            try
            {
                //// copia del file 
                //File.Copy(pathCriteri, pathTemplate, true);
                //// valori predefiniti per l'apertura del file
                //object missing = Missing.Value;
                //// crea l'oggetto che contiene l'istanza di Word
                //Word.Application wordApp = new Word.Application();
                ////  crea l'oggetto che contiene il documento
                //Word.Document aDoc = null;
                //// oggetto che definisce il file copiato (e da modificare)
                //object filename = pathTemplate;
                //// Se il file esiste
                //if (File.Exists((string)filename))
                //{
                //    object readOnly = false;
                //    object isVisible = false;
                //    wordApp.Visible = false;
                //    //  apertura del file copiato
                //    aDoc = wordApp.Documents.Open(ref filename, ref missing,
                //        ref readOnly, ref missing, ref missing, ref missing,
                //        ref missing, ref missing, ref missing, ref missing,
                //        ref missing, ref isVisible, ref missing, ref missing,
                //        ref missing, ref missing);
                //    aDoc.Activate();
                //    // richiama la funzione FindAndReplace passandogli due parametri,
                //    // il testo da sostituire e con cosa sostituirlo
                //    this.FindAndReplace(wordApp, titolo, titoloQdc.Text);
                //    this.FindAndReplace(wordApp, nomeFormatoreloc, nomeFormatore.Text);

                // valori predefiniti per l'apertura del file
                object missing = Missing.Value;
                // crea l'oggetto che contiene l'istanza di Word
                Word.Application wordApp = new Word.Application();
                //  crea l'oggetto che contiene il documento
                Word.Document aDoc = null;
                // oggetto che definisce il file copiato (e da modificare)
                object filename = pathCriteri;
                object filenameTemplate = pathTemplate;
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
                    this.FindAndReplace(wordApp, titolo, titoloQdc.Text);
                    this.FindAndReplace(wordApp, nomeFormatoreloc, nomeFormatore.Text);


                    //  salva il file
                    aDoc.Save();
                    ////////////////// IMPORTANTE, CHIUDERE IL PROCESSO ///////////////////////////////////////////////
                    wordApp.Quit();
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
            //replaceText = false;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                        ref matchDiacritics,
                ref matchAlefHamza, ref matchControl);
        }



        ///////////////////////// /////////////////////////////////////////////////////
        // /// ///////////////// ///////////////////////////////////



        private void button1_Click(object sender, EventArgs e)
        {
            var pathReq = "C:\\Users\\lucas\\Desktop\\samt\\anno4\\progetti\\Gestione qdc e valutazioni\\" +
                "A2. Criteri di valutazione LPI (estesi).docx";
            var pathQdc = "C:\\Users\\lucas\\Desktop\\samt\\anno4\\progetti\\Gestione qdc e valutazioni\\" +
                        "progettazione\\TemplateQdcTry.docx";
            var pathCopia = "C:\\Users\\lucas\\Desktop\\samt\\anno4\\progetti\\Gestione qdc e valutazioni\\" +
                        "requisitiTry.docx";
            var a14 = "<a14>";
            try
            {
                File.Copy(pathReq, pathCopia, true);
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

                    this.FindTables(wordApp, aDoc, titoloQdc.Text);

                    //  salva il file
                    aDoc.Save();
                    ////////////////// IMPORTANTE, CHIUDERE IL PROCESSO ///////////////////////////////////////////////
                    wordApp.Quit();
                }
                else
                {
                    MessageBox.Show("File does not exist.", "No File", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error in process.", "Internal Error", MessageBoxButtons.OK);
            }
        }

        private void FindTables(Word.Application wordApp, Word.Document aDoc, object text)
        {
            int whichTable = 1; //starting index is 1, not 0
            object missing = Missing.Value;
            bool isFound = false;
            //string cont = "vuota";
            object replace = "REPLACETEXT";
            string tablecontent = "";
            string titolo = "";

            do
            { 
                aDoc.Tables[whichTable].Range.Find.ClearFormatting();
                aDoc.Tables[whichTable].Range.Find.Wrap = Word.WdFindWrap.wdFindContinue;
                aDoc.Tables[whichTable].Range.Find.Text = text.ToString();
                aDoc.Tables[whichTable].Range.Select();
                isFound = aDoc.Tables[whichTable].Range.Find.Execute(ref text, ref missing, 
                    ref missing, ref missing, ref missing, ref missing, ref missing, 
                    ref missing, ref missing, ref missing, ref missing, ref missing, 
                    ref missing, ref missing, ref missing);
                if (isFound == true)
                {
                    //aDoc.Tables[whichTable].Range.MoveEnd(WdUnits.wdWord, 1);
                    aDoc.Tables[whichTable].Range.Find.Execute(ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref replace, ref missing, ref missing,
                        ref missing, ref missing, ref missing);

                    //tablecontent = aDoc.Tables[whichTable].ConvertToText().ToString();
                    tablecontent = aDoc.Tables[whichTable].Columns.ToString();
                    //List<string> list = new List<string>(Regex.Split(tablecontent, Environment.NewLine));
                    //titolo = list[3];

                    string[] list = tablecontent.Split(new string[] { @"\0020", }, StringSplitOptions.None);

                    nomeFormatore.Text = "trovato: " + whichTable;
                    //cont = aDoc.Tables[whichTable].Range.Find.Text;
                    //richTextBox1.Text = list[0];
                    richTextBox1.Text = tablecontent;
                    break;
                }
                else
                {
                    nomeFormatore.Text = "nope";
                }
                whichTable++;
            } while (true);
        }
    }
}
