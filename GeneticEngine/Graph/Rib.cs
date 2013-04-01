using System;
using System.Collections.Generic;
using System.Globalization;
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

        public override string ToString()
        {
            return StartNode.ToString() + " " + EndNode.ToString() + " " + Weight.ToString();
        }

        public static bool operator ==(Rib left, Rib right)
        {
            if (0 == left.Weight.CompareTo(right.Weight))
            {
                if ((left.StartNode == right.StartNode && left.EndNode == right.EndNode) || (left.EndNode == right.StartNode && left.StartNode == right.EndNode))
                    return true;
            }
            return false;
        }

        public static bool operator !=(Rib left, Rib right)
        {
            if (0 == left.Weight.CompareTo(right.Weight))
            {
                if ((left.StartNode == right.StartNode && left.EndNode == right.EndNode) || (left.EndNode == right.StartNode && left.StartNode == right.EndNode))
                    return false;
            }
            return true;
        }
    }
}
