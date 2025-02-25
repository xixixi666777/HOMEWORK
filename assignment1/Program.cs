using System.ComponentModel.DataAnnotations;

namespace _2_21_c_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int a, b = 0;
            char c='1';
        
            Console.WriteLine("please input the first number");
            s=Console.ReadLine();
            a=Int32.Parse(s);
            Console.WriteLine("please input the second number");
            s = Console.ReadLine();
            b = Int32.Parse(s);
            Console.WriteLine("please input the cal");
            s = Console.ReadLine();
            c = Char.Parse(s);
            if (c == '+')
                Console.WriteLine(a + b);
            if (c == '-')
                Console.WriteLine(a - b);
            if (c == '*')
                Console.WriteLine(a * b);
            if (c == '/')
                Console.WriteLine(a / b);
        }
    }
}
