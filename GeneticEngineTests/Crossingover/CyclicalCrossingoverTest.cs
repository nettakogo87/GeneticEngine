using GeneticEngine.Crossingover;
using GeneticEngine.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeneticEngine.Track;

namespace GeneticEngineTests.Crossingover
{
    /// <summary>
    ///Это класс теста для CyclicalCrossingoverTest, в котором должны
    ///находиться все модульные тесты CyclicalCrossingoverTest
    ///</summary>
    [TestClass()]
    public class CyclicalCrossingoverTest
    {
        private const int CountOfAllele = 5;
        private AbstractTrack _parent1;
        private AbstractTrack _parent2;
        private AbstractTrack _child1;
        private AbstractTrack _child2;
        private IGraph _graph;
        private int[] _equalChild1;
        private int[] _equalChild2;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            int[,] ribs = new int[10, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 1, 2 }, { 1, 3 }, { 1, 4 }, { 2, 3 }, { 2, 4 }, { 3, 4 } };
            double[] weights = new double[] { 3, 5, 10, 7, 8, 9, 1, 2, 4, 6 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
            int[] trackPoints1 = new int[] { 0, 2, 1, 3, 4 };
            int[] trackPoints2 = new int[] { 1, 3, 0, 4, 2 };
            _equalChild1 = new int[] { 0, 1, 3, 4, 2 };
            _equalChild2 = new int[] { 1, 3, 0, 2, 4 };
            _parent1 = new UnclosedTrack(trackPoints1, _graph);
            _parent2 = new UnclosedTrack(trackPoints2, _graph);
            _child1 = new UnclosedTrack(CountOfAllele, _graph, false);
            _child2 = new UnclosedTrack(CountOfAllele, _graph, false);
        }

        /// <summary>
        ///Тест для Crossingover
        ///</summary>
        [TestMethod()]
        public void CrossingoverTest()
        {
            CyclicalCrossingover target = new CyclicalCrossingover();
            target.Crossingover(_parent1, _parent2, _child1, _child2);
            Assert.IsTrue(TwoIntArrayEquals(_child1.Genotype, _equalChild1));
            Assert.IsTrue(TwoIntArrayEquals(_child2.Genotype, _equalChild2));
        }

        private static bool NegativeNumber(int i)
        {
            if (i < 0)
            {
                return true;
            }
            return false;
        }

        protected bool TwoIntArrayEquals(int[] firstArray, int[] secondArray)
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
