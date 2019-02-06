using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class MyLinkedList<T> : IEnumerable<T>
    {
        Node<T> first;

        public void Insert(T nodeItem)
        {
            Node<T> newNode = new Node<T>(nodeItem);

            if (first == null)
            {
                first = newNode;
            }
            else
            {
                Node<T> current = first;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                newNode.Prev = current;
            }
        }
        public void Insert(T nodeItem, int index)
        {
            Node<T> newNode = new Node<T>(nodeItem);
            if (first == null && index == 0)
            {
                first = newNode;
            }
            else
            {
                Node<T> current = first;
                int i = 0;
                while (current != null && index != i)
                {
                    current = current.Next;
                    i++;
                }
                if (current == null)
                {
                    Insert(nodeItem);
                }
                else if (current.Prev == null)
                {
                    newNode.Next = first;
                    first = newNode;
                    first.Next.Prev = first;
                }
                else if (index == i)
                {
                    if (current.Next != null)
                    {
                        newNode.Prev = current.Prev;
                        current.Prev.Next = newNode;
                        if (current != null)
                        {
                            newNode.Next = current;
                            current.Prev = newNode;
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("A megadott indexre nem hoztható létre nodeItem");
                }
            }
        }
        public void Delete(T toDelete)
        {
            if (first != null)
            {
                Node<T> current = first;
                while (current != null && !current.NodeItem.Equals(toDelete))
                {
                    current = current.Next;
                }
                if (first == null)
                {
                    first = first.Next;
                }
                else if (current != null)
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        first = current.Next;
                    }
                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                }
                else
                {
                    throw new ArgumentException("The list does not contain this item.");
                }
            }
        }
        public void Delete(int index)
        {
            if (first != null)
            {
                int idx = 0;
                Node<T> current = first;
                while (current != null && idx != index)
                {
                    current = current.Next;
                    idx++;
                }
                if (first == null)
                {
                    first = first.Next; 
                }
                else if (current != null && idx == index)
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        first = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("Index does not exist in the list");
                }
            }
        }
        public bool Search(T searched)
        {
            Node<T> current = first;
            while (current != null && !current.NodeItem.Equals(searched))
            {
                current = current.Next;
            }
            return current != null;
        }
        public Node<T> KeresesIndexes(int index)
        {
            int idx = 0;
            Node<T> current = first;
            while (current != null && idx != index)
            {
                current = current.Next;
                idx++;
            }
            if (current != null && idx == index)
            {
                return current;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public int Length()
        {
            int x = 0;
            if (first != null)
            {
                x = 1;
                Node<T> current = first;
                while (current.Next != null)
                {
                    current = current.Next;
                    x++;
                }
            }
            return x;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListWalkThrough<T>(first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LinkedListWalkThrough<T>(first);
        }
    }

    internal class LinkedListWalkThrough<T> : IEnumerator<T>
    {
        private Node<T> first;
        Node<T> current;

        public LinkedListWalkThrough(Node<T> first)
        {
            this.first = first;
            current = null;
        }

        public T Current
        {
            get
            {
                return current.NodeItem;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return current.NodeItem;
            }
        }

        public void Dispose()
        {
            first = null;
            current = null;
        }

        public bool MoveNext()
        {
            if (first != null)
            {
                if (current == null)
                {
                    current = first;
                    return true;
                }
                else if (current.Next != null)
                {
                    current = current.Next;
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            current = null;
        }
    }
}
