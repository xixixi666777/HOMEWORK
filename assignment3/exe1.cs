namespace _3_6_1C_
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
            if (!isValid()) throw new Exception("An invalid rectangle");
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
            if(!isValid()) throw new Exception("An invalid triangle");
        }
        public override double AreaCalculator()
        {
            /*if (isValid())
            {*/
                double s = (Side1 + Side2 + Side3) / 2;
                return Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - Side3));
            }
            /*else { throw new Exception("An invalid triangle"); }*/
        
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
            if (!isValid()) throw new Exception("An invalid Square");
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
    
    internal class exe1
    {


        static void Main(string[] args)
        {
            /*Shape triangle1 = new Triangle(5, 10,2);*///used for testing the valid judgement
            Shape rectangle1 = new Rectangle(6.5, 9.3);
            Shape square1= new Square(5);
            Shape triangle2 = new Triangle(3,4,5);
            double area1= rectangle1.AreaCalculator();
            double area2= square1.AreaCalculator();
            double area3= triangle2.AreaCalculator();
            Console.WriteLine($"the area of rectangle1 is: {area1:F2}");
            Console.WriteLine($"the area of square1 is: {area2:F2}");
            Console.WriteLine($"the area of triangle2 is: {area3:F2}");
        }
    }
}
