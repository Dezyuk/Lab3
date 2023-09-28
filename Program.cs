using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task925();
            //Удалить столбец Двумерного массива вещественных чисел, в котором находится максимальный элемент этого массива.

            task932();
            //Отсортировать четные строки массива по возрастанию, а нечетные по убыванию.

            //task951();
            //Дан Двумерный массив.
            //а) Заменить значения всех элементов второй строки массива числом 5.
            //б) Заменить значения всех элементов пятого столбца массива числом 10.

            //task988();
            //Найти координаты(индекс) элемента, наиболее близкого к среднему значению всех элементов массива.

            //task932();
            //Вопрос уже был.
        }
        static void task925()
        {
            Random random = new Random();

            double[,] array2D = new double[random.Next(2, 10), random.Next(2, 10)];
            Console.WriteLine("Двумерный массив:");
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i, j] = Math.Round((random.NextDouble() * 100 - 50), 2);
                    Console.Write(array2D[i, j] + "\t");
                }
                Console.WriteLine();
            }
            double maxValue = array2D[0, 0];
            int columToDelete = 0;
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    if (array2D[i, j] > maxValue)
                    {
                        maxValue = array2D[i, j];
                        columToDelete = j;
                    }
                }
            }
            Console.WriteLine($"\nМаксимальное число {maxValue} находится в столбце под индексом {columToDelete}\n");
            Console.WriteLine("Новый массив:");
            double[,] array2DResult = new double[array2D.GetLength(0), array2D.GetLength(1) - 1];
            for (int i = 0; i < array2DResult.GetLength(0); i++)
            {
                for (int j = 0; j < array2DResult.GetLength(1); j++)
                {
                    int a = j >= columToDelete ? j + 1 : j;
                    array2DResult[i, j] = array2D[i, a];
                    Console.Write(array2DResult[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void task932()
        {
            Random random = new Random();
            int[,] array2D = new int[10, 10];
            Console.WriteLine("Двумерный массив:");
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i, j] = random.Next(0, 20);
                    Console.Write(array2D[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nОтрисуем данный массив по условию задания:\n");
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    for (var k = 0; k < array2D.GetLength(1); k++)
                    {
                        if (i % 2 != 0)
                        {
                            if (array2D[i, j] <= array2D[i, k]) continue;
                            int temp = array2D[i, j];
                            array2D[i, j] = array2D[i, k];
                            array2D[i, k] = temp;
                        }
                        else
                        {
                            if (array2D[i, j] >= array2D[i, k]) continue;
                            int temp = array2D[i, j];
                            array2D[i, j] = array2D[i, k];
                            array2D[i, k] = temp;
                        }

                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    Console.Write(array2D[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void task951()
        {
            Random random = new Random();
            int[,] array2D = new int[10, 10];
            Console.WriteLine("Двумерный массив:");
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i, j] = random.Next(0, 20);
                    Console.Write(array2D[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nНовый массив:\n");
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i, j] = i == 1 ? 5 : array2D[i, j];
                    array2D[i, j] = j == 4 ? 10 : array2D[i, j];
                    Console.Write(array2D[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void task988()
        {
            Random random = new Random();
            int[,] array2D = new int[10, 10];
            Console.WriteLine("Двумерный массив:");
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i, j] = random.Next(0, 20);
                    Console.Write(array2D[i, j] + "\t");
                }
                Console.WriteLine();
            }
            double averageValue = 0;
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    averageValue += array2D[i, j];
                }
            }
            averageValue /= (array2D.GetLength(0) * array2D.GetLength(1));
            int xCoord = 0, yCoord = 0;
            double differenceWithAverageValue = Math.Abs(array2D[xCoord, yCoord] - averageValue);
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    if (differenceWithAverageValue > Math.Abs(array2D[i, j] - averageValue))
                    {
                        differenceWithAverageValue = Math.Abs(array2D[i, j] - averageValue);
                        xCoord = j;
                        yCoord = i;
                    }
                }
            }
            Console.WriteLine($"\nСреднее значение среди всех элементов массива:{averageValue}");
            Console.WriteLine($"\nКоординаты(индекс) элемента, наиболее близкого к среднему значению всех элементов массива: x={xCoord}, y={yCoord}");
        }

    }
}
