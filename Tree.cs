using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AvaloniaDef
{
    internal class Tree
    {
        public Node root { get; set; }
        public List<int> list1 = new List<int>();
        public List<int> datas = new List<int>();

        public void insert(Node node, string direction, Node unNode)
        {
            if (root == null)
            {
                root = node;
                root.id += 1;
                datas.Add(root.data);
            }
            else
            {
                if (direction.Equals("left") && unNode.left == null)
                {
                    unNode.left = node;
                    unNode.left.id = unNode.id + 1;
                    datas.Add(node.data);
                }
                else if (direction.Equals("right") && unNode.right == null)
                {
                    unNode.right = node;
                    unNode.right.id = unNode.id + 1;
                    datas.Add(node.data);
                }
                else
                {
                    return;
                }
            }

        }

        public int select(int data)
        {
            if (root != null)
            {
                if (data == root.data)
                {
                    Console.WriteLine(root + " " + root.data);
                    return root.data;
                }
                else
                {
                    root.search(data);
                }
            }
            else
            {
                return 0;
            }
            return 0;
        }

        public int select2(int data)
        {
            if (datas.Contains(data))
            {
                return data;
            }
            else
            {
                return 0;
            }
        }

        public void update(int value, int data)
        {
            if (root != null)
            {
                if (value == root.data)
                {
                    datas.Remove(root.data);
                    root.data = data;
                    datas.Add(data);
                }
                else
                {
                    root.change(value, data);
                }
            }
            else
            {
                return;
            }
        }

        public void height()
        {
            if (root != null)
            {
               root.height();
            }
            else
            {
                return;
            }
        }

        public void printTree()
        {
            Console.WriteLine(root.data);
            if (root != null)
            {
                root.print();
            }
            else
            {
                return;
            }
        }

        public void delete(int data)
        {
            if (root != null)
            {
                if (data == root.data)
                {

                }
                else
                {
                    root.remove(data);
                }
            }
            else
            {
                return;
            }
        }

        public void inOrder()
        {
            if (root != null)
                root.inOrder();
            else
            {
                return;
            }
        }

        public void preOrder()
        {
            if (root != null)
            {
                root.preOrder();
            }
            else
            {
                return;
            }
        }

        public void postOrder()
        {
            if (root != null)
            {
                root.postOrder();
            }
            else
            {
                return;
            }
        }
    }
}
