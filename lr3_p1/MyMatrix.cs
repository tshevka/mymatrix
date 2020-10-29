using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace lr3_p1
{
    class MyMatrix
    {
        private double[,] matrix;

        public int Height
        {
            get { return this.matrix.GetLength(0); }
        }

        public int Width
        {
            get { return this.matrix.GetLength(1); }
        }

        public MyMatrix(MyMatrix input) //constr1
        {
            this.matrix = input.matrix;
        }

        public MyMatrix(double[,] input) //constr2 for sq
        {
            this.matrix = input;
        }

        public MyMatrix(double[][] input_jagged) //constr3 for jugged array
        {
            try
            {
                foreach (double[] array in input_jagged)
                {
                    if (array.Length != input_jagged.Length)
                        Console.WriteLine("The input is incorrect.\n" +
                            "The number of rows and colums isn't the same");
                }

                int range = input_jagged.Length;
                this.matrix = new double[range, range];
                for (int i = 0; i < range; i++)
                {
                    for (int j = 0; j < range; j++)
                    {
                        this.matrix[i, j] = input_jagged[i][j];
                    }
                }
            }
            catch { Console.WriteLine("The matrix isn't square matrix"); }
        }

        //public MyMatrix(String[] input_txt)
        //{
        //    int range = input_txt[0].Split(' ').Length;
        //    try
        //    {
        //        for (int i = 0; i < input_txt.Length; i++)
        //        {
        //            if (range != input_txt[i].Split(' ').Length)
        //                Console.WriteLine("The number of elements in the matrix isn't the same");
        //        }
        //        matrix = new double[input_txt.Length, range];
        //        for (int i = 0; i < Height; i++)
        //        {
        //            Console.WriteLine();
        //            Console.Write("[");
        //            for (int j = 0; j < Width; j++)
        //            {
        //                string nextElem = this.matrix[i, j] < 0 ? string.Format("{0} ", this.matrix[i, j]): string.Format(" {0}", this.matrix[i, j]);
        //                Console.Write(nextElem);
        //            }
        //            Console.Write("]");
        //            //    String[] numbers = input_txt[i].Split(' ');
        //            //this.matrix[i, j] = Convert.ToDouble(numbers[j]);
        //        }
        //    }
        //    catch
        //    {
        //        Console.WriteLine("The number of elements in the matrix isn't the same");
        //    }


        //}


        //метод расширения матриц↓
        public double this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { this.matrix[i, j] = value; }
        }

        public double SetElement(int i, int j, double num)
        {
            this.matrix[i, j] = num;
            return this.matrix[i, j];
        }
        //метод расширения матриц↑
        public static MyMatrix operator *(MyMatrix matrix_1, MyMatrix matrix_2)
        {
            if (matrix_1.Height != matrix_2.Width)
            {
                throw new Exception("The multiplication is impossible.");
            }
            var result = new double[matrix_1.Width, matrix_2.Height];
            for (var i = 0; i < matrix_1.Width; i++)
            {
                for (var j = 0; j < matrix_2.Height; j++)
                {
                    result[i, j] = 0;
                    for (var k = 0; k < matrix_1.Height; k++)
                    {
                        result[i, j] += matrix_1[i, k] * matrix_2[k, j];
                    }
                }
            }
            return new MyMatrix(result);
        }

        public static MyMatrix operator +(MyMatrix matrix_1, MyMatrix matrix_2)
        {
            var result = new double[matrix_1.Height, matrix_2.Width];

            if (matrix_1.Height != matrix_2.Height && matrix_1.Width != matrix_2.Width)
            {
                Console.WriteLine("The addition is impossible.");
            }

            else
            {
                for (int i = 0; i < matrix_1.Height; i++)
                {
                    for (int j = 0; j < matrix_1.Width; j++)
                    {
                        result[i, j] = matrix_1[i, j] + matrix_2[i, j];
                    }
                }
            }
            return new MyMatrix(result);

        }

        public double GetHeihgt()
        {
            return Height;
        }

        public double GetWidth()
        {
            return Width;
        }

        //public MyMatrix(String input_txt) : this(input_txt.Split('\t')) { } // reboot

        override public String ToString()
        {
            String input_message = "";
            if (this.matrix == null) return "Matrix is null";

            for (int i = 0; i < Height; i++)
            {
                Console.WriteLine();
                Console.Write("[");
                for (int j = 0; j < Width; j++)
                {
                    string nextElem = this.matrix[i, j] < 0 ? string.Format("{0} ", this.matrix[i, j]) : string.Format(" {0}", this.matrix[i, j]);
                    Console.Write(nextElem);
                }
                Console.Write("]");
            }
          
                return input_message;
            
        }

        protected double[,] GetTransponedArray()
        {
            var result = new double[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    result[i, j] = this.matrix[j, i];
                }
            }

            return result;
        }

        public MyMatrix GetTransponedCopy() => new MyMatrix(this.GetTransponedArray());

        public void TransopnedMe()
        {
            this.matrix = GetTransponedArray();
        }
    }
}
