using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;


namespace Transliterator
{
    public class Transliter
    {
        private Dictionary<string, string> rules;

        ///<summary>
        ///Create object with default rules
        ///</summary>
        public Transliter()
        {
            rules = new Dictionary<string, string>();
            SetDefaultRules();
        }
        ///<summary>
        ///Create object with custom rules
        ///</summary>
        public Transliter(Dictionary<string, string> _rules)
        {
            rules = _rules;
        }
        ///<summary>
        ///Translit input string (default ukr-eng)
        ///</summary>
        public string Translit(string ukrStr)
        {
            StringBuilder sbUkrStr = new StringBuilder(ukrStr);
            sbUkrStr.Insert(0, " ");// adding " " for correct translit firt lowercase latter in row
            sbUkrStr.Insert(sbUkrStr.Length, " ");// adding " " for correct translit last latter in row
            for (int i = rules.Max(r => r.Key.Length); i > 0; i--)//First check rules with max length to prevent changing text wuth rules with less length
            {
                foreach (var rule in rules.Where(r=>r.Key.Length==i))
                {
                    sbUkrStr.Replace(rule.Key, rule.Value);
                }
            }
            sbUkrStr.Remove(0, 1);
            sbUkrStr.Remove(sbUkrStr.Length-1, 1);
            return sbUkrStr.ToString();
        }
        
        ///<summary>
        ///Replace default rulse with yours
        ///</summary>
        public void SetNewRules(Dictionary<string, string> newRules)
        {
            rules.Clear();
            rules = newRules;
        }
        ///<summary>
        ///Change exist rule or add new
        ///</summary>
        public void ModifyRule(string ukr, string lat)
        {
            if(rules.ContainsKey(ukr))
            {
                rules[ukr] = lat;
            }
            else
            {
                rules.Add(ukr, lat);
            }

        }
        private void SetDefaultRules()
        {
            rules.Clear();
            rules.Add("А","A");
            rules.Add("Б", "B");
            rules.Add("В", "V");
            rules.Add("Г", "H");
            rules.Add("Ґ", "G");
            rules.Add("Д", "D");
            rules.Add("Е", "E");
            rules.Add("Є", "Ye");
            rules.Add("Ж", "Zh");
            rules.Add("З", "Z");
            rules.Add("И", "Y");
            rules.Add("І", "I");
            rules.Add("Ї", "Yi");
            rules.Add("Й", "Y");
            rules.Add("К", "K");
            rules.Add("Л", "L");
            rules.Add("М", "M");
            rules.Add("Н", "N");
            rules.Add("О", "O");
            rules.Add("П", "P");
            rules.Add("Р", "R");
            rules.Add("С", "S");
            rules.Add("Т", "T");
            rules.Add("У", "U");
            rules.Add("Ф", "F");
            rules.Add("Х", "Kh");
            rules.Add("Ц", "Ts");
            rules.Add("Ч", "Ch");
            rules.Add("Ш", "Sh");
            rules.Add("Щ", "Shch");
            rules.Add("Ю", "Yu");
            rules.Add("Я", "Ya");

            rules.Add("а", "a");
            rules.Add("б", "b");
            rules.Add("в", "v");
            rules.Add("г", "h");
            rules.Add("ґ", "g");
            rules.Add("д", "d");
            rules.Add("е", "e");
            rules.Add("є", "ie");
            rules.Add(" є", " ye");
            rules.Add("ж", "zh");
            rules.Add("з", "z");
            rules.Add("и", "y");
            rules.Add("і", "i");
            rules.Add("ї", "i");
            rules.Add(" ї", " yi");
            rules.Add("й", "i");
            rules.Add(" й", " y");
            rules.Add("к", "k");
            rules.Add("л", "l");
            rules.Add("м", "m");
            rules.Add("н", "n");
            rules.Add("о", "o");
            rules.Add("п", "p");
            rules.Add("р", "r");
            rules.Add("с", "s");
            rules.Add("т", "t");
            rules.Add("у", "u");
            rules.Add("ф", "f");
            rules.Add("х", "kh");
            rules.Add("ц", "ts");
            rules.Add("ч", "ch");
            rules.Add("ш", "sh");
            rules.Add("щ", "shch");
            rules.Add("ю", "iu");
            rules.Add(" ю", " yu");
            rules.Add("я", "ia");
            rules.Add(" я", " ya");

            rules.Add("ь", "");
            rules.Add("’", "");

            rules.Add("зг", "zgh");
            rules.Add("Зг", "Zgh");
        }
    }
}
