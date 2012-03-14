using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1_redo
{
    class Paragraph
    {
        public String OriginalText { get; set; }
        public ParagraphList list;
        public int NumberOfSentences { get; set; }
        public int NumberOfWords { get; set; }
        public double AverageSentenceLength { get; set; }
        public int FirstToken { get; set; }
        public String SingleParagraph { get; set; }
        public int LastToken { get; set; }
        public String paragraphDelims = "\n\n";


        public Paragraph(Text userText)
        {
            OriginalText = userText.ToString();
            BreakIntoParagraphs();
        }
        public Paragraph(String para)
        {
            this.SingleParagraph = para;
        }

        public void BreakIntoParagraphs()
        {
            int column;
            String token;
            String text = OriginalText;
            list = new ParagraphList();

            while (!String.IsNullOrEmpty(text))
            {
                column = text.IndexOf(paragraphDelims);

                    if (column < 0)
                        column = text.Length;

                    if (column == 0)
                        column = 1;

                    token = text.Substring(0, (column));
                    text = text.Substring(column);
                    text = text.Trim(" \t".ToCharArray());
                    list.AddToList(new Paragraph(token));
                
            }

        }

        public ParagraphList GetParaList()
        {
            return new ParagraphList(list);
        }

        public void CountSentences()
        {
            // TO - DO
        }

        public void CountWords()
        {
            // TO - DO
        }

        public void GetTokens()
        {
            // TO - DO
        }

        public void AvgSentLength()
        {
            // TO - DO
        }
    }
}
