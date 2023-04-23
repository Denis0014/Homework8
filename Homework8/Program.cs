using System;
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
        public AgileLinkedList(params T[] values)
        {
            if (values.Length == 0)
            {
                node = null;
                return;
            }
            var nodeTemp = new Node(values.First(), null, null);
            var c = 0;
            for (int i = 1; i < values.Length; i++)
            {
                nodeTemp.Next = new Node(values[i], nodeTemp, null);
                nodeTemp = nodeTemp.Next;
                c++;
            }
            while (c > 0)
            {
                nodeTemp = nodeTemp.Prev;
                c--;
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
            var root = new AgileLinkedList<int>(1, 2, 3, 4, 5);
            Console.WriteLine(root.ToString());
            Console.WriteLine(root.Last()?.Value);
            Console.WriteLine(root.Count());
        }
    }
}