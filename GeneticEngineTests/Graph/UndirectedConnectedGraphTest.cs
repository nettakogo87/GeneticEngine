using GeneticEngine.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using GeneticEngine.Exceptions;

namespace GeneticEngineTests.Graph
{
    /// <summary>
    ///Это класс теста для UndirectedConnectedGraphTest, в котором должны
    ///находиться все модульные тесты UndirectedConnectedGraphTest
    ///</summary>
    [TestClass()]
    public class UndirectedConnectedGraphTest
    {
        private int[,] _ribs;
        private double[] _weights;
        private UndirectedConnectedGraph _target;

        [TestInitialize()]
        public void MyTestInitialize()
        {
            _ribs = new int[6, 2] { { 1, 2 }, { 1, 3 }, { 1, 4 }, { 2, 3 }, { 2, 4 }, { 3, 4 }, }; 
            _weights = new double[] { 3, 5, 10, 7, 8, 9 }; 
            _target = new UndirectedConnectedGraph(_ribs, _weights);
        }

        /// <summary>
        ///Тест для Конструктор UndirectedConnectedGraph
        ///</summary>
        [TestMethod()]
        public void GraphConstructorTest()
        {
            double actual = _target.CountOfRibs;
            double expected = _weights.Length;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Тест для GetRibByNodes
        ///</summary>
        [TestMethod()]
        public void GeRibByNodesTest()
        {
            int startPoint = 4; 
            int endPoint = 1; 
            double expected = 10; 
            // если ребро существует, возвращает вес ребра.
            double actual = _target.GetRibByNodes(startPoint, endPoint).Weight;
            Assert.AreEqual(expected, actual);
            actual = _target.GetRibByNodes(startPoint, endPoint).Weight;
            Assert.AreEqual(expected, actual);
            // если ребро не существует, возвращает 0.
            startPoint = _weights.Length + 1;
            endPoint = _weights.Length + 2;
            try
            {
                double puppet = _target.GetRibByNodes(startPoint, endPoint).Weight;
            }
            catch (UnexistingRibException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(UnexistingRibException));
            }
        }

        /// <summary>
        ///Тест для GetRibByIndex
        ///</summary>
        [TestMethod()]
        public void GetRibByIndexTest()
        {
            int indexOfRip = 2;
            Rib rib = _target.GetRibByIndex(indexOfRip);
            int actual = rib.StartNode;
            int expected = 1;
            Assert.AreEqual(expected, actual);
            actual = rib.EndNode;
            expected = 4;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(10, rib.Weight);
        }
    }
}
