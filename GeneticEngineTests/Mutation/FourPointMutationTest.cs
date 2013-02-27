using GeneticEngine.Graph;
using GeneticEngine.Mutation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeneticEngine.Track;

namespace GeneticEngineTests.Mutation 
{
    /// <summary>
    ///Это класс теста для FourPointMutationTest, в котором должны
    ///находиться все модульные тесты FourPointMutationTest
    ///</summary>
    [TestClass()]
    public class FourPointMutationTest : SupportingMutationTest
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            int[,] ribs = new int[6, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 1, 3 }, { 2, 3 } };
            double[] weights = new double[] { 3, 5, 10, 7, 8, 9 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
            int[] trackPoints = new int[] { 0, 2, 1, 3 };
            _mutant = new UnclosedTrack(trackPoints, _graph);
            _subject = new UnclosedTrack(trackPoints, _graph);
        }


        /// <summary>
        ///Тест для Mutation
        ///</summary>
        [TestMethod()]
        public void MutationTest()
        {
            FourPointMutation target = new FourPointMutation();
            target.Mutation(_mutant);
            Assert.IsFalse(TwoIntArrayEquals(_mutant.Genotype, _subject.Genotype));
            Assert.IsTrue(IsItemsUnique(_mutant.Genotype));
            Assert.IsTrue(_mutant.TypeOfSelection == FourPointMutation.MutationName);
        }
    }
}
