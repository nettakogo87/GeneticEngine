using GeneticEngine.FitnessFunction;
using GeneticEngine.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeneticEngine.Track;

namespace GeneticEngineTests
{
    /// <summary>
    ///Это класс теста для ReachWantedResultTest, в котором должны
    ///находиться все модульные тесты ReachWantedResultTest
    ///</summary>
    [TestClass()]
    public class ReachWantedResultTest
    {
        private AbstractTrack[] _parents;
        private IGraph _graph;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            int[,] ribs = new int[6, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 1, 3 }, { 2, 3 } };
            double[] weights = new double[] { 3, 5, 10, 7, 8, 9 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
            _parents = new AbstractTrack[2];
            int[] trackPoints1 = new int[] { 0, 2, 1, 3 };
            int[] trackPoints2 = new int[] { 1, 3, 0, 2 };
            _parents[0] = new UnclosedTrack(trackPoints1, _graph);
            _parents[1] = new UnclosedTrack(trackPoints2, _graph);
        }

        /// <summary>
        ///Тест для Fitness при нахождении желаемого результата.
        ///</summary>
        [TestMethod()]
        public void FitnessFalseTest()
        {
            double wantedBestResult = 20; 
            ReachWantedResult target1 = new ReachWantedResult(wantedBestResult);
            bool actual = target1.Fitness(_parents);
            Assert.IsFalse(actual);
            Assert.AreEqual(wantedBestResult, target1.BestResult);

            wantedBestResult = 21;
            ReachWantedResult target2 = new ReachWantedResult(wantedBestResult);
            actual = target2.Fitness(_parents);
            Assert.IsFalse(actual);
            Assert.AreNotEqual(wantedBestResult, target2.BestResult);
        }

        /// <summary>
        ///Тест для Fitness при отсутствии желаемого результата.
        ///</summary>
        [TestMethod()]
        public void FitnessTrueTest()
        {
            double wantedBestResult = 19;
            ReachWantedResult target = new ReachWantedResult(wantedBestResult);
            bool actual = target.Fitness(_parents);
            Assert.IsTrue(actual);
            Assert.AreEqual(1, target.ActualCountOfReps);
        }
    }
}
