using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GeneticEngine.Graph
{
    [Serializable]
    public struct Rib
    {
        public int StartNode { get; private set; }
        public int EndNode { get; private set; }
        public double Weight { get; set; }

        public Rib(int startNode, int endNode, double weight) : this()
        {
            StartNode = startNode;
            EndNode = endNode;
            Weight = weight;
        }
    }
}
