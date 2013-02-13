using GeneticEngine.Crossingover;
using GeneticEngine.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeneticEngine.Track;

namespace GeneticEngineTests
{
    
    
    /// <summary>
    ///Это класс теста для OnePointTest, в котором должны
    ///находиться все модульные тесты OnePointTest
    ///</summary>
    [TestClass()]
    public class OnePointTest
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

        private const int CountOfAllele = 4;
        private ITrack _parent1;
        private ITrack _parent2;
        private ITrack _child1;
        private ITrack _child2;
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
            ICrossingover target = new OnePoint(); // TODO: инициализация подходящего значения
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
