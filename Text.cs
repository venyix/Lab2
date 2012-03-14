using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1_redo
{
    class Text
    {
        /*
         * Properties and Fields for Text class
         */
        public String OriginalText { get; set; }

        private List<String> Tokens { get; set; }
        private List<String> TokensMinusDelims { get; set; }
        private List<String> UniqueWords { get; set; }
        private List<int> SentenceTracker { get; set; }
        private List<int> ParagraphTracker { get; set; }
        private List<int> NumberOfUniqueWords { get; set; }
        private List<String> BuiltContractions { get; set; }
        public List<String> StrippedWords { get; set; }

        public Words words {get;set;}
        private String delimiters;
        public String delims
        {
            get
            {
                return delimiters;
            }
            private set
            {
                delimiters = value;
            }
        }

        /*
         * Constructors for the Text class
         */
        public Text()
        {

        }
        public Text(String userText)
        {
            NumberOfUniqueWords = new List<int>();
            delims = ".,?!*()-+=@%&{}|\n\r :;',<>~[]";
            OriginalText = userText;
            breakIntoTokens();
            ToLowerCase();
            ConcatContractions();
            removeDelimiters();
            FindUniqueWords();
            PassUniqueWords();
        }

        /*
         * Begin rest of methods for Text class
         */
        public void breakIntoTokens()
        {
            int column;
            String token;
            String text = OriginalText;
            Tokens = new List<String>();

            while (!String.IsNullOrEmpty(text))
            {
                column = text.IndexOfAny(delims.ToCharArray());

                if (column < 0)
                    column = text.Length;

                if (column == 0)
                    column = 1;

                token = text.Substring(0, column);
                Tokens.Add(token);
                text = text.Substring(column);
                text = text.Trim(" \t".ToCharArray());
            }
        }

        public void removeDelimiters()
        {
            TokensMinusDelims = new List<String>();
            SentenceTracker = new List<int>();
            StrippedWords = new List<String>();

            for (int i = 0; i < BuiltContractions.Count; i++)
            {
                if (BuiltContractions[i] == " " || BuiltContractions[i] == "." || BuiltContractions[i] == "," || BuiltContractions[i] == "?" ||
                     BuiltContractions[i] == ")" || BuiltContractions[i] == "(" || BuiltContractions[i] == "*" || BuiltContractions[i] == "!" ||
                     BuiltContractions[i] == "-" || BuiltContractions[i] == "+" || BuiltContractions[i] == "=" || BuiltContractions[i] == "@" ||
                     BuiltContractions[i] == "}" || BuiltContractions[i] == "{" || BuiltContractions[i] == "&" || BuiltContractions[i] == "%" ||
                     BuiltContractions[i] == "|" || BuiltContractions[i] == "\n" || BuiltContractions[i] == "\r" || BuiltContractions[i] == ":" ||
                     BuiltContractions[i] == "," || BuiltContractions[i] == "," || BuiltContractions[i] == "'" || BuiltContractions[i] == ";" ||
                     BuiltContractions[i] == "[" || BuiltContractions[i] == "~" || BuiltContractions[i] == ">" || BuiltContractions[i] == "<" ||
                     BuiltContractions[i] == "]")
                {
                }
                else
                {
                    StrippedWords.Add(BuiltContractions[i]);
                }
            }

        }

        public void ToLowerCase()
        {
            for (int i = 0; i < Tokens.Count; i++)
            {
                Tokens[i] = Tokens[i].ToLower();
            }
        }

        public void FindUniqueWords()
        {
            UniqueWords = new List<String>();
            int i = 0;
            int j = 0;
            int counter;
            for (i = 0; i < StrippedWords.Count; i++)
            {
                i = 0;
                counter = 0;
                UniqueWords.Add(StrippedWords[i]);
                StrippedWords.Remove(StrippedWords[i]);
                counter++;
                for (int k = 0; k < StrippedWords.Count; k++)
                {
                    if (StrippedWords[k].Equals(UniqueWords[j]))
                    {
                        StrippedWords.Remove(BuiltContractions[k]);
                        counter++;
                    }
                }
                j++;
                NumberOfUniqueWords.Add(counter);
            }
        }

        public void PassUniqueWords()
        {
            words = new Words();

            for(int i = 0; i < UniqueWords.Count; i++)
            {
                words.AddNewWord(new DistinctWord(UniqueWords[i], NumberOfUniqueWords[i]));
            }
        }

        public Words GetWordsList()
        {
            return words;
        }

        public void ConcatContractions()
        {
            BuiltContractions = new List<String>();

            for (int i = 0; i < Tokens.Count; i++)
            {
                if (i != ((Tokens.Count) - 1))
                {
                    if (Tokens[(i + 1)] == "\'")
                    {
                        BuiltContractions.Add(Tokens[i] + Tokens[++i] + Tokens[++i]);
                    }
                    else
                    {
                        BuiltContractions.Add(Tokens[i]);
                    }
                }
            }
        }

        public override string ToString()
        {
            return OriginalText;
        }
    }
}
