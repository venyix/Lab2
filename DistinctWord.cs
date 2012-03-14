using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1_redo
{
    /* SUPPOSED TO IMPLEMENT THE GENERIC 
     * IEQUATABLE AND ICOMPARABLE CLASS*/
    class DistinctWord
    {
        /*
         * Begin Properties
         */
        public String Word { get; set; }
        public int NumberOfWords { get; set; }
        /*
         * End Properties
         */

        /*
         * Begin Constructors
         */
        // Default Constructor
        public DistinctWord()
        {
            Word = "";
            NumberOfWords = 0;
        }
        // Copy Constructor
        public DistinctWord(DistinctWord word)
        {
            Word = word.Word;
            NumberOfWords = word.NumberOfWords;
        }
        // Parameterized Constructor
        public DistinctWord(String word, int count)
        {
            Word = word;
            NumberOfWords = count;
        }
        /*
         * End Constructors
         */

        /*
         * Begin Rest of Methods
         */

        /*
         * End of Methods
         */
    }
}
