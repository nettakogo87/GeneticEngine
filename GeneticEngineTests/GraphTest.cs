using GeneticEngine.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GeneticEngineTests
{
    /// <summary>
    ///Это класс теста для GraphTest, в котором должны
    ///находиться все модульные тесты GraphTest
    ///</summary>
    [TestClass()]
    public class GraphTest
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
            int startPoint = 4; // TODO: инициализация подходящего значения
            int endPoint = 1; // TODO: инициализация подходящего значения
            double expected = 10; // TODO: инициализация подходящего значения
            double actual = _target.GetWeightByRip(startPoint, endPoint);
            Assert.AreEqual(expected, actual);
            actual = _target.GetWeightByRip(endPoint, startPoint);
            Assert.AreEqual(expected, actual);
            startPoint = _weights.Length + 1; // TODO: инициализация подходящего значения
            endPoint = _weights.Length + 2; ; // TODO: инициализация подходящего значения
            actual = _target.GetWeightByRip(startPoint, endPoint);
            expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}
