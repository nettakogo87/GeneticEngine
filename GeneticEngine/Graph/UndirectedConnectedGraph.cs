using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticEngine.Graph
{
    [Serializable()]
    public class UndirectedConnectedGraph : IGraph
    {
        private List<Rib> _ribs;
        public int CountOfRibs { get; set; }

        public UndirectedConnectedGraph(int[,] ribs, double[] weights)
        {
            CountOfRibs = weights.Length;
            _ribs = new List<Rib>();
            for (int i = 0; i < CountOfRibs; i++)
            {
                _ribs.Add(new Rib(ribs[i, 0], ribs[i, 1], weights[i]));
            }
        }

        public UndirectedConnectedGraph(List<Rib> ribs)
        {
            CountOfRibs = ribs.Count;
            _ribs = ribs;
        }

        public double GetWeightByRip(int startPoint, int endPoint)
        {
            for (int i = 0; i < CountOfRibs; i++)
            {
                int key1 = _ribs[i].StartNode;
                int key2 = _ribs[i].EndNode;
                if ((key1 == startPoint && key2 == endPoint) || (key2 == startPoint && key1 == endPoint))
                {
                    return _ribs[i].Weight;
                }
            }
            return 0;
        }

        public Rib GetRib(int index)
        {
            return _ribs[index];
        }
    }
}
