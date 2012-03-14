using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1_redo
{
    class Words
    {
        /*
         * Begin Properties
         */
        public List<DistinctWord> WordList 
        { 
            get;
            set;
        }
        /*
         * End Properties
         */

        /*
         * Begin Constructors
         */

        // Default Constructor
        public Words(DistinctWord newWord)
        {
            WordList.Add(newWord);
        }
        // Parameterized Constructor
        public Words()
        {
            WordList = new List<DistinctWord>();
        }
        // Copy Constructor
        public Words(Words wordsObject)
        {
            for (int i = 0; i < WordList.Count; i++)
            {
                WordList[i] = wordsObject.WordList[i];
            }
        }

        /*
         * End Constructors
         */

        /*
         * Begin Rest of Methods
         */
        public void AddNewWord(DistinctWord newWord)
        {
            WordList.Add(new DistinctWord(newWord));
        }
        public override string ToString()
        {
            String rtnString = "";

            for (int i = 0; i < WordList.Count; i++)
            {
                rtnString += "Word: " + WordList[i].Word;
                rtnString += "\n";
                rtnString += "# of Appearances: " + WordList[i].NumberOfWords;
                rtnString += "\n\n";
            }

            return rtnString;
        }
        /*
         * End of Methods
         */
    }
}
