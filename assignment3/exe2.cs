namespace _3_6_2C_
{
    public abstract class Shape
    {
        public abstract double AreaCalculator();
        public abstract bool isValid();


    }
    public class Rectangle : Shape
    {
        public double Longside { get; set; }
        public double Shortside { get; set; }
        public Rectangle(double longside, double shortside)
        {
            Longside = longside;
            Shortside = shortside;
        }
        public override double AreaCalculator()
        {
            return Longside * Shortside;
        }
        public override bool isValid()
        {
            return (Longside > 0) && (Shortside > 0);
        }
    }
    public class Triangle : Shape
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }
        public Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }
        public override double AreaCalculator()
        {
            double s = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - Side3));
        }
        public override bool isValid()
        {
            return (Side1 + Side2 > Side3) && (Side1 + Side3 > Side2) && (Side2 + Side3 > Side1);
        }
    }
    public class Square : Shape
    {
        public double Side { get; set; }
        public Square(double side)
        {
            Side = side;
        }
        public override double AreaCalculator()
        {
            return Side * Side;
        }
        public override bool isValid()
        {
            return Side > 0;
        }
    }
    public static class ShapeFactory
    {
        private static Random random = new Random();
        public static Shape Create()
        {
            int shapetype = random.Next(0, 3);
            switch (shapetype)
            {
                case 0:
                    return new Rectangle(random.NextDouble() * 10, random.NextDouble() * 10);
                case 1:
                    return new Square(random.NextDouble() * 10);
                case 2:
                    return new Triangle(random.NextDouble() * 10, random.NextDouble() * 10, random.NextDouble() * 10);
                default:
                    throw new Exception("Invalid shape type");
            }
        }
    }
    internal class exe2
    {


        static void Main(string[] args)
        {
            double Sum = 0;
            int ShapeNum = 0;
            while (ShapeNum < 10)
            {
                Shape shape = ShapeFactory.Create();
                if (shape.isValid())
                {
                    double area = shape.AreaCalculator();
                    Sum += area;
                    Console.WriteLine($"Shape:{shape.GetType().Name} Area:{area:F2}");
                    ShapeNum++;
                }
                else
                {
                    Console.WriteLine("An Invalid shape has been created");

                }
            }
            Console.WriteLine($"The sum area of ten shapes is{Sum:F2} ");
        }
    }
}
