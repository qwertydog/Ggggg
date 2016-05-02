using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ggggg
{
    internal class Ggggg
    {
        Dictionary<char, string> letters;

        public Ggggg(Dictionary<char, string> letters)
        {
            this.letters = letters;
        }

        public string Decode(string input)
        {
            string output = string.Empty;
            string currentLetter = string.Empty;

            for (int i=0; i<input.Length; i++)
            {
                currentLetter += input[i].ToString();

                if (!currentLetter.ToUpper().Contains("G"))
                {
                    output += currentLetter;
                    currentLetter = string.Empty;
                    continue;
                }

                foreach (var letter in letters)
                {
                    if (letter.Value == currentLetter)
                    {
                        output += letter.Key;
                        currentLetter = string.Empty;
                        break;
                    }
                }
            }

            return output;
        }
    }
}
