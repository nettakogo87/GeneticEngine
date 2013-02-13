using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticEngine.Graph
{
    public class UndirectedConnectedGraph : IGraph
    {
        private const int FirstPintAndSecondPointAndWeight = 3;
        private double[,] _ribsAndWeights;
        public int CountOfWeight { get; set; }
        public UndirectedConnectedGraph(int[,] ribs, double[] weights)
        {
            CountOfWeight = weights.Length;
            _ribsAndWeights = new double[CountOfWeight, FirstPintAndSecondPointAndWeight];
            for (int i = 0; i < CountOfWeight; i++)
            {
                _ribsAndWeights[i, 0] = ribs[i, 0];
                _ribsAndWeights[i, 1] = ribs[i, 1];
                _ribsAndWeights[i, 2] = weights[i];
            }
        }

        public double GetWeightByRip(int startPoint, int endPoint)
        {
            for (int i = 0; i < CountOfWeight; i++)
            {
                int key1 =Convert.ToInt32(_ribsAndWeights[i, 0]);
                int key2 =Convert.ToInt32(_ribsAndWeights[i, 1]);
                if ((key1 == startPoint && key2 == endPoint) || (key2 == startPoint && key1 == endPoint))
                {
                    return _ribsAndWeights[i, 2];
                }
            }
            return 0;
        }
    }
}
