using System;
using System.Collections;

namespace BatmansSecretNumberBook
{
    public class LinkedListNode<T>
    {
        public LinkedListNode<T>? Next { get; set; }
        public T Value { get; }

        public LinkedListNode(T value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value), "Value cannot be null");
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        private int count;
        public int Count { get { return count; } }

        private LinkedListNode<T>? head;
        public LinkedListNode<T>? Head { get { return head; } }

        public LinkedList()
        {
            count = 0;
            head = null;
        }

        //Elemente hinzufügen
        public void AddToFront(T value)
        {
            var newNode = new LinkedListNode<T>(value);
            newNode.Next = head;
            head = newNode;
            count++;
        }
        public void AddToBack(T value)
        {
            var newNode = new LinkedListNode<T>(value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

            count++;
        }
        public void AddAtPos(T value, int position)
        {
            if (position < 0 || position > count)
            {
                throw new IndexOutOfRangeException("Position was out of range");
            }

            var newNode = new LinkedListNode<T>(value);

            if (position == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                var current = head!;

                for (int i = 0; i < position - 1; i++)
                {
                    current = current.Next!;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
            }

            count++;
        }

        //Elemente entfernen
        public void RemoveAtFront()
        {
            if (head == null)
            {
                throw new InvalidOperationException("LinkedList is empty");
            }

            head = head.Next;
            count--;
        }
        public void RemoveAtEnd()
        {
            if (head == null)
            {
                throw new InvalidOperationException("LinkedList is empty");
            }

            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                var current = head!;

                while (current.Next?.Next != null)
                {
                    current = current.Next!;
                }

                current.Next = null;
            }

            count--;
        }
        public void RemoveAtPos(int position)
        {
            if (position < 0 || position >= count)
            {
                throw new IndexOutOfRangeException("Position was out of range");
            }

            if (position == 0)
            {
                RemoveAtFront();
            }
            else
            {
                var current = head!;

                for (int i = 0; i < position - 1; i++)
                {
                    current = current.Next!;
                }

                current.Next = current.Next?.Next;
                count--;
            }
        }
        public void RemoveWhere(Func<T, bool> predicate)
        {
            LinkedListNode<T>? current = head;
            LinkedListNode<T>? previous = null;

            while (current != null)
            {
                if (predicate(current.Value))
                {
                    if (previous == null)
                    {
                        head = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    count--;
                }
                else
                {
                    previous = current;
                }

                current = current.Next;
            }
        }
        

        public bool Contains(Func<T, bool> predicate, out T? found)
        {
            LinkedListNode<T>? current = head;

            while (current != null)
            {
                if (predicate(current.Value))
                {
                    found = current.Value;
                    return true;
                }

                current = current.Next;
            }
            found = default;
            return false;
        }

        /*
         * Implementation für IEnumerator.
         * So kann man ein Objekt deiser
         * Klasse als Liste behandeln und mit
         * einer foreach Schleife durch Iterieren
         */
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T>? current = head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
