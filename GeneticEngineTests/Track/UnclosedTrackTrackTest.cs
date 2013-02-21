using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GeneticEngine.Track;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticEngine.Graph;

namespace GeneticEngineTests.Track
{
    [TestClass]
    public class UnclosedTrackTrackTest : SupportingTrackTest
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            int[,] ribs = new int[6, 2] { { 0, 1 }, { 0, 2 }, { 0, 3 }, { 1, 2 }, { 1, 3 }, { 2, 3 } };
            double[] weights = new double[] { 3, 5, 10, 7, 8, 9 };
            _graph = new UndirectedConnectedGraph(ribs, weights);
            int[] trackPoints = new int[] { 0, 2, 1, 3 };
            _track = new UnclosedTrack(trackPoints, _graph);
        }

        /// <summary>
        ///Проверяет вновь созданый путь, на выход за приделы допустимых значений
        ///</summary>
        [TestMethod]
        public void UnclosedTrackConstructorTest()
        {
            AbstractTrack track = new UnclosedTrack(CountOfAllele, _graph, true);
            Assert.IsTrue(track.Genotype.Length == CountOfAllele);
            Assert.IsTrue(track.Genotype[0] != track.Genotype[track.Genotype.Length - 1]);
            Assert.IsTrue(!Array.Exists(track.Genotype, NegativeNumber));
            Assert.IsTrue(!Array.Exists(track.Genotype, UpperLimitNumber));
        }

        /// <summary>
        ///Проверяет длинну пути по графу
        ///</summary>
        [TestMethod()]
        public void GetTrackLengthTest()
        {
            double expected = 20; 
            double actual = _track.GetTrackLength();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Тест для EmptyClone
        ///</summary>
        [TestMethod()]
        public void EmptyCloneTest()
        {
            string expected = "GeneticEngine.Track.UnclosedTrack";
            AbstractTrack actual = _track.EmptyClone();
            Assert.AreEqual(expected, actual.GetType().ToString());
        }

        /// <summary>
        ///Тест для GetWorstRip
        ///</summary>
        [TestMethod()]
        public void GetWorstRipTest()
        {
            Dictionary<int, int> actual = _track.GetWorstRip();
            Assert.IsTrue(actual.ContainsValue(1) && actual.ContainsValue(3));
        }

        /// <summary>
        ///Тест для GetBestRip
        ///</summary>
        [TestMethod()]
        public void GetBestRipTest()
        {
            Dictionary<int, int> actual = _track.GetBestRip();
            Assert.IsTrue(actual.ContainsValue(0) && actual.ContainsValue(2));
        }
    }
}
