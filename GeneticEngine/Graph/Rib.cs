using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticEngine.Graph
{
    public struct Rib
    {
        public int StartNode { get; private set; }
        public int EndNode { get; private set; }
        public double Weight { get; private set; }

        public Rib(int startNode, int endNode, double weight) : this()
        {
            StartNode = startNode;
            EndNode = endNode;
            Weight = weight;
        }
    }
}
