using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticEngine.Graph
{
    public interface IGraph
    {
        double GetWeightByRip(int startPoint, int endPoint);
        Rib GetRib(int index);
        void SetRib(int index, Rib newRib);
        int CountOfRibs { get; set; }
        int CountOfNode { get; set; }
    }
}
