using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ggggg
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] letters = Console.ReadLine().Split(' ');
            Dictionary<char, string> dict = new Dictionary<char, string>();
            
            for (int i=0; i<letters.Length; i+=2)
            {
                char letter = char.Parse(letters[i]);
                string translation = letters[i + 1];

                dict.Add(letter, translation);
            }

            Ggggg ggggg = new Ggggg(dict);

            string output = ggggg.Decode(Console.ReadLine());

            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
