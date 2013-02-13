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
        #region Дополнительные атрибуты теста
        // 
        //При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        //ClassInitialize используется для выполнения кода до запуска первого теста в классе
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //TestInitialize используется для выполнения кода перед запуском каждого теста
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion
        private AbstractTrack[] _parents;
        private IGraph _graph;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _parents = new AbstractTrack[2];
            int[] trackPoints1 = new int[] { 0, 2, 1, 3 };
            int[] trackPoints2 = new int[] { 1, 3, 0, 2 };
            _parents[0] = new UnclosedTrack(trackPoints1);
            _parents[1] = new UnclosedTrack(trackPoints2);
            int[,] ribs = new int[6, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 1, 3 }, { 2, 3 } };
            double[] weights = new double[] { 3, 5, 10, 7, 8, 9 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
        }

        /// <summary>
        ///Тест для Fitness
        ///</summary>
        [TestMethod()]
        public void FitnessTrueTest()
        {
            int countOfReps = 5;
            BestReps target = new BestReps(countOfReps); // TODO: инициализация подходящего значения
            bool expected = false; // TODO: инициализация подходящего значения
            bool actual = target.Fitness(_parents, _graph);
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
            BestReps target = new BestReps(countOfReps); // TODO: инициализация подходящего значения
            bool expected = false; // TODO: инициализация подходящего значения
            bool actual = target.Fitness(_parents, _graph);
            Assert.IsFalse(actual);
            Assert.AreEqual(1, target.ActualCountOfReps);
            Assert.AreEqual(20.0, target.BestResult);
        }
    }
}
