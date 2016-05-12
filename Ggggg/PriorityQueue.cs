using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ggggg
{
    class PriorityQueue<T>
    {
        private SortedDictionary<int, Queue<T>> priorityQueue;

        public PriorityQueue()
        {
             priorityQueue = new SortedDictionary<int, Queue<T>>();
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var queue in priorityQueue.Values)
                {
                    count += queue.Count;
                }
                return count;
            }
            private set { }
        }

        public void Clear()
        {
            foreach (var queue in priorityQueue.Values)
            {
                queue.Clear();
            }
        }

        public void Enqueue(T item, int priority = 1)
        {
            if (priorityQueue.ContainsKey(priority))
            {
                priorityQueue[priority].Enqueue(item);
            }
            else
            {
                var newQueue = new Queue<T>();
                newQueue.Enqueue(item);
                priorityQueue.Add(priority, newQueue);
            }
            Count++;
        }

        public T Dequeue()
        {
            return Dequeue(priorityQueue.First().Key);
        }

        public T Dequeue(int priority)
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var returnItem = priorityQueue[priority].Dequeue();

            if (priorityQueue[priority].Count == 0)
            {
                priorityQueue.Remove(priority);
            }

            Count--;

            return returnItem;
        }

        public T Peek()
        {
            return Peek(priorityQueue.First().Key);
        }

        public T Peek(int priority)
        {
            return priorityQueue[priority].Peek();
        }
    }
}
