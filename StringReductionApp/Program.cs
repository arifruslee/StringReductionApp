using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringReductionApp
{
    class Program
    {
        public static string StringReduction(string[] args)
        {
            var inputString = args[0];
            var words = new Dictionary<string, string>
            {
            {"ab", "c"},
            {"ac", "b"},
            {"ba", "c"},
            {"bc", "a"},
            {"ca", "b"},
            {"cb","a"}
            };

            //Only accept a, b or c combinations (Distinct of dictionary values).
            var distinctWordsCheck = words.Select(s => Convert.ToChar(s.Value)).Distinct().ToList();
            if (inputString.Except(distinctWordsCheck).Any())
                return "Only a, b, c";

            //Loop through as long as inputString has any different characters inside to be reduced
            while (inputString.Distinct().Count() > 1)
            {
                //Replaces inputString according to the dictionary Key Value pair. StringBuilder to be used for the aggregate func for performance.
                inputString = words.Aggregate(new StringBuilder(inputString), (current, value) => current.Replace(value.Key, value.Value)).ToString();
            }

            return inputString.Length.ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(StringReduction(args));
        }
    }
}
