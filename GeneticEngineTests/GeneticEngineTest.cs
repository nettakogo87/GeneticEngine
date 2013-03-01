using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeneticEngine.FitnessFunction;
using GeneticEngine.Mutation;
using GeneticEngine.Selection;
using GeneticEngine.Crossingover;
using GeneticEngine.Graph;
using GeneticEngine.Track;
using GeneticEngine;

namespace GeneticEngineTests
{
    /// <summary>
    ///Это класс теста для GeneticEngineTest, в котором должны
    ///находиться все модульные тесты GeneticEngineTest
    ///</summary>
    [TestClass()]
    public class GeneticEngineTest : SupportingGeneticEngineTest
    {
        private AbstractTrack[] _closedTracks;
        private IGraph _graph;
        private IMutation _mutation;
        private ISelection _selection;
        private ICrossingover _crossingover;


        [TestInitialize()]
        public void MyTestInitialize()
        {
            _mutation = new TwoPointMutation();
            _selection = new RankingSelection();
            _crossingover = new TwoPointCrossingover();
            int[,] ribs = new int[6, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 1, 3 }, { 2, 3 } };
            double[] weights = new double[] { 3, 5, 10, 7, 8, 9 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
            _closedTracks = new AbstractTrack[4];
            int[] trackPoints1 = new int[] { 0, 2, 1, 3 };
            int[] trackPoints2 = new int[] { 1, 3, 0, 2 };
            int[] trackPoints3 = new int[] { 2, 1, 0, 3 };
            int[] trackPoints4 = new int[] { 2, 3, 0, 1 };
            _closedTracks[0] = new ClosedTrack(trackPoints1, _graph);
            _closedTracks[1] = new ClosedTrack(trackPoints2, _graph);
            _closedTracks[2] = new ClosedTrack(trackPoints3, _graph);
            _closedTracks[3] = new ClosedTrack(trackPoints4, _graph);
        }


        /// <summary>
        ///Тест для Run и фитнесфункции заключающейся в достижении заданного количества покалений.
        ///</summary>
        [TestMethod()]
        public void RunCounterTest()
        {
            int expectCountOfGeneration = 120;
            IFitnessFunction fitnessFunction = new GenerationCounter(expectCountOfGeneration);
            int pCrossingover = 80; 
            int pMutation = 60; 
            Array.Sort(_closedTracks);
            double preBestResult = _closedTracks[0].GetTrackLength();
            GEngine target = new GEngine(_closedTracks, pCrossingover, pMutation, fitnessFunction, _mutation, _crossingover, _selection);
            target.Run();
            Assert.AreEqual(expectCountOfGeneration, target.FitnessFunction.ActualCountOfReps);
            Assert.IsTrue(preBestResult >= target.FitnessFunction.BestResult);
        }

        /// <summary>
        ///Тест для Run и фитнесфункции заключающейся в достижении заданного количества повоторений лучшего результата.
        ///</summary>
        [TestMethod()]
        public void RunBestRipsTest()
        {
            int bestReps = 12;
            IFitnessFunction fitnessFunction = new BestReps(bestReps);
            int pCrossingover = 80; 
            int pMutation = 60;
            Array.Sort(_closedTracks);
            double preBestResult = _closedTracks[0].GetTrackLength();
            GEngine target = new GEngine(_closedTracks, pCrossingover, pMutation, fitnessFunction, _mutation, _crossingover, _selection);
            target.Run();
            Assert.AreEqual(bestReps, target.FitnessFunction.ActualCountOfReps);
            Assert.IsTrue(preBestResult >= target.FitnessFunction.BestResult);
        }
    }
}
