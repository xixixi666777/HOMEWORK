namespace _2_27C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input an integer:");
            string s = Console.ReadLine();
            int m = int.Parse(s);
            int n = 2;
            Console.WriteLine("Prime factors are:");
            while (n<=m)
            {
                if (m % n == 0)
                {
                    bool flag = true;
                    for(int i = 2; i * i <= n; i++)
                    {
                        if (n % i ==0) { 
                            flag = false;
                            break;
                        }
                            
                    }
                    if(flag)
                        Console.WriteLine(n);
                }
                    
                n++;
            }
        }
        
    }
}
