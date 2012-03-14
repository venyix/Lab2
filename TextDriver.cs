using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1_redo
{
    class TextDriver
    {
        [STAThread]
        static void Main(string[] args)
        {
            Text userText = new Text(Utility.GetExistingText());
            Sentence senttest = new Sentence(userText);
            Paragraph paras = new Paragraph(userText);

            //Console.WriteLine(userText);
            //Console.WriteLine("\n\n\n" + senttest.getSentList());
           // Console.WriteLine(paras.GetParaList().list[0].SingleParagraph);
            Console.WriteLine(userText.GetWordsList().ToString());

            Console.ReadKey();
        }
    }
}
