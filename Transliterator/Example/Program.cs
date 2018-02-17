using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transliterator;

namespace Example
{
    class Program
    {
        static Dictionary<string, string> rules = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            SetNewRules();

            string name = "яна Кравінський Василь Олександрович";

            Transliter tr = new Transliter();

            Console.WriteLine(name);
            Console.WriteLine();
            Console.WriteLine("Translit with dafault rules:");
            Console.WriteLine(tr.Translit(name));
            Console.WriteLine();

            Console.WriteLine("Translit with custom rules:");
            tr.SetNewRules(rules);
            Console.WriteLine(tr.Translit(name));
            Console.WriteLine();

            Console.WriteLine("Translit with custom rules and modefided rule \"a\" - \"+_+\" :");
            tr.ModifyRule("а", "+_+");
            Console.WriteLine(tr.Translit(name));

            Console.ReadKey();
        }
        public static void SetNewRules()
        {
            rules.Add("А", "A");
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
            rules.Add("і", "--");
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
        }
    }
}
