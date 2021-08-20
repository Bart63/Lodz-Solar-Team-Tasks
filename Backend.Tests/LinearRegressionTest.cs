using Backend;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Backend.Tests
{
    [TestClass]
    public class LinearRegressionTests
    {
        [TestMethod]
        public void Solve_Test_NaN_1()
        {
            List<double> xVals = new List<double>();
            List<double> yVals = new List<double>();

            LinearRegression.Solve(xVals, yVals, out double b, out double a);

            Assert.AreEqual(double.NaN, a);
            Assert.AreEqual(double.NaN, b);
        }

        [TestMethod]
        public void Solve_Test_NaN_2()
        {
            List<double> xVals = new List<double> { 0 };
            List<double> yVals = new List<double> { 2 };

            LinearRegression.Solve(xVals, yVals, out double b, out double a);

            Assert.AreEqual(double.NaN, a);
            Assert.AreEqual(double.NaN, b);
        }

        [TestMethod]
        public void Solve_Test_NaN_3()
        {
            List<double> xVals = new List<double> { 0, 0, 0 };
            List<double> yVals = new List<double> { 1, 0, -1 };

            LinearRegression.Solve(xVals, yVals, out double b, out double a);

            Assert.AreEqual(double.NaN, a);
            Assert.AreEqual(double.NaN, b);
        }

        [TestMethod]
        public void Solve_Test_1()
        {
            List<double> xVals = new List<double> { 0, 1, 2 };
            List<double> yVals = new List<double> { 0, 1, 2 };

            LinearRegression.Solve(xVals, yVals, out double b, out double a);

            Assert.AreEqual(1, a);
            Assert.AreEqual(0, b);
        }

        [TestMethod]
        public void Solve_Test_2()
        {
            List<double> xVals = new List<double> { 0, 1, 2 };
            List<double> yVals = new List<double> { 10, 0, -10 };

            LinearRegression.Solve(xVals, yVals, out double b, out double a);

            Assert.AreEqual(-10, a);
            Assert.AreEqual(10, b);
        }
    }
}
