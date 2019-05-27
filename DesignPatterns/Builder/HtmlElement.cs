using System;
using System.Text;
using System.Collections.Generic;

namespace DesignPatterns.Builder
{
    public class HtmlElement 
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int identSize = 2;
        
        public HtmlElement(){}
        
        public HtmlElement(string name, string text){
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
        }
        
        private string ToStringImpl(int indent){
            var sb = new StringBuilder();
            var i = new string(' ', identSize * indent);
            sb.AppendLine($"{i}<{Name}>");
            
            if(!string.IsNullOrWhiteSpace(Text)){
                sb.Append(new string(' ', identSize * (indent + 1)));
                sb.AppendLine(Text);
            }
            
            foreach(var e in Elements)
                sb.Append(e.ToStringImpl(indent +1));
                
            sb.AppendLine($"{i}</{Name}>");
            
            return sb.ToString();
        }
        
        public override string ToString(){
            return ToStringImpl(0);
        }
    }
}