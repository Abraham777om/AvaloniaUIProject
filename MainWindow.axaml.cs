using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Windows.Input;
using AvaloniaDef;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AvaloniaDef
{
    public partial class MainWindow : Window
    {

        Graph graph1 = new Graph();
        Vertex vertex1 = new Vertex();
        Vertex vertex2 = new Vertex();
        Vertex vertex3 = new Vertex();
        Vertex vertex4 = new Vertex();
        Vertex vertex5 = new Vertex();
        Vertex vertex6 = new Vertex();
        Vertex vertex7 = new Vertex();
        Vertex vertex8 = new Vertex();
        Vertex vertex9 = new Vertex();
        Vertex vertex10 = new Vertex();

        public MainWindow()
        {
            InitializeComponent();
            vertex1.data = "A";
            vertex2.data = "B";
            vertex3.data = "C";
            vertex4.data = "D";
            vertex5.data = "E";
            vertex6.data = "F";
            vertex7.data = "G";
            vertex8.data = "H";
            vertex9.data = "I";
            //vertex10.data = "J";

            graph1.insert(vertex1, vertex1, 0);


            graph1.insert(vertex2, vertex1, 3);
            graph1.insert(vertex3, vertex1, 4);
            graph1.insert(vertex4, vertex1, 1);
            graph1.insert(vertex5, vertex3, 2);
            graph1.insert(vertex6, vertex3, 10);
            graph1.insert(vertex7, vertex2, 5);
            graph1.insert(vertex8, vertex4, 7);
            graph1.insert(vertex9, vertex8, 11);
            //graph1.insert(vertex10, vertex9, 1);
            //graph1.insert(vertex10, vertex6, 1);
        }

        public void Clear(object sender, RoutedEventArgs e)
        {
            searchVertex.Text = "";
            printVertexes.Text = "";
            matrixVertexes.Text = "";
            bfsVertexes.Text = "";
            dfsVertexes.Text = "";
            spVertexes.Text = "";
        }

        public void InsertVertex(object sender, RoutedEventArgs e) 
        {
            Vertex vertex = new Vertex();
            vertex.data = newVertex.Text;

            //if (graph1.datas.Contains(vertex.data)) 
            //{ 

            //}

            for (int i = 0; i<onVertex.Text.Length; i++)
            {
                graph1.insert2(vertex, char.ToString(onVertex.Text[i]), int.Parse(char.ToString(weight.Text[i])));

                //graph1.insert(vertex, vertex9, int.Parse(weight.Text));
                //graph1.insert(vertex, vertex6, int.Parse(weight.Text));
            }
        }


            //graph1.insert2(vertex, onVertex.Text, int.Parse(weight.Text));
            //graph1.insert(vertex, vertex9, int.Parse(weight.Text));
            //graph1.insert(vertex, vertex6, int.Parse(weight.Text));
        

        public void SearchVertex(object sender, RoutedEventArgs e)
        {
            string x = graph1.search(dataSer.Text);
            searchVertex.Text = x;
        }

        public void DeleteVertex(object sender, RoutedEventArgs e)
        {
            graph1.delete(dataDel.Text);
        }

        public void PrintVertexes(object sender, RoutedEventArgs e)
        {
            string x = graph1.printVertexes();
            printVertexes.Text = x;
        }

        public void Matrix(object sender, RoutedEventArgs e)
        {
            string x = graph1.matrix();
            matrixVertexes.Text = x;
        }

        public void BFS(object sender, RoutedEventArgs e)
        {
            string x = graph1.bfs(vertex1);
            bfsVertexes.Text = x;
        }

        public void DFS(object sender, RoutedEventArgs e)
        {
            string x = graph1.dfs(vertex1);
            dfsVertexes.Text = x;
        }

        public void ShortestPath(object sender, RoutedEventArgs e)
        {
            string x = graph1.shortestPath(shortVertex.Text, vertex1);
            spVertexes.Text = x;
        }

    }
}
