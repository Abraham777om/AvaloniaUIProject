using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaDef;

namespace AvaloniaDef
{
    internal class Node
    {
        public Node right { get; set; }
        public Node left { get; set; }
        public int data { get; set; }
        public int id { get; set; }

        public int num = 1;

        public Node(int value)
        {
            data = value;
        }

        public void add(int data, string direction)
        {
            if (direction.Equals("left"))
            {
                if (left == null)
                {
                    left = new Node(data);
                    left.id = id++;
                }
                else
                {
                    left.add(data, direction);
                }
            }
            else if (direction.Equals("right"))
            {
                if (right == null)
                {
                    right = new Node(data);
                    right.id = id++;
                }
                else
                {
                    right.add(data, direction);
                }
            }
            else
            {
                return;
            }
        }

        public void search(int value)
        {
            if (left != null && left.data != value && right != null && right.data != value)
            {
                if (left != null)
                {
                    left.search(value);
                    right.search(value);
                }
                else
                {
                    right.search(value);
                    left.search(value);
                }
            }
            else
            {
                if (left != null && (left.data == value || data == value))
                {
                    Console.WriteLine(left + " " + left.data);
                }
                else if (right != null && (right.data == value || data == value))
                {
                    Console.WriteLine(right + " " + right.data);
                }
                else
                {
                    return;
                }
            }
        }

        public void change(int value, int newValue)
        {
            if (left != null && left.data != value && right != null && right.data != value)
            {
                if (left != null)
                {
                    left.change(value, newValue);
                    right.change(value, newValue);
                }
                else
                {
                    right.change(value, newValue);
                    left.change(value, newValue);
                }
            }
            else
            {
                if (left != null && (left.data == value || data == value))
                {
                    left.data = newValue;
                }
                else if (right != null && (right.data == value || data == value))
                {
                    right.data = newValue;
                }
                else
                {
                    return;
                }
            }
        }

        public void height()
        {
            height(num);
        }

        public void height(int num)
        {
            if (left != null || left != null)
            {
                if (left != null)
                {
                    num = num + 1;
                    left.height(num);
                }
                else
                {
                    num = num + 1;
                    right.height(num);
                }
            }
            else
            {
                Console.WriteLine(num);
            }
        }

        public void remove(int value)
        {
            if (left != null && left.data != value && right != null && right.data != value)
            {
                if (left != null)
                {
                    left.remove(value);
                    right.remove(value);
                }
                else if (right != null)
                {
                    right.remove(value);
                    left.remove(value);
                }
            }
            else
            {
                if (left != null && (left.data == value || data == value))
                {
                    left = null;
                }
                else if (right != null && (right.data == value || data == value))
                {
                    right = null;
                }
            }
        }

        public void print()
        {
            if (left != null || right != null)
            {
                if (left != null)
                {
                    string str = new string(' ', left.id);
                    Console.WriteLine(str + left.data);
                    left.print();
                }
                if (right != null)
                {
                    string str = new string(' ', right.id);
                    Console.WriteLine(str + right.data);
                    right.print();
                }
            }
        }

        public void inOrder()
        {
            if (left != null)
                left.inOrder();
            Console.WriteLine(data);
            if (right != null)
                right.inOrder();
        }

        public void preOrder()
        {
            Console.WriteLine(data);
            if (left != null)
                left.preOrder();
            if (right != null)
                right.preOrder();
        }

        public void postOrder()
        {
            if (left != null)
                left.postOrder();
            if (right != null)
                right.postOrder();
            Console.WriteLine(data);
        }
    }
}
