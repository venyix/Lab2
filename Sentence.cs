using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1_redo
{
    class Sentence
    {
        public String OriginalText { get; set; }
        public String SentenceDelimiters = ".?!";
        public String SingleSentence { get; set; }
        public double AverageWords { get; set; }
        public SentenceList list;
        
        public Sentence(Text userText)
        {
            OriginalText = userText.ToString();
            BreakIntoSentences();
        }
        public Sentence(String sent)
        {
            SingleSentence = sent;
            //todo
            //AverageWords = findAverageWords();
        }

        public void BreakIntoSentences()
        {
            int column;
            String token;
            String text = OriginalText;
            list = new SentenceList();

            while (!String.IsNullOrEmpty(text))
            {
                column = text.IndexOfAny(SentenceDelimiters.ToCharArray());

                if (column < 0)
                    column = text.Length;

                if (column == 0)
                    column = 1;

                token = text.Substring(0, (++column));
                text = text.Substring(column);
                text = text.Trim(" \t".ToCharArray());
                list.AddToList(token);
            }     

        }

        public SentenceList getSentList()
        {
            SentenceList newList = new SentenceList(list);

            return newList;
        }

        public override string ToString()
        {
            return SingleSentence;
        }
    }
}
