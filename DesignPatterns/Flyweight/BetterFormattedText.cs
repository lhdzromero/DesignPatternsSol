using System;
using System.Text;
using System.Collections.Generic;

namespace DesignPatterns.Flyweight
{
    public class BetterFormatedText
    {
        private string plainText;
        private List<TextRange> formatting = new List<TextRange>();
        
        
        public BetterFormatedText(string plainText){
            this.plainText = plainText;
        }
        
        public TextRange GetRange(int start, int end){
            var range = new TextRange {Start = start, End = end };
            formatting.Add(range);
            return range;
        }
        
        public override string ToString(){
            var sb = new StringBuilder();
            for(var i = 0; i < plainText.Length; i++){
                var c = plainText[i];
                foreach(var range in formatting)
                    if(range.Covers(i) && range.Capitalize)
                        c = char.ToUpper(c);
                sb.Append(c);
            }
            
            return sb.ToString();
        }
        
        public class TextRange
        {
            public int Start, End;
            public bool Capitalize, Bold, Italic;
            
            public bool Covers(int position){
                return position >= Start && position <= End;
            }
            
        }
        
        
    }
}