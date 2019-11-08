using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office;
using Microsoft.Office.Interop.Word;

namespace ProvaWord
{
    class Program
    {
        static void Main(string[] args)
        {
            //readfile();
            openfile();
            //readline();
        }

        static void openfile()
        {
            Application application = new Application();
            Document file = application.Documents.Open(@"C:\Users\lucas\Desktop\samt\anno4\progetti\Gestione qdc e valutazioni\prova.docx");
        }

        static void readfile()
        {
            Application application = new Application();
            Document file = application.Documents.Open(@"C:\Users\lucas\Desktop\samt\anno4\progetti\Gestione qdc e valutazioni\prova.docx");

            int count = file.Words.Count;
            for (int i = 1; i <= count; i++)
            {
                string text = file.Words[i].Text;
                Console.WriteLine("Word {0} = {1}", i, text);
            }
            application.Quit();


            //string percorso = @"C:\Users\lucas\Desktop\samt\anno4\progetti\
            //    Gestione qdc e valutazioni\prova.docx";
            //var word = new Microsoft.Office.Interop.Word.Application();
            //word.Visible = true;

            //word.Workbooks 
        }

        static void readline()
        {
            //Microsoft.Office.Interop.Word.Application wordApp = new Application();

            //object file = @"C:\Users\lucas\Desktop\samt\anno4\progetti\Gestione qdc e valutazioni\prova.docx";

            //object nullobj = System.Reflection.Missing.Value;

            //Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(

            //ref file, ref nullobj, ref nullobj,

            //                                      ref nullobj, ref nullobj, ref nullobj,

            //                                      ref nullobj, ref nullobj, ref nullobj,

            //                                      ref nullobj, ref nullobj, ref nullobj);

            //doc.ActiveWindow.Selection.WholeStory();

            //doc.ActiveWindow.Selection.Copy();

            //IDataObject data = Clipboard.GetDataObject();

            //txtFileContent.Text = data.GetData(DataFormats.Text).ToString();

            //doc.Close();
        }
    }
}
