using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaDef
{
    internal class Graph
    {
        public Vertex root { get; set; }
        public List<Vertex> vertexes = new List<Vertex>();
        public List<string> datas = new List<string>();


        public void insert(Vertex vertex, Vertex onVertex, int wei)
        {

            if (root == null)
            {
                root = vertex;
                vertexes.Add(vertex);
                datas.Add(vertex.data);
            }
            else
            {
                Edge edge1 = new Edge();
                edge1.weight = wei;
                edge1.vertexIni = onVertex;
                edge1.vertexEnd = vertex;
                onVertex.edges.Add(edge1);

                //Edge edge2 = new Edge();
                //edge2.weight = wei;
                //edge2.vertexIni = vertex;
                //edge2.vertexEnd = onVertex;
                //vertex.edges.Add(edge1);

                onVertex.vertexes.Add(vertex);
                vertex.vertexes.Add(onVertex);

                datas.Add(onVertex.data);
                datas.Add(vertex.data);

                int x = 0;
                foreach (Vertex v in vertexes)
                {
                    if (v.data.Equals(vertex.data))
                    {
                        x += 1;
                    }
                }
                if (x == 0)
                {
                    vertexes.Add(vertex);
                    datas.Add(vertex.data);
                }
            }
        }

        public void insert2(Vertex vertex, string onData, int wei)
        {
            Vertex onVertex = new Vertex();

            foreach (Vertex v in vertexes)
            {
                if (onData.Equals(v.data))
                {
                    onVertex = v;
                }
            }

            if (root == null)
            {
                root = vertex;
                vertexes.Add(vertex);
            }
            else
            {
                Edge edge1 = new Edge();
                edge1.weight = wei;
                edge1.vertexIni = onVertex;
                edge1.vertexEnd = vertex;
                onVertex.edges.Add(edge1);

                //Edge edge2 = new Edge();
                //edge2.weight = wei;
                //edge2.vertexIni = vertex;
                //edge2.vertexEnd = onVertex;
                //vertex.edges.Add(edge1);

                onVertex.vertexes.Add(vertex);
                vertex.vertexes.Add(onVertex);

                int x = 0;
                foreach (Vertex v in vertexes)
                {
                    if (v.data.Equals(vertex.data))
                    {
                        x += 1;
                    }
                }
                if (x == 0)
                {
                    vertexes.Add(vertex);
                }
            }
        }

        public void delete(string data)
        {
            //foreach (Vertex v in vertexes)
            //{
            //    if (v.data.Equals(data))
            //    {
            //        v.vertexes.Clear();
            //        v.edges.Clear();
            //        vertexes.Remove(v);
            //    }
            //}

            for (int i = 0; i < vertexes.Count; i++)
            {
                if (vertexes[i].data.Equals(data))
                {
                    vertexes[i].vertexes.Clear();
                    vertexes[i].edges.Clear();
                    vertexes.Remove(vertexes[i]);
                }
            }
            foreach (Vertex v in vertexes)
            {
                foreach (Edge e in v.edges)
                {
                    if (e.vertexEnd.data.Equals(data))
                    {
                        v.edges.Remove(e);
                        break;
                    }
                }
            }
        }

        public string search(string data)
        {
            foreach (Vertex v in vertexes)
            {
                if (v.data.Equals(data))
                {
                    Console.WriteLine("Value found: " + v + " " + v.data);
                    return "Value found: " + v + " " + v.data;
                }
            }
            foreach (Vertex v in vertexes)
            {
                foreach (Edge e in v.edges)
                {
                    if (e.vertexIni.data.Equals(data) | e.vertexEnd.data.Equals(data))
                    {
                        Console.WriteLine("Edge: " + e.vertexIni.data + " " + e.vertexEnd.data);
                    }
                }
            }
            return "Value Not found";
        }
        public string printVertexes()
        {
            string x = "";
            foreach (Vertex v in vertexes)
            {
                Console.WriteLine(v.data);
                x += v.data + " ";
            }
            return x;
        }


        public string matrix()
        {
            string x = "";

            Console.Write(" ");
            x += " ";

            for (int i = 0; i < vertexes.Count(); i++)
            {
                Console.Write(" " + vertexes[i].data);
                x += " " + vertexes[i].data;
            }

            for (int i = 0; i < vertexes.Count(); i++)
            {
                Console.WriteLine(" ");
                Console.Write(vertexes[i].data);
                x += "\n";
                x += vertexes[i].data;

                for (int j = 0; j < vertexes.Count(); j++)
                {
                    //Console.WriteLine(vertexes[i].data + " " + vertexes[j].data);

                    if (vertexes[j].vertexes.Contains(vertexes[i]))
                    {
                        //Console.Write(vertexes[j].data);
                        //Console.WriteLine(" ");
                        Console.Write(" 1");
                        x += " 1";
                    }
                    else
                    {
                        //Console.Write(vertexes[j].data);
                        //Console.WriteLine(" ");
                        Console.Write(" 0");
                        x += " 0";
                    }
                }
            }
            return x;
        }
        public string bfs(Vertex vertex)
        {
            string x = "";
            List<Vertex> visited = new List<Vertex>();
            LinkedList<Vertex> queue = new LinkedList<Vertex>();
            visited.Add(vertex);
            queue.AddLast(vertex);

            while (queue.Count != 0)
            {
                vertex = queue.First();
                Console.WriteLine("next-> " + vertex.data);
                x += "next-> " + vertex.data + "\n";
                queue.RemoveFirst();

                foreach (Vertex v in vertex.vertexes)
                {
                    if (!visited.Contains(v))
                    {
                        visited.Add(v);
                        queue.AddLast(v);
                    }
                }
            }
            return x;
        }
        public string dfs(Vertex vertex)
        {
            string x = "";

            List<Vertex> visited = new List<Vertex>();
            Stack<Vertex> stack = new Stack<Vertex>();
            visited.Add(vertex);
            stack.Push(vertex);

            while (stack.Count != 0)
            {
                vertex = stack.Pop();
                Console.WriteLine("next-> " + vertex.data);
                x += "next-> " + vertex.data + " \n";

                foreach (Vertex v in vertex.vertexes)
                {
                    if (!visited.Contains(v))
                    {
                        visited.Add(v);
                        stack.Push(v);
                    }
                }
            }
            return x;
        }

 
        public string shortestPath(string data, Vertex vertexIni)
        {
            Vertex vertex = new Vertex();

            foreach (Vertex v in vertexes)
            {
                if (data.Equals(v.data))
                {
                    vertex = v;
                }
            }

            string x = "";
            List<Vertex> path = new List<Vertex>();
            List<Vertex> path2 = new List<Vertex>();
            Stack<Vertex> stack = new Stack<Vertex>();
            Stack<Vertex> vers = new Stack<Vertex>();
            Vertex vertexs = vertex;

            //delete("I");

            foreach (Vertex v in vertex.vertexes)
            {
                vers.Push(v);
            }

            //Console.WriteLine(" ");
            path.Add(vertex);
            Vertex pred = vertex;
            stack.Push(vertex);


            while (stack.Count != 0)
            {
                vertex = stack.Pop();
                //Console.WriteLine("Vertex: " + vertex.data);
                //Console.WriteLine("Pred: " + pred.data);
                foreach (Vertex v in vertex.vertexes)
                {
                    //Console.WriteLine("V: " + v.data);
                    if (!path.Contains(v) && v.vertexes.Contains(pred))
                    {
                        pred = v;
                        stack.Push(v);
                        path.Add(v);
                        //Console.WriteLine(v.data);
                    }
                }
            }
            int sum = 0;
            List<Vertex> final = new List<Vertex>();

            foreach (Vertex v in path)
            {
                final.Add(v);
                //Console.WriteLine(v.data);
                if (v.data.Equals("A"))
                {
                    break;
                }
            }

            Console.WriteLine(" ");

            foreach (Vertex v in final)
            {
                foreach (Edge e in v.edges)
                {
                    if (final.Contains(e.vertexIni) && final.Contains(e.vertexEnd))
                    {
                        //Console.WriteLine(e.vertexIni.data + "-> " + e.weight + " <-" + e.vertexEnd.data);
                        sum += e.weight;
                    }

                }
            }
            //Console.WriteLine(" ");
            //Console.WriteLine(sum);
            //Console.WriteLine(" ");




            int sum2 = 0;
            List<Vertex> final2 = new List<Vertex>();

            if (vers.Count > 1)
            {
                //path.Clear();
                path2.Add(vertexs);
                vertex = vers.Pop();
                //Console.WriteLine("Vertex: " + vertex.data);

                path2.Add(vertex);
                pred = vertex;
                stack.Push(vertex);


                while (stack.Count != 0)
                {
                    vertex = stack.Pop();
                    //Console.WriteLine("Vertex: " + vertex.data);
                    //Console.WriteLine("Pred: " + pred.data);
                    foreach (Vertex v in vertex.vertexes)
                    {
                        //Console.WriteLine("V: " + v.data);
                        if (!path2.Contains(v) && v.vertexes.Contains(pred))
                        {
                            pred = v;
                            stack.Push(v);
                            path2.Add(v);
                            //Console.WriteLine(v.data);
                        }
                    }
                }
                foreach (Vertex v in path2)
                {
                    final2.Add(v);
                    //Console.WriteLine(v.data);
                    if (v.data.Equals("A"))
                    {
                        break;
                    }
                }

                Console.WriteLine(" ");
                foreach (Vertex v in final2)
                {
                    foreach (Edge e in v.edges)
                    {
                        if (final2.Contains(e.vertexIni) && final2.Contains(e.vertexEnd))
                        {
                            //Console.WriteLine(e.vertexIni.data + "-> " + e.weight + " <-" + e.vertexEnd.data);
                            sum2 += e.weight;
                        }

                    }
                }
            }



            Console.WriteLine(" ");
            if (sum < sum2)
            {
                foreach (Vertex v in path)
                {
                    //final.Add(v);
                    Console.WriteLine(v.data);
                    x += v.data + "\n";
                    if (v.data.Equals("A"))
                    {
                        break;
                    }
                }

                Console.WriteLine(" ");
                x += "\n";

                foreach (Vertex v in final)
                {
                    foreach (Edge e in v.edges)
                    {
                        if (final.Contains(e.vertexIni) && final.Contains(e.vertexEnd))
                        {
                            Console.WriteLine(e.vertexIni.data + "-> " + e.weight + " <-" + e.vertexEnd.data);
                            x += e.vertexIni.data + "-> " + e.weight + " <-" + e.vertexEnd.data + "\n";
                        }

                    }
                }
                Console.WriteLine(" ");
                Console.WriteLine(sum);
                x += "\n" + sum;
            }


            if (sum2 < sum)
            {
                foreach (Vertex v in path2)
                {
                    //final2.Add(v);
                    Console.WriteLine(v.data);
                    x += v.data + "\n";
                    if (v.data.Equals("A"))
                    {
                        break;
                    }
                }

                Console.WriteLine(" ");
                x += "\n";

                foreach (Vertex v in final2)
                {
                    foreach (Edge e in v.edges)
                    {
                        if (final2.Contains(e.vertexIni) && final2.Contains(e.vertexEnd))
                        {
                            Console.WriteLine(e.vertexIni.data + "-> " + e.weight + " <-" + e.vertexEnd.data);
                            x += e.vertexIni.data + "-> " + e.weight + " <-" + e.vertexEnd.data + "\n";
                        }

                    }
                }
                Console.WriteLine(" ");
                Console.WriteLine(sum2);
                x += "\n" + sum2;
            }


            if (sum == sum2)
            {
                Console.WriteLine(sum + " " + sum2);
                x += sum + " " + sum2;
            }
            return x;
        }
        
    }
}
