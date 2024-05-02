using MyLib;

namespace Task2
{
    public class ShapeCalculator
    {
        public double CalculateArea(object shape)
        {
            double area = 0;

            if (shape is Circle)
            {
                Circle circle = (Circle)shape;
                area = Math.PI * Math.Pow(circle.Radius, 2);
            }
            else if (shape is Triangle)
            {
                Triangle rectangle = (Triangle)shape;
                double semiperimeter = (rectangle.Side1 + rectangle.Side2 + rectangle.Side3) / 2;
                area =  Math.Sqrt(semiperimeter * (semiperimeter - rectangle.Side1) * (semiperimeter - rectangle.Side2) * (semiperimeter - rectangle.Side3));
            }
            return area;
        }
    }
}
