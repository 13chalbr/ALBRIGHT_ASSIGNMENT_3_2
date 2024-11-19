using System;
using System.Runtime.Intrinsics.X86;

namespace ALBRIGHT_ASSIGNMENT_3_2
{
    internal class Program
    {
        /*MSSA CCAD 16 - NOV 19 2024
             *DAY 12 - CHRIS ALBRIGHT
             *ASSIGNMENT 3.2
             */

        static void Main(string[] args)
        {
            // 3.2.1:
            // Create a 2D array to store integers and print them in matrix format with proper formatting.

            int[,] matrixA = new int[2, 2];

            Console.WriteLine("3.2.1: 2x2 Matrix Creation");
            Console.WriteLine("\nEnter the values for a 2x2 matrix:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine($"matrix1[{i}, {j}]: ");
                    matrixA[(int)i, (int)j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("\nYour 2x2 Matrix is as follows:\n");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(matrixA[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n=============================================================================");
            //===============================================================================================

            // 3.2.2:
            // Write a program in C# Sharp for addition of two Matrices of same size.

            Console.WriteLine("3.2.2: Matrix Addition Calculator");
            Console.WriteLine("\nEnter the number of matrices:");
            int matrixNum = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nEnter the number of desired rows for your matrices:");
            int rowsNum = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nEnter the number of desired columns for matrices: ");
            int columnsNum = int.Parse(Console.ReadLine());

            int[,,] InputMatrices = new int[matrixNum, rowsNum, columnsNum];
            MatrixInput(InputMatrices, matrixNum, rowsNum, columnsNum);

            Console.WriteLine("\nYour matrices are as follows:\n");
            Display3DMatrix(InputMatrices, matrixNum, rowsNum, columnsNum);

            int[,] SumMatrix = new int[rowsNum, columnsNum];
            SumMatrix = SummingTheMatrices(InputMatrices, SumMatrix, matrixNum, rowsNum, columnsNum);

            Console.WriteLine("\nYour sum matrix is as follows:\n");
            Display2DMatrix(SumMatrix, rowsNum, columnsNum);

            Console.WriteLine("\n=============================================================================");
            //===============================================================================================

            // 3.2.3:
            // Create a console application to overload “+” and “-“ operator for adding the areas of 2 circles
            // and getting their area difference respectively.
            Console.WriteLine("\n3.2.3.Welcome to Circle Area SUM/DIFF Calc:");
            Console.WriteLine("\nEnter the radius of circle 1:");
            double circle1Radius = double.Parse(Console.ReadLine());
            Circle circle1 = new Circle(circle1Radius);
            Console.WriteLine("\nEnter the radius of circle 2:");
            double circle2Radius = double.Parse(Console.ReadLine());
            Circle circle2 = new Circle(circle1Radius);

            double areaSum = circle1 +circle2;
            Console.WriteLine($"The sum of circle 1 and 2's area is {areaSum}");
            double areaDiff = circle1 -circle2;
            Console.WriteLine($"The difference of circle 1 and 2's area is {areaDiff}");

            Console.WriteLine("\n=============================================================================");
            //===============================================================================================

            // 3.2.4:
            // Write a function that takes 4 numbers as input to calculate the total and average.
            // (Make use of params array to pass arguments and out parameters to return both total and average to main method).

            double totalDouble;
            double averageDouble;
            Console.WriteLine("\n3.2.4.Welcome to Total/Average for four numbers.");
            int averageNumbers = 4;
            double[] averageArray = new double[averageNumbers];
            for (int i = 0; i < averageNumbers; i++)
            {
                Console.WriteLine($"\nEnter element {i + 1}:");
                averageArray[i] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("\nThe elements in the array are:");
            foreach (double i in averageArray)
            {
                Console.Write(i + " ");
            }
            TotalandAverageCalc(out totalDouble, out averageDouble, averageArray[0], averageArray[1], averageArray[2], averageArray[3]);
            Console.WriteLine($"\nThe total of your four numbers is {totalDouble}");
            Console.WriteLine($"The average of your four numbers is {averageDouble}");

            Console.WriteLine("\n=============================================================================");
            //===============================================================================================

            // 3.2.5:
            // Create a function that finds the index of a given item in the array

            Console.WriteLine("\n3.2.5.Welcome to numbered array indexer.");
            Console.WriteLine("\nEnter the number of elements in your desired array:");
            int arraySize = int.Parse(Console.ReadLine());
            double[] arrayIndex = new double[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine($"Enter element {i + 1}:");
                arrayIndex[i] = double.Parse(Console.ReadLine());
            }
            Console.Write("The Items in your array are:\n{");
            foreach (double i in arrayIndex)
            {
                Console.Write(i+", ");
            }
            Console.Write("}");
            Console.WriteLine("\nEnter the value you'd like to know the index of:");
            double indexSearch = double.Parse(Console.ReadLine());
            double indexValue = FindIndex(arrayIndex, indexSearch);
            Console.WriteLine($"\nThe index of item {indexSearch} is: {indexValue}");
        }
        // 3.2.2 method 1
        static int[,,] MatrixInput(int[,,] matrices, int matrixNum, int rowsNum, int columnsNum)
        {

            for (int k = 0; k < matrixNum; k++)
            {

                for (int i = 0; i < rowsNum; i++)
                {
                    for (int j = 0; j < columnsNum; j++)
                    {
                        Console.WriteLine($"matrix {k + 1}, [{i}, {j}]: ");
                        matrices[(int)k, (int)i, (int)j] = int.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine();
            }
            return matrices;
        }
        // 3.2.2 method 2
        static void Display2DMatrix(int[,] matrix, int rowsNum, int columnsNum)
        {
               
                for (int i = 0; i < rowsNum; i++)
                {
                    for (int j = 0; j < columnsNum; j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            
        }
        // 3.2.2 method 3
        static void Display3DMatrix(int[,,] matrix, int matrixNum, int rowsNum, int columnsNum)
        {
            for (int k = 0; k < matrixNum; k++)
            {
                Console.WriteLine($"Matrix {k + 1}:");
                for (int i = 0; i < rowsNum; i++)
                {
                    for (int j = 0; j < columnsNum; j++)
                    {
                        Console.Write(matrix[k, i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        // 3.2.2 method 4
        static int[,] SummingTheMatrices(int[,,] matrix, int[,] SumMatrix, int matrixNum, int rowsNum, int columnsNum)
        {
            for (int k = 0; k < matrixNum; k++)
            {
                for (int i = 0; i < rowsNum; i++)
                {
                    for (int j = 0; j < columnsNum; j++)
                        SumMatrix[i, j] += matrix[k, i, j];
                }
            }
            return SumMatrix;
        }
        // 3.2.4 method 
        static void TotalandAverageCalc(out double total, out double average, params double[] numbers)
        {
            total = 0;
            foreach (var number in numbers)
            {
                total += number;
            }
            average = total / numbers.Length;
        }
        //3.2.5 Method
        public static int FindIndex<T>(T[]array, T target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(target))
                {
                    return i;
                }
            }
            return -1;
        }
    }
    class Circle
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Area()
        {
            return Math.PI * (Radius * Radius);
        }
        public static double operator+(Circle circle1, Circle circle2)
        {
            return circle1.Area() + circle2.Area();
        }
        public static double operator-(Circle circle1, Circle circle2)
        {
            return Math.Abs(circle1.Area() - circle2.Area());           
        }
    }
}
