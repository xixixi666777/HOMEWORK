namespace _2_27C__3
{
    internal class Prime
    {
        static void Main(string[] args)
        {
            int[] A = new int[99];
            for (int i = 0; i < A.Length; i++) A[i] = i + 2;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0 && A[i] != 2 && A[i] != 0)
                {
                    A[i] = 0;

                }
                if (A[i] % 3 == 0 && A[i] != 3 && A[i] != 0)
                {
                    A[i] = 0;

                }
                if (A[i] % 5 == 0 && A[i] != 5 && A[i] != 0)
                {
                    A[i] = 0;

                }
                if (A[i] % 7 == 0 && A[i] != 7 && A[i] != 0)
                {
                    A[i] = 0;

                }
            }
            int m = 1;
            for (int i = 0; i < A.Length; i++)
            {
                
                if (A[i] != 0) { 
                    Console.Write(A[i]);
                    Console.Write(" ");
                    m++;
                }
                if (m % 5 == 0) Console.WriteLine();


            }
        }
    }
}

