using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaDef
{
    internal class Edge
    {
        public int weight { get; set; }
        public Vertex vertexIni = new Vertex();
        public Vertex vertexEnd = new Vertex();
    }
}
