using GeneticEngine.Graph;
using GeneticEngine.Mutation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeneticEngine.Track;

namespace GeneticEngineTests
{
    
    
    /// <summary>
    ///Это класс теста для TwoPointMutationTest, в котором должны
    ///находиться все модульные тесты TwoPointMutationTest
    ///</summary>
    [TestClass()]
    public class TwoPointMutationTest
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
        private ITrack _mutant;
        private IGraph _graph;
        private ITrack _subject;

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
            TwoPointMutation target = new TwoPointMutation(); // TODO: инициализация подходящего значения
            target.Mutation(_mutant);
            Assert.IsFalse(_mutant.Genotype.Equals(_subject.Genotype));
        }
    }
}
