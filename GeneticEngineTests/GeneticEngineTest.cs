﻿using GeneticEngine.FitnessFunction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
    public class GeneticEngineTest
    {
        private ITrack[] _parents;
        private IGraph _graph;
        

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _parents = new ITrack[4];
            int[] trackPoints1 = new int[] { 0, 2, 1, 3 };
            int[] trackPoints2 = new int[] { 1, 3, 0, 2 };
            int[] trackPoints3 = new int[] { 2, 1, 0, 3 };
            int[] trackPoints4 = new int[] { 2, 3, 0, 1 };
            _parents[0] = new ClosedTrack(trackPoints1);
            _parents[1] = new ClosedTrack(trackPoints2);
            _parents[2] = new ClosedTrack(trackPoints3);
            _parents[3] = new ClosedTrack(trackPoints4);
            int[,] ribs = new int[6, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 1, 3 }, { 2, 3 } };
            double[] weights = new double[] { 3, 5, 10, 7, 8, 9 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
        }


        /// <summary>
        ///Тест для Run
        ///</summary>
        [TestMethod()]
        public void RunCounterTest()
        {
            IFitnessFunction fitnessFunction = new GenerationCounter(100);
            int pCrossingover = 80; // TODO: инициализация подходящего значения
            int pMutation = 60; // TODO: инициализация подходящего значения
            GEngine target = new GEngine(_graph, _parents, pCrossingover, pMutation, fitnessFunction); // TODO: инициализация подходящего значения
            target.Run();
            Assert.AreEqual(target.FitnessFunction.ActualCountOfReps, 100);
            double her = target.FitnessFunction.BestResult;
            ITrack[] track = new ITrack[4];
            track = target.Tracks;
        }

        /// <summary>
        ///Тест для Run
        ///</summary>
        [TestMethod()]
        public void RunBestRipsTest()
        {
            IFitnessFunction fitnessFunction = new BestReps(13);
            int pCrossingover = 80; // TODO: инициализация подходящего значения
            int pMutation = 60; // TODO: инициализация подходящего значения
            GEngine target = new GEngine(_graph, _parents, pCrossingover, pMutation, fitnessFunction); // TODO: инициализация подходящего значения
            target.Run();
            Assert.AreEqual(target.FitnessFunction.ActualCountOfReps, 13);
            double her = target.FitnessFunction.BestResult;
            ITrack[] track = new ITrack[4];
            track = target.Tracks;
        }
    }
}
