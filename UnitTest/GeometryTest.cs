using MyLib;
using Task2;

namespace UnitTest
{
    public class Geometry
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CircleAreaTest()
        {
            double area;
            Circle circle = new(4);
            ShapeCalculator calculator = new();
            area = calculator.CalculateArea(circle);
            Assert.That(area, Is.EqualTo(50.26).Within(0.01));
        }

        [Test]
        public void TriangleAreaTest()
        {
            double area;
            Triangle triangle = new(4, 3, 5);
            ShapeCalculator calculator = new();
            area = calculator.CalculateArea(triangle);
            Assert.That(area, Is.EqualTo(6).Within(0.01));
        }

        [Test]
        public void IsRightTriangle()
        {
            Triangle calculator = new(4, 5, 3);
            bool isRightTriangle = calculator.IsRightTriangle();
            Assert.IsTrue(isRightTriangle);
        }

    }
}