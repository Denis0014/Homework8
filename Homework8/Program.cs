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
            var nodeTemp = new Node(values.First(), null, null);
            foreach (var value in values.Skip(1))
            {
                nodeTemp.Next = new Node(value, nodeTemp, null);
                nodeTemp = nodeTemp.Next;
            }
            while (nodeTemp.Prev != null)
            {
                nodeTemp = nodeTemp.Prev;
            }
            node = nodeTemp;
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
            node.Prev = new Node(value, null, node);
            node = node.Prev;
        }
        public void AddLast(T value)
        {
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = new Node(value, node, null);
            while (node.Prev != null)
            {
                node = node.Prev;
            }
        }
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
        }
    }
}