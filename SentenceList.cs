using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1_redo
{
    class SentenceList
    {
        public List<Sentence> list = new List<Sentence>();
        public double AverageSentenceLength { get; set; }
        public int NumberOfSentences { get; set; }

       public SentenceList()
        {
            NumberOfSentences = 0;
        }
       public SentenceList(SentenceList list)
       {
           for (int i = 0; i < list.list.Count; i++)
           {
               this.list.Add(list.list[i]);
           }
           this.AverageSentenceLength = list.AverageSentenceLength;
           this.NumberOfSentences = list.NumberOfSentences;
       }

       public void AddToList(String sent)
       {
           list.Add(new Sentence(sent));
           NumberOfSentences++;
           AverageWords();
       }

       public void AverageWords()
       {
           // TO - DO
       }

       public override string ToString()
       {
           String returnString = "";

           for (int i = 0; i < list.Count; i++)
           {
               returnString += "Sentence #" + i;
               returnString += list[i];
               returnString += "\n";
           }

           return returnString;
       }
    }
}
