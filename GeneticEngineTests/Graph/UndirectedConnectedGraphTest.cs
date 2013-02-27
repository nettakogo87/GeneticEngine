using GeneticEngine.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            _ribs = new int[6, 2] { { 1, 2 }, { 1, 3 }, { 1, 4 }, { 2, 3 }, { 2, 4 }, { 3, 4 }, }; // TODO: инициализация подходящего значения
            _weights = new double[] { 3, 5, 10, 7, 8, 9 }; // TODO: инициализация подходящего значения
            _target = new UndirectedConnectedGraph(_ribs, _weights);
        }

        /// <summary>
        ///Тест для Конструктор UndirectedConnectedGraph
        ///</summary>
        [TestMethod()]
        public void GraphConstructorTest()
        {
            double actual = _target.CountOfWeight;
            double expected = _weights.Length;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Тест для GetWeightByRip
        ///</summary>
        [TestMethod()]
        public void GetWeightByRipTest()
        {
            int startPoint = 4; 
            int endPoint = 1; 
            double expected = 10; 
            // если ребро существует, возвращает вес ребра.
            double actual = _target.GetWeightByRip(startPoint, endPoint);
            Assert.AreEqual(expected, actual);
            actual = _target.GetWeightByRip(endPoint, startPoint);
            Assert.AreEqual(expected, actual);
            // если ребро не существует, возвращает 0.
            startPoint = _weights.Length + 1;
            endPoint = _weights.Length + 2;
            actual = _target.GetWeightByRip(startPoint, endPoint);
            expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}
