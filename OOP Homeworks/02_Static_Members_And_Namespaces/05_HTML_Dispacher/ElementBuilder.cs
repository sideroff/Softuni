using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_HTML_Dispacher
{
    class ElementBuilder
    {
        private string elementName;
        private string attributes;
        private string content;
        private uint timesToPrint;

        public string ElementName
        {
            get { return this.elementName; }
            set { this.elementName = value; }
        }
        public string Attributes
        {
            get
            {
                return this.attributes;
            }
            set
            {
                this.attributes = value;
            }
        }
        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }
        public uint TimesToPrint
        {
            get
            {
                return this.timesToPrint;
            }
            set
            {
                this.timesToPrint = value;
            }
        }

        public ElementBuilder(string name)
        {
            this.ElementName = name;
            this.TimesToPrint = 1;
        }

        public void addAtTribute(string attribute, string value)
        {
            this.Attributes += $" {attribute}=\"{value}\"";
        }
        public void addContent(string newContent)
        {
            this.Content += $"{Environment.NewLine}    {newContent}";
        }

        public static ElementBuilder operator *(ElementBuilder e1, uint times)
        {
            e1.TimesToPrint *= times;
            return e1;
        }
        public override string ToString()
        {
            string sb = "";
            for (int i = 0; i < this.TimesToPrint; i++)
            {
                sb += $"<{this.ElementName}{this.Attributes}>{this.Content}{Environment.NewLine}</{this.ElementName}>{Environment.NewLine}";
            }
            return sb;
        }
    }
}
