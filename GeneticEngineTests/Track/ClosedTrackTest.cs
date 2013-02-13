﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GeneticEngine.Track;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticEngine.Graph;

namespace GeneticEngineTests.Track
{
    [TestClass]
    public class ClosedTrackTest : SupportingTrackTest
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            int[] trackPoints = new int[] { 0, 2, 1, 3 };
            _track = new ClosedTrack(trackPoints);
            int[,] ribs = new int[6, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 1, 3 }, { 2, 3 } };
            double[] weights = new double[] { 3, 5, 10, 7, 8, 9 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
        }

        /// <summary>
        ///Проверяет вновь созданый путь, на выход за приделы допустимых значений
        ///</summary>
        [TestMethod]
        public void ClosedTrackConstructorTest()
        {
            AbstractTrack track = new ClosedTrack(CountOfAllele, true);
            Assert.IsTrue(track.Genotype.Length == CountOfAllele);
            Assert.IsTrue(!Array.Exists(track.Genotype, NegativeNumber));
            Assert.IsTrue(!Array.Exists(track.Genotype, UpperLimitNumber));
        }

        /// <summary>
        ///Проверяет длинну пути по графу
        ///</summary>
        [TestMethod()]
        public void GetTrackLengthTest()
        {
            double expected = 30; // TODO: инициализация подходящего значения
            double actual = _track.GetTrackLength(_graph);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Тест для EmptyClone
        ///</summary>
        [TestMethod()]
        public void EmptyCloneTest()
        {
            string expected = "GeneticEngine.Track.ClosedTrack";
            AbstractTrack actual = _track.EmptyClone();
            Assert.AreEqual(expected, actual.GetType().ToString());
        }
    }
}