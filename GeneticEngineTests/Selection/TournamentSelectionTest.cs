using GeneticEngine.Selection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeneticEngine.Track;
using GeneticEngine.Graph;

namespace GeneticEngineTests.Selection
{
    /// <summary>
    ///Это класс теста для TournamentSelectionTest, в котором должны
    ///находиться все модульные тесты TournamentSelectionTest
    ///</summary>
    [TestClass()]
    public class TournamentSelectionTest : SupportingGeneticEngineTest
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
        private const int CountOfTracks = 3;
        private AbstractTrack[] _parents;
        private AbstractTrack[] _childs;
        private AbstractTrack[] _expected;
        private IGraph _graph;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            int[,] ribs = new int[6,2] {{0, 1}, {0, 2}, {0, 3}, {1, 2}, {1, 3}, {2, 3}};
            double[] weights = new double[] {3, 5, 10, 7, 8, 9};
            _graph = new UndirectedConnectedGraph(ribs, weights);

            _parents = new AbstractTrack[CountOfTracks];
            _parents[0] = new UnclosedTrack(new int[] { 0, 1, 3, 2 }, _graph);
            _parents[1] = new UnclosedTrack(new int[] { 1, 0, 2, 3 }, _graph);
            _parents[2] = new UnclosedTrack(new int[] { 2, 0, 3, 1 }, _graph);

            _childs = new AbstractTrack[CountOfTracks];
            _childs[0] = new UnclosedTrack(new int[] { 2, 1, 0, 3 }, _graph);
            _childs[1] = new UnclosedTrack(new int[] { 0, 3, 2, 1 }, _graph);
            _childs[2] = new UnclosedTrack(new int[] { 0, 1, 2, 3 }, _graph);

            _expected = new AbstractTrack[CountOfTracks];
            _expected[0] = new UnclosedTrack(new int[] { 0, 1, 3, 2 }, _graph);
            _expected[1] = new UnclosedTrack(new int[] { 1, 0, 2, 3 }, _graph);
            _expected[2] = new UnclosedTrack(new int[] { 0, 1, 2, 3 }, _graph);
        }

        /// <summary>
        ///Проверяет изменение родительского массива после селекции
        ///</summary>
        [TestMethod()]
        public void SelectionTest()
        {
            TournamentSelection target = new TournamentSelection(); // TODO: инициализация подходящего значения
            target.Selection(_parents, _childs);
            Assert.IsTrue(TwoIntArrayEquals(_parents[0].Genotype, _expected[0].Genotype));
            Assert.IsTrue(TwoIntArrayEquals(_parents[1].Genotype, _expected[1].Genotype));
            Assert.IsTrue(TwoIntArrayEquals(_parents[2].Genotype, _expected[2].Genotype));
        }
    }
}
