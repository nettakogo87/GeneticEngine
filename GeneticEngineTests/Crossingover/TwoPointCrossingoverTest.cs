using GeneticEngine.Crossingover;
using GeneticEngine.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeneticEngine.Track;

namespace GeneticEngineTests.Crossingover
{
    /// <summary>
    ///Это класс теста для TwoPointCrossingoverTest, в котором должны
    ///находиться все модульные тесты TwoPointCrossingoverTest
    ///</summary>
    [TestClass()]
    public class TwoPointCrossingoverTest
    {
        private const int CountOfAllele = 4;
        private AbstractTrack _parent1;
        private AbstractTrack _parent2;
        private AbstractTrack _child1;
        private AbstractTrack _child2;
        private IGraph _graph;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            int[] trackPoints1 = new int[] { 0, 2, 1, 3 };
            int[] trackPoints2 = new int[] { 1, 3, 0, 2 };
            _parent1 = new UnclosedTrack(trackPoints1);
            _parent2 = new UnclosedTrack(trackPoints2);
            _child1 = new UnclosedTrack(CountOfAllele, false);
            _child2 = new UnclosedTrack(CountOfAllele, false);
            int[,] ribs = new int[6, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 1, 3 }, { 2, 3 } };
            double[] weights = new double[] { 3, 5, 10, 7, 8, 9 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
        }

        /// <summary>
        ///Тест для Crossingover
        ///</summary>
        [TestMethod()]
        public void CrossingoverTest()
        {
            ICrossingover target = new TwoPointCrossingover(); // TODO: инициализация подходящего значения
            target.Crossingover(_parent1, _parent2, _child1, _child2);
            Assert.IsTrue(!Array.Exists(_child1.Genotype, NegativeNumber));
            Assert.IsTrue(!Array.Exists(_child2.Genotype, NegativeNumber));
        }

        private static bool NegativeNumber(int i)
        {
            if (i < 0)
            {
                return true;
            }
            return false;
        }
    }
}
