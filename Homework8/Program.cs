using System;
using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace Homework8
{
    public class AgileLinkedList<T>
    {
        public class Node
        {
            public T? Value;
            public Node? Prev;
            public Node? Next;
            public Node(T? value, Node? prev, Node? next)
            {
                Value = value;
                Prev = prev;
                Next = next;
            }
        }
        private Node node;
        public AgileLinkedList(IEnumerable<T> values)
        {
            if (values.Count() == 0)
            {
                node = null;
                return;
            }
            var first = node = new Node(values.First(), null, null);
            foreach (var value in values.Skip(1))
            {
                node.Next = new Node(value, node, null);
                node = node.Next;
            }
            node = first;
        }
        public Node First() => node;
        public Node Last()
        {
            var nodeTemp = node;
            if (nodeTemp == null)
            {
                return null;
            }
            while (nodeTemp.Next != null)
                nodeTemp = nodeTemp.Next;
            return nodeTemp;
        }
        public int Count()
        {
            var nodeTemp = node;
            if (nodeTemp == null)
            {
                return 0;
            }
            var c = 1;
            while (nodeTemp.Next != null)
            {
                nodeTemp = nodeTemp.Next;
                c++;
            }
            return c;
        }
        public void AddFirst(T value)
        {
            if (node == null)
            {
                node = new Node(value, null, null);
                return;
            }
            node.Prev = new Node(value, null, node);
            node = node.Prev;
        }
        public void AddLast(T value)
        {
            var first = node;
            if (node == null)
            {
                node = new Node(value, null, null);
                return;
            }
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = new Node(value, node, null);
            node = first;
        }
        public bool Remove(int n)
        {
            var first = node;
            if (n > this.Count() || n < 0)
            {
                return false;
            }
            for (var i = 0; i < n; i++)
            {
                node = node.Next;
            }
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            node = first;
            return true;
        }
        public bool Insert(int n, T value)
        {
            var first = node;
            if (n > this.Count() || n < 0)
            {
                return false;
            }
            for (var i = 0; i < n; i++)
            {
                node = node.Next;
            }
            var nodeTemp = new Node(value, node, node.Next);
            node.Next.Prev = nodeTemp;
            node.Next = nodeTemp;
            node = first;
            return true;
        }
        public void Reverse()
        {
            if (this.Count() == 0)
            {
                node = null;
                return;
            }
            var nodeTemp = new Node(this.Last().Value, null, null);
            node = this.Last().Prev;
            while (node != null)
            {
                nodeTemp.Next = new Node(node.Value, nodeTemp, null);
                nodeTemp = nodeTemp.Next;
                node = node.Prev;
            }
            node = nodeTemp;
            while (node.Prev != null)
                node = node.Prev;
        }
        /* public void ShiftLeft(int n)
        {
            if (node == null)
            {
                return;
            }
            for (int i = 0; i < n; i++)
            {
                var count = this.Count();
                var first = node;
                var nodeTemp = node;
                node.Prev = this.Last();
                node = this.Last();
                node.Next = first;
                node = first;
                for (var j = 0; j < count; j++)
                {
                    nodeTemp.Next.Prev = node;
                    nodeTemp.Next = node.Next.Next;
                    node = node.Next;
                }
                node.Next = null;
                node = first;
                node.Prev = null;
                node = first;
            }
        } */

        public override string ToString()
        {
            var nodeTemp = node;
            var res = "";
            if (nodeTemp == null)
            {
                return "<empty>";
            }
            while (nodeTemp.Next != null)
            {
                res += nodeTemp.Value + " <-> ";
                nodeTemp = nodeTemp.Next;
            }
            res += nodeTemp.Value + "";
            return res;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var lst = new AgileLinkedList<int>(new List<int> { 1, 2, 3, 4, 5 });
            Console.WriteLine(lst.ToString());
            Console.WriteLine(lst.Last()?.Value);
            Console.WriteLine(lst.Count());
            lst.AddFirst(0);
            lst.AddLast(6);
            Console.WriteLine(lst.ToString());
            lst.Remove(3);
            Console.WriteLine(lst.ToString());
            lst.Insert(2, 3);
            Console.WriteLine(lst.ToString());
            // lst.ShiftLeft(3);
            // Console.WriteLine(lst.ToString());
            lst.Reverse();
            Console.WriteLine(lst.ToString());
        }
    }
}