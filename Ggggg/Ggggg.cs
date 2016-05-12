using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ggggg
{
    internal class Ggggg
    {
        public Ggggg() { }

        public string Decode(string keys, string input)
        {
            string output = string.Empty; 
            string currentLetter = string.Empty;

            Dictionary<string, char> letters = new Dictionary<string, char>();

            string[] letterTokens = keys.Split(' ');

            for (int i = 0; i < letterTokens.Length; i += 2)
            {
                char letter = char.Parse(letterTokens[i]);
                string key = letterTokens[i + 1];

                letters.Add(key, letter);
            }

            for (int i = 0; i < input.Length; i++)
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
                    if (letter.Key == currentLetter)
                    {
                        output += letter.Value;
                        currentLetter = string.Empty;
                        break;
                    }
                }
            }

            return output;
        }

        public string Encode(string input)
        {
            Dictionary<char, string> keys = GenerateKeys(input);

            string output = string.Empty;

            foreach (char character in input)
            {
                if (char.IsLetter(character))
                {
                    output += keys[character];
                }
                else
                {
                    output += character;
                }
            }
            return output;
        }

        private Dictionary<char, string> GenerateKeys(string input)
        {
            SortedDictionary<char, int> letters = new SortedDictionary<char, int>();

            foreach (var letter in input)
            {
                if (char.IsLetter(letter))
                {
                    if (!letters.ContainsKey(letter))
                    {
                        letters.Add(letter, 1);
                    }
                    else
                    {
                        letters[letter]++;
                    }
                }
            }
            
            PriorityQueue<PriorityNode<char>> huffmanQueue = new PriorityQueue<PriorityNode<char>>();

            foreach (var letter in letters)
            {
                var leafNode = new LeafNode<char>(letter.Key, letter.Value);
                huffmanQueue.Enqueue(leafNode, letter.Value);
            }

            while (huffmanQueue.Count > 1)
            {
                var first = huffmanQueue.Dequeue();
                var second = huffmanQueue.Dequeue();

                var internalNode = new InternalNode<char>(first, second);

                huffmanQueue.Enqueue(internalNode, internalNode.frequency);
            }

            var root = huffmanQueue.Dequeue();
            var keys = new Dictionary<char, string>();

            TraverseTree(keys, root, string.Empty);

            foreach (var key in keys)
            {
                Console.Write("{0} {1} ", key.Key, key.Value);
            }
            Console.Write("\n");
            return keys;
        }

        private void TraverseTree(Dictionary<char, string> keys, PriorityNode<char> currentNode, string code)
        {
            if (currentNode is InternalNode<char>)
            {
                TraverseTree(keys, (currentNode as InternalNode<char>).leftChild, code + "g");
                TraverseTree(keys, (currentNode as InternalNode<char>).rightChild, code + "G");
            }
            else
            {
                keys.Add((currentNode as LeafNode<char>).symbol, code);
            }
        }
    }
}
