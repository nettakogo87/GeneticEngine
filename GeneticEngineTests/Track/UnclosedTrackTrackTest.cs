using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using GeneticEngine.Crossingover;
using GeneticEngine.Mutation;
using GeneticEngine.Selection;
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
            Assert.IsFalse(Array.Exists(track.Genotype, NegativeNumber));
            Assert.IsFalse(Array.Exists(track.Genotype, UpperLimitNumber));
            Assert.IsTrue(track.TypeOfCrossingover == AbstractCrossingover.WithoutCrossingover);
            Assert.IsTrue(track.TypeOfMutation == AbstractMutation.WithoutMutation);
            Assert.IsTrue(track.TypeOfSelection == AbstractSelection.WithoutSelection);
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
        ///Тест для првоерки копирования объекта Пути, содержащего массив заполненный "-1".
        ///</summary>
        [TestMethod()]
        public void EmptyCloneTest()
        {
            int[] expectedArray = new int[] { -1, -1, -1, -1 };
            string expected = "GeneticEngine.Track.UnclosedTrack";
            AbstractTrack actual = _track.EmptyClone();
            Assert.AreEqual(expected, actual.GetType().ToString());
            Assert.IsTrue(TwoIntArrayEquals(expectedArray, actual.Genotype));
        }

        /// <summary>
        ///Тест для првоерки копирования объекта Пути, содержащего тот же массив генов, что и исходный объект.
        ///</summary>
        [TestMethod()]
        public void CloneTest()
        {
            string expected = "GeneticEngine.Track.UnclosedTrack";
            AbstractTrack actual = _track.Clone();
            Assert.AreEqual(expected, actual.GetType().ToString());
            Assert.IsTrue(TwoIntArrayEquals(_trackPoints, actual.Genotype));
        }

        /// <summary>
        ///Тест для получения наиболее "тяжелого" ребра из объекта "Пути"
        ///</summary>
        [TestMethod()]
        public void GetWorstRipTest()
        {
            // "тяжелое" ребро состоит из двух вершин:
            Rib badRib = new Rib(1, 3, 8);
            Rib actual = _track.GetWorstRib();
            Assert.IsTrue(actual == badRib);
        }

        /// <summary>
        ///Тест для получения наиболее "легкого" ребра из объекта "Пути"
        ///</summary>
        [TestMethod()]
        public void GetBestRipTest()
        {
            // "легкое" ребро состоит из двух вершин:
            Rib bestRib = new Rib(0, 2, 5);
            Rib actual = _track.GetBestRib();
            Assert.IsTrue(actual == bestRib);
        }
    }
}
