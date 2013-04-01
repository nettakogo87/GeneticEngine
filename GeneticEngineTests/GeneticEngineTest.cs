using System.Collections.Generic;
using GeneticEngine.ProxyOperation;
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
            int[,] ribs = new int[15, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 0, 5 }, { 1, 2 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 2, 3 }, { 2, 4 }, { 2, 5 }, { 3, 4 }, { 3, 5 }, { 4, 5 } };
            double[] weights = new double[] { 1, 2, 3, 4, 1, 1, 3, 3, 3, 1, 2, 5, 1, 5, 1 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
            _closedTracks = new AbstractTrack[4];
            int[] trackPoints1 = new int[] { 0, 2, 1, 3, 5, 4 };
            int[] trackPoints2 = new int[] { 1, 3, 0, 2, 4, 5 };
            int[] trackPoints3 = new int[] { 2, 1, 0, 3, 5, 4 };
            int[] trackPoints4 = new int[] { 2, 3, 0, 1, 4, 5 };
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
            _mutation = new NotRandomMutation();
            _selection = new TournamentSelection();
            _crossingover = new CyclicalCrossingover();

            int expectCountOfGeneration = 12000;
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
            _mutation = new NotRandomMutation();
            _selection = new TournamentSelection();
            _crossingover = new CyclicalCrossingover();

            int bestReps = 150;
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

        /// <summary>
        ///Тест для Run и фитнесфункции заключающейся в достижении заданного лучшего результата.
        ///</summary>
        [TestMethod()]
        public void RunReachWantedResultTest()
        {
            _mutation = new NotRandomMutation();
            _selection = new TournamentSelection();
            _crossingover = new CyclicalCrossingover();

            int wantedResult = 6;
            IFitnessFunction fitnessFunction = new ReachWantedResult(wantedResult);
            int pCrossingover = 80;
            int pMutation = 60;
            Array.Sort(_closedTracks);
            double preBestResult = _closedTracks[0].GetTrackLength();
            GEngine target = new GEngine(_closedTracks, pCrossingover, pMutation, fitnessFunction, _mutation, _crossingover, _selection);
            target.Run();
            Assert.AreEqual(wantedResult, target.FitnessFunction.BestResult);
            Assert.IsTrue(preBestResult > target.FitnessFunction.BestResult);
        }

        /// <summary>
        ///Тест для Run заключается в надежности работы алгоритма сревнения алгоритмов Мутации, Селекции и Скрещивания.
        ///</summary>
        [TestMethod()]
        public void RunQualityCountsTest()
        {
            int wantedResult = 6;
            int bestReps = 120;
            List<ProxyMutation> proxyMutations = new List<ProxyMutation>();
            proxyMutations.Add(new ProxyMutation(new NotRandomMutation()));
            proxyMutations.Add(new ProxyMutation(new FourPointMutation()));
            proxyMutations.Add(new ProxyMutation(new TwoPointMutation()));
            _mutation = new QualityCountsMutation(proxyMutations, wantedResult);

            List<ProxySelection> proxySelectios = new List<ProxySelection>();
            proxySelectios.Add(new ProxySelection(new TournamentSelection()));
//            proxySelectios.Add(new ProxySelection(new RouletteSelection()));
//            proxySelectios.Add(new ProxySelection(new RankingSelection()));
            _selection = new QualityCountsSelection(proxySelectios);

            List<ProxyCrossingover> proxyCrossingovers = new List<ProxyCrossingover>();
            proxyCrossingovers.Add(new ProxyCrossingover(new CyclicalCrossingover()));
            proxyCrossingovers.Add(new ProxyCrossingover(new InversionCrossingover()));
            proxyCrossingovers.Add(new ProxyCrossingover(new OnePointCrossingover()));
            proxyCrossingovers.Add(new ProxyCrossingover(new TwoPointCrossingover()));
            _crossingover = new QualityCountsCrossingover(proxyCrossingovers, wantedResult);

            IFitnessFunction fitnessFunction = new BestReps(bestReps);
            int pCrossingover = 100;
            int pMutation = 100;
            Array.Sort(_closedTracks);
            double preBestResult = _closedTracks[0].GetTrackLength();
            GEngine target = new GEngine(_closedTracks, pCrossingover, pMutation, fitnessFunction, _mutation, _crossingover, _selection);
            target.Run();
            double progress1 = proxySelectios[0].GetProgress();
//            double progress2 = proxySelectios[1].GetProgress();
//            double progress3 = proxySelectios[2].GetProgress();
            Assert.IsTrue(preBestResult >= target.FitnessFunction.BestResult);
        }

        /// <summary>
        ///Тест для Run заключается в надежности работы алгоритма сревнения алгоритмов Мутации, Селекции и Скрещивания.
        ///</summary>
        [TestMethod()]
        public void RunSearchBestTest()
        {
            int bestReps = 50;
            int wantedResult = 6;
            List<ProxyMutation> proxyMutations = new List<ProxyMutation>();
            proxyMutations.Add(new ProxyMutation(new TwoPointMutation()));
            proxyMutations.Add(new ProxyMutation(new FourPointMutation()));
            proxyMutations.Add(new ProxyMutation(new NotRandomMutation()));
            _mutation = new SearchBestMutation(proxyMutations);

            List<ProxySelection> proxySelectios = new List<ProxySelection>();
            proxySelectios.Add(new ProxySelection(new TournamentSelection()));
            proxySelectios.Add(new ProxySelection(new RouletteSelection()));
            proxySelectios.Add(new ProxySelection(new RankingSelection()));
            _selection = new SearchBestSelection(proxySelectios);

            List<ProxyCrossingover> proxyCrossingovers = new List<ProxyCrossingover>();
            proxyCrossingovers.Add(new ProxyCrossingover(new CyclicalCrossingover()));
            proxyCrossingovers.Add(new ProxyCrossingover(new InversionCrossingover()));
            proxyCrossingovers.Add(new ProxyCrossingover(new OnePointCrossingover()));
            proxyCrossingovers.Add(new ProxyCrossingover(new TwoPointCrossingover()));
            _crossingover = new SearchBestCrossingover(proxyCrossingovers);

            IFitnessFunction fitnessFunction = new BestReps(bestReps);
            int pCrossingover = 100;
            int pMutation = 100;
            Array.Sort(_closedTracks);
            double preBestResult = _closedTracks[0].GetTrackLength();
            GEngine target = new GEngine(_closedTracks, pCrossingover, pMutation, fitnessFunction, _mutation, _crossingover, _selection);
            target.Run();
            double progress1 = proxySelectios[0].GetProgress();
            double progress2 = proxySelectios[1].GetProgress();
            double progress3 = proxySelectios[2].GetProgress();
            Assert.IsTrue(preBestResult >= target.FitnessFunction.BestResult);
        }

    }
}
