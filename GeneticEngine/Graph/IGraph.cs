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
        int CountOfRibs { get; set; }
    }
}
