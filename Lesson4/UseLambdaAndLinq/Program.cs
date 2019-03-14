/*
 * Дан фрагмент программы:
   Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };

            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });

            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
 * Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
 * * Развернуть обращение к OrderBy с использованием делегата .
 * 
 * Сергей Ткачев
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseLambdaAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four", 4 },
                {"two",  2 },
                {"one",  1 },
                {"three",3 },
            };

            var d = dict.OrderBy(pairs => pairs.Value);

            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }


            Console.ReadLine();
        }
    }
}
