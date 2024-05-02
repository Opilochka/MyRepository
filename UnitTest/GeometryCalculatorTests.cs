using NUnit.Framework;
using MyLib;
using Task2;

namespace UnitTest
{
    [TestFixture]
    public class GeometryCalculatorTests
    {
        [Test]
        public void CircleAreaTest()
        {
            double area;
            Circle circle = new(4);
            ShapeCalculator calculator = new();
            area = calculator.CalculateArea(circle);
            Assert.Equals(50.26, area);
        }

        

        [Test]
        public void IsRightTriangle()
        {
            Triangle calculator = new(4, 5, 3);
            bool isRightTriangle = calculator.IsRightTriangle();
            Assert.Equals(isRightTriangle, true);
        }

        [Test]
        public void TestSubtraction()
        {
            // Arrange
            int a = 10;
            int b = 4;

            // Act
            int result = a - b;

            // Assert
            Assert.Equals(result, 6);
        }
    }
}