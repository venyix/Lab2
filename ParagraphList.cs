using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1_redo
{
    class ParagraphList
    {
        public List<Paragraph> list = new List<Paragraph>(); 

        public ParagraphList()
        {

        }
        
        public ParagraphList(ParagraphList paralist)
        {
            for (int i = 0; i < paralist.list.Count; i++)
            {
                this.list.Add(new Paragraph(paralist.list[i].SingleParagraph));
            }
        }

        public void AddToList(Paragraph para)
        {
            list.Add(para);
        }

        public override string ToString()
        {
            String returnString = "";
            for (int i = 0; i < list.Count; i++)
            {
                returnString += "Paragraph #" + i;
                returnString += list[i];
                returnString += "\n\n";
            }

            return returnString;
        }
    }
}
