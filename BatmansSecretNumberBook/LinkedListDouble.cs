using System;
using System.Collections;
using System.Collections.Generic;

namespace BatmansSecretNumberBook
{
    class LinkedListDoubleNode<T>
    {
        public LinkedListDoubleNode<T>? Next { get; set; }
        public LinkedListDoubleNode<T>? Previous { get; set; }
        
        public T Value { get; }

        public LinkedListDoubleNode(T value)
        {
            Value = value;
        }
    }

    class LinkedListDouble<T> : IEnumerable<T>
    {
        public int Count { get; private set; }

        public LinkedListDoubleNode<T>? Head { get; private set; }
        public LinkedListDoubleNode<T>? Tail { get; private set; }

        public LinkedListDouble()
        {
            Count = 0;
            Head  = null;
            Tail = null;
        }

        //Hinzufügen
        public void AddToFront(T value)
        {
            var newNode = new LinkedListDoubleNode<T>(value);
            newNode.Next = Head;
            newNode.Previous = null;

            if (Head != null)
            {
                Head.Previous = newNode;
            }

            Head = newNode;

            if (Tail == null)
            {
                Tail = newNode;
            }

            Count++;
        }
        public void AddToBack(T value)
        {
            var newNode = new LinkedListDoubleNode<T>(value);
            newNode.Next = null;
            newNode.Previous = Tail;

            if (Tail != null)
            {
                Tail.Next = newNode;
            }

            Tail = newNode;

            if (Head == null)
            {
                Head = newNode;
            }

            Count++;
        }
        public void AddAtPos(T value, int position)
        {
            var newNode = new LinkedListDoubleNode<T>(value);

            if (position > Count)
            {
                throw new IndexOutOfRangeException("Position was out of range");
            }
            else if (position == 0)
            {
                AddToFront(value);
            }
            else if (position == Count)
            {
                AddToBack(value);
            }
            else
            {
                var current = Head;
                for (int i = 0; i < position - 1; i++)
                {
                    if (current == null)
                    {
                        throw new InvalidOperationException("Invalid state: current is null");
                    }
                    current = current.Next;
                }

                if (current == null || current.Next == null)
                {
                    throw new InvalidOperationException("Invalid state: current or current.Next is null");
                }

                newNode.Next = current.Next;
                newNode.Previous = current;
                current.Next.Previous = newNode;
                current.Next = newNode;

                Count++;
            }
        }


        //Entfernen
        public void RemoveAtFront()
        {
            if (Head == null || Tail == null)
            {
                throw new InvalidOperationException("LinkedList is empty");
            }

            Head = Head.Next;

            if (Head != null)
            {
                Head.Previous = null;
            }

            Count--;
        }
        public void RemoveAtEnd()
        {
            if (Head == null || Tail == null)
            {
                throw new InvalidOperationException("LinkedList is empty");
            }

            Tail = Tail.Previous;

            if (Tail != null)
            {
                Tail.Next = null;
            }

            Count--;
        }
        public void RemoveAtPos(int position)
        {
            if (position >= Count)
            {
                throw new IndexOutOfRangeException("Position was out of range");
            }
            else if (position == 0)
            {
                RemoveAtFront();
            }
            else if (position == Count - 1)
            {
                RemoveAtEnd();
            }
            else
            {
                var current = Head;
                for (int i = 0; i < position - 1; i++)
                {
                    if (current == null)
                    {
                        throw new InvalidOperationException("Invalid state: current is null");
                    }
                    current = current.Next;
                }

                if (current == null || current.Next == null || current.Next.Next == null)
                {
                    throw new InvalidOperationException("Invalid state: current, current.Next, or current.Next.Next is null");
                }

                current.Next = current.Next.Next;
                current.Next.Previous = current;

                Count--;
            }
        }
        public void RemoveWhere(Func<T, bool> predicate)
        {
            LinkedListDoubleNode<T>? current = Head;

            while (current != null)
            {
                if (predicate(current.Value))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        Head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        Tail = current.Previous;
                    }

                    Count--;
                }

                current = current.Next;
            }
        }


        //Suchen nach
        public bool Contains(Func<T, bool> predicate)
        {
            LinkedListDoubleNode<T>? current = Head;

            while (current != null)
            {
                if (predicate(current.Value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }
        public bool Contains(Func<T, bool> predicate, out T? found)
        {
            LinkedListDoubleNode<T>? current = Head;

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


            LinkedListDoubleNode<T>? current = Head;

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
