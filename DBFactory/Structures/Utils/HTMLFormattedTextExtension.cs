using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory.Structures.Utils
{
    public class HTMLFormattedTextExtension
    {
        private string text;

        /* Holds the raw text input from text areas.*/
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        /* 
         * Fetch the html formatted text used for Views 
         * - @Html.Raw(FormattedText)
         */
        public string FormattedText
        {
            get { return FormatText(Text); }
        }

        private static string FormatText(string text)
        {
            if (text != null)
                return text.Replace(Environment.NewLine, "<br>");

            return string.Empty;
        }
    }
}
