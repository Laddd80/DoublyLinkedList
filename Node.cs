using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class Node<T>
    {
        T nodeItem;
        Node<T> prev;
        Node<T> next;

        public T NodeItem { get => nodeItem; set => nodeItem = value; }
        internal Node<T> Prev { get => prev; set => prev = value; }
        internal Node<T> Next { get => next; set => next = value; }

        public Node(T nodeItem)
        {
            NodeItem = nodeItem;
        }
    }
}
