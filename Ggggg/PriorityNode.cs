using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ggggg
{
    public abstract class PriorityNode<T>
    {
        public int frequency { get; protected set; }
    }

    public class LeafNode<T> : PriorityNode<T>
    {
        public readonly T symbol;
        /*public string Key
        {
            get
            {
                return Key;
            }
            set
            {
                Key = value;
            }
        }*/

        public LeafNode(T symbol, int frequency)
        {
            this.symbol = symbol;
            this.frequency = frequency;
        }
    }

    public class InternalNode<T> : PriorityNode<T>
    {
        public PriorityNode<T> leftChild { get; }
        public PriorityNode<T> rightChild { get; }

        public InternalNode(PriorityNode<T> leftChild, PriorityNode<T> rightChild)
        {
            this.leftChild = leftChild;
            this.rightChild = rightChild;
            frequency = leftChild.frequency + rightChild.frequency;
        }
    }

}
