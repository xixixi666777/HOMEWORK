namespace _2_27C__2
{
    class ArrayCalculator
    { public int maxvalue, minvalue, sumvalue;
        public double averagevalue;
        public void MaxValue(int[]a)
        {
            int max = a[0];
            for(int i = 0; i < a.Length; i++)
            {
                if(a[i] > max)
                    max = a[i];
            }
            maxvalue = max;
        }
        public void MinValue(int[] a)
        {
            int min = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < min)
                    min = a[i];
            }
            minvalue = min;
            
        }
        public void sumandaverage(int[] a) { 
        int sum = 0;
            double average = 0;
            for(int i = 0;i < a.Length; i++)
            {
                sum += a[i];

            }
        average= (double)sum / a.Length;
            sumvalue = sum;
            averagevalue = average;
            
           
        }
    }
    internal class ArrayCalculation
    {
        static void Main(string[] args)
        {
            ArrayCalculator obj = new ArrayCalculator();
            int[] A = new int[10];Random random = new Random();
            for(int i = 0;i<A.Length ; i++) A[i]=random.Next(11);
            Console.WriteLine("Original Array:");
            for (int i = 0; i < A.Length; i++) { 
                Console.Write(A[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine("The max value:");
            obj.MaxValue(A);
            Console.WriteLine(obj.maxvalue);
            Console.WriteLine("The min value:");
            obj.MinValue(A);
            Console.WriteLine(obj.minvalue);
            Console.WriteLine("The sum value:");
            obj.sumandaverage(A);
            Console.WriteLine(obj.sumvalue);
            Console.WriteLine("The average value:");
            Console.WriteLine(obj.averagevalue);
        }
    }
}
