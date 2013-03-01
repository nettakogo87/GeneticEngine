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
    public class CyclicalCrossingoverTest : SupportingCrossingoverTest
    {
        private int[] _equalChild1;
        private int[] _equalChild2;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            int countOfAllele = 5;
            int[,] ribs = new int[10, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 1, 2 }, { 1, 3 }, { 1, 4 }, { 2, 3 }, { 2, 4 }, { 3, 4 } };
            double[] weights = new double[] { 3, 5, 10, 7, 8, 9, 1, 2, 4, 6 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
            int[] trackPoints1 = new int[] { 0, 2, 1, 3, 4 };
            int[] trackPoints2 = new int[] { 1, 3, 0, 4, 2 };
            _equalChild1 = new int[] { 0, 1, 3, 4, 2 };
            _equalChild2 = new int[] { 1, 3, 0, 2, 4 };
            _parent1 = new UnclosedTrack(trackPoints1, _graph);
            _parent2 = new UnclosedTrack(trackPoints2, _graph);
            _child1 = new UnclosedTrack(countOfAllele, _graph, false);
            _child2 = new UnclosedTrack(countOfAllele, _graph, false);
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
            Assert.IsFalse(TwoIntArrayEquals(_child1.Genotype, _child2.Genotype));
            Assert.IsTrue(IsItemsUnique(_child1.Genotype));
            Assert.IsTrue(IsItemsUnique(_child2.Genotype));
        }
    }
}
