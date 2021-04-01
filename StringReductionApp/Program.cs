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
            List<char> checkCharacters = new List<char>() { 'a', 'b', 'c' };

            //Only accept a, b or c combinations.
            if (inputString.Except(checkCharacters).Any())
                return "Only a, b, c";

            //Loop as long as inputString has any different characters inside to be reduced
            while (inputString.Distinct().Count() > 1)
            {
                List<char> outputCharacters = new List<char>();
                //Loop through current inputString iteration to check all adjacent chars
                for (var i = 0; i < inputString.Length; i++)
                {
                    var currChar = inputString[i];
                    char? prevChar = outputCharacters.Count > 0 ? outputCharacters.Last() : null;

                    //On 1st loop or whenever current char and previous char are the same, to move to next char checking
                    if (i == 0 || currChar == prevChar)
                    {
                        outputCharacters.Add(currChar);
                        continue;
                    }

                    List<char> processCharacters = new List<char>() { Convert.ToChar(prevChar), currChar };
                    //Get the char difference between the 2 adjacent chars for reduction
                    outputCharacters[outputCharacters.Count - 1] = checkCharacters.Except(processCharacters).FirstOrDefault();
                }
                //Reassign back for further checking if require anymore processing. Convert Char list back to String
                inputString = new string(outputCharacters.ToArray());
            }

            return inputString.Length.ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(StringReduction(args));
        }
    }
}
