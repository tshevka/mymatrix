using System;

namespace lr3_p1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] input = new double[5, 5];
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    input[i, j] = i;
                }
            }
            MyMatrix Matrix = new MyMatrix(input);
            Console.WriteLine(Matrix);

        }
    }
}
