using GeneticEngine.Crossingover;
using GeneticEngine.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeneticEngine.Track;

namespace GeneticEngineTests.Crossingover
{
    /// <summary>
    ///Это класс теста для InversionCrossingoverTest, в котором должны
    ///находиться все модульные тесты InversionCrossingoverTest
    ///</summary>
    [TestClass()]
    public class InversionCrossingoverTest : SupportingCrossingoverTest
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            int[,] ribs = new int[6, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 1, 3 }, { 2, 3 } };
            double[] weights = new double[] { 3, 5, 10, 7, 8, 9 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
            int[] trackPoints1 = new int[] { 0, 2, 1, 3 };
            int[] trackPoints2 = new int[] { 1, 3, 0, 2 };
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
            InversionCrossingover target = new InversionCrossingover();
            target.Crossingover(_parent1, _parent2, _child1, _child2);
            Assert.IsTrue(!Array.Exists(_child1.Genotype, NegativeNumber));
            Assert.IsTrue(!Array.Exists(_child2.Genotype, NegativeNumber));
            Assert.IsFalse(TwoIntArrayEquals(_child1.Genotype, _child2.Genotype));
            Assert.IsTrue(IsItemsUnique(_child1.Genotype));
            Assert.IsTrue(IsItemsUnique(_child2.Genotype));
        }
    }
}
