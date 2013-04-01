using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticEngine.Graph
{
    public interface IGraph
    {
        Rib GetRibByNodes(int startNode, int endNode);
        Rib GetRibByIndex(int index);
        void SetRib(int index, Rib newRib);
        int CountOfRibs { get; set; }
        int CountOfNode { get; set; }
    }
}
