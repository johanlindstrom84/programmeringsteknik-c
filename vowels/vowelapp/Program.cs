using System;
using System.Collections.Generic;
using System.Linq;

namespace vowelapp
{
    class Program
    {
        private char[] _vowels;

        public char[] vowels { get; set;}
        static void Main(string[] args)
        {
            char[] vowels = new Char[] { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };
            Console.WriteLine("skriv en sträng: ");
            var input = Console.ReadLine();
            var output = new List<char>();
            int remowedcount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var currentCharacter = input[i];
                var normalizedCharacter = char.ToLower(currentCharacter);

                if (vowels.Contains(normalizedCharacter) == false)
                {
                    output.Add(currentCharacter);
                
                }
                else
                {
                    remowedcount++;
                }

            }
            var resultingString = new string(output.ToArray());

            Console.WriteLine($"Din sträng utan vokaler: {resultingString}, vi tog bort: {remowedcount}");

        }
        

    }
}
