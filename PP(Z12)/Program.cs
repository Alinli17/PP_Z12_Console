using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PP_Z12_
{
    class RegExp
    {
        private Regex r;
        private string text;

        public RegExp(string pattern, string txt)
        {
            r = new Regex(pattern);
            text = txt;
        }
       
        public Regex R
        {
            get { return r; }
            set { r = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public object CheckType(int n)
        {
            if (n == 0)
            {
                return new Regex("");
            }
            else if (n == 1)
            {
                return "string";
            }

            return null;
        }

        public object this[int i]
        {
            set
            {

                var result = CheckType(i);
                if (result.GetType() == typeof(Regex))
                {
                    R = (Regex)value;
                }
                else
                {
                    text = value.ToString();
                }
            }
            get
            {
                var result = CheckType(i);
                if (result.GetType() == typeof(Regex))
                {
                    return R;
                }
                else
                {
                    return text;
                }

            }
        }
        public static string operator -(RegExp My)
        {
            MatchCollection m = My.r.Matches(My.text);
            string s = My.text;
            foreach (Match x in m)
            {
                int i = s.IndexOf(x.Value);
                int l = x.Value.Length;

                s = s.Remove(i, l);
            }
            return s;
        }
        public static bool operator true(RegExp My)
        {
            if (My.text.Length != 0)
                return true;
            else
                return false;
        }
        public static bool operator false(RegExp My)
        {
            if (My.text.Length == 0)
                return false;
            else
                return true;
        }
        public static string operator +(RegExp My, string str)
        {
            My.Text += str;
            return My;
        }

        public static implicit operator string(RegExp r)
        {
            return r.ToString();
        }

        public static implicit operator Regex(RegExp text)
        {
            return new Regex(text);
        }
        public override string ToString()
        {
            return $"{text}";
        }
    }
    class Program
        {
        static void Main(string[] args)
        {

            string text = "Мой телефон 8(926)123-45-67, а у мамы +7 926 123 45 67";
            string pattern = @"((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}";

            Console.WriteLine("Строка текста:\n" + text + "\n");
            Console.WriteLine("Регулярное выражение:\n" + pattern + "\n");

            RegExp My = new RegExp(pattern, text);

            Console.WriteLine($"Операция унарного -:\n{-My}\n");

            if (My) Console.WriteLine("Поле text не пустое!\n");
            else Console.WriteLine("Поле text постое!\n");

            Console.WriteLine($"Операция бинарного +:\n{My+" - Это пример"}\n");

            Console.WriteLine("Индексатор, позволяющий по индексу 0 обращаться к полю r (My[0]):");
            Console.WriteLine(My[0]);
            Console.WriteLine("\nИндексатор, позволяющий по индексу 1 обращаться к полю text (My[1]):");
            Console.WriteLine(My[1]);            

            Console.ReadKey();
        }
    }
}
