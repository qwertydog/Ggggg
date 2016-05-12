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
            var ggggg = new Ggggg();

            //string keys = Console.ReadLine();

            while (true)
            {
                //string input = Console.ReadLine();
                //string output = ggggg.Decode(keys, input);
                //Console.WriteLine(output);

                string output = ggggg.Encode(Console.ReadLine());
                Console.WriteLine(output);
            }
        }
    }
}
