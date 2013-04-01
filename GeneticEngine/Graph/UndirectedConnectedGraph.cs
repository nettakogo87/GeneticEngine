using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneticEngine.Exceptions;

namespace GeneticEngine.Graph
{
    [Serializable]
    public class UndirectedConnectedGraph : IGraph
    {
        private Rib[] _ribs;
        public int CountOfRibs { get; set; }
        public int CountOfNode { get; set; }

        public UndirectedConnectedGraph(int defaultCountOfNode)
        {
            CountOfNode = defaultCountOfNode;
            CountOfRibs = (defaultCountOfNode * defaultCountOfNode - defaultCountOfNode) / 2;
            _ribs = new Rib[CountOfRibs];
            int k = 0;
            for (int i = 0; i < defaultCountOfNode; i++)
            {
                for (int j = i + 1; j < defaultCountOfNode; j++)
                {
                    _ribs[k] = new Rib(i, j, 1);
                    k++;
                }
            }
        }

        public UndirectedConnectedGraph(int[,] ribs, double[] weights)
        {
            CountOfNode = ribs[weights.Length - 1, 1];
            CountOfRibs = weights.Length;
            _ribs = new Rib[weights.Length];
            for (int i = 0; i < CountOfRibs; i++)
            {
                _ribs[i] = new Rib(ribs[i, 0], ribs[i, 1], weights[i]);
            }
        }

        public UndirectedConnectedGraph(Rib[] ribs)
        {
            CountOfNode = ribs[ribs.Length - 1].EndNode + 1;
            CountOfRibs = ribs.Length;
            _ribs = ribs;
        }

        public Rib GetRibByNodes(int startNode, int endNode)
        {
            for (int i = 0; i < CountOfRibs; i++)
            {
                int key1 = _ribs[i].StartNode;
                int key2 = _ribs[i].EndNode;
                if ((key1 == startNode && key2 == endNode) || (key2 == startNode && key1 == endNode))
                {
                    return _ribs[i];
                }
            }
            throw new UnexistingRibException();
        }

        public Rib GetRibByIndex(int index)
        {
            if (_ribs.Count() <= index || 0 > index)
                throw new UnexistingRibException();
            return _ribs[index];
        }

        public void SetRib(int index, Rib newRib)
        {
            if (_ribs.Count() <= index || 0 > index)
                throw new UnexistingRibException();
            _ribs[index] = newRib;
        }
    }
}
