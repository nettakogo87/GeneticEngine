using GeneticEngine.Mutation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeneticEngine.Graph;
using GeneticEngine.Track;

namespace GeneticEngineTests.Mutation
{
    /// <summary>
    ///Это класс теста для NotRandomMutationTest, в котором должны
    ///находиться все модульные тесты NotRandomMutationTest
    ///</summary>
    [TestClass()]
    public class NotRandomMutationTest : SupportingGeneticEngineTest
    {
        private const int CountOfAllele = 4;
        private AbstractTrack _mutant;
        private IGraph _graph;
        private AbstractTrack _subject;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            int[] trackPoints = new int[] { 0, 2, 1, 3 };
            _mutant = new UnclosedTrack(trackPoints);
            _subject = new UnclosedTrack(trackPoints);
            int[,] ribs = new int[6, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 1, 3 }, { 2, 3 } };
            double[] weights = new double[] { 3, 5, 10, 7, 8, 9 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
        }

        /// <summary>
        ///Тест для Mutation
        ///</summary>
        [TestMethod()]
        public void MutationTest()
        {
            NotRandomMutation target = new NotRandomMutation(_graph);
            target.Mutation(_mutant);
            Assert.IsFalse(TwoIntArrayEquals(_mutant.Genotype, _subject.Genotype));
        }
    }
}
