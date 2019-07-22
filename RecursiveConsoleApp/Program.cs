using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ListAverage(list, list.Count - 1, 0, 0);
            Console.WriteLine("Inverted List: ");
            InvertedList(list, 0, list.Count - 1).ForEach(Console.WriteLine);
        }


        static void ListAverage(List<int> list, int size, double soma, double average)
        {
            if (size >= 0)
            {
                soma = soma + list[size];
                ListAverage(list, size - 1, soma, average);
            }
            else
            {
                average = (soma / list.Count);
                Console.WriteLine("Average: " + average);
                BiggerNumbers(average, list, list.Count - 1, 0);
            }

        }

        static void BiggerNumbers(double average, List<int> list, int index, int count)
        {
            if (index >= 0)
            {
                if (list[index] > average)
                {
                    count++;
                }
                BiggerNumbers(average, list, index - 1, count);
            }
            else
            {
                Console.WriteLine("Quantity of numbers biggers than average: " + count);
            }

        }

        static List<int> InvertedList(List<int> list, int i, int j)
        {
            if (i < j)
            {
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
                InvertedList(list, i + 1, j - 1);
            }
            return list;
        }
    }
}
