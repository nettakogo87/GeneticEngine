using GeneticEngine.FitnessFunction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeneticEngine.Track;
using GeneticEngine.Graph;

namespace GeneticEngineTests.FitnessFunction
{
    /// <summary>
    ///Это класс теста для BestRepsTest, в котором должны
    ///находиться все модульные тесты BestRepsTest
    ///</summary>
    [TestClass()]
    public class BestRepsTest
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
        ///Тест для Fitness
        ///</summary>
        [TestMethod()]
        public void FitnessTrueTest()
        {
            int countOfReps = 5;
            BestReps target = new BestReps(countOfReps);
            bool actual = target.Fitness(_parents);
            Assert.IsTrue(actual);
            Assert.AreEqual( 1, target.ActualCountOfReps);
            Assert.AreEqual(20.0, target.BestResult);
        }

        /// <summary>
        ///Тест для Fitness
        ///</summary>
        [TestMethod()]
        public void FitnessFalseTest()
        {
            int countOfReps = 1;
            BestReps target = new BestReps(countOfReps);
            bool actual = target.Fitness(_parents);
            Assert.IsFalse(actual);
            Assert.AreEqual(countOfReps, target.ActualCountOfReps);
            Assert.AreEqual(20.0, target.BestResult);
        }
    }
}
