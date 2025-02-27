namespace _2_27C__4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("请输入矩阵的行数 M: ");
            int m = int.Parse(Console.ReadLine());

            Console.Write("请输入矩阵的列数 N: ");
            int n = int.Parse(Console.ReadLine());


            int[,] matrix = new int[m, n];


            Console.WriteLine("请输入矩阵数据：");
            for (int i = 0; i < m; i++)
            {
                Console.Write($"第 {i + 1} 行: ");
                string[] rowValues = Console.ReadLine().Split(' ');

                if (rowValues.Length != n)
                {
                    Console.WriteLine($"错误：每行必须包含 {n} 个元素。");
                    return;
                }
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(rowValues[j]);
                }
               
            }
            if (IsToeplitzMatrix(matrix))
            {
                Console.WriteLine("该矩阵是托普利茨矩阵。");
            }
            else
            {
                Console.WriteLine("该矩阵不是托普利茨矩阵。");
            }

        }
        static bool IsToeplitzMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0); 
            int n = matrix.GetLength(1); 
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (matrix[i, j] != matrix[i + 1, j + 1])
                    {
                        return false; 
                    }
                }
            }

            return true; 
        }
    }
}
